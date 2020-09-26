using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public TextMeshPro _letterMesh;
    public TextMeshPro _numberMesh;
    public float _animationTime = 1.5f;
    internal FloatTimer _timer = new FloatTimer(0, 0, 1.5f);


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!_timer.isEnded())
        {
            bool ended = _timer.Update(Time.deltaTime);
            _numberMesh.SetText(_timer.getValue().ToString("0.0"));
        }
    }

    public void setName(string letter)
    {
        _letterMesh.SetText(letter);
    }
    public void setValue(float value)
    {
        _numberMesh.SetText(value.ToString());
        _timer = new FloatTimer(value, value, _animationTime);
    }

    public void addValue(float value)
    {
        _timer = new FloatTimer(_timer.getValue(), _timer.getValue() + value, _animationTime);
    }
}
