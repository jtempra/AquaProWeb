namespace AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesLectures
{
    public class ReadIncidenciaLecturaDTO
    {
        public int Id { get; set; }
        public string Tipus { get; set; }
        public Boolean ConsumApte { get; set; }
        public Boolean ConsumImputar { get; set; }
        public char Opcio { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
