using System;
using MediatR;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class GetNotesListQuery : IRequest<NotesLookupListVM>
    {
        public Guid UserId { get; set; }
    }
}
