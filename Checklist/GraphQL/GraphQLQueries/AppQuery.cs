using Checklist.GraphQL.GraphQLSchema;
using Checklist.Models;
using Checklist.Repository;
using GraphQL.Types;
using System;

public class AppQuery : ObjectGraphType
{
    public AppQuery(IBaseRepository<Grocery> groceryRepository, IBaseRepository<Category> categoryRepository)
    {
        Field<ListGraphType<GroceryType>>(
            "groceries",
        resolve: context => groceryRepository.Get(null, null));

        Field<GroceryType>(
            "grocery",
            arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "groceryId" }),
            resolve: context =>
            {
                var id = context.GetArgument<Guid>("groceryId");
                return groceryRepository.GetById(id);
            }
        );

        Field<ListGraphType<CategoryType>>(
            "categories",
        resolve: context => categoryRepository.Get(null, null));
    }
}
