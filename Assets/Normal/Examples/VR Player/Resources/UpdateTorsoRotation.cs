using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTorsoRotation : MonoBehaviour
{   
    public Transform headTransform;

    private RotationSync _rotationSync;

    public float smooth = 5.0f;

    private Transform thisTransform;

    private Vector3 partialRotationOfHead;

    //private Quaternion InverseRotationOfHead;
    //private Quaternion rotationOfTorso;
    // Start is called before the first frame update
    private void Awake()
    {
        //rotationOfTorso = GetComponent<Transform>().rotation;
        //headRotation = GetComponent<Transform>().rotation;
        _rotationSync = GetComponent<RotationSync>();
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        partialRotationOfHead = headTransform.rotation.eulerAngles * 0.5f;
        //partialRotationOfHead.y = partialRotationOfHead.y * 0.1f;

        //InverseRotationOfHead = Quaternion.Inverse(headConstraintTransform.rotation);
        //rotationOfTorso = Quaternion.Inverse(headConstraintTransform.rotation);
        //_rotationSync.SetRotation(InverseRotationOfHead);

        //headTransform.rotation = headTransform.rotation * Quaternion.Euler(trackingRotOffset);

        transform.rotation = Quaternion.Euler(partialRotationOfHead);

        //transform.rotation = headTransform.rotation;
        //transform.rotation = Quaternion.Slerp(transform.rotation,headTransform.rotation,Time.deltaTime*smooth);

        //thisTransform.rotation = headTransform.rotation;
        //print(thisTransform);

        _rotationSync.SetRotation(transform.rotation);

    }
}
