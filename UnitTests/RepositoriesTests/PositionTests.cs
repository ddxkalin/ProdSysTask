using Persistence.Repository.Position;
using Domain.Dtos;

namespace UnitTests.RepositoriesTests
{
    public class PositionTests
    {
        private readonly IPositionRepository PositionRepository;

        public PositionTests(IPositionRepository positionRepository) => PositionRepository = positionRepository;

        [Theory]
        [InlineData("Back-end Developer")]
        [InlineData("front-end Developer")]
        public async Task CreatePositionTest(string PositionName)
        {
            var position = new PositionDTO()
            {
                Name = PositionName
            };

            var positionId = await PositionRepository.CreatePosition(position);

            Assert.NotEqual(0, positionId);
        }
    }
}
