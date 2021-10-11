using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBehaviour : MonoBehaviour
{
    private Vector3 originalPos;
    private Quaternion originalRot;

    private static bool shouldReset = false;

    void Start()
    {   
        originalPos = gameObject.transform.position;
        originalRot = gameObject.transform.rotation;
    }

    void Update()
    {
        if (shouldReset) {
            gameObject.transform.position = originalPos;
            gameObject.transform.rotation = originalRot;
            shouldReset = false;
        }
    }
}
