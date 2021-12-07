using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.IO;


public class GameManagerLogic : MonoBehaviour
{
    [Header("Game Mode: 1: Most Kills, 2: Rounds")]
    int gameMode = 2; //if 1 kills, if 2 rounds

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

    GameLogic gameLogic;

    public bool isPlayersConnectedAndTeamsAssigned;
    bool isPlayersReadyToStartGame;
    bool isGameStart;
    public static bool isRoundStarted;
    public static bool isRoundCountdownStarted;
    int gameWinner;


    public static int teamSize = 2;

    //Probably have to be networked:
    public List<GameObject> team1Players = new List<GameObject>();
    public List<GameObject> team2Players = new List<GameObject>();

    //is players dead
    float roundTotalTime = 180;
    float roundStartTime;
    float roundElapsedTime;

    public int team1Score;
    public int team2Score;

    public int roundCurrent = 0;
    int roundsPlayed;
    int roundsTotal = 5;

    int team1Kills;
    int team2Kills;
    int team1TotalKills;
    int team2TotalKills;


    public float countdownTime = 5f;

    public static string playerFeedbackString;

    float roundDelayStartTime;
    float roundDelayLifeTime = 2;



    //public GameObject debugText;


    public bool isServer = false;

    int loopStart = 0;





    public GameObject gunSpawnLocationsObject;
    public List<GameObject> gunsList = new List<GameObject>();


    //LOG DATA
    string userPositionPath = @"C:\TelemetryData\UserPosition.txt";

    private void Awake()
    {
        LogStartOfDataCollection();
    }

