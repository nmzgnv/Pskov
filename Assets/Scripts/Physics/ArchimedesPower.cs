using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchimedesPower : MonoBehaviour
{
	[SerializeField]
	private float _archimedesPower = 0;
	[SerializeField]
	private Transform _maxHeightPoint;
	[SerializeField]
	private Fluid _fluid;
	private Rigidbody2D _rb;
	private float _rbHeight;
	private float _rbWidth;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		var _rbCollider = GetComponent<Collider2D>();
		_rbHeight = _rbCollider.bounds.size.y;
		_rbWidth = _rbCollider.bounds.size.x;
	}

	private void FixedUpdate()
	{
		_rb.AddForce(new Vector2(0, GetArcimedePower()), ForceMode2D.Force);
		if (!(_rb.gameObject.transform.position.y + _rbHeight / 2 < _maxHeightPoint.position.y))
			_rb.velocity = _rb.velocity / 1.1f;

	}

	private float GetArcimedePower()
	{
		var _underWaterHeight = Mathf.Min(_rbHeight / 2 - (_rb.gameObject.transform.position.y - _maxHeightPoint.position.y), _rbHeight);
		var _underWaterSize = _underWaterHeight * _rbWidth;
		var _archimedePower = _fluid.Destiny * PhysicalVariables.GravityScale * _underWaterHeight * 0.1f;
		_archimedePower = Mathf.Max(0, _archimedePower);
		Debug.Log(string.Format("[ArchimedesPower.cs] Volume={1:0.0}, mass={2:0.0}, power={3:0.0}", name, _underWaterSize, _rb.mass, _archimedePower));
		return _archimedePower;
	}
}
