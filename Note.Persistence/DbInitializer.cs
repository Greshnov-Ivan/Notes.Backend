namespace Notes.Persistence
{
    public class DbInitializer
    {
        /// <summary>
        /// Проверить, создана ли БД и если нет - создать на основе контекста
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
