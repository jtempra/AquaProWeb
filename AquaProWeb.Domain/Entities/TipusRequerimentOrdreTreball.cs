using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities;
public class TipusRequerimentOrdreTreball : BaseEntity
{
    public string Requeriment
    {
        get; set;
    }
    public string Observacions
    {
        get; set;
    }
    public Boolean Administratiu
    {
        get; set;
    }
}
