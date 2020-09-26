using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityChanger : MonoBehaviour
{
	[SerializeField]
	private Player _player;
	[SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Scrollbar _scrollbar;
	[SerializeField]
	private Text _gravityValue;
	[SerializeField]
	private GameObject _remoteController;
	private float _gravityCoefficient = 0.5f;
	private float _previousValue;
	

	private void Start()
	{
		_previousValue = 0.49f;
		_gravityValue.text = $"g: {GetNormalizedValue(_previousValue * 20)} м/с^2";
		_scrollbar.value = _previousValue;
	}

	private void Update()
	{
		var _scrollbarValue = _scrollbar.value;
		float _gravityScale = 0;
		if (_previousValue != _scrollbarValue)
		{
			_previousValue = _scrollbarValue;
			if (_scrollbarValue < 0.5)
				_gravityScale = _scrollbarValue * 20;
			else
				_gravityScale = 9.8f + (_scrollbarValue - _gravityCoefficient) * 80.4f;

			var _normalizedGravity = GetNormalizedValue(_gravityScale);
			_gravityValue.text = $"g: {_normalizedGravity} м/с^2";

			ChangeGravityScale(_gravityScale);
		}
	}

	private float GetNormalizedValue(float value)
	{
		return Mathf.Round(value * 10) * 0.1f;
	}

	private void ChangeGravityScale(float value)
	{
		_rb.gravityScale = value;
		PhysicalVariables.GravityScale = value;
		if (value >= 50)
			_player.Sqeeze();
		else
			_player.SetNormalSqueeze();
	}


}
