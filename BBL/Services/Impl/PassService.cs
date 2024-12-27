using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl
{
    public class PassService : IPassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int PageSize = 10;

        public PassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<PassDTO> GetActivePasses(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            if (user.GetType() != typeof(SecurityOfficer) && user.GetType() != typeof(Controller))
            {
                throw new MethodAccessException();
            }

            var passes = _unitOfWork.PassRepository
                .GetActivePasses()
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var passDtos = new List<PassDTO>();
            foreach (var pass in passes)
            {
                passDtos.Add(new PassDTO
                {
                    Id = pass.Id,
                    PassNumber = pass.PassNumber,
                    EmployeeName = pass.EmployeeName,
                    ExpirationDate = pass.ExpirationDate,
                    IsActive = pass.IsActive
                });
            }

            return passDtos;
        }

        public void DeactivatePass(int passId)
        {
            var user = SecurityContext.GetUser();
            if (user.GetType() != typeof(SecurityOfficer))
            {
                throw new MethodAccessException();
            }

            _unitOfWork.PassRepository.DeactivatePass(passId);
            _unitOfWork.Save();
        }
    }
}