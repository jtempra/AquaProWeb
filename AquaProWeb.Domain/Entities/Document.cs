using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Document : BaseEntity
    {
        public int IdDocument
        {
            get; set;
        }
        public int ContracteId
        {
            get; set;
        }
        public Contracte Contracte
        {
            get; set;
        }
        public string? AutorCreacio
        {
            get; set;
        }
        public DateTime? DataCreacio
        {
            get; set;
        }
        public string? AutorModificacio
        {
            get; set;
        }
        public DateTime? DataModificacio
        {
            get; set;
        }
        public string Descripcio
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
        public string Ruta
        {
            get; set;
        }
        public int TipusDocumentId
        {
            get; set;
        }
        public TipusDocument Tipus
        {
            get; set;
        }
        public TipusDocumentAssociat? AssociatA
        {
            get; set;
        }
        public int? DocumentAssociatId
        {
            get; set;
        }
    }
}
