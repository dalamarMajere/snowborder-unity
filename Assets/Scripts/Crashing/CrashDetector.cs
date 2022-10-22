using System;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using Variables;

namespace Player
{
    public class CrashDetector : MonoBehaviour
    {
        public event Action OnCrashed;
        
        [SerializeField] private float reloadDelay;
        [SerializeField] private BooleanVariable isGameOverVariable;

        private const string GroundTag = "Ground";

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(GroundTag) && !isGameOverVariable.Value)
            {
                MarkGameAsOver();
                OnCrashed?.Invoke();
                Invoke(nameof(ReloadScene), reloadDelay);
            }
        }

        private void MarkGameAsOver()
        {
            isGameOverVariable.Value = true;
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
