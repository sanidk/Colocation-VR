using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreBoard : MonoBehaviour
{
    GameLogic gameLogic;
    GameManagerLogic gameManager;

    //UI
    public GameObject roundText;

    public GameObject teamCounterText;
    public GameObject team1countText;
    public GameObject team2countText;

    public GameObject team1scoreText;
    public GameObject team2scoreText;

    public GameObject team1killsText;
    public GameObject team2killsText;

    public GameObject timeText;
    public GameObject winnerText;
    public GameObject debugText;

    public GameObject playerInfoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        gameManager = GetComponent<GameManagerLogic>();
        gameLogic = gameManager.GetComponent<GameLogic>();
        

    }

    // Update is called once per frame
    void Update()
    { 
        if (gameManager.isPlayersConnectedAndTeamsAssigned)
        {
            team1countText.SetActive(false);
            team2countText.SetActive(false);
            teamCounterText.SetActive(false);
        } else
        {
            team1countText.SetActive(true);
            team2countText.SetActive(true);
            teamCounterText.SetActive(true);
        }

        team1countText.GetComponent<TextMesh>().text = gameLogic._team1PlayerCount.ToString();
        team2countText.GetComponent<TextMesh>().text = gameLogic._team2PlayerCount.ToString();

        team1scoreText.GetComponent<TextMesh>().text = gameLogic._team1Score.ToString();
        team2scoreText.GetComponent<TextMesh>().text = gameLogic._team2Score.ToString();

        team1killsText.GetComponent<TextMesh>().text = gameLogic._team1Kills.ToString();
        team2killsText.GetComponent<TextMesh>().text = gameLogic._team2Kills.ToString();


        roundText.GetComponent<TextMesh>().text = "Round " + gameLogic._roundCurrent.ToString();
        int time = (int)(gameLogic._roundTotalTime - gameLogic._roundElapsedTime);
        int minutes;
        int seconds;
        minutes = (int)Mathf.Floor(time / 60);
        seconds = time - (int)Mathf.Floor(time / 60)*60;

        timeText.GetComponent<TextMesh>().text = minutes.ToString()+":"+seconds.ToString();
        //ToString("mm:ss");
    }
}
