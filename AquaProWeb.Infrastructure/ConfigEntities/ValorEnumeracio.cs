namespace AquaProWeb.Infrastructure.ConfigEntities;
public class ValorEnumeracio
{
    public int Id
    {
        get;
        set;
    }

    public int Valor
    {
        get;
        set;
    }

    public string Descripcio
    {
        get;
        set;
    }

    public Enumeracio Enumeracio
    {
        get;
        set;
    }

    public int EnumeracioId
    {
        get;
        set;
    }
}
