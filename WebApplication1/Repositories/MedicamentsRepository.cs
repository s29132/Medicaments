using System.Data.SqlClient;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IMedicamentsRepository
{
    public IEnumerable<MedicamentDto> GetMedicaments(int id);
}

public class MedicamentsRepository : IMedicamentsRepository
{
    private readonly IConfiguration _configuration;

    public MedicamentsRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    public IEnumerable<MedicamentDto> GetMedicaments(int id)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var cmd = new SqlCommand(@"SELECT Medicament.IdMedicament, Dose, Details, Description, Name, Type, Date, DueDate
        FROM Prescription_Medicament
        INNER JOIN Medicament ON Prescription_Medicament.IdMedicament=Medicament.IdMedicament
        INNER JOIN Prescription ON Prescription.IdPrescription=Prescription_Medicament.IdPrescription
        WHERE Medicament.IdMedicament=@id
        ORDER BY Date DESC", con);
        cmd.Parameters.AddWithValue("@id", id);
        var reader = cmd.ExecuteReader();
        var medicaments = new List<MedicamentDto>();
        while (reader.Read())
        {
            var medicament = new MedicamentDto()
            {
                IdMedicament = (int)reader["Medicament.IdMedicament"],
                Dose = (int)reader["Dose"],
                Details = reader["Details"].ToString()!,
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString()! : "",
                Name = reader["Name"].ToString()!,
                Date = (DateTime)reader["Date"],
                DueTime = (DateTime)reader["DueDate"]
            };
            medicaments.Add(medicament);

            return medicaments;
        }
    }
}