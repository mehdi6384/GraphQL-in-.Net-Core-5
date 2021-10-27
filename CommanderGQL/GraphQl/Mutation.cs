using CommanderGQL.Data;
using CommanderGQL.GraphQl.Commands;
using CommanderGQL.GraphQl.Platfroms;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading;
using System.Threading.Tasks;

namespace CommanderGQL.GraphQl
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationtoken
            )
        {
            var platform = new Platform
            {
                Name = input.name
            };

            context.Platfroms.Add(platform);
            await context.SaveChangesAsync(cancellationtoken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationtoken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(
            AddCommandInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationtoken
            )
        {
            var command = new Command
            {
                HowTo = input.howTo,
                CommandLine = input.commandLine,
                PlatformId = input.platformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync(cancellationtoken);


            return new AddCommandPayload(command);
        }
    }
}
