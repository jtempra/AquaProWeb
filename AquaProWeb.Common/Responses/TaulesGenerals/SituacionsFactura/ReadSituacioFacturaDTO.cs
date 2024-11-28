using AquaProWeb.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura
{
	public class ReadSituacioFacturaDTO
	{
		public int Id { get; set; }
		public EstatFactura Estat { get; set; }
		public string Situacio { get; set; }
		public string Descripcio { get; set; }
		public string Observacions { get; set; }
	}
}
