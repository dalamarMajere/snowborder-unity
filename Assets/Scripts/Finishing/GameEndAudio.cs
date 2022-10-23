using UnityEngine;

namespace Finishing
{
    [RequireComponent(typeof(GameEnd))]
    public class GameEndAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip winSFX;
        [SerializeField] private AudioClip loseSFX;
        
        private AudioSource _audioSource;
    
        private void Start()
        {
            AssignCallback();
            GetComponents();
        }

        private void OnDestroy()
        {
            UnassignCallback();
        }
        
        private void Play(GameResult gameResult)
        {
            if (gameResult == GameResult.Win)
            {
                _audioSource.PlayOneShot(winSFX);
            }
            else
            {
                _audioSource.PlayOneShot(loseSFX);
            }
        }

        private void AssignCallback()
        {
            GetComponent<GameEnd>().OnGameOver += Play;
        }
        
        private void UnassignCallback()
        {
            GetComponent<GameEnd>().OnGameOver -= Play;
        }

        private void GetComponents()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
