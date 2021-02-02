using MotorqService.Models;
using System.Threading.Tasks;

namespace MotorqService.Service
{
    public interface IMotorqService
    {
        Task<TokenResponseModel> GetAccessToken(TokenRequestModel request);
        Task<GetEnrollmentResponseModel> GetEnrollments(AuthRequest<GetEnrollmentRequestModel> request);

        Task<string> GetDriver(string path);
    }
}
