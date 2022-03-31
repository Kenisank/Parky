using ParkyApi.Models;
using System.Collections.Generic;

namespace ParkyApi.Repositories.Interfaces
{
    public interface INationalParkRepository
    {
        ICollection<NationalParks> GetAll();

        NationalParks Get(int id);

        bool Exists(int id);

        bool Exists(string name);

        bool Create(NationalParks entity);

        bool Update(NationalParks entity);

        bool Delete(int Id);

        bool Delete(NationalParks entity);

        bool Save();






    }
}
