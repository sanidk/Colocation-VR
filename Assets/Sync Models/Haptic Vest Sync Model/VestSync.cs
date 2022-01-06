using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class VestSync : RealtimeComponent<VestSyncModel>
{
    private Vest _vest;

    private void Awake()
    {
        // Get a reference to the mesh renderer
        _vest = GetComponent<Vest>();
    }

    protected override void OnRealtimeModelReplaced(VestSyncModel previousModel, VestSyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.actuatorDidChange -= ActuatorDidChange;
            previousModel.timeDidChange -= TimeDidChange;

        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
            {
                currentModel.actuator = _vest._actuator;
                currentModel.time = _vest._time;
            }
                


            // Update the mesh render to match the new model
            UpdateActuator();
            UpdateTime();

            // Register for events so we'll know if the color changes later
            currentModel.actuatorDidChange += ActuatorDidChange;
            currentModel.timeDidChange += TimeDidChange;

        }
    }

    private void ActuatorDidChange(VestSyncModel model, int actuator)
    {
        // Update the mesh renderer
        UpdateActuator();
    }

    private void TimeDidChange(VestSyncModel model, int time)
    {
        // Update the mesh renderer
        UpdateTime();
    }

    private void UpdateActuator()
    {
        // Get the color from the model and set it on the mesh renderer.
        
        _vest._actuator = model.actuator;
        
    }

    private void UpdateTime()
    {
        // Get the color from the model and set it on the mesh renderer.

        _vest._time = model.time;
    }

    public void SetActuator(int actuator)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.

        model.actuator = actuator;
    }

    public void SetTime(int time)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.

        model.time = time;

    }
}