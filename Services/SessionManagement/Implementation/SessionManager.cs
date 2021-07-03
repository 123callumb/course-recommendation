using Library.DTOs;
using Library.EntityFramework.DbEntities;
using Library.Models.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.GenericRepository;
using Services.SessionManagement.Helpers;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.SessionManagement.Implementation
{
    public class SessionManager : ISessionManager
    {
        private readonly IGenericRepo _genericRepo;
        private readonly IGenericQuerier _genericQuerier;
        private readonly HttpContext _context;

        public SessionManager(IHttpContextAccessor contextAccessor, IGenericRepo genericRepo, IGenericQuerier genericQuerier)
        {
            _context = contextAccessor.HttpContext;
            _genericRepo = genericRepo;
            _genericQuerier = genericQuerier;
        }

        public async Task<UserSession> GetOrSetSession()
        {
            var session = _context.Session;
            string userSessionToken = session.Get<string>(SessionKeys.UserSession);

            if (userSessionToken == null)
            {
                userSessionToken = await CreateUserSession();
                session.Set(SessionKeys.UserSession, userSessionToken);
            }

            int sessionID = GetUserSessionID(userSessionToken);
            var answerSets = await _genericQuerier.Load(SessionAnswerDTO.MapEntity, w => w.SessionId == sessionID).ToListAsync();

            return new UserSession
            {
                SessionID = sessionID,
                AnswerSet = answerSets
            };
        }

        private async Task<string> CreateUserSession()
        {
            Session newSession = new Session();
            await _genericRepo.Add(newSession);

            // Throw this key in db, or maybe app settings
            var key = Encoding.ASCII.GetBytes("FEFwdwefefHJUkdgvSBTynkfegHdFWEPOfhGsfwdaeqwfhtibddfHRTUYhdgewEWfDw");
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(SessionKeys.Claim_UserSession, newSession.SessionId.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token);
        }

        private int GetUserSessionID(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            Claim sessionIDClaim = tokenHandler.ReadJwtToken(token).Claims.FirstOrDefault(f => f.Type == SessionKeys.Claim_UserSession);
            return int.Parse(sessionIDClaim.Value);
        }
    }
}
