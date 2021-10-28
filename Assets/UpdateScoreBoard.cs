using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreBoard : MonoBehaviour
{
    GameLogic gameLogic;
    GameManagerLogic gameManager;

    //UI
    public GameObject roundText;


    public GameObject team1countText;
    public GameObject team2countText;

    public GameObject team1scoreText;
    public GameObject team2scoreText;

    public GameObject team1killsText;
    public GameObject team2killsText;

    public GameObject timeText;
    public GameObject winnerText;
    public GameObject debugText;

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
        team1countText.GetComponent<TextMesh>().text = gameLogic._team1PlayerCount.ToString();
        team2countText.GetComponent<TextMesh>().text = gameLogic._team2PlayerCount.ToString();

        team1scoreText.GetComponent<TextMesh>().text = gameLogic._team1Score.ToString();
        team2scoreText.GetComponent<TextMesh>().text = gameLogic._team2Score.ToString();

        team1killsText.GetComponent<TextMesh>().text = gameLogic._team1Kills.ToString();
        team2killsText.GetComponent<TextMesh>().text = gameLogic._team2Kills.ToString();

        roundText.GetComponent<TextMesh>().text = "Round " + gameLogic._roundCurrent.ToString();
        timeText.GetComponent<TextMesh>().text = gameLogic._roundElapsedTime.ToString();
    }
}
