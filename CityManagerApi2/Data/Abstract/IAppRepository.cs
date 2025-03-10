using CityManagerApi2.Entities;

namespace CityManagerApi2.Data.Abstract
{
    public interface IAppRepository
    {
        Task AddAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task<bool> SaveAllAsync();

        Task<List<City>> GetCitiesAsync(int userId);
        Task<List<CityImage>> GetPhotosByCityIdAsync(int cityId);
        Task<City> GetCityByIdAsync(int cityId);
        Task<CityImage> GetPhotoByIdAsync(int photoId);
    }
}
