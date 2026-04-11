using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    
    private float _elapsedTime = 0.5f;
    private int _count = 0;
    private bool _isCounting;
    private Coroutine _coroutine;

    public event Action CountChanged;

    public int Count => _count;
    
    private void OnEnable()
    {
        _inputReader.InputDown += Togle;
    }

    private void OnDisable()
    {
        _inputReader.InputDown -= Togle;
    }
    
    
    private void Togle()
    {
        if (!_isCounting)
        {
            Start();
        }
        else
        {
            Stop();
        }
    }

    private void Start()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _isCounting = true;
        _coroutine = StartCoroutine(Countdown());
    }

    private void Stop()
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
            _count++;
            CountChanged?.Invoke();
            yield return wait;
        }
    }
}
