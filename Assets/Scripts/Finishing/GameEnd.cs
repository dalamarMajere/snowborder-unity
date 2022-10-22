using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Variables;

namespace Effects
{
    public enum GameResult
    {
        Win, 
        Lose
    }
    
    public class GameEnd : MonoBehaviour
    {
        public event Action<GameResult> OnGameOver;

        [SerializeField] private GameResult gameResult;
        
        [SerializeField] private float reloadDelay;
        [SerializeField] private string checkingTag;

        private bool isGameOver;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(checkingTag) && !isGameOver)
            {
                OnGameOver?.Invoke(gameResult);
                isGameOver = true;
                Invoke(nameof(ReloadScene), reloadDelay);
            }
        }


        private void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
