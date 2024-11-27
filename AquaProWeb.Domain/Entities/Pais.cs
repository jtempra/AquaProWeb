using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities;
public class Pais : BaseEntity
{
    public string Codi
    {
        get; set;
    }
    public string NomPais
    {
        get; set;
    }
    public string Observacions { get; set; } = string.Empty;
}
