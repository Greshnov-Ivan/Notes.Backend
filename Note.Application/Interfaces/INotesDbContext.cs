using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Interfaces
{
    public interface INotesDbContext
    {
        /// <summary>
        /// Коллекция всех сущностей в контексте
        /// </summary>
        DbSet<Note> Notes { get; set; }
        /// <summary>
        /// Сохранить изменение контекста в БД
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
