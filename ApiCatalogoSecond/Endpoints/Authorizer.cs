using ApiCatalogoSecond.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ApiCatalogoSecond.Endpoints
{
    public static class Authorizer
    {
        public static void AuthorizerEndpoints(this WebApplication app)
        {
            app.MapPost("/register", async (UserDTO model, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager) =>
            {
                var User = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(User);

                await signManager.SignInAsync(User, false);

                return Results.Ok();
            }).WithTags("auth");
        }
    }
}
