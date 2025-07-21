using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const float Delay = 0.5f;

    [SerializeField] private UserInput _userInput;

    private int _counter = 0;
    private bool _isCounting = false;

    private Coroutine _countingCoroutine;

    public event Action CounterChanged;

    public int CurrentCounterValue => _counter;

    private void OnEnable() => 
        _userInput.MouseButtonDown += ToggleCounter;

    private void OnDisable() => 
        _userInput.MouseButtonDown -= ToggleCounter;

    private void ToggleCounter()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            _countingCoroutine = StartCoroutine(CountHalfSecond());
        }
        else
        {
            if (_countingCoroutine != null)
                StopCoroutine(_countingCoroutine);
        }
    }

    private IEnumerator CountHalfSecond()
    {
        var wait = new WaitForSeconds(Delay);

        while (enabled)
        {
            yield return wait;
            _counter++;
            Debug.Log("Counter: " + _counter);
            CounterChanged?.Invoke();
        }
    }
}