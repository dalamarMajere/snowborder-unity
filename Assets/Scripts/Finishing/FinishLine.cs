using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Variables;

namespace Effects
{
    public class FinishLine : MonoBehaviour
    {
        public event Action OnFinished;
        
        [SerializeField] private float reloadDelay;
        [SerializeField] private BooleanVariable isGameOverVariable;
    
        private const string PlayerTag = "Player";
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(PlayerTag) && !isGameOverVariable.Value)
            {
                OnFinished?.Invoke();
                MakeGameOver();
                Invoke(nameof(ReloadScene), reloadDelay);
            }
        }

        private void MakeGameOver()
        {
            isGameOverVariable.Value = true;
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
