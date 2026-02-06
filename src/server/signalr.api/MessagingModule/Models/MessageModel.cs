using SignalR.Api.UserModule.Models;
using System;

namespace SignalR.Api.MessagingModule.Models;

/// <summary>
/// Represents a message in the messaging module.
/// </summary>
public class MessageModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the message.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the text content of the message.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the user who created the message.
    /// </summary>
    public UserModel CreatorUser { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the message was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
