using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(TextUpdater))]
public class Counter : MonoBehaviour
{
    private const float IntervalInSeconds = 0.5f;

    [SerializeField] private InputActionReference _clickAction;
    [SerializeField] private TextUpdater _textUpdater;

    private bool _isCounting = false;
    private Coroutine _countingCoroutine;

    private void Awake()
    {
        InitializeInputSystem();
    }

    private void InitializeInputSystem()
    {
        _clickAction.action.performed += ToggleCounting;
        _clickAction.action.Enable();
    }

    private void ToggleCounting(InputAction.CallbackContext context)
    {
        if (_isCounting)
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
        _isCounting = true;
        _countingCoroutine = StartCoroutine(CountEveryHalfSecond());
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }

        _isCounting = false;
    }

    private IEnumerator CountEveryHalfSecond()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(IntervalInSeconds);
        while (_isCounting)
        {
            yield return waitForSeconds;
            _textUpdater.AddCount();
        }
    }
}