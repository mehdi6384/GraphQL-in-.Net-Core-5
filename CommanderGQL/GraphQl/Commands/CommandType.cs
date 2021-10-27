using System.Linq;
using HotChocolate;
using CommanderGQL.Data;
using HotChocolate.Types;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQl.Commands
{
    public class CommandType: ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable commands");

            descriptor
                .Field(p => p.Platform)
                .ResolveWith<Resolvers>(p => p.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform to which command belongs");
        }

        public class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platfroms.FirstOrDefault(p => p.Id == command.PlatformId);
            }

        }
    }
}
