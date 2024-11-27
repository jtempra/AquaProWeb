using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class LecturaComptador
    {
        public int LecturaId
        {
            get; set;
        }
        public Lectura Lectura
        {
            get; set;
        }
        public int ComptadorId
        {
            get; set;
        }
        public Comptador Comptador
        {
            get; set;
        }
        public Double LecturaInicial { get; set; } = 0;
        public Double LecturaFinal { get; set; } = 0;
        public DateTime? DataLecturaInicial
        {
            get; set;
        }
        public DateTime? DataLecturaFinal
        {
            get; set;
        }
        public int DiesEntreLectures => ((TimeSpan)(DataLecturaFinal - DataLecturaInicial)).Days;
        public TipusLectura Tipus { get; set; } = TipusLectura.Manual;
        public int OperariId
        {
            get; set;
        }
        public Operari Operari
        {
            get; set;
        }
        public int TipusIncidenciaLecturaId
        {
            get; set;
        }
        public TipusIncidenciaLectura IncidenciaLectura
        {
            get; set;
        }
        public TipusIncidenciaComptador IncidenciaComptador { get; set; } = TipusIncidenciaComptador.SenseIncidencia;
        public TipusIncidenciaConsum IncidenciaConsum { get; set; } = TipusIncidenciaConsum.SenseIncidencia;

    }
}
