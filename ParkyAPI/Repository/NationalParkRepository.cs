﻿using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {

        private readonly AppDbContext _context;
        public NationalParkRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _context.NationalParks.FirstOrDefault(a => a.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.NationalParks.OrderBy(a => a.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _context.NationalParks.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _context.NationalParks.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
