using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class RotationSync : RealtimeComponent<RotationSyncModel>
{
    //private Quaternion _rotation;
    private Transform _transform;


    private void Awake()
    {
        //_rotation = GetComponent<Transform>().rotation;
        _transform = GetComponent<Transform>();
    }

    protected override void OnRealtimeModelReplaced(RotationSyncModel previousModel, RotationSyncModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.rotationDidChange -= RotationDidChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
                currentModel.rotation = transform.rotation;

            // Update the mesh render to match the new model
            UpdateRotation();

            // Register for events so we'll know if the color changes later
            currentModel.rotationDidChange += RotationDidChange;
        }
    }

    private void UpdateRotation()
    {
        _transform.rotation = model.rotation;
    }

    private void RotationDidChange(RotationSyncModel model, Quaternion value)
    {
        UpdateRotation();
    }

    public void SetRotation(Quaternion rotation)
    {
        model.rotation = rotation;
        //_transform.rotation = rotation;
    }
}
