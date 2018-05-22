using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Checkpoint1.Models;
using Checkpoint1.Models.Data;
using Checkpoint1.Models.ViewModels;

namespace Checkpoint1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SurveyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Survey
        public ActionResult Index()
        {
            return View(db.Survey.ToList());
        }

        // GET: Survey/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Survey/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Survey.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey);
        }

        // GET: Survey/ViewQuestion/Id
        //need to update
        public ActionResult ViewQuestions(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {
                List<Question> questions = db.Questions.Where(q => q.SurveyID == id).ToList();
                return View(questions);
            }
        }

        // GET: Survey/AddQuestion/Id
        public ActionResult AddQuestion(int? id)
        {
            SurveyQuestion sq = new SurveyQuestion();
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {
                sq.SurveyId = (int)id;
                return View(sq);
            }
        }

        // GET: Survey/AddQuestion/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestion(SurveyQuestion sq)
        {
            Question q = new Question()
            {
                SurveyID = sq.SurveyId,
                Required = sq.Required,
                QuestionText = sq.QuestionText
            };

            db.Questions.Add(q);
            db.SaveChanges();

            // Look for the survey matching the surveyID from previously created question
            var survey = db.Survey.SingleOrDefault(s => s.ID == q.SurveyID);
            if (survey != null)
            {
                survey.Questions.Add(q.ID);
                db.SaveChanges();
            }
            
            return View("Success");
            
        }

        public ActionResult AddResponse(int? id)
        {
            QuestionResponse qr = new QuestionResponse();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {
                qr.SurveyId = (int)id;
                return View(qr);
            }
        }

        // GET: Survey/AddQuestion/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddResponse(QuestionResponse qr)
        {
            Response r = new Response()
            {
                SurveyID = qr.SurveyId,
                CustomerID = qr.CustomerId,
                QuestionID = qr.QuestionId,
                QuestionResponse = qr.Response
            };

            db.Responses.Add(r);
            db.SaveChanges();

            // Look for the survey matching the surveyID from previously created question
            //var survey = db.Survey.SingleOrDefault(s => s.ID == q.SurveyID);
            //if (survey != null)
            //{
            //    survey.Questions.Add(q.ID);
            //    db.SaveChanges();
            //}

            return View("Success");
        }

        // GET: Survey/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Survey/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Survey/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Survey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Survey.Find(id);
            db.Survey.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
