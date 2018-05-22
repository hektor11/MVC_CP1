using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Checkpoint1.Models.Data
{
    public class Response
    {
        public int ID { get; set; }

        public int SurveyID { get; set; }

        public int QuestionID { get; set; }

        public int CustomerID { get; set; }

        [Display(Name = "Question Response")]
        public string QuestionResponse { get; set; }
    }
}