using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    /// <summary>
    /// Обработчик создания команды
    /// Содержит логику создания заметки
    /// </summary>
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid> // тип запроса и тип ответа
    {
        // Понадобится контекст для сохранения изменений в базу
        private readonly INotesDbContext _dbContext;
        
        public CreateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        /// <summary>
        /// Логика обработки команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            // Формируем заметку
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                Content = request.Content,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.UtcNow,
                EditDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Возвращаем её Id
            return note.Id;
        }
    }
}
