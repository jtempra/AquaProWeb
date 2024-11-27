namespace AquaProWeb.Infrastructure.ConfigEntities;
public class Enumeracio
{
    public int Id
    {
        get;
        set;
    }

    public string Descripcio
    {
        get;
        set;
    }

    public virtual ICollection<ValorEnumeracio> Valors
    {
        get; set;
    }
}
