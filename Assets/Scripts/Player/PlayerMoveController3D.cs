using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player3D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMoveController3D : MonoBehaviour
{
	[SerializeField]
	private float _normalSpeed = 10f;
	[SerializeField]
	private float _jumpForce = 200f;
	private float _speed;
	private bool _isGrounded;
	private string _runAnimationId = "isRunning";
	private string _jumpAnimationId = "isJumping";

	private Rigidbody _rb;
	private Animator _animator;
	private Player3D _player;
	private AudioSource _jumpSound;

	void Start()
	{
		_speed = 0;
		_jumpForce *= 100;
		_player = GetComponent<Player3D>();
		_rb = GetComponent<Rigidbody>();
		_animator = GetComponent<Animator>();
		_jumpSound = GetComponent<AudioSource>();
	}

	void FixedUpdate()
	{
		if (_player.IsAlive)
		{
			_rb.velocity = new Vector3(_speed, _rb.velocity.y, 0);
			JumpLogic();
		}
	}

	private void Update()
	{
		var _inputValue = Input.GetAxis("Horizontal");
		if (_inputValue != 0)
		{
			_animator.SetBool(_runAnimationId, true);
			_speed = _normalSpeed * _inputValue;
			Flip();
		}
		else
		{
			_animator.SetBool(_runAnimationId, false);
			_speed = 0;
		}
	}

	private void Flip()
	{
		var scale = transform.localScale;
		var scaleAbs = Mathf.Abs(scale.x);
		if (_speed >= 0)
			scale.x = -scaleAbs;
		else
			scale.x = scaleAbs;
		transform.localScale = scale;
	}

	private void JumpLogic()
	{
		if (Input.GetAxis("Jump") > 0 & _isGrounded)
		{
			_jumpSound.pitch = Random.Range(0.9f, 1.1f);
			_jumpSound.Play();
			_rb.AddForce(Vector3.up * _jumpForce);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		ChangeGroundedState(collision, true);
	}

	private void OnCollisionStay(Collision collision)
	{
		ChangeGroundedState(collision, true);
	}

	private void OnCollisionExit(Collision collision)
	{
		ChangeGroundedState(collision, false);
	}

	private void ChangeGroundedState(Collision collision2d, bool value)
	{
		if (collision2d.gameObject.tag == "Ground")
		{
			_isGrounded = value;
		}
	}
}
