using System;
using UnityEngine;

public class TimerInput : MonoBehaviour
{
    private int _mouseButton = 0;

    public event Action InputAction;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            InputAction?.Invoke();
        }
    }
}
