﻿namespace WebApplication1.Models;

public class Prescription
{
    public int? IdPrescription { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueTime { get; set; }
    public int? IdPatient { get; set; }
    public int? IdDoctor { get; set; }
}