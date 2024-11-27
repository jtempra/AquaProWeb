using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;

namespace AquaProWeb.Common.Responses.TaulesGenerals.Carrers
{
    public class ReadCarrerDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string CodiPostal { get; set; }
        public string Observacions { get; set; }
        public int PoblacioId { get; set; }
        public ReadPoblacioDTO Poblacio { get; set; }
        public int ZonaCarrersId { get; set; }
        public ReadZonaCarrerDTO ZonaCarrer { get; set; }
        public int TipusViaId { get; set; }
        public ReadTipusViaDTO TipusVia { get; set; }
        public CategoriaVia CategoriaVia { get; set; }
    }
}
