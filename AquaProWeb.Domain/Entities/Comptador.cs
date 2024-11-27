using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Comptador : BaseEntity
    {
        public string Codi
        {
            get; set;
        }
        public string Model
        {
            get; set;
        }
        public string Classe
        {
            get; set;
        }
        public int MarcaId
        {
            get; set;
        }
        public MarcaComptador Marca
        {
            get; set;
        }
        public int TipusComptadorId
        {
            get; set;
        }
        public TipusComptador Tipus
        {
            get; set;
        }
        public DiametreComptador Diametre
        {
            get; set;
        }
        public int Digits
        {
            get; set;
        }
        public string Microxip
        {
            get; set;
        }
        public DateTime? DataCompra
        {
            get; set;
        }
        public DateTime? DataBaixa
        {
            get; set;
        }
        public int PeriodeRevisio
        {
            get; set;
        }
        public ICollection<ComptadorUbicacio> ComptadorUbicacions
        {
            get; set;
        }
        public ICollection<LecturaComptador> LecturesComptador
        {
            get; set;
        }

    }
}
