using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFeedbackManager : MonoBehaviour
{
    public static string feedbackText = "";
    string previousFeedbackText;
    float startTime;
    float textLifeTime = 5;
    TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (feedbackText == "CHOOSE YOUR TEAM")
        {
            textMesh.text = feedbackText;
            return;
        }

        if (feedbackText != previousFeedbackText)
        {
            previousFeedbackText = feedbackText;
            startTime = Time.time;
        }

        

        if (Time.time < startTime + textLifeTime)
        {
            textMesh.text = feedbackText;
        } else
        {
            textMesh.text = "";
        }


    }
}
