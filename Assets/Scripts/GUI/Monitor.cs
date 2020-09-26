using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Monitor : MonoBehaviour
{
    private float _delta;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _delta = _rb.mass / 9.8f;
    }

    // Update is called once per frame
    void Update()
    {
        _rb.mass = _delta * PhysicalVariables.GravityScale;
    }
}
