using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public PlayerStatsSync _playerStatsSync;

    private void Awake()
    {
        // Get a reference to the color sync component
        _playerStatsSync = GetComponent<PlayerStatsSync>();
    }

    private void Update()
    {
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

    }
}