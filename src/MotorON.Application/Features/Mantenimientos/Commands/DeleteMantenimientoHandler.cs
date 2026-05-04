using MediatR;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.Mantenimientos.Commands;

public class DeleteMantenimientoHandler : IRequestHandler<DeleteMantenimientoCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMantenimientoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Mantenimientos.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null) return false;

        _unitOfWork.Mantenimientos.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
