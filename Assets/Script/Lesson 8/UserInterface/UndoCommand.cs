using System.Collections.Generic;

namespace Script.UserInterface
{
    public class UndoCommand : ICommand
    {
        // jTODO maybe use stack?
        private readonly List<ICommand> _commands;

        public bool Succeeded { get; private set; }

        public UndoCommand(List<ICommand> commands)
        {
            _commands = commands;
        }

        public bool TryExecute()
        {
            if (_commands.Count > 0)
            {
                ICommand latestCommand = _commands[_commands.Count - 1];
                if (latestCommand.Succeeded)
                {
                    latestCommand.Undo();

                    _commands.RemoveAt(_commands.Count - 1);
                    Succeeded = true;
                }
            }

            Succeeded = false;
            return Succeeded;
        }

        public void Undo()
        {
        }
    }
}