using Effects;
using Player;
using UnityEngine;

namespace Finishing
{
    [RequireComponent(typeof(FinishLine))]
    public class FinishLineParticleSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem finishParticleSystem;
        
        private void Start()
        {
            AssignCallback();
        }

        private void OnDestroy()
        {
            GetComponent<FinishLine>().OnFinished -= PlayParticle;
        }
        
        private void AssignCallback()
        {
            GetComponent<FinishLine>().OnFinished += PlayParticle;
        }
        
        private void PlayParticle()
        {
            finishParticleSystem.Play();
        }
    }
}