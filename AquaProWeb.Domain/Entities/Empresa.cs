﻿using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Empresa : BaseEntity
    {
        public string NomEmpresa { get; set; }
        public string CIF { get; set; }
        public string Direccio { get; set; }
        public string CP { get; set; }
        public string Poblacio { get; set; }
        public string Provincia { get; set; }
        public string Telefon { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }
        public string WWW { get; set; }
        public string Observacions { get; set; }
        public string NomCurtEmpresa { get; set; }
        public ICollection<SubconcepteTarifa> SubconceptesTarifa { get; set; }
    }
}
