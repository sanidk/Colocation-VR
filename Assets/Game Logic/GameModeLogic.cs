using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeLogic : MonoBehaviour
{
    [Header("Game Mode: 1: Most Kills, 2: Rounds")]
    public int gameMode; //if 1 kills, if 2 rounds

    //Game Mode 1: 2v2
    //You play best of X(uneven) rounds (roundsTotal)
    //Round lasts x amounts of minutes (roundTotalTime)
    //When time runs out most kills wins the round (or tie)

    //Go back to spawn on death - respawn instantly. Immunity for 5 seconds when spawning? No zone/area immunity
    //Reward for killstreak in own base?

    

    //Game Mode 2. 2v2 (Last standing)
    //You play best of X(uneven) rounds (roundsTotal)
    //Round lasts x amounts of minutes (roundTotalTime)
    //Last standing player wins for the team

    //Go back to spawn on death - respawn at new round.


    bool isGameStart;
    bool isRoundStarted;
    int gameWinner;


    public static int teamSize = 1;

    //Probably have to be networked:
    public List<GameObject> team1Players = new List<GameObject>();
    public List<GameObject> team2Players = new List<GameObject>();

    //is players dead
    public float roundTotalTime;
    float roundStartTime;
    float roundElapsedTime;

    public int team1Score;
    public int team2Score;

    public int roundCurrent;
    int roundsPlayed;
    int roundsTotal;

    int team1Kills;
    int team2Kills;
    int team1TotalKills;
    int team2TotalKills;
    //create player stats variable to track kills
    //create player stats variable to track ready to start new round
    //Team variable to track which team the player is joined
    //

    //UI
    public GameObject playersConnectedText;
    public GameObject roundText;
    public GameObject scoreText;
    public GameObject killsText;
    public GameObject timeText;
    public GameObject winnerText;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (gameMode == 1)
        {
            roundTotalTime = 180f; //3 minutes
            roundsTotal = 5;

        }

        if (gameMode == 2)
        {
            roundTotalTime = 600f; //10 minutes
            roundsTotal = 5;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {   
        if (!isRoundStarted)
        {
            if (CheckIfAllPlayersReady())
            {
                roundStartTime = Time.time;
                isRoundStarted = true;
            }
        }
        

        roundElapsedTime = Time.time - roundStartTime;

        if (CheckRoundWinner() == 1)
        {
            team1Score++;
            ResetAndCreateNewRound();


        } else if (CheckRoundWinner() == 2)
        {
            team2Score++;
            ResetAndCreateNewRound();
            
        }

        gameWinner = CheckGameWinner();

        playersConnectedText.GetComponent<TextMesh>().text = team1Players.Count.ToString() + "/" + team2Players.Count.ToString();
        roundText.GetComponent<TextMesh>().text = roundCurrent.ToString();
        scoreText.GetComponent<TextMesh>().text = team1Score.ToString() + "-" + team2Score.ToString();
        killsText.GetComponent<TextMesh>().text = team1Kills.ToString() + "-" + team2Kills.ToString();
        timeText.GetComponent<TextMesh>().text = (roundTotalTime - roundElapsedTime).ToString();

    }

    bool CheckIfAllPlayersReady()
    {
        if (team1Players.Count != teamSize || team2Players.Count != teamSize) { 
            return false; 
        }

        bool isTeam1Ready = true;
        bool isTeam2Ready = true;

        foreach (GameObject obj in team1Players)
        {
            //CREATE IS PLAYER READY VARIABLE IN PLAYER STATS
            /*
            if (!obj.GetComponent<PlayerBehaviour>()._isPlayerReady)
            {
                isTeam1Ready = false;
            }
            */
        }

        foreach (GameObject obj in team2Players)
        {
            //CREATE IS PLAYER READY VARIABLE IN PLAYER STATS
            /*
            if (!obj.GetComponent<PlayerBehaviour>()._isPlayerReady)
            {
                isTeam2Ready = false;
            }
            */
        }

        if (isTeam1Ready && isTeam2Ready)
        {
            return true;
        }
        else
        {
            return false;
        }


    }

    void ResetAndCreateNewRound()
    {
        roundCurrent++;
        team1Kills = 0;
        team2Kills = 0;
    }

    int CheckRoundWinner()
    {
        
        if (gameMode == 1)
        {
            if (roundElapsedTime > roundTotalTime)
            {
                if (team1Kills > team2Kills)
                {
                    return 1;
                }
                else if (team2Kills > team1Kills)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            } else
            {
                return 0;
            }
            
        } else if (gameMode == 2)
        {
            bool isTeam1Dead = true;
            bool isTeam2Dead = true;

            foreach (GameObject obj in team1Players){
                if (obj.GetComponent<PlayerStats>()._health > 0)
                {
                    isTeam1Dead = false;
                }
            }

            foreach (GameObject obj in team1Players)
            {
                if (obj.GetComponent<PlayerStats>()._health > 0)
                {
                    isTeam2Dead = false;
                }
            }

            if (isTeam1Dead && isTeam2Dead)
            {
                return 3;
            } else if (isTeam1Dead)
            {
                return 2;
            } else if (isTeam2Dead)
            {
                return 1;
            } else
            {
                return 0;
            }


        } else
        {
            return 0;
        }
    }

    int CheckGameWinner()
    {
        if (roundsPlayed == roundsTotal)
        {
            if (team1Score > team2Score)
            {
                return 1;
            } else if (team2Score > team1Score)
            {
                return 2;
            } else
            {
                return 3;
            }
        } else
        {
            return 0;
        }
    }
}
