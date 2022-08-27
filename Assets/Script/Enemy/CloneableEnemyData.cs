using System;

namespace Script.Enemy
{
    public class CloneableEnemyData: ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}