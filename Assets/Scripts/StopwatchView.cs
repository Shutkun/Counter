using TMPro;
using UnityEngine;

public class StopwatchView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Stopwatch _stopwatch;


    private void Start()
    {
        DisplayCountdown(_stopwatch.CurrentCount);
    }

    private void OnEnable()
    {
        _stopwatch.StopwatchСhanging += DisplayCountdown;
    }

    private void OnDisable()
    {
        _stopwatch.StopwatchСhanging -= DisplayCountdown;
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }
}
