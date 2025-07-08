﻿using System.Runtime.InteropServices.JavaScript;
using Eventify.Platform.API.Operation.Domain.Model.Commands;
using Eventify.Platform.API.Operation.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Operation.Domain.Model.Aggregates;

public partial class Review
{
    public int Id { get; }
    
    public string Reviewer { get; private set; }
    
    public string EventName { get; private set; }
    
    public DateTime EventDate { get; private set; }
    public string Content { get; private set; }
    public int Rating { get; private set; }
    public DateTime ReviewDate { get; private set; }

    public Review(string content, int rating, string reviewer, string eventName, DateTime eventDate, DateTime reviewDate)
    {
        Reviewer = reviewer;
        EventName = eventName;
        EventDate = eventDate;
        Content = content;
        Rating = rating;
        ReviewDate = reviewDate;
    }

    public Review(CreateReviewCommand command) : this( 
        command.Content,
        command.Rating,
        command.Reviewer, 
        command.EventName,
        command.EventDate,
        command.ReviewDate)
    { }
    
    
}