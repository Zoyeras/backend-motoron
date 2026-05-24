namespace MotorON.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int CurrentMileage { get; set; }
    public string? Placa { get; set; }
    public int? Cilindraje { get; set; }
    public string? Color { get; set; }
    public string? NumeroSerie { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
    public ICollection<GastoCombustible> GastosCombustible { get; set; } = new List<GastoCombustible>();
}
