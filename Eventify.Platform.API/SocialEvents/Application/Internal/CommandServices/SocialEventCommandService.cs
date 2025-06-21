using Eventify.Platform.API.Shared.Domain.Repositories;
using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Eventify.Platform.API.SocialEvents.Domain.Model.Commands;
using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;
using Eventify.Platform.API.SocialEvents.Domain.Repositories;
using Eventify.Platform.API.SocialEvents.Domain.Services;

namespace Eventify.Platform.API.SocialEvents.Application.Internal.CommandServices;

public class SocialEventCommandService : ISocialEventCommandService
{
    private readonly ISocialEventRepository _socialEventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SocialEventCommandService(ISocialEventRepository socialEventRepository, IUnitOfWork unitOfWork)
    {
        _socialEventRepository = socialEventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<SocialEvent?> Handle(CreateSocialEventCommand command)
    {
        var socialEvent = new SocialEvent(new SocialEventTitle(command.EventTitle), command.EventDate, new CustomerName(command.CustomerName), 
            new SocialEventPlace(command.Location), command.Status);
        
        await _socialEventRepository.AddAsync(socialEvent);
        await _unitOfWork.CompleteAsync();
        return socialEvent;
    }

    public async Task<SocialEvent?> Handle(UpdateSocialEventCommand command)
    {
        var socialEvent = await _socialEventRepository.FindByIdAsync(command.Id);
        if (socialEvent == null) return null;

        socialEvent.UpdateInformation(new SocialEventTitle(command.EventTitle), command.EventDate, new CustomerName(command.CustomerName),
           new SocialEventPlace(command.Location), command.Status);
        
        _socialEventRepository.Update(socialEvent);
        await _unitOfWork.CompleteAsync();
        return socialEvent;
    }

    public async Task<SocialEvent?> Handle(DeleteSocialEventCommand command)
    {
        var socialEvent = await _socialEventRepository.FindByIdAsync(command.Id);
        if (socialEvent == null) return null;

        _socialEventRepository.Remove(socialEvent);
        await _unitOfWork.CompleteAsync();
        return socialEvent;
    }
}