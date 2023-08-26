namespace RESTDemo.Models.Internal;

public record PatientAdress
{
    public int Id { get; set; } = 0;
    public string Street { get; set; } = "";
    public string Nr { get; set; } = "";
    public string Plz { get; set; } = "";
    public string City { get; set; } = "";
}