using SignalR.Api.UserModule.Models;
using System.Collections.Generic;

namespace SignalR.Api.MessagingModule.Models;

/// <summary>
/// Represents a conversation with an audience of users.
/// </summary>
public class ConversationAudienceModel : ConversationModel
{
    /// <summary>
    /// Gets or sets the users in the audience of the conversation.
    /// </summary>
    public IEnumerable<UserModel> AudienceUsers { get; set; }
}
