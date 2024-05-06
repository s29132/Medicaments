namespace WebApplication1.Dto;

public class MedicamentDto
{
    public int? IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string? Details { get; set; }
    public string? Description { get; set; }
    public string? Name { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueTime { get; set; }
}