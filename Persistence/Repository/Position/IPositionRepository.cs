using Domain.Dtos;

namespace Persistence.Repository.Position
{
    public interface IPositionRepository
    {
        Task<int> CreatePosition(PositionDTO position);
        Task UpdatePosition(int PositionId, PositionDTO position);
    }
}
