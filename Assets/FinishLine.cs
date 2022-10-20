using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay;
    
    private const string PlayerTag = "Player";
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(PlayerTag))
        {
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
