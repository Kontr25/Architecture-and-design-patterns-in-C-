using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.UserInterface
{
    public class SettingsHandler: MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private GameObject _soundWindow;
        [SerializeField] private GameObject _volumeOn;
        [SerializeField] private AudioListener _audioListener;
        
        private ICommand _menuEnter;
        private ICommand _soundWindowEnter;
        private ICommand _changeVolume;
        private ICommand _buttonQ;

        private readonly List<ICommand> _oldCommands = new List<ICommand>();

        private void Start()
        {
            _menuEnter = new MenuEnter(_menu);
            _soundWindowEnter = new SoundSettingEnter(_soundWindow);
            _changeVolume = new ChangeVolume(_volumeOn, _audioListener);
            _buttonQ = new UndoCommand(_oldCommands);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _buttonQ.TryExecute();
            }
        }

        public void MenuEnter()
        {
            if (_menuEnter.TryExecute())
            {
                _oldCommands.Add(_menuEnter);
            }
        }
        
        public void SoundSettingsEnter()
        {
            if (_soundWindowEnter.TryExecute())
            {
                _oldCommands.Add(_soundWindowEnter);
            }
        }
        
        public void ChangeVolume()
        {
            if (_changeVolume.TryExecute())
            {
                _oldCommands.Add(_changeVolume);
            }
        }
    }
}