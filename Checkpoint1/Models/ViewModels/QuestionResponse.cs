using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkpoint1.Models.ViewModels
{
    public class QuestionResponse
    {
        public int SurveyId { get; set; }

        public int QuestionId { get; set; }

        public int CustomerId { get; set; }

        public string QuestionText { get; set; }

        public string Response { get; set; }
    }
}