    // Update is called once per frame
    void Update()
    {
        //Get list of players connected
        if (manager == null)
        {
            manager = networkManager.GetComponent<RealtimeAvatarManager>();
        }
        else
        {
            avatars = manager.avatars;

        }

        gameLogic = GetComponent<GameLogic>();

        if (avatars.Count == 1)
        {
            isServer = true;
            avatars[0].GetComponent<PlayerStats>()._isServer = true;
            
        }

        if (!isServer)
        {
            //avatars[0].gameObject.SetActive(false);
            return;
        }

        if (!isServer) { return; }
        LogDataCollection();


        if (CheckForGameReset())
        {
            ResetGame();
        }
        


        gameLogic._gameMode = gameMode;
        gameLogic._isPlayersConnectedAndTeamsAssigned = isPlayersConnectedAndTeamsAssigned;
        gameLogic._isPlayersReadyToStartGame = isPlayersReadyToStartGame;
        gameLogic._isGameStart = isGameStart;
        gameLogic._isRoundStarted = isRoundStarted;
        gameLogic._gameWinner = gameWinner;
        gameLogic._teamSize = teamSize;
        gameLogic._roundTotalTime = roundTotalTime;
        gameLogic._roundStartTime = roundStartTime;
        gameLogic._roundElapsedTime = roundElapsedTime;
        gameLogic._team1Score = team1Score;
        gameLogic._team2Score = team2Score;
        gameLogic._roundCurrent = roundCurrent;
        gameLogic._roundsPlayed = roundsPlayed;
        gameLogic._roundsTotal = roundsTotal;
        gameLogic._team1Kills = team1Kills;
        gameLogic._team2Kills = team2Kills;
        gameLogic._team1TotalKills = team1TotalKills;
        gameLogic._team2TotalKills = team2TotalKills;
        gameLogic._team1PlayerCount = team1Players.Count;
        gameLogic._team2PlayerCount = team2Players.Count;


        if (gameWinner != 0) return;


        if (!isPlayersConnectedAndTeamsAssigned)
        {
            if (CheckIfPlayersConnectedAndTeamsAssigned())
            {
                isPlayersConnectedAndTeamsAssigned = true;

                //debugText.GetComponent<TextMesh>().text = "teams assigned success";
            }
            else
            {
                //debugText.GetComponent<TextMesh>().text = "teams assigned failed";

                return;
            }
        }



        if (!isPlayersReadyToStartGame && !isRoundStarted && Time.time > roundDelayStartTime + roundDelayLifeTime)
        {

            //debugText.GetComponent<TextMesh>().text = "checking if players ready";
            if (CheckIfAllPlayersReady())
            {


                isPlayersReadyToStartGame = true;
                SpawnGuns();
                roundStartTime = Time.time;
                isRoundStarted = true;
                roundCurrent++;

                //debugText.GetComponent<TextMesh>().text = "all players ready";
            }
            else
            {
                //debugText.GetComponent<TextMesh>().text = "players not ready";

            }

        }


        if (isRoundStarted)
        {
            //debugText.GetComponent<TextMesh>().text = "round started successfully";
            roundElapsedTime = Time.time - roundStartTime;
            //debugText.GetComponent<TextMesh>().text = "round started";

            int roundWinner = CheckRoundWinner();

            if (roundWinner == 1)
            {
                //ResetPlayerHealth();
                TextFeedbackManager.winnerFeedbackText = "Blue Team Wins Round";
                roundDelayStartTime = Time.time;
                team1Score++;
                //roundCurrent++;

                team1Kills = 0;
                team2Kills = 0;

                isRoundStarted = false;
                isPlayersReadyToStartGame = false;

                DestroyGuns();

                //roundText.GetComponent<TextMesh>().text = "round winner team 1";



            }
            else if (roundWinner == 2)
            {
                //ResetPlayerHealth();
                TextFeedbackManager.winnerFeedbackText = "Red Team Wins Round";
                roundDelayStartTime = Time.time;
                team2Score++;
                //roundCurrent++;

                team1Kills = 0;
                team2Kills = 0;

                isPlayersReadyToStartGame = false;
                isRoundStarted = false;

                DestroyGuns();

                //roundText.GetComponent<TextMesh>().text = "round winner team 2";
            }
            else if (roundWinner == 3)
            {
                //ResetPlayerHealth();
                TextFeedbackManager.winnerFeedbackText = "Tie Round";
                roundDelayStartTime = Time.time;
                //roundCurrent++;

                team1Kills = 0;
                team2Kills = 0;

                isPlayersReadyToStartGame = false;
                isRoundStarted = false;

                DestroyGuns();

                //roundText.GetComponent<TextMesh>().text = "round winner team 2";
            }

        }

        if (roundCurrent > roundsTotal)
        {
            gameWinner = CheckGameWinner();
            if (gameWinner == 1)
            {
                TextFeedbackManager.winnerFeedbackText = "Blue Team Wins";
            }

            if (gameWinner == 2)
            {
                TextFeedbackManager.winnerFeedbackText = "Red Team Wins";
            }
            //roundText.GetComponent<TextMesh>().text = gameWinner.ToString();
        }

    }

    void SpawnGuns()
    {

        {
            foreach (Transform childTransform in gunSpawnLocationsObject.GetComponentsInChildren<Transform>())
            {
                if (childTransform.gameObject.name == "Pistol")
                {
                    GameObject gun = Realtime.Instantiate("Pistol", childTransform.position, childTransform.rotation, new Realtime.InstantiateOptions
                    {
                        ownedByClient = false,
                        preventOwnershipTakeover = false,
                        destroyWhenOwnerLeaves = false,
                        destroyWhenLastClientLeaves = true,
                        //useInstance = _realtime,
                    });
                    gunsList.Add(gun);
                }
                else if (childTransform.gameObject.name == "Rifle")
                {
                    GameObject gun = Realtime.Instantiate("Rifle", childTransform.position, childTransform.rotation, new Realtime.InstantiateOptions
                    {
                        ownedByClient = false,
                        preventOwnershipTakeover = false,
                        destroyWhenOwnerLeaves = false,
                        destroyWhenLastClientLeaves = true,
                        //useInstance = _realtime,
                    });
                    gunsList.Add(gun);

                }
                else if (childTransform.gameObject.name == "Magazine")
                {
                    GameObject gun = Realtime.Instantiate("Mag", childTransform.position, childTransform.rotation, new Realtime.InstantiateOptions
                    {
                        ownedByClient = false,
                        preventOwnershipTakeover = false,
                        destroyWhenOwnerLeaves = false,
                        destroyWhenLastClientLeaves = true,
                        //useInstance = _realtime,
                    });
                    gunsList.Add(gun);

                }


            }
            Debug.Log(gunsList.Count);
        }
    }

