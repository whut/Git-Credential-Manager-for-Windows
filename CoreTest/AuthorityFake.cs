﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.TeamFoundation.Git.Helpers.Authentication
{
    internal class AuthorityFake : IAzureAuthority, ILiveAuthority, IVsoAuthority
    {
        public Tokens AcquireToken(string clientId, string resource, Uri redirectUri, string queryParameters = null)
        {
            return new Tokens("token-access", "token-refresh");
        }

        public async Task<Tokens> AcquireTokenAsync(string clientId, string resource, Credential credentials = null)
        {
            return await Task.Run(() => { return new Tokens("token-access", "token-refresh"); });
        }

        public async Task<Tokens> AcquireTokenByRefreshTokenAsync(string clientId, string resource, Token refreshToken)
        {
            return await Task.Run(() => { return new Tokens("token-access", "token-refresh"); });
        }

        public async Task<Credential> GeneratePersonalAccessToken(Uri targetUri, Token accessToken)
        {
            return await Task.Run(() => { return new Credential("username"); });
        }

        public async Task<bool> ValidateCredentials(Credential credentials)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Credential.Validate(credentials);
                    return true;
                }
                catch { }
                return false;
            });
        }
    }
}