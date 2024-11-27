namespace AquaProWeb.Infrastructure.ConfigEntities;

public class Columna
{
    public int Id
    {
        get; set;
    }
    public string Propietat
    {
        get; set;
    }
    public string Capçalera
    {
        get; set;
    }
    public string Descripcio
    {
        get; set;
    }
    public TipusColumna TipusColumna
    {
        get; set;
    }
    public int Amplada
    {
        get; set;
    }
    public Boolean Visible
    {
        get; set;
    }
    public Taula Taula
    {
        get; set;
    }
    public int TaulaId
    {
        get; set;
    }

    public int Ordre
    {
        get; set;
    }

    public int? TaulaComboId
    {
        get;
        set;
    }
    public int? ColumnaComboId
    {
        get;
        set;
    }
    public int? EnumeracioId
    {
        get;
        set;
    }
}
