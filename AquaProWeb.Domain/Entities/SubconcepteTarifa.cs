using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class SubconcepteTarifa : BaseEntity
    {
        public string Subconcepte
        {
            get; set;
        }
        public int Versio { get; set; } = 1;
        public string Descripcio
        {
            get; set;
        }
        public double Valor { get; set; } = 0;
        public double Minim { get; set; } = 0;
        public double Exempt { get; set; } = 0;
        public double Bonificacio { get; set; } = 0;
        public TipusSubconcepteTarifa TipusSubconcepte
        {
            get; set;
        }
        public double Taxa { get; set; } = 0;
        public int? PartidaAplicarId
        {
            get; set;
        }
        public PartidaTarifa PartidaAplicar
        {
            get; set;
        }
        public DateTime DataAprovacio
        {
            get; set;
        }
        public DateTime DataAplicacio
        {
            get; set;
        }
        public DateTime? DataCaducitat
        {
            get; set;
        }
        public Boolean Actiu { get; set; } = false;
        public Unitat Unitats
        {
            get; set;
        }
        public Boolean Demora { get; set; } = false;
        public Boolean Prorratejable { get; set; } = false;
        public PeriodeFacturacio Periode
        {
            get; set;
        }
        public bool MultiplicaFactor { get; set; } = false;
        public int FactorCorreccio { get; set; } = 0;
        public int ConcepteTarifaId
        {
            get; set;
        }
        public ConcepteTarifa ConcepteTarifa
        {
            get; set;
        }
        public int TarifaServeiId
        {
            get; set;
        }
        public TarifaServei TarifaServei
        {
            get; set;
        }
        public int EmpresaId
        {
            get; set;
        }
        public Empresa Empresa
        {
            get; set;
        }
        public ICollection<FactorMultiplicadorTarifa> FactorMultiplicadors
        {
            get; set;
        }
        public FactorMultiplicadorTarifa FactorMultiplicador { get; set; } = FactorMultiplicadorTarifa.NumVivendes;
        public ICollection<SubconcepteTarifaPartida> SubconceptesPartida
        {
            get; set;
        }
        public ICollection<BlocTarifa> BlocsTarifa
        {
            get; set;
        }
    }
}
