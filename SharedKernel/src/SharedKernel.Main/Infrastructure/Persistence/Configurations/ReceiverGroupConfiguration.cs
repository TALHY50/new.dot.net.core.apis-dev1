using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Main.Domain.Notification.Setups;
using SharedKernel.Main.Domain.Notification.ValueObjects;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
    public class ReceiverGroupConfiguration : IEntityTypeConfiguration<ReceiverGroup>
    {
        public void Configure(EntityTypeBuilder<ReceiverGroup> builder)
        {
            builder.ToTable("notification_receiver_groups");

            builder.HasKey(rg => rg.Id);

            RelationalPropertyBuilderExtensions
                .HasColumnType<int>(builder.Property(rg => rg.Id)
                    .ValueGeneratedOnAdd(), "int(11)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<NotificationType>(builder.Property(rg => rg.Type)
                    .IsRequired(), "tinyint(4)")
                .HasConversion(
                    nt => nt.Type,
                    nt => NotificationType.From(nt))
                .HasComment("1=mail, 2= sms, 3 = web");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<string>(builder.Property(rg => rg.Name)
                    .IsRequired()
                    .HasMaxLength(50), "0")
                .HasColumnType("varchar(50)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(rg => rg.To), "mediumtext")
                .HasComment("must be separated by comma(,)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(rg => rg.CcEmails), "text")
                .HasColumnName("cc_emails")
                .HasComment("must be separated by comma(,)");

            RelationalPropertyBuilderExtensions
                .HasColumnType<string>(builder.Property(rg => rg.BccEmails), "text")
                .HasColumnName("bcc_emails")
                .HasComment("must be separated by comma(,)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(rg => rg.CreatedById)
                    .IsRequired(), 0)
                .HasColumnName("created_by_id")
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(rg => rg.UpdatedById)
                    .IsRequired(), 0)
                .HasColumnName("updated_by_id")
                .HasColumnType("int(11)");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(rg => rg.Status)
                    .IsRequired(), 1)
                .HasColumnType("tinyint(4)")
                .HasComment("1= active, 0= inactive");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(rg => rg.CreatedAt), "created_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasColumnName<DateTime?>(builder.Property(rg => rg.UpdatedAt), "updated_at")
                .HasColumnType("datetime");

            RelationalPropertyBuilderExtensions
                .HasDefaultValue<int>(builder.Property(rg => rg.CompanyId)
                    .IsRequired(), 0)
                .HasColumnName("company_id")
                .HasColumnType("int(11)");
        }
    }
}
