using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNote
{
    public class GetNoteQuery : IRequest<NoteVM>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
