using UnityEngine;
using System;
public class InputReader : MonoBehaviour
{
    private KeyCode _inputMouse1 = KeyCode.Mouse1;

    public event Action InputDown;
    private void Update()
    {
        if (Input.GetKeyDown(_inputMouse1))
        {
            InputDown?.Invoke();
        }
    }
}
