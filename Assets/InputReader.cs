using UnityEngine;
using System;
public class InputReader : MonoBehaviour
{
    public event Action InputDown;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            InputDown?.Invoke();
        }
    }
}
