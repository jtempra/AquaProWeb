using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Suggeriment : BaseEntity
    {
        public int ContracteId { get; set; }
        public Contracte Contracte { get; set; }
        public DateTime DataEntrada { get; set; }
        public int TipusSuggerimentId { get; set; }
        public TipusSuggeriment Tipus { get; set; }
        public SituacioSuggeriment Situacio { get; set; }
        public DateTime DataSituacio { get; set; }
        public CanalEntrada CanalEntrada { get; set; }
        public string Descripcio { get; set; }
        public string Resposta { get; set; }
        public DateTime DataResposta { get; set; }
    }
}
