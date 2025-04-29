using MediatR;
using ApiPersonalAudioAssistant.Application.Interfaces;
using ApiPersonalAudioAssistant.Contracts.Conversation;

namespace ApiPersonalAudioAssistant.Application.PlatformFeatures.Queries.ConversationQuery
{
    public class GetConversationByIdQuery : IRequest<ConversationsResponse>
    {
        public required string SubUserId { get; set; }

        public class GetConversationByIdQueryHandler : IRequestHandler<GetConversationByIdQuery, ConversationsResponse>
        {
            private readonly IConversationRepository _conversationRepository;

            public GetConversationByIdQueryHandler(IConversationRepository conversationRepository)
            {
                _conversationRepository = conversationRepository;
            }

            public async Task<ConversationsResponse> Handle(GetConversationByIdQuery query, CancellationToken cancellationToken)
            {
                var conversations = await _conversationRepository.GetConversationByIdAsync(query.SubUserId, cancellationToken);

                if (conversations == null)
                {
                    throw new Exception("Conversation not found");
                }

                var response = new ConversationsResponse
                {
                    IdConversation = conversations.Id.ToString(),
                    Description = conversations.Description
                };

                return response;
            }
        }
    }
}
