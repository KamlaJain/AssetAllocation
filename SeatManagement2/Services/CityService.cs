using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<CityLookUp> _repository;

        public CityService(IRepository<CityLookUp> repository)
        {
            _repository = repository;
        }

        public List<CityLookUp> IndexCity()
        {
            return (_repository.GetAll().ToList());
        }

        public void AddCity(CityLookUpDTO cityLookUpDTO)
        {
            var reqCity = _repository.GetAll().FirstOrDefault(c => c.CityName == cityLookUpDTO.CityName || c.CityCode == cityLookUpDTO.CityCode);
            if (reqCity != null)
            {
                throw new BadRequestException("City already exists");
            }
            var item = new CityLookUp
            {
                CityName = cityLookUpDTO.CityName,
                CityCode = cityLookUpDTO.CityCode,
            };
            _repository.Add(item);
            _repository.Save();
        }

    }
}

