using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities;
public class IncidenciaCreacioLectura : BaseEntity
{
    public int ContracteId
    {
        get; set;
    }
    public int Periode
    {
        get; set;
    }
    public TipusIncidenciaCreacioLectura TipusIncidencia
    {
        get; set;
    }
    public DateTime DataIncidencia
    {
        get; set;
    }
}
