using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities;
public class CartaCampanya : BaseEntity
{
    public int CampanyaId
    {
        get; set;
    }

    public Campanya Campanya
    {
        get; set;
    }

    public int ContracteId
    {
        get; set;
    }

    public Contracte Contracte
    {
        get; set;
    }

    public string RutaCarta
    {
        get; set;
    }

    public string? Descripcio
    {
        get; set;
    }

    public string? Observacions
    {
        get; set;
    }
}
