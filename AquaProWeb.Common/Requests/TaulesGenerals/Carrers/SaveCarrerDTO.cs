using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Requests.TaulesGenerals.Carrers
{
    public class SaveCarrerDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string CodiPostal { get; set; }
        public string Observacions { get; set; }
        public int PoblacioId { get; set; }
        public int ZonaCarrersId { get; set; }
        public int TipusViaId { get; set; }
        public CategoriaVia CategoriaVia { get; set; }
    }
}
