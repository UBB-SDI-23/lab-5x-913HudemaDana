using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecordLabelService : IRecordLabelService
    {

        private readonly ApplicationDbContext _context;
        public RecordLabelService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<RecordLabelDto>> GetAllRecordLabels()
        {
            var recordLabelList = await _context.RecordLabels.ToListAsync();
            var recordLabelListDto = recordLabelList.Select(rl => new RecordLabelDto()
            {
                Id = rl.Id,
                Name = rl.Name,
                Description = rl.Description,
                Gendre = rl.Gendre
            });

            return recordLabelListDto.ToList() ?? new List<RecordLabelDto>();
        }
        public async Task<RecordLabel?> GetRecordLabelById(int id)
        {
            var recordLabel = await _context.RecordLabels.SingleOrDefaultAsync(a => a.Id == id);
            var contracts = await _context.Contracts.Where(c => c.RecordLabelId == id).ToListAsync();

            return (recordLabel != null ? new RecordLabel()
            {
                Id = recordLabel.Id,
                Name = recordLabel.Name,
                Description = recordLabel.Description,
                Gendre = recordLabel.Gendre,
                Contracts = contracts
            } : null);
        }
        public async Task AddRecordLabel(RecordLabelDto recordLabel)
        {
            var newRecordLabel = new RecordLabel()
            {
                Name = recordLabel.Name,
                Description = recordLabel.Description,
                Gendre = recordLabel.Gendre
            };
            await _context.RecordLabels.AddAsync(newRecordLabel);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveRecordLabel(int id)
        {
            var recordLabel = _context.RecordLabels.Find(id);
            if (recordLabel != null)
            {
                _context.RecordLabels.Remove(recordLabel);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateRecordLabel(int id, RecordLabelDto newRecordLabel)
        {
            var recordLabel = _context.RecordLabels.Find(id);
            if (recordLabel != null)
            {
                recordLabel.Name = newRecordLabel.Name;
                recordLabel.Description = newRecordLabel.Description;
                recordLabel.Gendre = newRecordLabel.Gendre;

                _context.RecordLabels.Update(recordLabel);
            }
            await _context.SaveChangesAsync();
        }

    }
}
