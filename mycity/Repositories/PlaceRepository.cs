using mycity.DAL.Models;
using mycity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mycity.Repositories
{
    public class PlaceRepository : IRepository<Places>
    {
        private readonly IRepository<Places> _placeRepository;
        private readonly mycityDbContext _context;

        public PlaceRepository(IRepository<Places> placeRepository, mycityDbContext context)
        {

            this._placeRepository = placeRepository;
            this._context = context;
        }

        public Places Add(Places entity)
        {
            this._context.Add(entity);
            this._context.SaveChanges();

            return entity;
        }

        public void Delete(Places entity)
        {
            this._context.Remove(entity);
        }

        public Places GetById(int id)
        {
            return this._context.Places.Where(c => c.PlacesId == id).FirstOrDefault();
        }

        public IEnumerable<Places> ListAll()
        {
            return this._context.Places.ToList();
        }

        public void Update(Places entity)
        {
            this._context.Places.Update(entity);
            this._context.SaveChanges();
        }
    }
}
