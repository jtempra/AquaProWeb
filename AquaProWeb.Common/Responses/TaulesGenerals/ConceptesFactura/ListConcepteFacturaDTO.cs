namespace AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura
{
    public class ListConcepteFacturaDTO
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
        public string Unitat { get; set; }
        public string FamiliaConcepteFactura { get; set; }
        public string TipusConcepteFactura { get; set; }
        public double Estoc { get; set; } = 0;
        public double EstocMinim { get; set; } = 0;
        public string? CodiComptable { get; set; }
        public Boolean Emmagatzemable { get; set; } = true;
    }
}
