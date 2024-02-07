using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INoteDbContext _db;
        public DeleteNoteCommandHandler(INoteDbContext context) => _db = context;

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _db.Notes.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);

            //по сути возвращаем пустое значение like void
            return Unit.Value;
        }
    }
}
