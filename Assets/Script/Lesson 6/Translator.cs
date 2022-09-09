using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Lesson_6
{
    public class Translator : MonoBehaviour
    {
        private string _word;

        [Header("Приветствие/прощание на русском")] [SerializeField]
        private string _wordInRussia;

        private void Start()
        {
            Word = _wordInRussia;
            Debug.Log(Word);
        }

        public string Word
        {
            get
            {
                return _word;
            }

            set
            {
                _word = inEnglish[value];
            }
        }

        public Dictionary<string, string> inEnglish = new Dictionary<string, string>
        {
            ["Привет"] = "Hi",
            ["Пока"] = "Bye",
            ["Здравствуйте"] = "Hello",
            ["Досвидания"] = "Good bye",
            ["Доброе утро"] = "Good morning",
            ["Добрый день"] = "Good afternoon",
            ["Добрый вечер"] = "Good evening",
            ["Доброй ночи"] = "Good night",
        };
    }
}
