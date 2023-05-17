using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Common;
using Budget.Infrastructure.DTOS.Movements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class MovementService : IMovementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;

        public MovementService(IUnitOfWork unitOfWork, IMapping mapping)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
        }

        public async Task<ResponseServiceDTO> InsertAsync(CreateMovementDTO createMovementDTO)
        {
            throw new NotImplementedException();
            //var movement = _mapping.Map<Movement>(createMovementDTO);
            //var movement = _mapping.Map<>();
            //await _unitOfWork.MovementRepository.AddAsync(movement);
        }
    }
}
