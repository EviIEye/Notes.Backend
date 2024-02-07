using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(D => D.Id).NotEqual(Guid.Empty);
            RuleFor(U => U.UserId).NotEqual(Guid.Empty);
        }
    }
}
