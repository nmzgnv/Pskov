using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player3D : MonoBehaviour
{
	public bool IsAlive { get; set; } = true;
	private Rigidbody _rb;
	private GameManager _gameManager;

	private void Start()
	{
		_gameManager = FindObjectOfType<GameManager>();
		_rb = GetComponent<Rigidbody>();
	}

	private void Die()
	{
		gameObject.SetActive(false);
		IsAlive = false;
		StopAllCoroutines();
		_gameManager.restartScene();
	}

	public void SetNormalSqueeze()
	{
		StopAllCoroutines();
		Sqeeze(false);
	}
	public void Sqeeze(bool decrement = true)
	{
		if (IsAlive)
			StartCoroutine(SqeezeBySteps(decrement));
	}

	private IEnumerator SqeezeBySteps(bool decrement)
	{
		var scale = transform.localScale;
		var coefficcient = decrement ? 0.7f : 1.3f;
		while ((scale.y > 0.1f & decrement) || (scale.y < 1 & !decrement))
		{
			scale.y *= coefficcient;
			transform.localScale = scale;
			yield return new WaitForSeconds(0.1f);
		}
		if (decrement)
			Die();
	}
}
