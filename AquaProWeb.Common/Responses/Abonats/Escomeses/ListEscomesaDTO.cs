namespace AquaProWeb.Common.Responses.Abonats.Escomeses
{
    public class ListEscomesaDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
        public float DiametreNominal { get; set; }
        public float DiametreEscomesa { get; set; }
        public float CoeficientCabdal { get; set; }
        public float PressioDisseny { get; set; }
        public float PressioMaximaDisseny { get; set; }
        public float PressioFuncionamentAdmisible { get; set; }
        public float PressioMaximaAdmisible { get; set; }
        public float PressioAssaigAdmisible { get; set; }
        public float PressioNominal { get; set; }
        public string ValvulaPasIntegral { get; set; }
        public string Ramal { get; set; }

    }
}
