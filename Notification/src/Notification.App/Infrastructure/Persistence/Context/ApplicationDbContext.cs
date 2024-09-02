using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Notification.App.Domain.Entities.Events;
using Notification.App.Domain.Entities.Outgoings;
using Notification.App.Domain.Entities.Setups;

using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Domain;

namespace Notification.App.Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    private readonly ICurrentUser _currentUser;
    private readonly IDateTime _dateTime;
    private readonly IDomainEventService _domainEventService;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentUser currentUser,
        IDomainEventService domainEventService,
        IDateTime dateTime)
        : base(options)
    {
        _currentUser = currentUser;
        _domainEventService = domainEventService;
        _dateTime = dateTime;
    }
    
    public DbSet<Event> Events => Set<Event>();

    public DbSet<AppEventData> AppEventData => Set<AppEventData>();

    public DbSet<EmailEvent> EmailEvents => Set<EmailEvent>();

    public DbSet<WebEvent> WebEvents => Set<WebEvent>();

    public DbSet<SmsEvent> SmsEvents => Set<SmsEvent>();

    public DbSet<EventTemplate> EventTemplates => Set<EventTemplate>();

    public DbSet<Credential> Credentials => Set<Credential>();

    public DbSet<ReceiverGroup> ReceiverGroups => Set<ReceiverGroup>();

    public DbSet<EmailOutgoing> EmailOutgoings => Set<EmailOutgoing>();

    public DbSet<SmsOutgoing> SmsOutgoings => Set<SmsOutgoing>();

    public DbSet<WebOutgoing> WebOutgoings => Set<WebOutgoing>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUser.UserId;
                    entry.Entity.Created = _dateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUser.UserId;
                    entry.Entity.LastModified = _dateTime.Now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    break;
            }
        }

        var events = Enumerable
                .SelectMany<List<DomainEvent>, DomainEvent>(
                    ChangeTracker.Entries<IHasDomainEvent>().Select(x => x.Entity.DomainEvents), x => x)
                .Where(domainEvent => !domainEvent.IsPublished)
                .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}