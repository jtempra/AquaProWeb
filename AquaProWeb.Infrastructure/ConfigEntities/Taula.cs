namespace AquaProWeb.Infrastructure.ConfigEntities;

public class Taula
{
    public int Id
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
    public string Observacions
    {
        get; set;
    }
    public string Simbol
    {
        get; set;
    }
    public virtual ICollection<Columna> Columnes
    {
        get; set;
    }

}
