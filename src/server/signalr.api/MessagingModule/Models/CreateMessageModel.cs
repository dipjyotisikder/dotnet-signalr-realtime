namespace SignalR.Api.MessagingModule.Models;

/// <summary>
/// Model for creating a new message in a conversation.
/// </summary>
public class CreateMessageModel
{
    /// <summary>
    /// Gets or sets the ID of the conversation.
    /// </summary>
    public int ConversationId { get; set; }

    /// <summary>
    /// Gets or sets the text of the message.
    /// </summary>
    public string Text { get; set; }
}
