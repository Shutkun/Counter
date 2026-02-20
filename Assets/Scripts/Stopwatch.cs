using System;
using System.Collections;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private StopwatchInput _stopwatchInput;

    private Coroutine _countdown;
    private bool _isRunning = false;
    private float _delay = 0.5f;

    public event Action<int> Сhanging;

    public int CurrentCount { get; private set; } = 0;

    private void OnEnable()
    {
        _stopwatchInput.Clicked += Start;
    }

    private void OnDisable()
    {
        _stopwatchInput.Clicked -= Start;

    }

    private void Start()
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

            Сhanging?.Invoke(CurrentCount);

            yield return wait;
        }
    }
}
