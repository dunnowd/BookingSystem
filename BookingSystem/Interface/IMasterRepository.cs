using BookingSystem.DTOs.Master;
using BookingSystem.Entities;

namespace BookingSystem.Interface
{
    public interface IMasterRepository
    {
        Task<List<MasterDto>> GetAllAsync();
        Task<List<MasterShortDto>> GetAllShortAsync();
        Task<MasterDto?> GetByIdAsync(int id);
        Task<MasterShortDto?> GetByIdShortAsync(int id);
        Task<MasterDto?> CreateAsync(CreateMasterDto master);
        Task<MasterDto?> UpdateAsync(UpdateMasterDto master, int id);
        Task<MasterDto?> DeleteByIdAsync(int id);
    }
}
