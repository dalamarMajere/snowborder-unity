using Player;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(CrashDetector))]
    public class CrashParticleSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem crashParticleSystem;
        
        private void Start()
        {
            AssignCallback();
        }

        private void OnDestroy()
        {
            GetComponent<CrashDetector>().OnCrashed -= PlayParticle;
        }
        
        private void AssignCallback()
        {
            GetComponent<CrashDetector>().OnCrashed += PlayParticle;
        }
        
        private void PlayParticle()
        {
            crashParticleSystem.Play();
        }

    }
}