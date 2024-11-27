using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Escomesa : BaseEntity
    {
        public string Nom
        {
            get; set;
        }
        public string Descripcio
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }
        public float DiametreNominal
        {
            get; set;
        }
        public float DiametreEscomesa
        {
            get; set;
        }
        public float CoeficientCabdal
        {
            get; set;
        }
        public float PressioDisseny
        {
            get; set;
        }
        public float PressioMaximaDisseny
        {
            get; set;
        }
        public float PressioFuncionamentAdmisible
        {
            get; set;
        }
        public float PressioMaximaAdmisible
        {
            get; set;
        }
        public float PressioAssaigAdmisible
        {
            get; set;
        }
        public float PressioNominal
        {
            get; set;
        }

        public string ValvulaPasIntegral
        {
            get; set;
        }
        public int RamalId
        {
            get; set;
        }
        public Ramal Ramal
        {
            get; set;
        }

        public ICollection<Component> Components
        {
            get; set;
        }
        public ICollection<Ubicacio> Ubicacions
        {
            get; set;
        }

    }
}
