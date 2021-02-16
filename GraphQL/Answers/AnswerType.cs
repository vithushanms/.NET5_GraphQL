using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using QuestionQL.DataAccess;
using QuestionQL.Models;

namespace QuestionQL.GrqphQL.Answers
{
    public class AnswerType : ObjectType<Answer>
    {
        protected override void Configure(IObjectTypeDescriptor<Answer> descriptor){
            descriptor.Description("Representing the Answers for the questions");

            descriptor
                .Field(a => a.QuestionId)
                .ResolveWith<Resolvers>(q => q.GetQuestions(default!, default!))
                .UseDbContext<AppDbContext>();
        }

        private class Resolvers
        {
            public IQueryable<Question> GetQuestions([ScopedService] AppDbContext context, Answer answer){
                return context.Questions.Where(q => q.QuestionId == answer.QuestionId);
            }
        }
    }
}