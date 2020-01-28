using Checklist.GraphQL.GraphQLSchema;
using Checklist.Models;
using Checklist.Repository;
using GraphQL.Types;

public class AppQuery : ObjectGraphType
{
    public AppQuery(IBaseRepository<Category> categoryRepository, IBaseRepository<Grocery> groceryRepository)
    {
        Field<ListGraphType<GroceryType>>(
            "groceries",
        resolve: context => groceryRepository.Get(null, null));
    }
}
