using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TextUpdater : MonoBehaviour
{
    private TextMeshProUGUI _counterText;
    private int _countAmount = 0;

    public void AddCount()
    {
        _countAmount++;
        UpdateCounterText();
    }

    private void Awake()
    {
        _counterText = GetComponent<TextMeshProUGUI>();
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        _counterText.text = $"—четчик: {_countAmount}";
    }
}
