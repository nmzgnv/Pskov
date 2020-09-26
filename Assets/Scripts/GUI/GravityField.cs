using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : FieldController
{
    private float _maxValue;
    void Start()
    {
        setName("G");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_timer.isEnded())
        {
            bool ended = _timer.Update(Time.deltaTime);
            _numberMesh.SetText( _timer.getValue().ToString("0.0"));
        }
        if (_maxValue != PhysicalVariables.GravityScale)
        {
            addValue(PhysicalVariables.GravityScale - _timer.getValue());
        }
    }

    public void setValue(float value)
    {
        base.setValue(value);
        _maxValue = value;
    }

    public void addValue(float value)
    {
        _maxValue = _timer.getValue() + value;
        base.addValue(value);
    }
}
