using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionCustom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject head;
    bool isVerticalLocked;
    bool isHorizontalLocked;
    Vector3 headRotationVerticalVector;
    Vector3 headRotationHorizontalVector;

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

                //if (triggerValue.x > 0)
                //{

                //        Vector3 headRotationVector = new Vector3(head.transform.forward.x, 0, 0);
                //        transform.position += headRotationVector * triggerValue.y * scalar;

                //}
                //if (triggerValue.x < 0)
                //{

                //        Vector3 headRotationVector = new Vector3(head.transform.forward.x, 0, 0);
                //        transform.position += headRotationVector * triggerValue.y * scalar;
                //}

                if (!isHorizontalLocked)
                {
                    headRotationHorizontalVector = new Vector3(head.transform.forward.x, 0, 0);
                }
                if (triggerValue.y > 0)
                {
                    isHorizontalLocked = true;
                    transform.position += headRotationHorizontalVector * scalar;

                }
                else if (triggerValue.y < 0)
                {
                    isHorizontalLocked = true;
                    transform.position -= headRotationHorizontalVector * scalar;
                }
                else
                {
                    isHorizontalLocked = false;
                }


                if (!isVerticalLocked)
                {
                    headRotationVerticalVector = new Vector3(head.transform.forward.x, 0, head.transform.forward.z);
                }
                if (triggerValue.y > 0)
                {
                    isVerticalLocked = true;

                 
                    transform.position += headRotationVerticalVector*scalar;

                } else if (triggerValue.y < 0)
                {
                    isVerticalLocked = true;
                    transform.position -= headRotationVerticalVector * scalar;
                }
                else
                {
                    isVerticalLocked = false;
                }
            

            }
        }

        //DebuggerVR.debuggingString = triggerValue.ToString();
    }
}
