using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float reloadDelay;
    
    private const string GroundTag = "Ground";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GroundTag))
        {
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }
    
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
