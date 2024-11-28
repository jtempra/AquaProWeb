using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities;
public class Parametre : BaseEntity
{
    public string Descripcio { get; set; }
    public double? ValorNumeric { get; set; }
    public string? ValorString  { get; set; }
    public DateTime? ValorData  { get; set; }
    public string Observacions  {  get; set; }
}
