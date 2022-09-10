using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Lesson_8
{
    public class InterpreterPoint: MonoBehaviour
    {
        public static Action<float> KillPoint;
        
        private string[] names = { "", "K", "M", "B", "T" };

        private float _currentPoint;
        
        [SerializeField] private TMP_Text _points;

        private void Start()
        {
            KillPoint += PointUp;
        }

        private void OnDestroy()
        {
            KillPoint = null;
        }

        public void PointUp(float value)
        {
            _currentPoint += value;
            _points.text = FormatPoint(_currentPoint);
        }

        public string FormatPoint(float number)
        {
            if (number >= 1000 && number <= 1000000) return (RoundedNumber(number, 1000).ToString() + "K");
            if (number >= 1000000 && number <= 1000000000) return (RoundedNumber(number, 1000000).ToString() + "M");
            
            return string.Empty;
        }

        private float RoundedNumber(float number, int divideNumber)
        {
            return Mathf.Round(number/divideNumber);
        }
    }
}