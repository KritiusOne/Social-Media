using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Service
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _unitOfWork.SecurityRepo.GetLoginByCredentials(login);
        }
        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.SecurityRepo.Add(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
