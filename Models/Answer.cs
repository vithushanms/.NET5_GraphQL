using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace QuestionQL.Models
{
    public class Answer{
        [Key]
        public int AnswerId { get; set; }
        public string AnswerString { get; set; }
        public int QuestionId {get; set;}
        public Question Question { get; set; }
    }
}