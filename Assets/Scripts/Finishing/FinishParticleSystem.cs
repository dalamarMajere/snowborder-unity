using Player;
using UnityEditor;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(GameEnd))]
    public class FinishParticleSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem winParticleSystem;
        [SerializeField] private ParticleSystem loseParticleSystem;
        
        private void Start()
        {
            AssignCallback();
        }

        private void OnDestroy()
        {
            GetComponent<GameEnd>().OnGameOver -= PlayParticle;
        }
        
        private void AssignCallback()
        {
            GetComponent<GameEnd>().OnGameOver += PlayParticle;
        }
        
        private void PlayParticle(GameResult gameResult)
        {
            if (gameResult == GameResult.Win)
            {
                winParticleSystem.Play();
            }
            else
            {
                loseParticleSystem.Play();
            }
        }

    }
}