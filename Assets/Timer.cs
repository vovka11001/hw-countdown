using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    
    private float _elapsedTime = 0.5f;
    private int _counter = 0;
    private bool _isCounting;
    private Coroutine _coroutine;
    

    private void Start()
    {
        _text.text = _counter.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (_isCounting)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }
    }

    private void StartTimer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _isCounting = true;
        StartCoroutine(Countdown(_elapsedTime));
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

    private IEnumerator Countdown(float delay)
    {
        var wait =  new WaitForSeconds(delay);

        while (_isCounting)
        {
            _counter++;
            _text.text = _counter.ToString();
            yield return wait;
        }
    }
}
