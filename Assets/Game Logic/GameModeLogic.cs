using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.UI;
using UnityEngine.UIElements;

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

    public GameObject networkManager;
    static RealtimeAvatarManager manager;
    public Dictionary<int, RealtimeAvatar> avatars;
    public Dictionary<int, RealtimeAvatar> previousAvatars;


    bool isPlayersConnectedAndTeamsAssigned;
    bool isPlayersReadyToStartGame;
    bool isGameStart;
    bool isRoundStarted;
    int gameWinner;


    public static int teamSize = 1;

    //Probably have to be networked:
    public List<GameObject> team1Players = new List<GameObject>();
    public List<GameObject> team2Players = new List<GameObject>();

    //is players dead
    float roundTotalTime = 60;
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
    public GameObject debugText;

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
        //Update UI
        playersConnectedText.GetComponent<TextMesh>().text = team1Players.Count.ToString() + "/" + team2Players.Count.ToString();
        roundText.GetComponent<TextMesh>().text = roundCurrent.ToString();
        scoreText.GetComponent<TextMesh>().text = team1Score.ToString() + "-" + team2Score.ToString();
        killsText.GetComponent<TextMesh>().text = team1Kills.ToString() + "-" + team2Kills.ToString();
        timeText.GetComponent<TextMesh>().text = roundElapsedTime.ToString();
        //debugText.GetComponent<TextMesh>().text = "hello world"; //GetComponent<PlayerStats>()._health.ToString();

        //Get list of players connected
        if (manager == null)
        {
            manager = networkManager.GetComponent<RealtimeAvatarManager>();
        }
        else
        {
            avatars = manager.avatars;
            
            //print("updated: " + avatars.Count);

        }

        if (!isPlayersConnectedAndTeamsAssigned)
        {
            if (CheckIfPlayersConnectedAndTeamsAssigned())
            {
                isPlayersConnectedAndTeamsAssigned = true;
                debugText.GetComponent<TextMesh>().text = "teams assigned success";
            }
            else
            {
                debugText.GetComponent<TextMesh>().text = "teams assigned failed";
                return;
            }
        }

        

        if (!isPlayersReadyToStartGame && !isRoundStarted)
        {
            debugText.GetComponent<TextMesh>().text = "checking if players ready";
            if (CheckIfAllPlayersReady())
            {
                isPlayersReadyToStartGame = true;
                roundStartTime = Time.time;
                isRoundStarted = true;
                debugText.GetComponent<TextMesh>().text = "all players ready";
            } else
            {
                debugText.GetComponent<TextMesh>().text = "players not ready" + "team "+GetComponent<PlayerStats>()._team + " I am ready: "+GetComponent<PlayerStats>()._isReady;
                /*
                string notreadyplayers = "";
                for (int i = 0; i < avatars.Count; i++)
                {
                    RealtimeAvatar player = avatars[i];

                    if (!player.gameObject.GetComponent<PlayerStats>()._isReady)
                    {
                        
                        string oldstring = notreadyplayers;
                        notreadyplayers = oldstring + player.gameObject.GetComponent<PlayerStats>()._team.ToString() + GetComponent<PlayerStats>()._isReady.ToString();
                    }

                }

                debugText.GetComponent<TextMesh>().text = notreadyplayers;
                */
            }

        } else
        {
            debugText.GetComponent<TextMesh>().text = "players not ready" + "team " + GetComponent<PlayerStats>()._team + " I am ready: " + GetComponent<PlayerStats>()._isReady;
        }


        
        if (isRoundStarted)
        {
            roundElapsedTime = Time.time - roundStartTime;
            //debugText.GetComponent<TextMesh>().text = "round started";

            if (CheckRoundWinner() == 1)
            {
                team1Score++;
                ResetAndCreateNewRound();
                isRoundStarted = false;
                //debugText.GetComponent<TextMesh>().text = "round winner team 1";
                roundText.GetComponent<TextMesh>().text = "round winner team 1";



            }
            else if (CheckRoundWinner() == 2)
            {
                team2Score++;
                ResetAndCreateNewRound();
                isRoundStarted = false;
                //debugText.GetComponent<TextMesh>().text = "round winner team 2";
                roundText.GetComponent<TextMesh>().text = "round winner team 2";
            }
        }


        if (roundCurrent > roundsTotal)
        {
            gameWinner = CheckGameWinner();
            roundText.GetComponent<TextMesh>().text = gameWinner.ToString();
        }





        
        
        /*
        playersConnectedText.text = team1Players.Count.ToString() + "/" + team2Players.Count.ToString();
        roundText.text = roundCurrent.ToString();
        scoreText.text = team1Score.ToString() + "-" + team2Score.ToString();
        killsText.text = team1Kills.ToString() + "-" + team2Kills.ToString();
        timeText.text = (roundTotalTime - roundElapsedTime).ToString();
        debugText.text = "hello world";//GetComponent<PlayerStats>()._health.ToString();
        */
    }

    bool CheckIfPlayersConnectedAndTeamsAssigned()
    {
        if (avatars.Count != teamSize * 2) return false;

        bool isTeamsSet = true;
        team1Players.Clear();
        team2Players.Clear();

        for (int i = 0; i < avatars.Count; i++)
        {
            RealtimeAvatar player = avatars[i];
            int team;
            team = player.gameObject.GetComponent<PlayerStats>()._team;

            if (team == 0)
            {
                isTeamsSet = false;
                return false;
            }
            else if (team == 1)
            {

                team1Players.Add(player.gameObject);

            }
            else if (team == 2)
            {
                team2Players.Add(player.gameObject);
            }
        }

        return isTeamsSet;
    }

    bool CheckIfAllPlayersReady()
    {
        if (avatars.Count != teamSize * 2)
        {
            return false;
        }

        bool isTeamsReady = true;

        for (int i = 0; i < avatars.Count; i++)
        {
            RealtimeAvatar player = avatars[i];

            if (!player.gameObject.GetComponent<PlayerStats>()._isReady)
            {
                isTeamsReady = false;
            }

        }

        return isTeamsReady;


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
            }
            else
            {
                return 0;
            }

        }
        else if (gameMode == 2)
        {
            bool isTeam1Dead = true;
            bool isTeam2Dead = true;

            foreach (GameObject obj in team1Players)
            {
                if (obj.GetComponent<PlayerStats>()._health > 0)
                {
                    isTeam1Dead = false;
                }
            }

            foreach (GameObject obj in team2Players)
            {
                if (obj.GetComponent<PlayerStats>()._health > 0)
                {
                    isTeam2Dead = false;
                }
            }

            if (isTeam1Dead && isTeam2Dead)
            {
                return 3;
            }
            else if (isTeam1Dead)
            {
                return 2;
            }
            else if (isTeam2Dead)
            {
                return 1;
            }
            else
            {
                return 0;
            }


        }
        else
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
            }
            else if (team2Score > team1Score)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        else
        {
            return 0;
        }
    }
}
