using Checklist.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.GraphQL.GraphQLSchema
{
    public class CategoryType : ObjectGraphType<Category>
    {

        public CategoryType()
        {
            Field(x => x.CategoryName);
            Field(x => x.CategoryId, type: typeof(IdGraphType));
        }
    }
}
