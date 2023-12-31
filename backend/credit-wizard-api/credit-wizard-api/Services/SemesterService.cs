﻿using credit_wizard_api.Models;
using credit_wizard_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace credit_wizard_api.Services
{
    /// <summary>
    /// Business logic for semester, method comments are placed in its interface
    /// </summary>
    public class SemesterService : ISemesterService
    {
        private readonly ApplicationDbContext _dbContext;
        public SemesterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Semester>> GetAsync() => await _dbContext.Semesters.OrderBy(x => x.Number).ToListAsync();

        public async Task<Semester?> GetByIdAsync(Guid id) => await _dbContext.Semesters.FirstOrDefaultAsync(x => x.Id == id);
    }
}
