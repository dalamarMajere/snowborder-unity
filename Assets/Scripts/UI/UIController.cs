using System.Collections;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private float secondsToShowText;
    
    private TextMeshProUGUI[] _tutorials;
    
    private void Start()
    {
        _tutorials = GetComponentsInChildren<TextMeshProUGUI>();
        
        DisableAll();

        StartTutorial();
    }

    private void DisableAll()
    {
        foreach (var textMeshProUGUI in _tutorials)
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
        foreach (var textMeshProUGUI in _tutorials)
        {
            EnableText(textMeshProUGUI);

            yield return new WaitForSeconds(secondsToShowText);
        
            DisableText(textMeshProUGUI);
        }
    }

    private void EnableText(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.gameObject.SetActive(true);
    }
    
    private static void DisableText(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.gameObject.SetActive(false);
    }
}
