using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities;
public class RequerimentOrdreTreball : BaseEntity
{
    public int OrdreTreballId
    {
        get; set;
    }
    public int TipusRequerimentOrdreTreballId
    {
        get; set;
    }

    public Boolean Fet
    {
        get; set;
    }
    public DateTime DataInici
    {
        get; set;
    }
    public DateTime DataFinal
    {
        get; set;
    }
    public string Observacions
    {
        get; set;
    }
}
