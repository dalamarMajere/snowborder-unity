using UnityEngine;

namespace Effects
{
    public class SnowTrailEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem snowParticles;

        private const string GroundTag = "Ground";

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (IsGround(col))
            {
                snowParticles.Play();
            }
        }
    
        private void OnCollisionExit2D(Collision2D col)
        {
            if (IsGround(col))
            {
                snowParticles.Stop();
            }
        }

        private static bool IsGround(Collision2D col)
        {
            return col.gameObject.CompareTag(GroundTag);
        }
    }
}