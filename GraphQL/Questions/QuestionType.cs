using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using QuestionQL.DataAccess;
using QuestionQL.Models;

namespace QuestionQL.GrqphQL.Questions
{
    public class QuestionType : ObjectType<Question>{
        protected override void Configure(IObjectTypeDescriptor<Question> descriptor)
        {
            descriptor.Description("Representing the questions in the platform");

            descriptor
            .Field(q => q.Answers)
            .ResolveWith<Resolvers>(q => q.GetAnswers(default!, default!))
            .UseDbContext<AppDbContext>();
        }

        private class Resolvers{
            public IQueryable<Answer> GetAnswers([ScopedService] AppDbContext context, Question question){
                return context.Answers.Where(a => a.QuestionId == question.QuestionId);
            }
        }
    }
}