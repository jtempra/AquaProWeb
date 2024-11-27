using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusConceptesFactura;

namespace AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura
{
    public class CreateConcepteFacturaDTO
    {
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
        public CreateFamiliaConcepteFacturaDTO Familia { get; set; }
        public int TipusConcepteFacturaId { get; set; }
        public CreateTipusConcepteFacturaDTO Tipus { get; set; }
        public double Estoc { get; set; } = 0;
        public double EstocMinim { get; set; } = 0;
        public string? CodiComptable { get; set; }
        public Boolean Emmagatzemable { get; set; } = true;
    }
}
