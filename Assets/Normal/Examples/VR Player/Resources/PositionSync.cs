using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PositionSync : RealtimeComponent<PositionSyncModel>
{
    //private Vector3 _position;
    private Transform _transform;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        //_position = GetComponent<Transform>().position;
    }

    protected override void OnRealtimeModelReplaced(PositionSyncModel previousModel, PositionSyncModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.positionDidChange -= PositionDidChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
                currentModel.position = _transform.position;

            // Update the mesh render to match the new model
            UpdatePosition();

            // Register for events so we'll know if the color changes later
            currentModel.positionDidChange += PositionDidChange;
        }
    }

    private void UpdatePosition()
    {
        //_position = model.position;
        _transform.position = model.position;
    }

    private void PositionDidChange(PositionSyncModel model, Vector3 value)
    {
        UpdatePosition();
    }

    public void SetPosition(Vector3 pos)
    {
        model.position = pos;
        //_transform.position = pos;
    }
}
