﻿using Library.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.QuestionManagement
{
    public interface IQuestionManager
    {
        Task<List<QuestionDTO>> LoadAll();
    }
}