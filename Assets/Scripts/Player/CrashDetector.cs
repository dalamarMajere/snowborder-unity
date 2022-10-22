using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class CrashDetector : MonoBehaviour
    {
        [SerializeField] private float reloadDelay;
        [SerializeField] private ParticleSystem crashParticleSystem;
        [SerializeField] private AudioClip crashSFX;

        private AudioSource _audioSource;
        private const string GroundTag = "Ground";

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(GroundTag))
            {
                crashParticleSystem.Play();
                _audioSource.PlayOneShot(crashSFX);
                Invoke(nameof(ReloadScene), reloadDelay);
            }
        }
    
        private void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
