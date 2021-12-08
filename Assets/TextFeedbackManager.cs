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
    public GameObject parentObj;
    public static Color textColor;

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
        if (!parentObj.GetComponentInParent<RealtimeView>().isOwnedLocallySelf)
        {
            return;
        }

        if (gameLogic._team1Score != previousScoreBlue)
        {
            feedbackText = "Blue Team" + "\n" + "Won Round" + (gameLogic._roundCurrent-1).ToString();
            previousScoreBlue = gameLogic._team1Score;
            textColor = Color.blue;
        }

        if (gameLogic._team2Score != previousScoreRed)
        {
            feedbackText = "Red Team" + "\n" + "Won Round" + (gameLogic._roundCurrent - 1).ToString();
            previousScoreRed = gameLogic._team2Score;
            textColor = Color.red;
        }

        if (gameLogic._roundCurrent != previousRoundCurrent)
        {
            feedbackText = "Round Started";
            previousRoundCurrent = gameLogic._roundCurrent;
            textColor = Color.white;
        }

        if (gameLogic._team1Score > 1)
        {
            feedbackText = "Blue Won the Game"  + "\n" +  "Congratulations!";
            textColor = Color.blue;

        }
        if (gameLogic._team2Score > 1)
        {
            feedbackText = "Red Won the Game" + "\n" + "Congratulations!";
            textColor = Color.red;
        }
        
        if (feedbackText != previousFeedbackText)
        {
            previousFeedbackText = feedbackText;
            startTime = Time.time;
        }


        if (Time.time < startTime + textLifeTime)
        {
            textMesh.text = feedbackText;
            textMesh.color = textColor;


        } else
        {
            textMesh.text = "";
        }
        //textMesh.text = "hej";
        //TextFeedbackManager.feedbackText = "WAITING FOR PLAYERS"+"\n"+"CHOOSING TEAMS";
        //TextFeedbackManager.feedbackText = "ROUND STARTED";
        //wins the game


    }
}
