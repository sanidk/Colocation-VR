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
    void FixedUpdate()
    {
        LocomotionControl();
    }

    void LocomotionControl()
    {

        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        Vector2 triggerValue = new Vector2();
        float scalar = 1f;

        if (!isVerticalLocked)
        {
            headRotationVerticalVector = new Vector3(head.transform.forward.x, 0, head.transform.forward.z);
        }

        if (!isHorizontalLocked)
        {
            headRotationHorizontalVector = new Vector3(head.transform.forward.x, 0, 0);
        }

        foreach (var device in inputDevices)
        {
            //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out triggerValue))
            //{ 

            //}

            

            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out triggerValue))
            {
                //HORIZONTAL
                if (triggerValue.x > 0.1)
                {
                    isHorizontalLocked = true;
                    transform.position += headRotationHorizontalVector * triggerValue.x * scalar * Time.deltaTime;

                }
                else if (triggerValue.x < -0.1)
                {
                    isHorizontalLocked = true;
                    transform.position += headRotationHorizontalVector * triggerValue.x * scalar * Time.deltaTime;
                }
                else
                {
                    isHorizontalLocked = false;
                }


                //VERTICAL
                if (triggerValue.y > 0.1)
                {
                    isVerticalLocked = true;
                    transform.position += headRotationVerticalVector * triggerValue.y * scalar * Time.deltaTime;

                } else if (triggerValue.y < -0.1)
                {
                    isVerticalLocked = true;
                    transform.position += headRotationVerticalVector * triggerValue.y * scalar * Time.deltaTime;
                } else
                {
                    isVerticalLocked = false;
                }
            

            }
        }

        //DebuggerVR.debuggingString = triggerValue.ToString();
    }
}
