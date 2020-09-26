using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelComplete()
    {
        GameManager.GM.nextScene();
    }
}
