using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Commands;

namespace Eventify.Platform.API.Planning.Domain.Services;

public interface IQuoteCommandService
{
    public Task<Quote?> Handle(CreateQuoteCommand command);
    
    public Task<Quote?> Handle(UpdateQuoteCommand command);
    
    public Task Handle(DeleteQuoteCommand command);
    
    public Task<string> Handle(ConfirmQuoteCommand command);
    public Task<string> Handle(RejectQuoteCommand command);
}