using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPlayerText : MonoBehaviour
{
    GameObject gameManager;
    TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

        text.text = "det virker";
    }
}
