using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    public class SemesterTimeSlotService : ISemesterTimeSlotService
    {
        private readonly ApplicationDbContext _dbContext;
        public SemesterTimeSlotService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<SemesterTimeSlot>> GetAsync()
        {
            return await _dbContext.SemesterTimeSlots.ToListAsync();
        }

        public async Task<SemesterTimeSlot?> GetByIdAsync(Guid id)
        {
            return await _dbContext.SemesterTimeSlots.FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}
