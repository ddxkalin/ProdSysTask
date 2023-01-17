using Persistence.Repository.Position;
using Domain;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
