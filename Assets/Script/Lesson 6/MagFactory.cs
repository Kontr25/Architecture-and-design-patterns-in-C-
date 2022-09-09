using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Script.Lesson_6
{
    public class MagFactory: MonoBehaviour, IUnitCreator
    {
        public void CreateUnit()
        {
            var text = File.ReadAllText(@"Assets\Script\Lesson 6\unit.json");
            var Type = Newtonsoft.Json.JsonConvert.DeserializeObject<Unit.UnitType>(text);
            var Health = Newtonsoft.Json.JsonConvert.DeserializeObject<float>(text);
            Unit Mage = new Unit(Health ,Type);
            Debug.Log("hp " + Mage.Health + " type " + Mage.Type);
        }

        private void Start()
        {
            CreateUnit();
        }
    }
}