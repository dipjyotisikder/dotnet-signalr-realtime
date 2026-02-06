using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SignalR.Api.MessagingModule.Models.Entities;

/// <summary>
/// Represents the audience of a message.
/// </summary>
public class MessageAudience
{
    /// <summary>
    /// Gets or sets the ID of the message.
    /// </summary>
    public int MessageId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the audience user.
    /// </summary>
    public int AudienceUserId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the message has been seen.
    /// </summary>
    public bool Seen { get; set; } = false;
}

/// <summary>
/// Configures the MessageAudience entity.
/// </summary>
public class MessageAudienceConfiguration : IEntityTypeConfiguration<MessageAudience>
{
    /// <summary>
    /// Configures the MessageAudience entity type.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<MessageAudience> builder)
    {
        builder.HasKey(x => new
        {
            x.MessageId,
            x.AudienceUserId
        });
    }
}
