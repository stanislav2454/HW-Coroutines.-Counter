using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;

    private int _counter = 0;
    private bool _isCounting = false;

    private Coroutine _countingCoroutine;

    public event Action CounterChanged;

    public int CurrentCounterValue => _counter;
    public bool CurrentCounterCondition => _isCounting;

    private void OnEnable() => _userInput.MouseButtonDown += ToggleCounter;

    private void OnDisable() => _userInput.MouseButtonDown -= ToggleCounter;

    private void ToggleCounter()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            CounterChanged?.Invoke();
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
        var wait = new WaitForSeconds(0.5f);

        while (true)
        {
            yield return wait;
            //yield return new WaitForSeconds(0.5f);
            _counter++;
            // _counterText.text = _counter.ToString();
            Debug.Log("Counter: " + _counter);
        }
    }
}