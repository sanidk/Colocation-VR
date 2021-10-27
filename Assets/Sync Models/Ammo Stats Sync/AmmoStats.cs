using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoStats : MonoBehaviour
{
    [SerializeField]
    public int _ammo = default;
    public int _previousAmmo = default; 

    public AmmoStatsSync _ammoStatsSync;

    private void Awake() {
        _ammoStatsSync = GetComponent<AmmoStatsSync>();
    }

    private void Update() {
        if (_ammo != _previousAmmo) {
            _ammoStatsSync.SetAmmo(_ammo);
            _previousAmmo = _ammo; 
        }
    }
}
