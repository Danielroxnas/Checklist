using Checklist.GraphQL.GraphQLSchema;
using Checklist.Models;
using Checklist.Services;
using GraphQL.Types;

public class AppMutation : ObjectGraphType
{
    public AppMutation(IGroceryService groceryService, ICategoryService categoryService)
    {
        Field<GroceryType>(
            "createGrocery",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<GroceryInputType>> { Name = "grocery" }),
            resolve: context =>
            {
                var grocery = context.GetArgument<Grocery>("grocery");

                return groceryService.Create(grocery);
            }
        ); 
        
        Field<CategoryType>(
            "createCategory",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<CategoryInutType>> { Name = "category" }),
            resolve: context =>
            {
                var category = context.GetArgument<Category>("category");

                return categoryService.Create(category);
            }
        );
    }
}

public class GroceryInputType : InputObjectGraphType<Grocery>
{
    public GroceryInputType()
    {
        Name = "GroceryInputType";
        Field(_ => _.GroceryName);
        Field(_ => _.CategoryId, type: typeof(IdGraphType));
    }
}
public class CategoryInutType : InputObjectGraphType<Category>
{
    public CategoryInutType()
    {
        Name = "CategoryInutType";
        Field(_ => _.CategoryName);
        Field(_ => _.CategoryId, type: typeof(IdGraphType));
    }
}