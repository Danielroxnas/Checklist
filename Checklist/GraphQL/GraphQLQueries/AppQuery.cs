using Checklist.GraphQL.GraphQLSchema;
using Checklist.Models;
using Checklist.Repository;
using GraphQL.Types;

public class AppQuery : ObjectGraphType
{
    public AppQuery(IBaseRepository<Grocery> groceryRepository, IBaseRepository<Category> categoryRepository)
    {
        Field<ListGraphType<GroceryType>>(
            "groceries",
        resolve: context => groceryRepository.Get(null, null)); 

        Field<ListGraphType<CategoryType>>(
            "categories",
        resolve: context => categoryRepository.Get(null, null));
    }
}
