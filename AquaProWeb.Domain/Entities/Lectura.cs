using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Lectura : BaseEntity
    {
        public int ContracteId
        {
            get; set;
        }
        public Contracte Contracte
        {
            get; set;
        }
        public int Periode
        {
            get; set;
        }
        public SituacioLectura Situacio { get; set; } = SituacioLectura.Pendent;
        public double ConsumLectura { get; set; } = 0;
        public double ConsumImputat { get; set; } = 0;
        public double ConsumEstimat { get; set; } = 0;
        public int RutaId
        {
            get; set;
        }
        public RutaLectura Ruta
        {
            get; set;
        }
        public int OrdreRuta
        {
            get; set;
        }
        public PeriodeFacturacio PeriodeFacturacio
        {
            get; set;
        }
        public Boolean Fuita { get; set; } = false;
        public Boolean BonificarFuita { get; set; } = false;
        public double ConsumBonificarFuita { get; set; } = 0;
        public string Observacions
        {
            get; set;
        } = string.Empty;
        public ICollection<Document> Imatges { get; set; } = new List<Document>();
        public ICollection<LecturaComptador> LecturesComptador { get; set; } = new List<LecturaComptador>();
    }
}
