using AquaProWeb.Common.Enums;

namespace AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura
{
    public class SaveConcepteFacturaDTO
    {
        public int Id { get; set; }
        public string Codi { get; set; }
        public string Descripcio { get; set; }
        public string? Observacions { get; set; }
        public decimal PVP { get; set; } = 0;
        public decimal PreuCompra { get; set; } = 0;
        public decimal PreuTarifa { get; set; } = 0;
        public decimal PreuUltimaCompra { get; set; } = 0;
        public double Descompte { get; set; } = 0;
        public Unitat? Unitat { get; set; }
        public int FamiliaConcepteFacturaId { get; set; }
        public int TipusConcepteFacturaId { get; set; }
        public double Estoc { get; set; } = 0;
        public double EstocMinim { get; set; } = 0;
        public string? CodiComptable { get; set; }
        public Boolean Emmagatzemable { get; set; } = true;
    }
}
