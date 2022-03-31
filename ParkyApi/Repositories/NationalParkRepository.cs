using Microsoft.EntityFrameworkCore;
using ParkyApi.Data;
using ParkyApi.Models;
using ParkyApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParkyApi.Repositories
{
    public class NationalParkRepository : INationalParkRepository
    {

        private readonly EFContext _context;
        private readonly DbSet<NationalParks> nationalParks;

        public NationalParkRepository(EFContext context)
        {
            _context = context;
            nationalParks = _context.NationalParks;
        }


        public bool Create(NationalParks entity)
        {
            nationalParks.Add(entity);
            return Save();
        }

        public bool Delete(int Id)
        {
            var park = nationalParks.FirstOrDefault(x => x.Id == Id);


            if (park != null)
                nationalParks.Remove(park);
            return Save();


        }

        public bool Delete(NationalParks entity)
        {
            nationalParks.Remove(entity);
            return Save();

        }

        public bool Exists(int id)
        {
            return nationalParks.Any(x => x.Id == id);
        }

        public bool Exists(string name)
        {
            return nationalParks.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public NationalParks Get(int id)
        {
            return nationalParks.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<NationalParks> GetAll()
        {
            return nationalParks.OrderBy(x => x.Name).ToList();
        }
         
        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool Update(NationalParks entity)
        {
            nationalParks.Update(entity);
            return Save();
        }
    }
}
