using CityManagerApi2.Data.Abstract;
using CityManagerApi2.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityManagerApi2.Data.Concrete
{
    public class AppRepository : IAppRepository
    {
        private readonly AppDataContext _context;

        public AppRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await _context.AddAsync<T>(entity);
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            await Task.Run(() =>
            {
                _context.Remove(entity);
            });
        }

        public async Task<List<City>> GetCitiesAsync(int userId)
        {
            var cities = await _context
                 .Cities
                 .Include(c => c.CityImages)
                 .Where(c => c.UserId == userId)
                 .ToListAsync();
            return cities;
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            var city = await _context
                .Cities
                .Include(c => c.CityImages)
                .FirstOrDefaultAsync(c => c.Id == cityId);
            return city;
        }

        public Task<CityImage> GetPhotoByIdAsync(int photoId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CityImage>> GetPhotosByCityIdAsync(int cityId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
