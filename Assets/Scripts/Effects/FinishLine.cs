using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Effects
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private float reloadDelay;
        [SerializeField] private ParticleSystem finishParticleSystem;
        [SerializeField] private FinishLineAudio finishLineAudio;
    
        private const string PlayerTag = "Player";
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(PlayerTag))
            {
                finishParticleSystem.Play();
                finishLineAudio.Play();
                Invoke(nameof(ReloadScene), reloadDelay);
            }
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
