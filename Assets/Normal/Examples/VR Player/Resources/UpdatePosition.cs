using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour
{

    public Vector3 trackingPosOffset;
    //
    public Transform vrTarget;
    public Transform rigTarget;
    //

    private Transform thisTransform;

    private PositionSync _positionSync; // was PositionSync (and not V2)

    private void Awake()
    {

        _positionSync = GetComponent<PositionSync>();
        //thisTransform = GetComponent<Transform>();
    }

    void Update() // Dont do fixedUpdate!
    {
        //thisTransform.position = thisTransform.position + trackingPosOffset;

        //transform.position = transform.position + trackingPosOffset;

        //
        rigTarget.position = vrTarget.TransformPoint(trackingPosOffset);
        //

        _positionSync.SetPosition(rigTarget.position);
    }
}
