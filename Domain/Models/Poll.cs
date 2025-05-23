﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Poll
    {
        public Poll()
        {
            DateCreated = DateTime.Now;
            Option1VotesCount = 0;
            Option2VotesCount = 0;
            Option3VotesCount = 0;
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Option1Text { get; set; }

        public string Option2Text { get; set; }

        public string Option3Text { get; set; }

        public int Option1VotesCount { get; set; }

        public int Option2VotesCount { get; set; }

        public int Option3VotesCount { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
