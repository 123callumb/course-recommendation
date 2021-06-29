using Library.DTOs;
using Microsoft.EntityFrameworkCore;
using Services.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.QuestionManagement.Implementation
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IGenericQuerier _genericQuerier;

        public QuestionManager(IGenericQuerier genericQuerier)
        {
            _genericQuerier = genericQuerier;
        }
        public async Task<List<SectionDTO>> LoadAll()
        {
            return await _genericQuerier.Load(SectionDTO.MapEntity).ToListAsync();
        }
    }
}
