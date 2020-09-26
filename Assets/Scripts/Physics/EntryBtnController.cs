using UnityEngine;

public class EntryBtnController : MonoBehaviour
{
    private string tag;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Press()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.gameObject.tag;
        if (tag == "Player" || tag == "Stone")
        {
            Debug.Log("door open");
            //StartGame.loadFirstScene();
        }
    }
}
