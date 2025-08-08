using BookingSystem.Data;
using BookingSystem.DTOs.Service;
using BookingSystem.Entities;
using BookingSystem.Interface;
using BookingSystem.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ServiceDto>> GetAllAsync()
        {
            return await _context.Services
                .Select(x => x.ToServiceDto())
                .ToListAsync();
        }

        public async Task<ServiceDto> GetByIdAsync(int id)
        {
            var serviceDto = await _context.Services
                .FindAsync(id);


            if (serviceDto == null)
                return null;

            return serviceDto.ToServiceDto();
        }

        public async Task<ServiceDto?> CreateAsync(CreateServiceDto serviceDto)
        {
            if (serviceDto == null)
                return null;

            var newService = serviceDto.ToModelFromCreateServiceDto();

            await _context.Services.AddAsync(newService);
            await _context.SaveChangesAsync();

            return newService.ToServiceDto();
        }

        public async Task<ServiceDto?> DeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return null;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return service.ToServiceDto();
        }


        public async Task<ServiceDto?> UpdateAsync(UpdateServiceDto serviceDto, int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return null;

            service.Name = serviceDto.Name;
            service.Duration = serviceDto.Duration;
            service.Cost = serviceDto.Cost;

            await _context.SaveChangesAsync();

            return service.ToServiceDto();
        }
    }
}
