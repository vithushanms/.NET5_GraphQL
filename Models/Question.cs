using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HotChocolate;

namespace QuestionQL.Models
{
    public class Question{
        [Key]
        public int QuestionId {get; set;}
        public string QuestionString { get; set; }    
        public List<Answer> Answers { get; set; }
        public string AddedBy { get; set; }
    }
}