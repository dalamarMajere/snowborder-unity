using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
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

            yield return new WaitForSeconds(4);
        
            textMeshProUGUI.gameObject.SetActive(false);
        }
    }
}
