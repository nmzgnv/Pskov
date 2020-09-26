using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _offset = new Vector3(2, 10, 0);
    [SerializeField]
    private float _smooth;
    [SerializeField]
    private Transform _leftUpCorner;
    [SerializeField]
    private Transform _rightDownCorner;

    public void Update()
    {
        var _newPosition = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _smooth);
        transform.position = _newPosition;
    }
}
