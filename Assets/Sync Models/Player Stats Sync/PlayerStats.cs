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
    public int _ammo = default;
    public int _previousAmmo = default;

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
    }
}
