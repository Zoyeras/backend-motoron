namespace MotorON.Domain.Entities;

public class GastoCombustible
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid VehicleId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Litros { get; set; }
    public decimal Costo { get; set; }
    public int Kilometraje { get; set; }
    public decimal PrecioPorLitro => Litros <= 0 ? 0 : Math.Round(Costo / Litros, 2);
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

    // Navigation property
    public Vehicle Vehicle { get; set; } = null!;
}
