namespace Script.UserInterface
{
    public interface ICommand
    {
        bool Succeeded { get; }

        bool TryExecute();

        void Undo();
    }
}