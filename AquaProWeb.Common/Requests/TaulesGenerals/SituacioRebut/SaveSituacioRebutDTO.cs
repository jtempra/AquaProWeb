using AquaProWeb.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaProWeb.Common.Requests.TaulesGenerals.SituacioRebut
{
	public class SaveSituacioRebutDTO
	{
		public int Id { get; set; }
		public EstatRebut Estat { get; set; }
		public string Situacio { get; set; }
		public string Descripcio { get; set; }
		public string Observacions { get; set; }
	}
}
