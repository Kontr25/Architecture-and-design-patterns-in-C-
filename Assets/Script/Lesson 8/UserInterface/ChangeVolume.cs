using UnityEngine;

namespace Script.UserInterface
{
    public class ChangeVolume: ICommand
    {
        private  GameObject _volumeOn;
        private AudioListener _audioListener;

        public bool Succeeded { get; private set; }


        public ChangeVolume(GameObject volumeOn, AudioListener audioListener)
        {
            _volumeOn = volumeOn;
            _audioListener = audioListener;
        }

        public bool TryExecute()
        {
            if (_volumeOn.activeInHierarchy)
            {
                _volumeOn.SetActive(false);
                _audioListener.enabled = false;
            }
            else
            {
                _volumeOn.SetActive(true);
                _audioListener.enabled = true;
            }
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
            if (_volumeOn.activeInHierarchy)
            {
                _volumeOn.SetActive(false);
                _audioListener.enabled = false;
            }
            else
            {
                _volumeOn.SetActive(true);
                _audioListener.enabled = true;
            }
        }
    }
}