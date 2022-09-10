using UnityEngine;

namespace Script.Lesson_8.Memento
{
    public class PointInTime
    {
        public Vector3 Position;
        
        public PointInTime (Vector3 position)
        {
            Position = position;
        }
    }
}