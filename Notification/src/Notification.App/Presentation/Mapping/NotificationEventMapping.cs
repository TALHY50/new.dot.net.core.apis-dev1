using Mapster;

using Notification.App.Contracts.Responses;
using Notification.App.Domain.Entities.Events;
using Notification.App.Domain.Entities.Outgoings;

namespace Notification.App.Presentation.Mapping;

public class NotificationEventMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        

        config.NewConfig<Event, NotificationEventResponse>()
            .Map(dest => dest.id, src => src.Id)
            .Map(dest => dest.category, src => src.Category)
            .Map(dest => dest.is_email, src => src.IsEmail)
            .Map(dest => dest.is_sms, src => src.IsSms)
            .Map(dest => dest.is_web, src => src.IsWeb)
            .Map(dest => dest.is_allow_from_app, src => src.IsAllowFromApp)
            .Map(dest => dest.created_by_id, src => src.CreatedById)
            .Map(dest => dest.updated_by_id, src => src.UpdatedById)
            .Map(dest => dest.status, src => src.Status)
            .Map(dest => dest.created_at, src => src.CreatedAt)
            .Map(dest => dest.updated_at, src => src.UpdatedAt);

    }
}