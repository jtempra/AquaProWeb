using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Responses.TaulesGenerals.Carrers
{
    public class ListCarrerDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string CodiPostal { get; set; }
        public string Observacions { get; set; }
        public string Poblacio { get; set; }
        public string ZonaCarrers { get; set; }
        public string TipusVia { get; set; }
        public CategoriaVia CategoriaVia { get; set; }
    }
}
