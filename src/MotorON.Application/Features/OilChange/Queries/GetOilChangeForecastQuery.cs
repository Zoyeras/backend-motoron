using MediatR;
using MotorON.Application.DTOs;

namespace MotorON.Application.Features.OilChange.Queries;

public record GetOilChangeForecastQuery : IRequest<OilChangeForecastDto>;
