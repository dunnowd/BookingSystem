using BookingSystem.DTOs.Master;
using BookingSystem.Entities;

namespace BookingSystem.Interface
{
    public interface IMasterRepository
    {
        Task<List<MasterDto>> GetAllAsync();
        Task<MasterDto?> GetByIdAsync(int id);
        Task<MasterDto?> CreateAsync(CreateMasterDto master);
        Task<MasterDto?> UpdateAsync(UpdateMasterDto master, int id);
        Task<MasterDto?> DeleteByIdAsync(int id);
        Task<MasterDto?> LinkServiceToMasterAsync(int masterId, int serviceId);
        Task<MasterDto?> RemoveServiceToMasterAsync(int masterId, int serviceId);
    }
}
