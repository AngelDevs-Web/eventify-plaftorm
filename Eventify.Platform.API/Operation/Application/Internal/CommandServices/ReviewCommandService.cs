using Eventify.Platform.API.Operation.Domain.Model.Aggregates;
using Eventify.Platform.API.Operation.Domain.Model.Commands;
using Eventify.Platform.API.Operation.Domain.Repositories;
using Eventify.Platform.API.Operation.Domain.Services;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Operation.Application.Internal.CommandServices;

public class ReviewCommandService(
    IReviewRepository reviewRepository,
    IUnitOfWork unitOfWork
    ) :IReviewCommandService
{
    public async Task<Review?> Handle(CreateReviewCommand command)
    {
        var review = new Review(command);
        await reviewRepository.AddAsync(review);
        await unitOfWork.CompleteAsync();
        return review;
    }
}