using slider.Models;

namespace slider.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
    }
}
