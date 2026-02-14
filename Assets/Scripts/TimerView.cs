using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;


    private void Start()
    {
        _text.text = _timer.currentCount.ToString();
    }

    private void Update()
    {
        DisplayCountdown(_timer.currentCount);
    }

    private void OnEnable()
    {
        _timer.TimerActiv += DisplayCountdown;
    }

    private void OnDisable()
    {
        _timer.TimerActiv -= DisplayCountdown;
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }
}
