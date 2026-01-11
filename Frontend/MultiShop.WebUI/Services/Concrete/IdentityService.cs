using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DTOLayer.IdentityDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Settings;
using System.Net.Http;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var refreshToken = await _httpContextAccessor.HttpContext
        .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            // 🔴 EN ÖNEMLİ KONTROL
            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var discovery = await _httpClient.GetDiscoveryDocumentAsync(
                _serviceApiSettings.IdentityServerUrl);

            var request = new RefreshTokenRequest
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                Address = discovery.TokenEndpoint,
                RefreshToken = refreshToken
            };

            var token = await _httpClient.RequestRefreshTokenAsync(request);

            // 🔴 Refresh başarısız
            if (token.IsError)
                return false;

            var authResult = await _httpContextAccessor.HttpContext.AuthenticateAsync();

            authResult.Properties.StoreTokens(new List<AuthenticationToken>
    {
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.AccessToken,
            Value = token.AccessToken
        },
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.RefreshToken,
            Value = token.RefreshToken
        },
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.ExpiresIn,
            Value = DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("O")
        }
    });

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                authResult.Principal,
                authResult.Properties);

            return true;

            // İlk hali:

            //var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            //{
            //    Address = _serviceApiSettings.IdentityServerUrl,
            //    Policy = new DiscoveryPolicy { RequireHttps = false }
            //});

            //var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            //RefreshTokenRequest refreshTokenRequest = new RefreshTokenRequest
            //{
            //    ClientId = _clientSettings.MultiShopManagerClient.ClientId,
            //    ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
            //    Address = discoveryEndPoint.TokenEndpoint,
            //    RefreshToken = refreshToken
            //};

            //var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            //var authenticationToken = new List<AuthenticationToken>()            
            //{
            //    new AuthenticationToken
            //    {
            //        Name = OpenIdConnectParameterNames.AccessToken,
            //        Value = token.AccessToken
            //    },
            //    new AuthenticationToken
            //    {
            //        Name = OpenIdConnectParameterNames.RefreshToken,
            //        Value = token.RefreshToken
            //    },
            //    new AuthenticationToken
            //    {
            //        Name = OpenIdConnectParameterNames.ExpiresIn,
            //        Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
            //    }
            //};

            //var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();

            //var properties = result.Properties;
            //properties.StoreTokens(authenticationToken);

            //await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

            //return true;
        }

        public async Task<bool> SignIn(SignInDTO signInDTO)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                UserName = signInDTO.Username,
                Password = signInDTO.Password,
                Address = discoveryEndPoint.TokenEndpoint              
            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            var userInfoRequest = new UserInfoRequest
            {
                Address = discoveryEndPoint.UserInfoEndpoint,
                Token = token.AccessToken
            };

            var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();
            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });

            authenticationProperties.IsPersistent = false;            

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            return true;
        }

        public async Task SignOut()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                return;

            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

//(ÖNERİLEN)IdentityServer’dan da Refresh Token’ı iptal etmek

//ROPC kullandığın için logout endpoint genelde olmaz ama revoke token yapabilirsin.

//public async Task SignOut()
//{
//    var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(
//        new DiscoveryDocumentRequest
//        {
//            Address = _serviceApiSettings.IdentityServerUrl,
//            Policy = new DiscoveryPolicy { RequireHttps = false }
//        });

//    var refreshToken = await _httpContextAccessor.HttpContext
//        .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

//    if (!string.IsNullOrEmpty(refreshToken))
//    {
//        await _httpClient.RevokeTokenAsync(new TokenRevocationRequest
//        {
//            Address = discoveryEndPoint.RevocationEndpoint,
//            ClientId = _clientSettings.MultiShopManagerClient.ClientId,
//            ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
//            Token = refreshToken,
//            TokenTypeHint = "refresh_token"
//        });
//    }

//    await _httpContextAccessor.HttpContext
//        .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//}