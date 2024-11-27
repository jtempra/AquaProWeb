
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.UI;
using AquaProWeb.UI.Authentication;
using AquaProWeb.UI.Services.Account;
using AquaProWeb.UI.Services.Configuracio.Explotacion;
using AquaProWeb.UI.Services.Configuracio.TaulesGenerals;
using AquaProWeb.UI.Services.Contracts;
using AquaProWeb.UI.Validations;
using Blazored.LocalStorage;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// servei d'autorització
builder.Services.AddAuthorizationCore();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// local storage per els JWT
builder.Services.AddBlazoredLocalStorage();

// registrem el servei de autenticació
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// registrem el servei de Http Client pel BackEnd
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BackEndUrl"] ?? "http://localhost:5107") });

// registrem el servei de Http Client pel FrontEnd
//builder.Services.AddHttpClient("Auth", options => options.BaseAddress = new Uri(builder.Configuration["BackEndUrl"] ?? "http://localhost:5235")).AddHttpMessageHandler<CustomHttpHandler>();

// registrem els serveis

builder.Services.AddScoped<ICarrerService, CarrerService>();
builder.Services.AddScoped<IExplotacioService, ExplotacioService>();
builder.Services.AddScoped<IPoblacioService, PoblacioService>();
builder.Services.AddScoped<IZonaCarrerService, ZonaCarrerService>();
builder.Services.AddScoped<ITipusViaService, TipusViaService>();
builder.Services.AddScoped<ICanalCobramentService, CanalCobramentService>();

// validadors

builder.Services.AddScoped<IValidator<CreateExplotacioDTO>, ExplotacioValidator>();
builder.Services.AddScoped<IValidator<CreateCanalCobramentDTO>, CanalCobramentValidator>();


// registrem els serveis de Mudblazor

builder.Services.AddMudServices();

// engegem la app

await builder.Build().RunAsync();
