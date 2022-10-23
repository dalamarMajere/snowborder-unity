using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finishing
{
    public class GameEnd : MonoBehaviour
    {
        public event Action<GameResult> OnGameOver;

        [SerializeField] private float reloadDelay;
        
        private bool _isGameOver;
        private GameResult _gameResult;

        private const string GroundTag = "Ground";
        private const string FinishTag = "Finish";
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_isGameOver)
            {
                return;
            }
            
            if (col.CompareTag(GroundTag))
            {
                GameOver(GameResult.Lose);
                return;
            }

            if (col.CompareTag(FinishTag))
            {
                GameOver(GameResult.Win);
            }
        }

        private void GameOver(GameResult gameResult)
        {
            _isGameOver = true;
            OnGameOver?.Invoke(gameResult);
            Invoke(nameof(ReloadScene), reloadDelay);
        }

        private void ReloadScene()
        {
            if (_gameResult == GameResult.Lose)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
            
            SceneManager.LoadScene(Math.Min(SceneManager.sceneCountInBuildSettings - 1, SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}
