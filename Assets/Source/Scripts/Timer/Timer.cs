using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    public Action OnTimerEnd;
    
    [SerializeField] private TextMeshProUGUI _timerText; 
    [SerializeField] private float _seconds;
    private float _secondsDone;

    private void OnValidate()
    {
        _timerText ??= GetComponent<TextMeshProUGUI>();
    }
    
    private void Start()
    {
        StartCoroutine(TimerTick());
    }
    
    private IEnumerator TimerTick()
    {
        while (_secondsDone < _seconds)
        {
            yield return new WaitForSeconds(1f);
            _seconds--;
            _timerText.text = (_seconds - _secondsDone).ToString();
        }
        OnTimerEnd?.Invoke();
    }
}
