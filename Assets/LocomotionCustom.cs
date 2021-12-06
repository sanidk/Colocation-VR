using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionCustom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject head;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LocomotionControl();
    }

    void LocomotionControl()
    {

        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        Vector2 triggerValue = new Vector2();
        float scalar = 0.025f;

        foreach (var device in inputDevices)
        {
            //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out triggerValue))
            //{ 
            
            //}

            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out triggerValue))
            {

            if (triggerValue.x > 0)
            {
                transform.position = new Vector3(transform.position.x + (triggerValue.x * scalar), transform.position.y, transform.position.z);
                //transform.position += Vector3.right;

            }
            if (triggerValue.x < 0)
            {
                transform.position = new Vector3(transform.position.x + (triggerValue.x * scalar), transform.position.y, transform.position.z);

            }

            if (triggerValue.y > 0)
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.forward.z + (triggerValue.y * scalar));
                //Vector3 normalized = head.transform.rotation.eulerAngles.normalized;

                Vector3 headRotationVector = new Vector3(head.transform.forward.x, 0, head.transform.forward.z);
                transform.position += headRotationVector * triggerValue.y*scalar;

            }
            if (triggerValue.y < 0)
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.forward.z + (triggerValue.y * scalar));
                Vector3 headRotationVector = new Vector3(head.transform.forward.x, 0, head.transform.forward.z);
                transform.position += headRotationVector * triggerValue.y * scalar;

            }

        }
        }

        //DebuggerVR.debuggingString = triggerValue.ToString();
    }
}
