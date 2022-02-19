using MediatR;
using System;

namespace Notes.Application.Notes.Commands.CreateNote
{
    /// <summary>
    /// Необходимые данные для создания заметки
    /// </summary>
    public class CreateNoteCommand : IRequest<Guid> // Помечает результат выполнения команды и возвращает результат определённого типа
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
