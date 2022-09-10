namespace Script.UserInterface
{
    public class DoNothing : ICommand
    {
        public bool Succeeded { get; private set; }


        public bool TryExecute()
        {
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
        }
    }
}