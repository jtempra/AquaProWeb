using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaProWeb.Common.Responses.Parametres
{
	public class ReadParametreDTO
	{
		public int Id { get; set; }
		public string Descripcio { get; set; }
		public double? ValorNumeric { get; set; }
		public string? ValorString { get; set; }
		public DateTime? ValorData { get; set; }
		public string Observacions { get; set; }
	}
}
