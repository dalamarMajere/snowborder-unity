using Effects;
using Unity.VisualScripting;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(FinishLine))]
    public class FinishLineAudio : MonoBehaviour
    {
        private AudioSource _finishAudioSource;
    
        private void Start()
        {
            AssignCallback();
            GetComponents();
        }

        private void OnDestroy()
        {
            GetComponent<FinishLine>().OnFinished -= Play;
        }

        private void AssignCallback()
        {
            GetComponent<FinishLine>().OnFinished += Play;
        }

        private void GetComponents()
        {
            _finishAudioSource = GetComponent<AudioSource>();
        }
        
        private void Play()
        {
            _finishAudioSource.Play();
        }
    }
}
