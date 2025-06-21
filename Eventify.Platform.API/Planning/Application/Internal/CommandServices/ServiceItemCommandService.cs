﻿using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Commands;
using Eventify.Platform.API.Planning.Domain.Repositories;
using Eventify.Platform.API.Planning.Domain.Services;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Planning.Application.Internal.CommandServices;

public class ServiceItemCommandService(IServiceItemRepository serviceItemRepository, IUnitOfWork unitOfWork):IServiceItemCommandService
{
       public async Task<ServiceItem?> Handle(CreateServiceItemCommand command)
       {
              var serviceItem = new ServiceItem(command);
              await serviceItemRepository.AddAsync(serviceItem);
              await unitOfWork.CompleteAsync();
              return serviceItem;
       }

       public async Task<ServiceItem?> Handle(UpdateServiceItemCommand command)
       {
              var serviceItem = await serviceItemRepository.FindByIdAsync(command.ServiceItemId);
              if(serviceItem is null) throw new Exception("Service Item Not Found");
              var updatedServiceItem = serviceItem.UpdateInformation(command.Description,command.Quantity,command.UnitPrice,command.TotalPrice);
              serviceItemRepository.Update(updatedServiceItem);
              await unitOfWork.CompleteAsync();
              return updatedServiceItem;
       }

       public async Task Handle(DeleteServiceItemCommand command)
       {
              var serviceItem = await serviceItemRepository.FindByIdAsync(command.ServiceItemId);
              if(serviceItem is null) throw new Exception("Service Item Not Found");
              serviceItemRepository.Remove(serviceItem);
              await unitOfWork.CompleteAsync();
       }
}