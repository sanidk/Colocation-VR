using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTorsoPosition : MonoBehaviour
{
    public Transform headConstraintTransform;
    public Vector3 trackingPosOffset;
    private Vector3 headBodyOffset;
    private Vector3 bodyPos;

    private PositionSync _positionSync; //private PositionSync _positionSync; (<<--WAS)


    private void Awake()
    {

        _positionSync = GetComponent<PositionSync>();
        headBodyOffset = transform.position - headConstraintTransform.position;

    }


    // Update is called once per frame
    private void Update()
    {
        //headBodyOffset = transform.position - headConstraintTransform.position;
        bodyPos = headConstraintTransform.position + headBodyOffset + trackingPosOffset;

        _positionSync.SetPosition(bodyPos);

    }
}
