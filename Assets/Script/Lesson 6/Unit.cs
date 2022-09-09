namespace Script.Lesson_6
{
    public class Unit
    {
        [Newtonsoft.Json.JsonProperty("type")]
        public float Health;
        
        [Newtonsoft.Json.JsonProperty("health")]
        public UnitType Type;
        public enum UnitType
        {
            mage,
            infantry
        }
        public Unit(float health, UnitType type)
        {
            this.Health = health;
            this.Type = type;
        }
    }
}