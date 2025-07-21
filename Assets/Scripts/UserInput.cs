using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public event Action MouseButtonDown;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // _coroutines.Add(StartCoroutine(CalculateTime()));
            MouseButtonDown.Invoke();
            //  _timerView.text = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.ff");
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    foreach (var item in _coroutines)
        //        if (item != null)
        //            StopCoroutine(item);

        //    _coroutines.Clear();
        //}
    }
}
