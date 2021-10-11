using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPosAndRot : MonoBehaviour
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPosOffset;
    public Vector3 trackingRotOffset;

    private PositionSync _objectPos;


    private RotationSync _objectRot;


    private void Awake()
    {
        _objectPos = GetComponent<PositionSync>();
        _objectRot = GetComponent<RotationSync>();

    }

    private void Update()
    {
        MapPosition();
        MapRotation();
    }


    public void MapPosition()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPosOffset);
        //rigTarget.position = vrTarget.position + trackingPosOffset;
        _objectPos.SetPosition(rigTarget.position);
    }


    public void MapRotation()
    {
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
        _objectRot.SetRotation(rigTarget.rotation);

    }
}
