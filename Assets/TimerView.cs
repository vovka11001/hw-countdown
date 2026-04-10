using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void Start()
    {
        Display();
    }
    private void OnEnable()
    {
        _timer.CountChanged += Display;
    }

    private void OnDisable()
    {
        _timer.CountChanged -= Display;
    }
    
    private void Display()
    {
        int value = _timer.Counter;
        _timerText.text = value.ToString(); 
    }
}
