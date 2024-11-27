using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities;
public class RebutCampanya : BaseEntity
{
    public int CampanyaId
    {
        get; set;
    }
    public int NumRebut
    {
        get; set;
    }
    public EstatRebut Estat
    {
        get; set;
    }
    public int SituacioRebutId
    {
        get; set;
    }
    public SituacioRebut SituacioRebut
    {
        get; set;
    }
    public decimal Import { get; set; } = decimal.Zero;
    public decimal ImportDespeses { get; set; } = decimal.Zero;
    public decimal ImportCobrat { get; set; } = decimal.Zero;
}
