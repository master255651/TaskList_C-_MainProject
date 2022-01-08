namespace TaskList.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TaskListDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
