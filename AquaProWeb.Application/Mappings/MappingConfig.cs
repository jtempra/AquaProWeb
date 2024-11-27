
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.Explotacions;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
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
            TypeAdapterConfig<Carrer, ReadCarrerDTO>
                .NewConfig()
            .Map(dest => dest.Poblacio, src => src.Poblacio)
            .Map(dest => dest.ZonaCarrer, src => src.Zona)
            .Map(dest => dest.TipusVia, src => src.TipusVia);

            TypeAdapterConfig<Poblacio, ReadPoblacioDTO>.NewConfig();
            TypeAdapterConfig<ZonaCarrers, ReadZonaCarrerDTO>.NewConfig();
            TypeAdapterConfig<TipusVia, ReadTipusViaDTO>.NewConfig();

            TypeAdapterConfig<UpdateCarrerDTO, Carrer>.NewConfig();

            TypeAdapterConfig<ReadCarrerDTO, Carrer>
                .NewConfig()
            .Map(dest => dest.Poblacio, src => src.Poblacio)
            .Map(dest => dest.Zona, src => src.ZonaCarrer)
            .Map(dest => dest.TipusVia, src => src.TipusVia);

            // Configuración de mapeo de PoblacioDTO a Poblacio
            TypeAdapterConfig<ReadPoblacioDTO, Poblacio>.NewConfig();

            // Configuración de mapeo de ZonaCarrerDTO a ZonaCarrer
            TypeAdapterConfig<ReadZonaCarrerDTO, ZonaCarrers>.NewConfig();

            // Configuración de mapeo de TipusViaDTO a TipusVia
            TypeAdapterConfig<ReadTipusViaDTO, TipusVia>.NewConfig();




            TypeAdapterConfig<Explotacio, ReadExplotacioDTO>
                .NewConfig();
            TypeAdapterConfig<ReadExplotacioDTO, Explotacio>
                .NewConfig();

            TypeAdapterConfig<UpdateExplotacioDTO, Explotacio>
                .NewConfig();

            TypeAdapterConfig<Poblacio, ReadPoblacioDTO>
                .NewConfig();

            TypeAdapterConfig<UpdatePoblacioDTO, Poblacio>
                .NewConfig();

            TypeAdapterConfig<TipusVia, ReadTipusViaDTO>
                .NewConfig();

            TypeAdapterConfig<UpdateTipusViaDTO, TipusVia>
                .NewConfig();

            TypeAdapterConfig<CanalCobrament, ReadCanalCobramentDTO>
                .NewConfig();

            TypeAdapterConfig<UpdateCanalCobramentDTO, CanalCobrament>
                .NewConfig();

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        }
    }
}
