using UnityEngine;

namespace Script.UserInterface
{
    public class SoundSettingEnter: ICommand
    {
        private  GameObject _soundwindow;

        public bool Succeeded { get; private set; }


        public SoundSettingEnter(GameObject soundwindow)
        {
            _soundwindow = soundwindow;
        }

        public bool TryExecute()
        {
            _soundwindow.SetActive(true);
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
            _soundwindow.SetActive(false);
        }
    }
}