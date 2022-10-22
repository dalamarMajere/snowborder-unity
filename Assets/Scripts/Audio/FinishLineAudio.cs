using UnityEngine;

namespace Audio
{
    public class FinishLineAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource finishAudioSource;
    
        public void Play()
        {
            finishAudioSource.Play();
        }
    }
}
