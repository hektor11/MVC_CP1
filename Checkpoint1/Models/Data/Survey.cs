using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Checkpoint1.Models.Data
{
    public class Survey
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<int> Customers { get; set; } = new List<int>();

        public List<int> Questions { get; set; } = new List<int>();

        public List<int> Completions { get; set; } = new List<int>();

    }
}