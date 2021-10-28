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
            previousModel.energyDidChange -= EnergyDidChange;
            previousModel.isReadyDidChange -= IsReadyDidChange;
            previousModel.teamDidChange -= TeamDidChange;
            previousModel.isServerDidChange -= IsServerDidChange;

        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel) {
                currentModel.health = _playerStats._health;
                currentModel.energy = _playerStats._energy;
                currentModel.isReady = _playerStats._isReady;
                currentModel.team = _playerStats._team;
                currentModel.isServer = _playerStats._isServer;
                }

            // Update the mesh render to match the new model
            UpdateHealth();
            UpdateEnergy();
            UpdateIsReady();
            UpdateTeam();
            UpdateIsServer();

            // Register for events so we'll know if the color changes later
            currentModel.healthDidChange += HealthDidChange;
            currentModel.energyDidChange += EnergyDidChange;
            currentModel.isReadyDidChange += IsReadyDidChange;
            currentModel.teamDidChange += TeamDidChange;
            currentModel.isServerDidChange += IsServerDidChange;
        }
    }

    private void HealthDidChange(PlayerStatsSyncModel model, float value)
    {
        // Update the mesh renderer
        UpdateHealth();
    }

    private void EnergyDidChange(PlayerStatsSyncModel model, float value) 
    {
        UpdateEnergy();
    }

    private void IsReadyDidChange(PlayerStatsSyncModel model, bool value) 
    {
        UpdateIsReady();
    }

    private void TeamDidChange(PlayerStatsSyncModel model, int value) 
    {
        UpdateTeam();
    }

    private void IsServerDidChange(PlayerStatsSyncModel model, bool value)
    {
        UpdateIsServer();
    }



    private void UpdateHealth()
    {
        // Get the color from the model and set it on the mesh renderer.
        //_meshRenderer.material.color = model.color;

        _playerStats._health = model.health;
    }

    private void UpdateEnergy() {
        _playerStats._energy = model.energy;
    }

    private void UpdateIsReady() {
        _playerStats._isReady = model.isReady;
    }

    private void UpdateTeam() {
        _playerStats._team = model.team;
    }

    private void UpdateIsServer()
    {
        _playerStats._isServer = model.isServer;
    }




    public void SetHealth(float health)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        model.health = health;
    }

    public void SetEnergy(float energy) {

        model.energy = energy;

    }

    public void SetIsReady(bool isReady) {
        model.isReady = isReady;
    }

    public void SetTeam(int team) {
        model.team = team;
    }

    public void SetIsServer(bool isServer)
    {
        model.isServer = isServer;
    }




}
