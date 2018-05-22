using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Checkpoint1.Models.ViewModels
{
    public class SurveyQuestion
    {
        public int SurveyId { get; set; }

        public bool Required { get; set; }

        [Display(Name = "Question Text")]
        public string QuestionText { get; set; }
    }
}