using API_con_base_de_datos.Models;

namespace API_con_base_de_datos.Repositories
{
    public interface IProductoRepository 
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetbyIdAsync(int id); 
        Task AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task DeleteAsync(int id);
    }
}
