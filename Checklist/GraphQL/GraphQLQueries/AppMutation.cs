using Checklist.GraphQL.GraphQLSchema;
using Checklist.Models;
using Checklist.Services;
using GraphQL.Types;

internal class AppMutation : ObjectGraphType
{
    public AppMutation(IGroceryService service)
    {
        Field<GroceryType>(
            "createGrocery",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<GroceryInputType>> { Name = "grocery" }),
            resolve: context =>
            {
                var owner = context.GetArgument<Grocery>("grocery");
                return service.Create(owner);
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
    }
}