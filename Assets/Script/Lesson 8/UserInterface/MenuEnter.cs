using UnityEngine;

namespace Script.UserInterface
{
    public class MenuEnter: ICommand
    {
        private  GameObject _settingwindow;

        public bool Succeeded { get; private set; }


        public MenuEnter(GameObject settingwindow)
        {
            _settingwindow = settingwindow;
        }

        public bool TryExecute()
        {
            _settingwindow.SetActive(true);
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
            _settingwindow.SetActive(false);
        }
    }
}