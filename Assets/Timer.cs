using System.Collections;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;
    
    public event Action CountChanged;
    private float _elapsedTime = 0.5f;
    private int _counter = 0;
    private bool _isCounting;
    private Coroutine _coroutine;
    
    public int Counter => _counter;
    
    private void OnEnable()
    {
        _inputReader.InputDown += TogleTimer;
    }

    private void OnDisable()
    {
        _inputReader.InputDown -= TogleTimer;
    }
    
    
    private void TogleTimer()
    {
        if (!_isCounting)
        {
            StartTimer();
        }
        else
        {
            StopTimer();
        }
    }

    private void StartTimer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _isCounting = true;
        _coroutine = StartCoroutine(Countdown());
    }

    private void StopTimer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        
        _isCounting = false;
    }

    private IEnumerator Countdown()
    {
        var wait =  new WaitForSeconds(_elapsedTime);

        while (_isCounting)
        {
            _counter++;
            CountChanged?.Invoke();
            yield return wait;
        }
    }
}
