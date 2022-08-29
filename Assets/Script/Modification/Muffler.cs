using Asteroids;
using UnityEngine;
using DG.Tweening;

namespace Script.Modification
{
    public class Muffler: IMuffler
    {
        public AudioSource AudioSourceMuffler { get; }
        public Transform BarrelPositionMuffler { get; }
        public GameObject MufflerInstance { get; }
        public Muffler(AudioSource audioSourceMuffler,
            Transform barrelPositionMuffler, GameObject mufflerInstance)
        {
            AudioSourceMuffler = audioSourceMuffler;
            BarrelPositionMuffler = barrelPositionMuffler;
            MufflerInstance = mufflerInstance;
        }

    }
}