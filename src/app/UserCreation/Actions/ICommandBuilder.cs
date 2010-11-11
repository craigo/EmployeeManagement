namespace UserCreation.Actions
{
    public interface ICommandBuilder
    {
        T BuildCommand<T>() where T : ICommand, new();
    }
}