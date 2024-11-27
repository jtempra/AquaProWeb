using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities;
public class DocumentCampanya : BaseEntity
{
    public int CampanyaId
    {
        get; set;
    }
    public TipusDocument TipusDocument
    {
        get;
        set;
    }
    public int? RebutId
    {
        get; set;
    }
    public Rebut Rebut
    {
        get; set;
    }
    public SituacioRebut SituacioRebut
    {
        get; set;
    }
    public int? FacturaId
    {
        get; set;
    }
    public Factura Factura
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
