using SignalR.Api.MessagingModule.Models;
using System.Threading.Tasks;

namespace SignalR.Api.MessagingModule.Services;

/// <summary>
/// Defines the contract for message-related operations in the messaging module.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Creates a new message based on the provided request model.
    /// </summary>
    /// <param name="request">The model containing the details of the message to be created.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created message model.</returns>
    Task<MessageModel> Create(CreateMessageModel request);
}
