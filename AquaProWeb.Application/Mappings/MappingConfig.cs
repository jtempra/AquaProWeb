
using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Responses.Explotacions;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AquaProWeb.Application.Mappings
{
    public static class MappingConfig
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            // Carrer
            TypeAdapterConfig<Carrer, ReadCarrerDTO>
                .NewConfig()
            .Map(dest => dest.Poblacio, src => src.Poblacio)
            .Map(dest => dest.ZonaCarrer, src => src.Zona)
            .Map(dest => dest.TipusVia, src => src.TipusVia);

            TypeAdapterConfig<Poblacio, ReadPoblacioDTO>.NewConfig();
            TypeAdapterConfig<ZonaCarrers, ReadZonaCarrerDTO>.NewConfig();
            TypeAdapterConfig<TipusVia, ReadTipusViaDTO>.NewConfig();

            TypeAdapterConfig<SaveCarrerDTO, Carrer>.NewConfig();

            TypeAdapterConfig<ReadCarrerDTO, Carrer>
                .NewConfig()
            .Map(dest => dest.Poblacio, src => src.Poblacio)
            .Map(dest => dest.Zona, src => src.ZonaCarrer)
            .Map(dest => dest.TipusVia, src => src.TipusVia);

            // Canal cobrament
            TypeAdapterConfig<CanalCobrament, ReadCanalCobramentDTO>.NewConfig();

            TypeAdapterConfig<SaveCanalCobramentDTO, CanalCobrament>.NewConfig();

            // Compte remesa banc
            TypeAdapterConfig<CompteRemesaBanc, ReadCompteRemesaBancDTO>.NewConfig();

            TypeAdapterConfig<SaveCompteRemesaBancDTO, CompteRemesaBanc>.NewConfig();

            // Compte transferencia client

            TypeAdapterConfig<CompteTransferenciaClient, ReadCompteTransferenciaClientDTO>.NewConfig();

            TypeAdapterConfig<SaveCompteTransferenciaClientDTO, CompteTransferenciaClient>.NewConfig();

            // Concepte Cobrament

            TypeAdapterConfig<ConcepteCobrament, ReadConcepteCobramentDTO>.NewConfig();

            TypeAdapterConfig<SaveConcepteCobramentDTO, ConcepteCobrament>.NewConfig();

            // Concepte Factura

            TypeAdapterConfig<ConcepteFactura, ReadConcepteFacturaDTO>.NewConfig();

            TypeAdapterConfig<SaveConcepteFacturaDTO, ConcepteFactura>.NewConfig();

            // Configuración de mapeo de PoblacioDTO a Poblacio
            TypeAdapterConfig<ReadPoblacioDTO, Poblacio>.NewConfig();

            // Configuración de mapeo de ZonaCarrerDTO a ZonaCarrer
            TypeAdapterConfig<ReadZonaCarrerDTO, ZonaCarrers>.NewConfig();

            // Configuración de mapeo de TipusViaDTO a TipusVia
            TypeAdapterConfig<ReadTipusViaDTO, TipusVia>.NewConfig();

            TypeAdapterConfig<Client, ReadClientDTO>
                .NewConfig()
                .Map(dest => dest.TipusClient, src => src.TipusClient)
                .Map(dest => dest.Pais, src => src.Pais)
                .Map(dest => dest.TipusVia, src => src.TipusVia);

            TypeAdapterConfig<Pais, ReadPaisDTO>.NewConfig();
            TypeAdapterConfig<TipusClient, ReadTipusClientDTO>.NewConfig();
            TypeAdapterConfig<TipusVia, ReadTipusViaDTO>.NewConfig();


            TypeAdapterConfig<Explotacio, ReadExplotacioDTO>
                .NewConfig();
            TypeAdapterConfig<ReadExplotacioDTO, Explotacio>
                .NewConfig();

            TypeAdapterConfig<SaveExplotacioDTO, Explotacio>
                .NewConfig();

            TypeAdapterConfig<Poblacio, ReadPoblacioDTO>
                .NewConfig();

            TypeAdapterConfig<SavePoblacioDTO, Poblacio>
                .NewConfig();

            TypeAdapterConfig<TipusVia, ReadTipusViaDTO>
                .NewConfig();

            TypeAdapterConfig<SaveTipusViaDTO, TipusVia>
                .NewConfig();

            // Ubicacio
            TypeAdapterConfig<Ubicacio, ReadUbicacioDTO>
                .NewConfig()
                .Map(dest => dest.TipusUbicacio, src => src.Tipus)
                .Map(dest => dest.ZonaUbicacio, src => src.Zona)
                .Map(dest => dest.Poblacio, src => src.Poblacio)
                .Map(dest => dest.Carrer, src => src.Carrer)
                .Map(dest => dest.Escomesa, src => src.Escomesa)
                .Map(dest => dest.RutaLectura, src => src.RutaLectura)
                .Map(dest => dest.Latitud, src => src.PosicioGeografica.Y)
                .Map(dest => dest.Longitud, src => src.PosicioGeografica.X)
                .TwoWays();

            TypeAdapterConfig<TipusUbicacio, ReadTipusUbicacioDTO>.NewConfig();
            TypeAdapterConfig<ZonaUbicacio, ReadZonaUbicacioDTO>.NewConfig();
            TypeAdapterConfig<Poblacio, ReadPoblacioDTO>.NewConfig();
            TypeAdapterConfig<Carrer, ReadCarrerDTO>.NewConfig();
            TypeAdapterConfig<Escomesa, ReadEscomesaDTO>.NewConfig();
            TypeAdapterConfig<RutaLectura, ReadRutaLecturaDTO>.NewConfig();

            TypeAdapterConfig<SaveUbicacioDTO, Ubicacio>.NewConfig();


            TypeAdapterConfig<Ubicacio, ListUbicacioDTO>
                .NewConfig()
                .Map(dest => dest.TipusUbicacio, src => src.Tipus.Tipus)
                .Map(dest => dest.ZonaUbicacio, src => src.Zona.Zona)
                .Map(dest => dest.Poblacio, src => src.Poblacio.Nom)
                .Map(dest => dest.Carrer, src => src.Carrer.Nom)
                .Map(dest => dest.Escomesa, src => src.Escomesa.Nom)
                .Map(dest => dest.RutaLectura, src => src.RutaLectura.Ruta)
                .Map(dest => dest.Latitud, src => src.PosicioGeografica.Y)
                .Map(dest => dest.Longitud, src => src.PosicioGeografica.X);





            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        }
    }
}
