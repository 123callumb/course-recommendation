using Library.DTOs;
using Library.EntityFramework.DbEntities;
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

        public async Task<int> SaveSessionAnswers()
        {
            var currentSession = _sessionManager.GetOrSetSession();

            if (!currentSession.AnswerSet.Any())
                throw new Exception("There are no answer sets to save.");

            // TODO: do a check here to make sure all questions that have a required tag have been answered
            Session newSession = new Session()
            {
                SessionAnswers = currentSession.AnswerSet.AsQueryable().Select(SessionAnswerDTO.ToEntity).ToList()
            };

            if (await _genericRepo.Add(newSession) < 1)
                throw new Exception("Failed to save session answers.");

            return newSession.SessionId;
        }
    }
}
