using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public float _health = default;
    public float _previousHealth = default;

    [SerializeField]
    public float _energy = default;
    public float _previousEnergy = default;

    [SerializeField]
    public bool _isReady = default;
    public bool _previousIsReady = default;

    [SerializeField]
    public int _team = default;
    public int _previousTeam = default;

    [SerializeField]
    public bool _isServer = default;
    public bool _previousIsServer = default;

    public PlayerStatsSync _playerStatsSync;
    GameLogic gameLogic;
    public GameObject gameManager;
    GameManagerLogic gameManagerLogic;

    private Material healthShaderMat;
    private int childIndexDisplay = 0;
    private float convertedHealth;
    private float convertedHealthColor;
    public GameObject watch;

    //HUSK VI HAR UNCOMMENTET I LINIE 86

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        // Get a reference to the color sync component
        _playerStatsSync = GetComponent<PlayerStatsSync>();
        gameLogic = gameManager.GetComponent<GameLogic>();
        gameManagerLogic = gameManager.GetComponent<GameManagerLogic>();
        //healthShaderMat = transform.GetChild(childIndexDisplay).GetChild(childIndexDisplay).GetComponent<MeshRenderer>().material;
        healthShaderMat = watch.GetComponent<MeshRenderer>().material;

        _health = 100;
        

        //_health = 100; this works and sets _health to 100 on connection/spawn

        if (Application.platform != RuntimePlatform.Android)
        {
            //Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        convertedHealth = Remap(_health, 0, 100, 5, 0);
        healthShaderMat.SetFloat("_ConvHealth", Remap(_health, 0, 100, 0, 1));
        healthShaderMat.SetFloat("_RemovedSegments", convertedHealth);

        //_health = _playerStatsSync.GetHealth();

        /*
        if (!gameLogic._isRoundStarted)
        {
            _health = 100;

        }
        */
        if (!gameManagerLogic.isServer)
        {
            //_health = _playerStatsSync.GetHealth();
            return;
        }


        _playerStatsSync.SetHealth(_health);

        //if (!gameManagerLogic.isServer) return;




        // If the color has changed (via the inspector), call SetColor on the color sync component.
        /*
        if (_health != _previousHealth)
        {
            _playerStatsSync.SetHealth(_health);
            _previousHealth = _health;
        }
        */

        if (_energy != _previousEnergy)
        {
            _playerStatsSync.SetEnergy(_energy);
            _previousEnergy = _energy;
        }

        if (_isReady != _previousIsReady)
        {
            _playerStatsSync.SetIsReady(_isReady);
            _previousIsReady = _isReady;
        }

        if (_team != _previousTeam)
        {
            _playerStatsSync.SetTeam(_team);
            _previousTeam = _team;
        }

        if (_isServer != _previousIsServer)
        {
            _playerStatsSync.SetIsServer(_isServer);
            //gameManagerLogic.isServer = _isServer;
            _previousIsServer = _isServer;
        }

    }

    // Remap function taken from unity forum
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}