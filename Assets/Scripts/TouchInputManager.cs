using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TouchInputManager : MonoBehaviour
{

    [Serializable]
    public class FloatEvent : UnityEvent<float> {}

    [SerializeField] float delay = 2;

    [SerializeField] UnityEvent onTouch;
    [SerializeField] UnityEvent onTouchCancel;
    [SerializeField] AnimationCurve timerUpdateCurve;
    [SerializeField] FloatEvent onTouchTimerUpdate;
    [SerializeField] UnityEvent onTouchTimerEnd;

    float timer;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    timer = 0;
                    onTouch.Invoke(); // invoke event associated with touch begin
                    break;
                case TouchPhase.Ended:
                    Cancel();
                    break;
                default:
                    // time since last update call
                    timer += Time.deltaTime;
                    // When timer is 2, we get 0.5 since delay is 2 and inverselerp gives a value from 0-1
                    onTouchTimerUpdate.Invoke (timerUpdateCurve.Evaluate (Mathf.InverseLerp(0, delay, timer)));
                    if (timer > delay)
                    {
                        onTouchTimerEnd.Invoke();
                    }
                    break;
            }
        }
    }

    void Cancel()
    {
        timer = 0;
        // Reset progress bar by resetting time
        onTouchTimerUpdate.Invoke(timerUpdateCurve.Evaluate(Mathf.InverseLerp(0, delay, timer)));
        onTouchCancel.Invoke();
    }

    private void OnDisable()
    {
        if (Input.touchCount > 0)
        {
            Cancel();
        }
    }
}
