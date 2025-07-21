using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    // [SerializeField] private Animator _heartAnimator;
    // [SerializeField] private AnimationClip _healthPulseAnimation;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChanged += ShowCounterValue;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= ShowCounterValue;
    }

    private void ShowCounterValue()
    {
        _counterText.text = _counter.CurrentCounterValue.ToString();
    }
}
