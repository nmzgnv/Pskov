using UnityEngine;

public class TriggerWithPlayer : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("next scene");
            _gameManager.nextScene();
        }
    }
}
