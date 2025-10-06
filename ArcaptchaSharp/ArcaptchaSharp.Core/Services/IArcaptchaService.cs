using ArcaptchaSharp.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ArcaptchaSharp.Core.Services
{
    public interface IArcaptchaService
    {
        ArcaptchaVerificationResult VerifyArcaptchaResponse(string response);
        Task<ArcaptchaVerificationResult> VerifyArcaptchaResponseAsync(string response, CancellationToken cancellationToken);
    }
}
