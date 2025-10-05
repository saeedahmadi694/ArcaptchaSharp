using ArcaptchaSharp.AspNetCore.Config;
using ArcaptchaSharp.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ArcaptchaSharp.AspNetCore.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddArcaptchaService(this IServiceCollection services, Action<ArcaptchaSetting> configure)
    {
        services.Configure(configure);

        services.AddScoped((Func<IServiceProvider, IArcaptchaService>)(sp =>
        {
            var setting = sp.GetRequiredService<IOptionsMonitor<ArcaptchaSetting>>().CurrentValue;
            return new ArcaptchaService(
                setting.SecretKey,
                setting.SiteKey,
                setting.VerificationUrl
            );
        }));

        return services;
    }
}