    void DestroyGuns()
    {
        foreach (GameObject gun in gunsList)
        {
            Realtime.Destroy(gun);
        }

        gunsList.Clear();
    }

    bool CheckIfPlayersConnectedAndTeamsAssigned()
    {
        if (avatars.Count < (teamSize * 2)+ loopStart) return false;

        bool isTeamsSet = true;
        team1Players.Clear();
        team2Players.Clear();

        for (int i = loopStart; i < avatars.Count; i++) // i = 1 . skip 1st player because its server.
        {
            try
            {
                if (avatars[i] != null)
                {
                    RealtimeAvatar player = avatars[i];
                    int team;
                    team = player.gameObject.GetComponent<PlayerStats>()._team;

                    if (team == 0)
                    {
                        isTeamsSet = false;
                        //return false;
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
            }
            catch
            {

            }


        }

        return isTeamsSet;
    }

    void ResetTeams()
    {

        team1Players.Clear();
        team2Players.Clear();

        for (int i = loopStart; i < avatars.Count; i++)
        {
            try
            {
                if (avatars[i] != null)
                {
                    RealtimeAvatar player = avatars[i];
                    int team;
                    player.gameObject.GetComponent<PlayerStats>()._team = 0;

                }
            }
            catch
            {

            }


        }

    }

    bool CheckIfAllPlayersReady()
    {
        if (avatars.Count < (teamSize * 2)+ loopStart)
        {
            return false;
        }

        bool isTeamsReady = true;

        for (int i = loopStart; i < avatars.Count; i++)
        {
            RealtimeAvatar player = avatars[i];

            if (!player.gameObject.GetComponent<PlayerStats>()._isReady)
            {
                isTeamsReady = false;
            }

        }

        return isTeamsReady;


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

    bool CheckForGameReset()
    {
        bool isLeftPressed = false;
        bool isRightPressed = false;

        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (leftHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = leftHandDevices[0];

            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
            {
                isLeftPressed = true;
            } else
            {
                isLeftPressed = false;
            }
        }

        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];

            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
            {
                isRightPressed = true;
            }
            else
            {
                isRightPressed = false;
            }
        }

        if (isLeftPressed && isRightPressed)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void ResetGame()
    {
        DestroyGuns();
        ResetTeams();
        
        isPlayersConnectedAndTeamsAssigned = false;
        isPlayersReadyToStartGame = false;
        isGameStart = false;
        isRoundStarted = false;
        gameWinner = 0;
        roundStartTime = 0;
        roundElapsedTime = 0;
        team1Score = 0;
        team2Score = 0;
        roundCurrent = 0;
        roundsPlayed = 0;
        team1Kills = 0;
        team2Kills = 0;
        team1TotalKills = 0;
        team2TotalKills = 0;

        //roundTotalTime;
        //gameMode;
        //teamSize;
        //roundsTotal;
        //team1Players.Count;
        //team2Players.Count;


    }

    void LogStartOfDataCollection()
    {
        File.AppendAllText(userPositionPath, "COLLECTION STARTED: " + System.DateTime.Now.ToString() + "\n");
    }

    void LogDataCollection()
    {
        for (int i = 1; i<avatars.Count; i++)
        {
            File.AppendAllText(userPositionPath, Time.time.ToString() + " : " + i + " : " + avatars[i].gameObject.transform.position.x.ToString() + " : " + avatars[i].gameObject.transform.position.y.ToString() + " : " + avatars[i].gameObject.transform.position.z.ToString() + "\n");
        }
        
    }
}




