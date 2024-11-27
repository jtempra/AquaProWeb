using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities;
public class FacturaCampanya : BaseEntity
{
    public int CampanyaId
    {
        get; set;
    }
    public int NumFactura
    {
        get; set;
    }
    public EstatFactura Estat
    {
        get; set;
    }
    public int SituacioFacturaId
    {
        get; set;
    }
    public SituacioFactura SituacioFactura
    {
        get; set;
    }
    public decimal Import { get; set; } = decimal.Zero;
    public decimal ImportDespeses { get; set; } = decimal.Zero;
    public decimal ImportCobrat { get; set; } = decimal.Zero;
}
