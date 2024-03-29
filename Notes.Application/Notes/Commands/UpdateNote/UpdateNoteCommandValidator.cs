﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(i => i.UserId).NotEqual(Guid.Empty);
            RuleFor(note => note.Title).NotEmpty().MaximumLength(250);
            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
