using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Carrer : BaseEntity
    {
        public string Nom
        {
            get; set;
        }
        public string CodiPostal
        {
            get; set;
        }
        public string Observacions
        {
            get; set;
        }
        public int PoblacioId
        {
            get; set;
        }
        public Poblacio Poblacio
        {
            get; set;
        }
        public int ZonaCarrersId
        {
            get; set;
        }
        public ZonaCarrers Zona
        {
            get; set;
        }
        public int TipusViaId
        {
            get; set;
        }
        public TipusVia TipusVia
        {
            get; set;
        }
        public CategoriaVia CategoriaVia
        {
            get; set;
        }
    }
}
