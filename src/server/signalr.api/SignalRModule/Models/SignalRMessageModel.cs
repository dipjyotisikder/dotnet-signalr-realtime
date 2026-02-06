namespace SignalR.Api.SignalRModule.Models;

/// <summary>
/// Represents a message model for SignalR communication.
/// </summary>
public class SignalRMessageModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the message.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the message.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the content of the message.
    /// </summary>
    public string Content { get; set; } = string.Empty;
}
