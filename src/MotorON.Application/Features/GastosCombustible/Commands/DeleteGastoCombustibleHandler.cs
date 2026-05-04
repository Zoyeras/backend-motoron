using MediatR;
using MotorON.Domain.Interfaces;

namespace MotorON.Application.Features.GastosCombustible.Commands;

public class DeleteGastoCombustibleHandler : IRequestHandler<DeleteGastoCombustibleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGastoCombustibleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteGastoCombustibleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.GastosCombustible.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null) return false;

        _unitOfWork.GastosCombustible.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
