using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IRecordLabelService
    {
        public Task<IList<RecordLabelDto>> GetAllRecordLabels();
        public Task<RecordLabel?> GetRecordLabelById(int id);
        public Task AddRecordLabel(RecordLabelDto recordLabel);
        public Task RemoveRecordLabel(int id);
        public Task UpdateRecordLabel(int id, RecordLabelDto newRecordLabel);
    }
}
