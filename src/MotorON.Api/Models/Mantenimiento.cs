namespace MotorON.Api.Models;

public class Mantenimiento
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Tipo { get; set; } = string.Empty;
    public int Kilometraje { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Costo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
}
