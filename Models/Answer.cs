using System.ComponentModel.DataAnnotations;

namespace QuestionQL.Models
{
    public class Answer{
        [Key]
        public int AnswerId { get; set; }
        public string AnswerString { get; set; }
    }
}