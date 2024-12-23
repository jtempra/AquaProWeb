using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaProWeb.Common.Requests.TaulesGenerals.RutaLectura
{
	public class SaveRutaLecturaDTO
	{
		public int Id { get; set; }
		public string Ruta { get; set; }
		public string Descripcio { get; set; }
		public string Observacions { get; set; }
	}
}
