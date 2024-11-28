namespace AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesLectures
{
    public class UpdateTipusIncidenciaLecturaDTO
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
