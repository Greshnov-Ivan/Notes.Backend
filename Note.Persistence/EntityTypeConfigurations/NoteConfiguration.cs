using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Разделяем конфигурацию для типа сущности на отдельный класс
    /// вместо метода OnModelCreating нашего Db context
    /// </summary>
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        /// <summary>
        /// Конфигурация для типа сущности
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
