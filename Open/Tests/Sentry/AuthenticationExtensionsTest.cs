using System;
using Microsoft.AspNetCore.Authentication;
namespace Open.Tests.Sentry {

    public static class AuthenticationExtensionsTest {

        public static AuthenticationBuilder AddTestAuth(this AuthenticationBuilder builder,
            Action<AuthenticationOptionsTest> configureOptions) {
            return builder.AddScheme<AuthenticationOptionsTest, AuthenticationHandlerTest>(
                "Test Scheme", "Test Auth", configureOptions);
        }

    }

}




