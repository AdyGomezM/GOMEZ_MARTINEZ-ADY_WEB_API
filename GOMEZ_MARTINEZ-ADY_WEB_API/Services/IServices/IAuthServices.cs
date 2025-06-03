using Domain.DTO;

namespace GOMEZ_MARTINEZ_ADY_WEB_API.Services.IServices
{
    public interface IAuthServices
    {
        Task<string> Login(LoginRequest request);
    }
}