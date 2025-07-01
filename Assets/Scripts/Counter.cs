using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using UnityEditor.Timeline.Actions;

public class Counter : MonoBehaviour
{
    private const float IntervalInSeconds = 0.5f;

    [SerializeField] private InputActionReference clickAction;

    private TextMeshProUGUI counterText; 
    private int countAmount = 0;
    private bool isCounting = false;
    private Coroutine countingCoroutine;

    private void Awake()
    {
        counterText = GetComponent<TextMeshProUGUI>(); 
        InitializeInputSystem();
        UpdateCounterText(); 
    }

    private void InitializeInputSystem()
    {
        clickAction.action.performed += ToggleCounting;
        clickAction.action.Enable();
    }

    private void ToggleCounting(InputAction.CallbackContext context)
    {
        if (isCounting)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    private void StartCounting()
    {
        isCounting = true;
        countingCoroutine = StartCoroutine(CountEveryHalfSecond());
    }

    private void StopCounting()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }

        isCounting = false;
    }

    private IEnumerator CountEveryHalfSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(IntervalInSeconds);
            countAmount++;
            UpdateCounterText();
        }
    }

    private void UpdateCounterText()
    {
        counterText.text = $"—четчик: {countAmount}";
    }
}