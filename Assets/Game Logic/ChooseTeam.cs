using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ChooseTeam : MonoBehaviour
{
    int team;
    bool isPressed;
    public GameObject playerReference;
    public GameObject gameReference;
    // Start is called before the first frame update
    void Start()
    {
        //playerReference = this.gameObject;
        gameReference = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];
            //Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));

            bool triggerValue;
            //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) // X button
            {

                isPressed = true;


            }
            else
            {
                isPressed = false;
            }

        }
        else if (rightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name);
        if (isPressed)
        {

            if (other.gameObject.name == "Team1")
            {
                //playerReference.GetComponent<PlayerBehaviour>().team = 1;
                team = 1;

            }

            if (other.gameObject.name == "Team2")
            {
                //playerReference.GetComponent<PlayerBehaviour>().team = 2;
                team = 2;

            }

            if (team != 0)
            {
                //Destroy(other.gameObject);
            }

        }


    }



}
