using SignalR.Api.MessagingModule.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Api.MessagingModule.Services;

/// <summary>
/// Provides methods for managing conversations and their messages.
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Gets all conversations.
    /// </summary>
    /// <returns>A collection of all conversations.</returns>
    IEnumerable<ConversationModel> GetAll();

    /// <summary>
    /// Gets the messages for a specific conversation.
    /// </summary>
    /// <param name="conversationId">The ID of the conversation.</param>
    /// <returns>A collection of messages for the specified conversation.</returns>
    IEnumerable<MessageModel> GetMessages(int conversationId);

    /// <summary>
    /// Gets the audience of a specific conversation.
    /// </summary>
    /// <param name="conversationId">The ID of the conversation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the audience of the specified conversation.</returns>
    Task<ConversationAudienceModel> GetAudiences(int conversationId);

    /// <summary>
    /// Creates a new conversation.
    /// </summary>
    /// <param name="request">The details of the conversation to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created conversation.</returns>
    Task<ConversationModel> Create(CreateConversationModel request);
}
