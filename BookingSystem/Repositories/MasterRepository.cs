using BookingSystem.Data;
using BookingSystem.DTOs.Master;
using BookingSystem.Interface;
using BookingSystem.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly AppDbContext _context;

        public MasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MasterDto>> GetAllAsync()
        {
            return await _context.Masters
                .Include(x=>x.Services)
                .Select(x => x.ToMasterDto())
                .ToListAsync();
        }

        public async Task<MasterDto?> GetByIdAsync(int id)
        {
            var master = await _context.Masters.FindAsync(id);

            if (master == null) { return null; }

            return master.ToMasterDto();
        }

        public async Task<MasterDto?> CreateAsync(CreateMasterDto master)
        {
            if (master == null) { return null; }

            var newMaster = master.ToMasterFromCreateDto();

            await _context.Masters.AddAsync(newMaster);
            await _context.SaveChangesAsync();

            return newMaster.ToMasterDto();
        }

        public async Task<MasterDto?> DeleteByIdAsync(int id)
        {
            var master = await _context.Masters.FindAsync(id);

            if (master == null) { return null; }

            _context.Masters.Remove(master);
            await _context.SaveChangesAsync();

            return master.ToMasterDto();
        }

        public async Task<MasterDto?> UpdateAsync(UpdateMasterDto master, int id)
        {
            var editMaster = await _context.Masters.FindAsync(id);

            if (master == null) { return null; }

            editMaster.Name = master.Name;

            await _context.SaveChangesAsync();
            return editMaster.ToMasterDto();
        }

        public async Task<MasterDto?> LinkServiceToMasterAsync(int masterId, int serviceId)
        {
            var master = await _context.Masters.FindAsync(masterId);
            
            if ( master == null) { return null; }

            var service = await _context.Services.FindAsync(serviceId);

            if (service == null) { return null; }

            master.Services.Add(service);
            await _context.SaveChangesAsync();

            return master.ToMasterDto();
        }

        public async Task<MasterDto?> RemoveServiceToMasterAsync(int masterId, int serviceId)
        {
            var master = await _context.Masters
                .Include(x=>x.Services)
                .FirstOrDefaultAsync(x=>x.Id == masterId);

            if (master == null) { return null; }

            var service = await _context.Services.FindAsync(serviceId);

            if (service == null) { return null; }

            master.Services.Remove(service);
            await _context.SaveChangesAsync();

            return master.ToMasterDto();
        }
    }
}
