using BookingSystem.DTOs.Service;
using BookingSystem.Entities;

namespace BookingSystem.Mappers
{
    public static class ServiceMapper
    {
        public static ServiceDto ToServiceDto(this Service serviceModel)
        {
            return new ServiceDto()
            {
                Id = serviceModel.Id,
                Name = serviceModel.Name,
                Duration = serviceModel.Duration,
                Cost = serviceModel.Cost,
            };
        }

        public static Service ToModelFromCreateServiceDto(this CreateServiceDto serviceDto)
        {
            return new Service()
            {
                Name = serviceDto.Name,
                Duration = serviceDto.Duration,
                Cost = serviceDto.Cost,
            };
        }
    }
}
