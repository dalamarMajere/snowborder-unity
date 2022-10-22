using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float reloadDelay;
    [SerializeField] private ParticleSystem crashParticleSystem;
    
    private const string GroundTag = "Ground";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GroundTag))
        {
            crashParticleSystem.Play();
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }
    
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
