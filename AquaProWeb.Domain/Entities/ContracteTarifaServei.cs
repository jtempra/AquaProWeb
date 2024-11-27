namespace AquaProWeb.Domain.Entities
{
    public class ContracteTarifaServei
    {
        public int ContracteId { get; set; }
        public Contracte Contracte { get; set; }
        public int TarifaServeiId { get; set; }
        public TarifaServei TarifaServei { get; set; }
        public DateTime DataIniciTarifa { get; set; }
        public DateTime DataFiTarifa { get; set; }
        public string Observacions { get; set; }

    }
}
