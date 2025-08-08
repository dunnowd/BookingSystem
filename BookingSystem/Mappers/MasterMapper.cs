using BookingSystem.DTOs.Master;
using BookingSystem.Entities;

namespace BookingSystem.Mappers
{
    public static class MasterMapper
    {
        public static MasterDto ToMasterDto(this Master masterModel)
        {
            return new MasterDto()
            {
                Id = masterModel.Id,
                Name = masterModel.Name,
                Services = masterModel.Services.Select(x=>x.ToServiceDto()).ToList(),
            };
        }

        public static MasterShortDto ToMasterShortDto(this Master masterModel)
        {
            return new MasterShortDto()
            {
                Id = masterModel.Id,
                Name = masterModel.Name,
            };
        }

        public static Master ToMasterFromCreateDto(this CreateMasterDto createMasterDto)
        {
            return new Master()
            {
                Name = createMasterDto.Name,
            };
        }
    }
}
