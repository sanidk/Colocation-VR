using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerStatsSync : RealtimeComponent<PlayerStatsSyncModel>
{
    //private MeshRenderer _meshRenderer;
    private PlayerStats _playerStats;

    private void Awake()
    {
        // Get a reference to the mesh renderer
        //_meshRenderer = GetComponent<MeshRenderer>();


        //Get reference to script containing player stats
        _playerStats = GetComponent<PlayerStats>();
    }

    protected override void OnRealtimeModelReplaced(PlayerStatsSyncModel previousModel, PlayerStatsSyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.healthDidChange -= HealthDidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
                currentModel.health = _playerStats._health;

            // Update the mesh render to match the new model
            UpdateHealth();

            // Register for events so we'll know if the color changes later
            currentModel.healthDidChange += HealthDidChange;
        }
    }

    private void HealthDidChange(PlayerStatsSyncModel model, float value)
    {
        // Update the mesh renderer
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        // Get the color from the model and set it on the mesh renderer.
        //_meshRenderer.material.color = model.color;

        _playerStats._health = model.health;
    }

    public void SetHealth(float health)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        model.health = health;
    }
}
