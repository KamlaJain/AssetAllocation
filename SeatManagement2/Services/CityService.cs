using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
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
            var item = new CityLookUp
            {
                CityName = cityLookUpDTO.CityName,
                CityCode = cityLookUpDTO.CityCode,
            };
            _repository.Add(item);
            _repository.Save();
        }
        public void DeleteCity(CityLookUpDTO cityLookUpDTO)
        {
            var item = _repository.GetAll().FirstOrDefault(c => c.CityCode == cityLookUpDTO.CityCode);
            if (item == null)
            {
                throw new Exception("Invalid City");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
        public void EditCity(string cityCode, CityLookUpDTO updatedCity)
        {
            var item = _repository.GetAll().FirstOrDefault(c => c.CityCode == cityCode);
            if (item == null)
            {
                throw new Exception("Invalid City");
            }
            else
            {
                item.CityName = updatedCity.CityName;
                item.CityCode = updatedCity.CityCode;

                _repository.Update(item);
                _repository.Save();
            }
        }

    }
}

