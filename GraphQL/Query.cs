using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using QuestionQL.DataAccess;
using QuestionQL.Models;

namespace QuestionQL.GrqphQL
{
    public class Query
    {
        /*int the HotChocolate framework the [Service] helps to inject the AppContect in the method itseld
        [UseProjection] will help to query complex opjects*/
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Question> GetQuestion([ScopedService] AppDbContext context){
            return context.Questions;
        }
    }
}