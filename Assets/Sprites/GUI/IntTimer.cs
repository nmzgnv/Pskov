using System;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements.Experimental;

public class FloatTimer
{
    private float _delta;
    private float _animationTime;
    private float _state;
    private float _start;

    public FloatTimer(float start, float end, float time)
    {
        _start = start;
        _delta = (end - start) / time;
        _animationTime = time;
        _state = _delta == 0? 1f: 0f;
    }

    public bool Update(float timeDelta)
    {
        _state = Math.Min(1, _state + timeDelta / _animationTime);
        return isEnded();
    }

    public float getValue()
    {
        return _start + _state * _delta * _animationTime;
    }

    public bool isEnded()
    {
        return _state == 1f;
    }


}
