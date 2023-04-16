using Budget.Application.Interfaces;
using Budget.Domain.DTOS.Models;
using Budget.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application.Services
{
    public class LoadsService : ILoadsService
    {
		private readonly IUnitOfWork _unitOfWork;

		public LoadsService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public ResponseServiceDTO LoadBanks(IFormFile file)
        {
            ResponseServiceDTO serviceDTO = new ResponseServiceDTO();

            try
			{
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;

                    _unitOfWork.LoadFilesRepository.SaveBankFromFile(stream);
                    int result = _unitOfWork.Save();

                    if (result <= 0) { 
                        serviceDTO.Result = false;
                        serviceDTO.Message = "An error has occurred loading the file";
                        return serviceDTO;
                    }

                    serviceDTO.Result = true;
                    serviceDTO.Message = "File loaded succesfully";
                }                             
            }            
            catch
			{
				throw;
			}

            return serviceDTO;
        }
    }
}
