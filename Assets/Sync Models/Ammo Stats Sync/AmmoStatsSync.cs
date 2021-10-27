using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class AmmoStatsSync : RealtimeComponent<AmmoStatsSyncModel> {

    private AmmoStats _ammoStats;

    void Awake() {
        _ammoStats = GetComponent<AmmoStats>(); 
    }

    protected override void OnRealtimeModelReplaced(AmmoStatsSyncModel previousModel, AmmoStatsSyncModel currentModel) {
        
        if (previousModel != null) {
            previousModel.ammoDidChange -= AmmoDidChange;
        }

        if (currentModel != null) {
            if (currentModel.isFreshModel) {
                currentModel.ammo = _ammoStats._ammo;
            }

            UpdateAmmo();

            currentModel.ammoDidChange += AmmoDidChange;
        }
    }

    private void AmmoDidChange(AmmoStatsSyncModel model, int value) {
        UpdateAmmo();
    }

    private void UpdateAmmo() {
        _ammoStats._ammo = model.ammo;
    }

    public void SetAmmo(int ammo) {
        model.ammo = ammo; 
    }
}
