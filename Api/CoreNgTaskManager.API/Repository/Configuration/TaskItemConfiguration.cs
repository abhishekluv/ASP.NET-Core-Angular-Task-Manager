using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(x => x.Id); // PK

            builder.Property(x => x.Title).IsRequired(); // required

            builder.Property(x => x.Description).IsRequired(); // required

            builder.Property(x => x.IsCompleted).IsRequired(); // required

            builder.HasOne(x => x.User).WithMany(x => x.Items).HasForeignKey(x => x.UserId);

        }
    }
}
