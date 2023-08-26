namespace RESTDemo.Models.Internal;

public record Patient
{
    public int Id { get; set; } = 0;
    public string LastName { get; set; } = "";
    public string Firstname { get; set; } = "";
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public List<PatientAdress> PatientAdresses { get; set; } = new List<PatientAdress>();
}