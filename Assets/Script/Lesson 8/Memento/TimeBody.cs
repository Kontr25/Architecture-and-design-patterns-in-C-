using System.Collections.Generic;
using UnityEngine;

namespace Script.Lesson_8.Memento
{
    public class TimeBody : MonoBehaviour
    {
        [SerializeField] private float _recordTime = 5f;
        private List<PointInTime> _pointsInTime;
        private bool _isRewinding;
        private void Start ()
        {
            _pointsInTime = new List<PointInTime>();
        }
        private void Update ()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                StopRewind();
            }
        }
        private void FixedUpdate ()
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }
        private void Rewind ()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                transform.position = pointInTime.Position;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                transform.position = pointInTime.Position;
                StopRewind();
            }
        }
        private void Record ()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime /
                                                  Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }
            _pointsInTime.Insert(0, new PointInTime(transform.position));
        }
        
        private void StartRewind (){
            _isRewinding = true;
        }
        private void StopRewind ()
        {
            _isRewinding = false;
        }
    }
}