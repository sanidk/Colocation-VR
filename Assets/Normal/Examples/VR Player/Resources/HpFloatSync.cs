using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class HpFloatSync : RealtimeComponent<HpFloatSyncModel>
{
    private float _hp;

    protected override void OnRealtimeModelReplaced(HpFloatSyncModel previousModel, HpFloatSyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.hpDidChange -= HpDidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
                currentModel.hp = _hp;

            // Update the mesh render to match the new model
            UpdatePlayerHP();

            // Register for events so we'll know if the color changes later
            currentModel.hpDidChange += HpDidChange;
        }
    }

    private void UpdatePlayerHP()
    {
        _hp = model.hp;
    }

    public void setHp(float hp)
    {
        model.hp = hp;
    }

    private void HpDidChange(HpFloatSyncModel model, float value)
    {
        UpdatePlayerHP();
    }

    public void hitOnceMinus20Hp()
    {
        _hp -= 20;
        UpdatePlayerHP();
    }

    public float GetHp()
    {
        return _hp;
    }
}
