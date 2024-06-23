using System;
using UnityEngine;

namespace Kitchen.Appliances
{
    public class StoveManager : MonoBehaviour
    {
        [SerializeField] private Stove stove;
        [SerializeField] private ParticleSystem smokeParticles;

        private void Awake()
        {
            stove = gameObject.GetComponent<Stove>();
         }

        private void Start()
        {
            stove.OnStoveTurnedOn += OnStoveTurnedOn;
            stove.OnStoveTurnedOff += OnStoveTurnedOff;
        }

        private void OnStoveTurnedOff()
        {
            smokeParticles.Stop();
        }

        private void OnStoveTurnedOn()
        {
            smokeParticles.Play();
        }
    }
}
