using Library.DTOs;
using Library.Models.Cache;
using Microsoft.Extensions.Caching.Memory;
using Services.GenericRepository;
using Services.SessionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.AnswerSetManagement.Implementation
{
    public class AnswerSetManager : IAnswerSetManager
    {
        private readonly ISessionManager _sessionManager;
        private readonly IGenericQuerier _genericQuerier;
        private readonly IGenericRepo _genericRepo;
        private readonly IMemoryCache _memoryCache;
        public AnswerSetManager(ISessionManager sessionManager, IGenericQuerier genericQuerier, IGenericRepo genericRepo, IMemoryCache memoryCache)
        {
            _sessionManager = sessionManager;
            _genericQuerier = genericQuerier;
            _genericRepo = genericRepo;
            _memoryCache = memoryCache;
        }

        public void SetAnswerSet(int sectionID, int answerID, int? questionID)
        {
            string sessionCode = _sessionManager.GetUserSessionCode();
            List<SessionAnswerDTO> existingAnswers = new List<SessionAnswerDTO>();

            if (_memoryCache.TryGetValue(CacheKeys.UserSession(sessionCode), out List<SessionAnswerDTO> answerSet))
                existingAnswers = answerSet;

            SessionAnswerDTO currentAnswer = existingAnswers.FirstOrDefault(f => f.SectionID == sectionID && f.QuestionID == questionID);
            
            if (currentAnswer == null)
                existingAnswers.Add(new SessionAnswerDTO()
                {
                    QuestionID = questionID,
                    AnswerID = answerID,
                    SectionID = sectionID
                });
            else
                currentAnswer.AnswerID = answerID;

            _memoryCache.Set(CacheKeys.UserSession(sessionCode), existingAnswers);
        }

        public async Task<bool> SaveAnswerSet()
        {
            throw new NotImplementedException();
        }
    }
}
