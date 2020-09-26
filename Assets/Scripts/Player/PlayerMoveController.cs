using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMoveController : MonoBehaviour
{
	[SerializeField]
	private float _normalSpeed = 10f;
	[SerializeField]
	private float _jumpForce = 200f;
	[SerializeField]
	private ParticleSystem _particleSystem;
	private float _speed;
	private bool _isGrounded;
	private string _runAnimationId = "isRunning";
	private string _jumpAnimationId = "isJumping";

	private Rigidbody2D _rb;
	private Animator _animator;
	private Player _player;
	private AudioSource _jumpSound;
	private Collider2D _collider2D;

	void Start()
	{
		_speed = 0;
		_jumpForce *= 100;
		_player = GetComponent<Player>();
		_rb = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
		_jumpSound = GetComponent<AudioSource>();
		_collider2D = GetComponent<Collider2D>();
	}

	void FixedUpdate()
	{
		if (_player.IsAlive)
		{
			_rb.velocity = new Vector2(_speed, _rb.velocity.y);
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
			_rb.AddForce(Vector2.up * _jumpForce);
		}
	}

	private void CheckCollideWithWall(Collision2D collision)
	{
		Collider2D collider = collision.collider;
		Vector3 center = collider.bounds.center;
		Vector3 contactPoint = collision.contacts[0].point;

		if ((contactPoint.y > center.y + collider.bounds.size.y / 2) & Mathf.Abs(_collider2D.bounds.center.x - center.x - 1.1f) < collider.bounds.size.x)
			ChangeGroundedState(collision, true);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		CheckCollideWithWall(collision);
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		CheckCollideWithWall(collision);
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		ChangeGroundedState(collision, false);
	}

	private void ChangeGroundedState(Collision2D collision2d, bool value)
	{
		if (collision2d.gameObject.tag == "Ground")
			_isGrounded = value;
	}
}
