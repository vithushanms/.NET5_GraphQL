using System.Linq;
using HotChocolate;
using QuestionQL.DataAccess;
using QuestionQL.Models;

namespace QuestionQL.GrqphQL
{
    public class Query
    {
        //int the HotChocolate framework the [Service] helps to inject the AppContect in the method itseld
        public IQueryable<Question> GetQuestion([Service] AppDbContext context){
            return context.QuestionDb;
        }
    }
}