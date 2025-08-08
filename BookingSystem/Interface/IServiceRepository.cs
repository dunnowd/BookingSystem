using BookingSystem.DTOs.Service;
using BookingSystem.Entities;

namespace BookingSystem.Interface
{
    public interface IServiceRepository
    {
        Task<List<ServiceDto>> GetAllAsync();
        Task<ServiceDto> GetByIdAsync(int id);
        Task<ServiceDto?> CreateAsync(CreateServiceDto serviceDto);
        Task<ServiceDto?> UpdateAsync(UpdateServiceDto serviceDto, int id);
        Task<ServiceDto?> DeleteAsync(int id);
    }
}
