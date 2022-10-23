using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private float secondsToShowText;
    
    private TextMeshProUGUI[] tutorials;
    
    private void Start()
    {
        tutorials = GetComponentsInChildren<TextMeshProUGUI>();
        
        DisableAll();

        StartTutorial();
    }

    private void DisableAll()
    {
        foreach (var textMeshProUGUI in tutorials)
        {
            textMeshProUGUI.gameObject.SetActive(false);
        }
    }

    private void StartTutorial()
    {
        StartCoroutine(ShowText());
        
    }

    private IEnumerator ShowText()
    {
        foreach (var textMeshProUGUI in tutorials)
        {
            textMeshProUGUI.gameObject.SetActive(true);

            yield return new WaitForSeconds(secondsToShowText);
        
            textMeshProUGUI.gameObject.SetActive(false);
        }
    }
}
