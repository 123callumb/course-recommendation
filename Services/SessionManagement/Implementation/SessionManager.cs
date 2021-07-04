using Library.DTOs;
using Library.Models.Cache;
using Library.Models.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Services.SessionManagement.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.SessionManagement.Implementation
{
    public class SessionManager : ISessionManager
    {
        private readonly HttpContext _context;
        private readonly IMemoryCache _memoryCache;

        public SessionManager(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache)
        {
            _context = contextAccessor.HttpContext;
            _memoryCache = memoryCache;
        }

        public UnsavedUserSession GetOrSetSession()
        {
            var session = _context.Session;
            string userSessionToken = session.Get<string>(SessionKeys.UserSession);

            if (userSessionToken == null)
            {
                userSessionToken = CreateUnsavedUserSession();
                session.Set(SessionKeys.UserSession, userSessionToken);
            }

            string sessionCode = GetUserSessionIDFromToken(userSessionToken);
            List<SessionAnswerDTO> existingSessionAnswers = new List<SessionAnswerDTO>();

            if (_memoryCache.TryGetValue(CacheKeys.UserSession(sessionCode), out List<SessionAnswerDTO> answerSets))
                existingSessionAnswers = answerSets;

            return new UnsavedUserSession
            {
                SessionCode = sessionCode,
                AnswerSet = existingSessionAnswers
            };
        }

        private string CreateUnsavedUserSession()
        {
            string sessionCode = CreateUnsavedSessionCode();
            List<string> currentSessionCodes = new List<string>() { sessionCode };

            if (_memoryCache.TryGetValue(CacheKeys.AllSessionCodes, out List<string> existingCodes))
                currentSessionCodes.Concat(existingCodes);

            _memoryCache.Set(CacheKeys.AllSessionCodes, currentSessionCodes);

            // Throw this key in db, or maybe app settings
            var key = Encoding.ASCII.GetBytes("FEFwdwefefHJUkdgvSBTynkfegHdFWEPOfhGsfwdaeqwfhtibddfHRTUYhdgewEWfDw");
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(SessionKeys.Claim_UserSession, sessionCode)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token);
        }

        private string GetUserSessionIDFromToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            Claim sessionIDClaim = tokenHandler.ReadJwtToken(token).Claims.FirstOrDefault(f => f.Type == SessionKeys.Claim_UserSession);
            return sessionIDClaim.Value;
        }

        public string GetUserSessionCode()
        {
            var session = _context.Session;
            string userSessionToken = session.Get<string>(SessionKeys.UserSession);

            if (userSessionToken == null)
                throw new Exception("Could not get user session ID as it has not been set.");

            return GetUserSessionIDFromToken(userSessionToken);
        }

        private string CreateUnsavedSessionCode()
        {
            Random rand = new Random();
            string newSessionCode;

            do
            {
                newSessionCode = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 6).Select(s => s[rand.Next(s.Length)]).ToArray());
            } while (SesionCodeExists(newSessionCode));

            return newSessionCode;
        }

        private bool SesionCodeExists(string sessionCode)
        {
            if (_memoryCache.TryGetValue(CacheKeys.AllSessionCodes, out List<string> unsavedSessionCodes))
                return unsavedSessionCodes.Contains(sessionCode);
            return false;
        }

        public void ClearUserSession()
        {
            string sessionCode = GetUserSessionCode();
            _memoryCache.Remove(CacheKeys.UserSession(sessionCode));

            if (_memoryCache.TryGetValue(CacheKeys.AllSessionCodes, out List<string> currentSessions))
            {
                string code = currentSessions.FirstOrDefault(f => f == sessionCode);

                if (code != null)
                {
                    currentSessions.Remove(sessionCode);
                    _memoryCache.Set(CacheKeys.AllSessionCodes, currentSessions);
                }
            }
        }
    }
}
