using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUiElem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> elems;

    public static HideUiElem H { get; set; }

    void Awake()
    {

        if (H != null && H != this)
        {
            Destroy(H);
        }

        H = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void hideUI()
    {
        foreach (GameObject elem in elems)
        {
            elem.SetActive(false);
        }
    }
}
