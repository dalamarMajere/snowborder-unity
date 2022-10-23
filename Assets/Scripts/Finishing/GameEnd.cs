using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Finishing
{
    public enum GameResult
    {
        Win, 
        Lose
    }
    
    public class GameEnd : MonoBehaviour
    {
        public event Action<GameResult> OnGameOver;

        [SerializeField] private float reloadDelay;
        
        private bool isGameOver;
        private GameResult _gameResult;

        private const string GroundTag = "Ground";
        private const string FinishTag = "Finish";
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (isGameOver)
            {
                return;
            }
            
            if (col.CompareTag(GroundTag))
            {
                GameOver(GameResult.Lose);
            }

            if (col.CompareTag(FinishTag))
            {
                GameOver(GameResult.Win);
            }
        }

        private void GameOver(GameResult gameResult)
        {
            OnGameOver?.Invoke(gameResult);
            isGameOver = true;
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
