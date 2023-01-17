using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Position
{
    public interface IPositionRepository
    {
        Task<int> CreatePosition(PositionDTO position);
    }
}
