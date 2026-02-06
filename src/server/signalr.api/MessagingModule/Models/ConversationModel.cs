using SignalR.Api.UserModule.Models;
using System;

namespace SignalR.Api.MessagingModule.Models;

/// <summary>
/// Represents a conversation model.
/// </summary>
public class ConversationModel
{
    /// <summary>
    /// Gets or sets the conversation ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the conversation.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the creator user of the conversation.
    /// </summary>
    public UserModel CreatorUser { get; set; }

    /// <summary>
    /// Gets or sets the creation date and time of the conversation.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
