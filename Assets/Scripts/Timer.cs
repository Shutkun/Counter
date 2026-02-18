using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerInput _timerInput;

    private Coroutine _countdown;
    private bool _isRunning = false;
    private float _delay = 0.5f;

    public event Action<int> TimerСhange;

    public int CurrentCount { get; private set; } = 0;

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
        else
        {
            StopCoroutine(_countdown);
            _countdown = null;
        }
    }

    private IEnumerator Countdown()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isRunning)
        {
            CurrentCount++;

            TimerСhange?.Invoke(CurrentCount);

            yield return wait;
        }
    }
}
