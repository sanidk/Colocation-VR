using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class HPSync : RealtimeComponent<HPSyncModel>
{
    private int _hp = 100;

    private void Awake()
    {
        //_playerHitbox = GetComponentInChildren<BoxCollider>();  
    }

    protected override void OnRealtimeModelReplaced(HPSyncModel previousModel, HPSyncModel currentModel)
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

    public void setHp(int hp)
    {
        model.hp = hp;
    }

    private void HpDidChange(HPSyncModel model, int value)
    {
        UpdatePlayerHP();
    }

    public void hitOnceMinus20Hp()
    {
        _hp -= 20;
        UpdatePlayerHP();
    }

    public int GetHpModel()
    {
        return model.hp;
    }


    public int GetHp()
    {
        return _hp;
    }

    public int GetHpIf()
    {
        if (_hp != model.hp)
        {
            print("_hp and model.hp is not the same in PlayerStatsSync");
            return -10000;
        }
        else
        {
            return _hp;
        }
    }
}
