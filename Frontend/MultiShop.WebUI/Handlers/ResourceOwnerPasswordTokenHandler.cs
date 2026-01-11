
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.WebUI.Services.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityService _identityService;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = _httpContextAccessor.HttpContext;

            var accessToken = await context.GetTokenAsync(
                OpenIdConnectParameterNames.AccessToken);

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await base.SendAsync(request, cancellationToken);

            // 🔐 SADECE AUTH HATASI
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshed = await _identityService.GetRefreshToken();

                // ❌ Refresh başarısız → Login
                if (!refreshed)
                {
                    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Response.Redirect("/Login/Index");
                    return response;
                }

                // ✅ Yeni token ile tekrar dene
                var newAccessToken = await context.GetTokenAsync(
                    OpenIdConnectParameterNames.AccessToken);

                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", newAccessToken);

                return await base.SendAsync(request, cancellationToken);
            }

            return response;

            // İlk hali:

            //var accessToken = _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Result);
            //var response = await base.SendAsync(request, cancellationToken);

            //if(response.StatusCode == HttpStatusCode.Unauthorized)
            //{
            //    var tokenResponse = await _identityService.GetRefreshToken();

            //    if(tokenResponse != null)
            //    {
            //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Result);
            //        response = await base.SendAsync(request, cancellationToken);
            //    }
            //}

            //if(response.StatusCode == HttpStatusCode.Unauthorized)
            //{
            //    // Hata mesajı
            //}

            //return response;
        }
    }
}
