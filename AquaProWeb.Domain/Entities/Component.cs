using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities;
public class Component : BaseEntity
{
    public string Codi
    {
        get; set;
    }
    public string Nom
    {
        get; set;
    }
    public string Descripcio
    {
        get; set;
    }

    public string? Observacions
    {
        get; set;
    }

}
