using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;


    private void Start()
    {
        DisplayCountdown(_timer.CurrentCount);
    }

    private void OnEnable()
    {
        _timer.TimerСhange += DisplayCountdown;
    }

    private void OnDisable()
    {
        _timer.TimerСhange -= DisplayCountdown;
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }
}
