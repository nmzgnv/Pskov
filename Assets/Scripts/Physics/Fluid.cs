using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class Fluid : MonoBehaviour
{
	[SerializeField]
	private Scrollbar _slider;
	private AudioSource _audioSource;
	public float Destiny { get; private set; } = 1000;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void OnChangeDensity()
	{
		Destiny = _slider.value * 3000 + 1;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
			_audioSource.Play();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
			_audioSource.Stop();
	}
}
