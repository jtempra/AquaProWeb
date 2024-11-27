using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class ConcepteFactura : BaseEntity
    {
        public string Codi
        {
            get; set;
        }
        public string Descripcio
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
        public decimal PVP { get; set; } = 0;
        public decimal PreuCompra { get; set; } = 0;
        public decimal PreuTarifa { get; set; } = 0;
        public decimal PreuUltimaCompra { get; set; } = 0;
        public double Descompte { get; set; } = 0;
        public Unitat? Unitat
        {
            get; set;
        }
        public int FamiliaConcepteFacturaId
        {
            get; set;
        }
        public FamiliaConcepteFactura Familia
        {
            get; set;
        }
        public int TipusConcepteFacturaId
        {
            get; set;
        }
        public TipusConcepteFactura Tipus
        {
            get; set;
        }
        public double Estoc { get; set; } = 0;
        public double EstocMinim { get; set; } = 0;
        public string? CodiComptable
        {
            get; set;
        }
        public Boolean Emmagatzemable { get; set; } = true;
    }
}
