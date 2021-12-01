using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;

public class TextFeedbackManager : MonoBehaviour
{
    public static string feedbackText = "";
    public static string winnerFeedbackText = "";
    string combinedString = "";
    string previousFeedbackText;
    float startTime;
    float textLifeTime = 10;
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
        if (!GetComponentInParent<RealtimeView>().isOwnedLocallySelf) return;


        //if (feedbackText != previousFeedbackText)
        //{
        //    previousFeedbackText = feedbackText;
        //    startTime = Time.time;
        //}

        textMesh.text = feedbackText;

        //if (Time.time < startTime + textLifeTime)
        //{
        //    textMesh.text = feedbackText;
        //}


    }
}
