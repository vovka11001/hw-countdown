using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        Display();
    }
    private void OnEnable()
    {
        _counter.CountChanged += Display;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= Display;
    }
    
    private void Display()
    {
        int value = _counter.Count;
        _text.text = value.ToString(); 
    }
}
