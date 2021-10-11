using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatePosAndRot : MonoBehaviour
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPosOffset;
    public Vector3 trackingRotOffset;
    //private Quaternion headRotation;
    private Transform thisTransform;

    private RotationSync _rotationSync;
    private PositionSync _positionSync;

  
    private void Awake()
    {
        //rotationOfTorso = GetComponent<Transform>().rotation;
        //headRotation = GetComponent<Transform>().rotation;
        _rotationSync = GetComponent<RotationSync>();
        _positionSync = GetComponent<PositionSync>();
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() // Dont do fixedUpdate!
    {

        //InverseRotationOfHead = Quaternion.Inverse(headConstraintTransform.rotation);
        //rotationOfTorso = Quaternion.Inverse(headConstraintTransform.rotation);
        //_rotationSync.SetRotation(InverseRotationOfHead);

        //thisTransform.rotation = thisTransform.rotation * Quaternion.Euler(trackingRotOffset);
        //transform.rotation = thisTransform.rotation;

        rigTarget.position = vrTarget.TransformPoint(trackingPosOffset);
        //_positionSync.SetPosition(rigTarget.position);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
        //_rotationSync.SetRotation(rigTarget.rotation);

        _positionSync.SetPosition(rigTarget.position);
        _rotationSync.SetRotation(rigTarget.rotation);
        

    }
}
