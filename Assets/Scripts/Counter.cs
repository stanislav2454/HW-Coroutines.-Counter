using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private int _counter = 0;
    private bool _isCounting = false;
    private Coroutine _countingCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ToggleCounter();
    }

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
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _counter++;

            Debug.Log("Counter: " + _counter);

            _counterText.text = _counter.ToString();
        }
    }
}