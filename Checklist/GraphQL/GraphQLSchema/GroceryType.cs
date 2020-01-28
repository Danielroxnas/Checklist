﻿using Checklist.Models;
using Checklist.Services;
using GraphQL.Types;

namespace Checklist.GraphQL.GraphQLSchema
{
    public class GroceryType : ObjectGraphType<Grocery>
    {
        public GroceryType(ICategoryService categoryService)
        {

            Field(x => x.GroceryName);
            Field(x => x.GroceryId, type: typeof(IdGraphType));
            Field<CategoryType>(
                "category",
                resolve: context =>
                {
                    var grocery = context.Source as Grocery;
                    return categoryService.GetCategoryById(grocery.CategoryId);
                }
            );
        }
    }
}
