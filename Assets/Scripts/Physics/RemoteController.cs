using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteController : MonoBehaviour
{
	[SerializeField]
	private GameObject _remoteControllerPanel;
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private AudioSource _appearanceSound;
	private string _animationId = "IsRemoteControllerActive";

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			ChangeRemoteControllerVisibility();
			HideUiElem.H.hideUI();
		}
	}

	private void ChangeRemoteControllerVisibility()
	{
		_appearanceSound.Play();
		if (!_remoteControllerPanel.activeSelf)
			OpenRemoteController();
		else
			CloseRemoteController();
	}

	private void OpenRemoteController()
	{
		_remoteControllerPanel.SetActive(true);
	}

	private void CloseRemoteController()
	{
		_animator.SetBool(_animationId, false);
		StartCoroutine(ClosePanelAfterAnimation());
	}

	private IEnumerator ClosePanelAfterAnimation()
	{
		yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length +
			_animator.GetCurrentAnimatorStateInfo(0).normalizedTime - 0.8f);
		_remoteControllerPanel.SetActive(false);
	}
}
