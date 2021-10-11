using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRotation : MonoBehaviour
{
    //[SerializeField]
    public Vector3 trackingRotOffset;
    //private Quaternion headRotation;
    private Transform thisTransform;

    private RotationSync _rotationSync; // Was RotationSync (not v2)

    //
    public Transform vrTarget;
    public Transform rigTarget;
    //

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
    void Update() // Dont do fixedUpdate!
    {
        //InverseRotationOfHead = Quaternion.Inverse(headConstraintTransform.rotation);
        //rotationOfTorso = Quaternion.Inverse(headConstraintTransform.rotation);
        //_rotationSync.SetRotation(InverseRotationOfHead);

        //thisTransform.rotation = thisTransform.rotation * Quaternion.Euler(trackingRotOffset);


        //transform.rotation = thisTransform.rotation;

        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
        //transform.rotation = rigTarget.rotation * Quaternion.Euler(trackingRotOffset);

        _rotationSync.SetRotation(transform.rotation);

    }
}
