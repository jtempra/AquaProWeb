using AquaProWeb.UI;
using AquaProWeb.UI.Authentication;
using AquaProWeb.UI.Services.Abonats;
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

//builder.Services.Scan(scan => scan
//    .FromExecutingAssembly()
//    .AddClasses(
//        filter => filter.Where(x => x.Name.EndsWith("Service")),
//        publicOnly: false)
//    .UsingRegistrationStrategy(RegistrationStrategy.Throw)
//    .AsMatchingInterface()
//    .WithScopedLifetime());

builder.Services.AddScoped<IExplotacioService, ExplotacioService>();
builder.Services.AddScoped<IParametreService, ParametreService>();

builder.Services.AddScoped<ICanalCobramentService, CanalCobramentService>();
builder.Services.AddScoped<ICarrerService, CarrerService>();
builder.Services.AddScoped<ICompteRemesaBancService, CompteRemesaBancService>();
builder.Services.AddScoped<ICompteTransferenciaClientService, CompteTransferenciaClientService>();
builder.Services.AddScoped<IConcepteCobramentService, ConcepteCobramentService>();
builder.Services.AddScoped<IConcepteFacturaService, ConcepteFacturaService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IFamiliaConcepteFacturaService, FamiliaConcepteFacturaService>();
builder.Services.AddScoped<IFamiliaContracteService, FamiliaContracteService>();
builder.Services.AddScoped<IMarcaComptadorService, MarcaComptadorService>();
builder.Services.AddScoped<IMotiuBaixaComptadorService, MotiuBaixaComptadorService>();
builder.Services.AddScoped<IMotiuBaixaCompteService, MotiuBaixaCompteService>();
builder.Services.AddScoped<IMotiuBaixaContacteService, MotiuBaixaContacteService>();
builder.Services.AddScoped<IMotiuBaixaTitularService, MotiuBaixaTitularService>();
builder.Services.AddScoped<IOperariService, OperariService>();
builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPoblacioService, PoblacioService>();
builder.Services.AddScoped<IRutaLecturaService, RutaLecturaService>();
builder.Services.AddScoped<ISerieFacturaService, SerieFacturaService>();
builder.Services.AddScoped<ISerieRebutService, SerieRebutService>();
builder.Services.AddScoped<ISituacioFacturaService, SituacioFacturaService>();
builder.Services.AddScoped<ISituacioRebutService, SituacioRebutService>();
builder.Services.AddScoped<ITipusBaixaClientService, TipusBaixaClientService>();
builder.Services.AddScoped<ITipusCampanyaService, TipusCampanyaService>();
builder.Services.AddScoped<ITipusClientService, TipusClientService>();
builder.Services.AddScoped<ITipusComptadorService, TipusComptadorService>();
builder.Services.AddScoped<ITipusConcepteFacturaService, TipusConcepteFacturaService>();
builder.Services.AddScoped<ITipusDocumentService, TipusDocumentService>();
builder.Services.AddScoped<ITipusFacturaService, TipusFacturaService>();
builder.Services.AddScoped<ITipusIncidenciaClientService, TipusIncidenciaClientService>();
builder.Services.AddScoped<ITipusIncidenciaContracteService, TipusIncidenciaContracteService>();
builder.Services.AddScoped<ITipusIncidenciaLecturaService, TipusIncidenciaLecturaService>();
builder.Services.AddScoped<ITipusIncidenciaTecnicaService, TipusIncidenciaTecnicaService>();
builder.Services.AddScoped<ITipusIncidenciaUbicacioService, TipusIncidenciaUbicacioService>();
builder.Services.AddScoped<ITipusOrdreTreballService, TipusOrdreTreballService>();
builder.Services.AddScoped<ITipusQueixaService, TipusQueixaService>();
builder.Services.AddScoped<ITipusSuggerimentService, TipusSuggerimentService>();
builder.Services.AddScoped<ITipusReclamacioService, TipusReclamacioService>();
builder.Services.AddScoped<ITipusUbicacioService, TipusUbicacioService>();
builder.Services.AddScoped<ITipusViaService, TipusViaService>();
builder.Services.AddScoped<IUsContracteService, UsContracteService>();
builder.Services.AddScoped<IZonaCarrerService, ZonaCarrerService>();
builder.Services.AddScoped<IZonaFacturacioService, ZonaFacturacioService>();
builder.Services.AddScoped<IZonaOrdreTreballService, ZonaOrdreTreballService>();
builder.Services.AddScoped<IZonaUbicacioService, ZonaUbicacioService>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IEscomesaService, EscomesaService>();
builder.Services.AddScoped<IUbicacioService, UbicacioService>();


// validadors

builder.Services.AddValidatorsFromAssemblyContaining<CanalCobramentValidator>();

// registrem els serveis de Mudblazor

builder.Services.AddMudServices();

// engegem la app

await builder.Build().RunAsync();
