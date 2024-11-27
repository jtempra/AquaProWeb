namespace AquaProWeb.Domain.Entities
{
    public class ComptadorUbicacio
    {
        public int UbicacioId
        {
            get; set;
        }
        public Ubicacio Ubicacio
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
        public DateTime DataInstalacio
        {
            get; set;
        }
        public int? OperariInstalacioId
        {
            get; set;
        }
        public Operari OperariInstalacio
        {
            get; set;
        }
        public DateTime? DataBaixa
        {
            get; set;
        }
        public int? OperariBaixaId
        {
            get; set;
        }
        public Operari OperariBaixa
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
    }
}
