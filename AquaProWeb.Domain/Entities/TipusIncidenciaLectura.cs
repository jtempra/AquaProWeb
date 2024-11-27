using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class TipusIncidenciaLectura : BaseEntity
    {
        public string Tipus { get; set; }
        public Boolean ConsumApte { get; set; }
        public Boolean ConsumImputar { get; set; }
        public char Opcio { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
