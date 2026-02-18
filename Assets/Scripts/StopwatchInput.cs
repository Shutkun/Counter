using System;
using UnityEngine;

public class StopwatchInput : MonoBehaviour
{
    private int _mouseButton = 0;

    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            Clicked?.Invoke();
        }
    }
}
