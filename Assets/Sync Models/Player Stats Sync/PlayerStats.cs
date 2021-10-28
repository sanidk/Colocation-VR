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

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        // Get a reference to the color sync component
        _playerStatsSync = GetComponent<PlayerStatsSync>();
        gameLogic = gameManager.GetComponent<GameLogic>();
        //_health = 100; this works and sets _health to 100 on connection/spawn

        if (Application.platform != RuntimePlatform.Android)
        {
            //Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!gameLogic._isRoundStarted)
        {
            _health = 100;
        }


        // If the color has changed (via the inspector), call SetColor on the color sync component.
        if (_health != _previousHealth)
        {
            _playerStatsSync.SetHealth(_health);
            _previousHealth = _health;
        }

        if (_energy != _previousEnergy) {
            _playerStatsSync.SetEnergy(_energy);
            _previousEnergy = _energy;
        }

        if (_isReady != _previousIsReady) {
            _playerStatsSync.SetIsReady(_isReady);
            _previousIsReady = _isReady;
        }

        if (_team != _previousTeam) {
            _playerStatsSync.SetTeam(_team);
            _previousTeam = _team;
        }

        if (_isServer != _previousIsServer)
        {
            _playerStatsSync.SetIsServer(_isServer);
            _previousIsServer = _isServer;
        }

    }
}