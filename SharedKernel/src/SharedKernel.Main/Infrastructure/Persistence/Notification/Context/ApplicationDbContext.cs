﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Domain.Notification.Notifications.Events;
using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;
using SharedKernel.Main.Domain.Notification.Setups;
using SharedKernel.Main.Domain.Notification.Todos;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

public class ApplicationDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IDomainEventService _domainEventService;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUserService,
        IDomainEventService domainEventService,
        IDateTime dateTime)
        : base(options)
    {
        _currentUserService = currentUserService;
        _domainEventService = domainEventService;
        _dateTime = dateTime;
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
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
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created = _dateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
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
                .SelectMany<List<DomainEvent>, DomainEvent>(ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents), x => x)
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