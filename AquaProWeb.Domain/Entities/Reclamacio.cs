using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Reclamacio : BaseEntity
    {
        public int ContracteId { get; set; }
        public Contracte Contracte { get; set; }
        public DateTime DataEntrada { get; set; }
        public int TipusReclamacioId { get; set; }
        public TipusReclamacio Tipus { get; set; }
        public SituacioReclamacio Situacio { get; set; }
        public DateTime DataSituacio { get; set; }
        public CanalEntrada CanalEntrada { get; set; }
        public string Descripcio { get; set; }
        public string Resposta { get; set; }
        public DateTime DataResposta { get; set; }
        public DateTime DataLimitResolucio { get; set; }
    }
}
