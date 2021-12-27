using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {

        private readonly AppDbContext _context;
        public TrailRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public bool CreateTrail(Trail trail)
        {
            _context.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _context.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _context.Trails.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == trailId);
        }

        public ICollection<Trail> GetTrails()
        {
            return _context.Trails.OrderBy(a => a.Name).ToList();
        }

        public bool TrailExists(string name)
        {
            bool value = _context.Trails.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            return _context.Trails.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _context.Trails.Update(trail);
            return Save();
        }

        public ICollection<Trail> GetTrailsInNationalPark(int npId)
        {
            return _context.Trails.Include(c => c.NationalPark).Where(c => c.NationalParkId == npId).ToList();
        }
    }
}
