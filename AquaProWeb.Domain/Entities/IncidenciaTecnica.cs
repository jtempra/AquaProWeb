using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class IncidenciaTecnica : BaseEntity
    {
        public string Ubicacio { get; set; }
        public CaracterIncidencia Caracter { get; set; }
        public string Descripcio { get; set; }
        public string Solucio { get; set; }
        public string Observacions { get; set; }
        public DateTime DataIncidencia { get; set; }
        public DateTime? DataInici { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
