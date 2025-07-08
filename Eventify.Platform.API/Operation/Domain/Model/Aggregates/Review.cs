using Eventify.Platform.API.Operation.Domain.Model.Commands;
using Eventify.Platform.API.Operation.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Operation.Domain.Model.Aggregates;

public partial class Review
{
    public int Id { get; }
    public string Content { get; private set; }
    public int Rating { get; private set; }
    public ProfileId ProfileId { get; private set; }
    public SocialEventId SocialEventId { get; private set; }

    public Review()
    {
        
    }
    public Review(string content, int rating, int profileId, int socialEventId)
    {
        Content = content;
        Rating = rating;
        ProfileId = new ProfileId(profileId);
        SocialEventId = new SocialEventId(socialEventId);
    }

    public Review(CreateReviewCommand command) : this( 
        command.Content, 
        command.Rating, 
        command.ProfileId, 
        command.SocialEventId)
    { }
    
    
}