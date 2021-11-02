using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPlayerText : MonoBehaviour
{
    GameObject gameManager;
    TextMesh textObject;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        textObject = GetComponent<TextMesh>();
        textObject.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float cd = gameManager.GetComponent<GameManagerLogic>().countdownTime;
        if (cd < 5 && cd > 0)
        {
            int cdint = (int)Mathf.Floor(cd);
            textObject.text = cdint.ToString();
        } else
        {
            textObject.text = "";
        }
        
    }
}
