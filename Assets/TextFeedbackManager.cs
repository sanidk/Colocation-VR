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

    public GameObject gameManager;
    GameLogic gameLogic;

    int previousScoreBlue = 0;
    int previousScoreRed = 0;
    int previousRoundCurrent = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        textMesh = GetComponent<TextMesh>();
        gameLogic = gameManager.GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponentInParent<RealtimeView>().isOwnedLocallySelf) return;

        if (gameLogic._team1Score != previousScoreBlue)
        {
            feedbackText = "Blue Won Round";
            previousScoreBlue = gameLogic._team1Score;
        }

        if (gameLogic._team2Score != previousScoreRed)
        {
            feedbackText = "Red Won Round";
            previousScoreRed = gameLogic._team2Score;
        }

        if (gameLogic._roundCurrent != previousRoundCurrent)
        {
            feedbackText = "Round Started";
            previousRoundCurrent = gameLogic._roundCurrent;
        }

        if (gameLogic._team1Score > 2)
        {
            feedbackText = "Blue Won the Game. Congratulations!";
        }
        if (gameLogic._team2Score > 2)
        {
            feedbackText = "Red Won the Game. Congratulations!";
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


        //TextFeedbackManager.feedbackText = "WAITING FOR PLAYERS"+"\n"+"CHOOSING TEAMS";
        //TextFeedbackManager.feedbackText = "ROUND STARTED";
        //wins the game


    }
}
