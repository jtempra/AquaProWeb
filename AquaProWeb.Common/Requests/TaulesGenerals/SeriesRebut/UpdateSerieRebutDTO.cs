﻿namespace AquaProWeb.Common.Requests.TaulesGenerals.SeriesRebut
{
    public class UpdateSerieRebutDTO
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public int Comptador { get; set; } = 1;
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string Descripcio { get; set; }
        public string Observacions { get; set; }
    }
}
