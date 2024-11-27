using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class BlocTarifa : BaseEntity
    {
        public int Bloc { get; set; }
        public string Descripcio { get; set; }
        public int Ordre { get; set; } = 1;
        public double Valor { get; set; } = 0;
        public decimal Preu { get; set; } = 0m;
        public Boolean Actiu { get; set; } = true;
        public double M3Adicionals { get; set; } = 0;
        public int Versio { get; set; } = 1;
        public int SubconcepteTarifaId { get; set; }
        public SubconcepteTarifa SubconcepteTarifa { get; set; }
    }
}
