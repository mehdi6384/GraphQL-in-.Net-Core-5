using System;
using System.Linq;
using HotChocolate;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate.Data;

namespace CommanderGQL.GraphQl
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatfrom([ScopedService] AppDbContext context) 
        {
            return context.Platfroms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }

    }
}
