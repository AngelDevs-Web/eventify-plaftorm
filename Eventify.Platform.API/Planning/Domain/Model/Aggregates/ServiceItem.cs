using Eventify.Platform.API.Planning.Domain.Model.Commands;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Domain.Model.Aggregates;

public class ServiceItem
{
    public ServiceItemId Id { get; }
    
    public string Description { get; private set; }
    
    public int Quantity { get; private set; }
    
    public double UnitPrice { get; private set; }
    
    public double TotalPrice { get; private set; }
    
    public QuoteId QuoteId { get; private set; }

    public ServiceItem()
    {
        
    }
    public ServiceItem(CreateServiceItemCommand command)
    {
        Id = new ServiceItemId(Guid.NewGuid());
        Description = command.Description;
        Quantity = command.Quantity;
        UnitPrice = command.UnitPrice;
        TotalPrice = command.TotalPrice;
        QuoteId = command.QuoteId;
    }

    public ServiceItem UpdateInformation(string description,  int quantity, double unitPrice, double totalPrice)
    {
        Description = description;
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = totalPrice;
        return this;
    }
}