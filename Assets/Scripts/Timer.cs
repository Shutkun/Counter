using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerInput _timerInput;

    public int currentCount = 0;

    private Coroutine _countdown;
    private bool _isRunning = false;
    private float _delay = 0.5f;

    public event Action <int> TimerActiv;

    private void OnEnable()
    {
        _timerInput.InputAction += StartTimer;
    }

    private void OnDisable()
    {
        _timerInput.InputAction -= StartTimer;

    }

    private void StartTimer()
    {
        _isRunning = !_isRunning;

        if (_isRunning && _countdown == null)
        {
            _countdown = StartCoroutine(Countdown());
        }

        TimerActiv?.Invoke(currentCount);
    }

    private IEnumerator Countdown()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            if (_isRunning)
            {
                currentCount++;
            }

            yield return wait;
        }
    }
}
