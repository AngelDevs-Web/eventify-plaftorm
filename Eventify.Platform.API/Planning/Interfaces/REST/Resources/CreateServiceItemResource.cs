﻿namespace Eventify.Platform.API.Planning.Interfaces.REST.Resources;

public record CreateServiceItemResource(string  Description, int Quantity, double UnitPrice, double TotalPrice, string QuoteId);