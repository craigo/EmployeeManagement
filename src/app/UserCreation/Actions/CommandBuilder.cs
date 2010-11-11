namespace UserCreation.Actions
{
    public class CommandBuilder : ICommandBuilder
    {
        public T BuildCommand<T>() where T : ICommand, new()
        {
            return new T();
        }
    }
}