﻿using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface ICityService
    {
        List<CityLookUp> IndexCity();
        void AddCity(CityLookUpDTO cityLookUpDTO);
    }
}
