using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "Google";
    })
    .AddCookie()
    .AddOpenIdConnect("Google", options =>
    {
        options.Authority = "https://accounts.google.com";
        //TO DO: Move\hide
        options.ClientId = "399230135650-sqarjvjms25lmc8bvojf5msse5i8jl7u.apps.googleusercontent.com";
        options.ClientSecret = "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";
        options.CallbackPath = "/signin-google";
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.SaveTokens = true;
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
            });

app.Run();
