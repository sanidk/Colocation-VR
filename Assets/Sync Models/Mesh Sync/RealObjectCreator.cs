using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Normal.Realtime;

public class RealObjectCreator : MonoBehaviour
{
    GameObject meshGeneratorObject;
    public GameObject meshGeneratorPrefab;

    bool waitingForSpawnPointsSelection;

    public GameObject boxPointPrefab;

    List<GameObject> boxPointsArray = new List<GameObject>();


    protected MeshFilter meshFilter;
    protected Mesh mesh;

    bool isButtonPressable = true;

    // Update is called once per frame
    void Update()
    {
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = leftHandDevices[0];
            //Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));

            bool triggerValue;
            //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue) // X button
            {
                
                Debug.Log("Trigger button is pressed.");
                //test.SetActive(false);

                if (isButtonPressable)
                {
                    GameObject go = Instantiate(boxPointPrefab, transform.position, transform.rotation);
                    boxPointsArray.Add(go);

                }

                isButtonPressable = false;

            } else
            {
                isButtonPressable = true;
            }
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        /*
        if (!waitingForSpawnPointsSelection && boxPointsArray.Count == 1)
        {
            //GameObject meshGeneratorObject = Instantiate(meshGeneratorPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            meshGeneratorObject = Realtime.Instantiate("MeshGenerator", new Vector3(0, 0, 0), Quaternion.identity);
            waitingForSpawnPointsSelection = true;
        }
        */

        if (boxPointsArray.Count == 4)
        {
            //waitingForSpawnPointsSelection = false;

            meshGeneratorObject = Realtime.Instantiate("MeshGenerator", new Vector3(0, 0, 0), Quaternion.identity, ownedByClient: false);
            //meshGeneratorObject = Instantiate(meshGeneratorPrefab, new Vector3(0, 0, 0), Quaternion.identity);



            Vector3[] vertices = new Vector3[8]
            {
                
                boxPointsArray[0].transform.position,
                boxPointsArray[1].transform.position,
                boxPointsArray[2].transform.position,
                boxPointsArray[3].transform.position,

                new Vector3(boxPointsArray[0].transform.position.x, 0, boxPointsArray[0].transform.position.z),
                new Vector3(boxPointsArray[1].transform.position.x, 0, boxPointsArray[1].transform.position.z),
                new Vector3(boxPointsArray[2].transform.position.x, 0, boxPointsArray[2].transform.position.z),
                new Vector3(boxPointsArray[3].transform.position.x, 0, boxPointsArray[3].transform.position.z)



            };


            meshGeneratorObject.GetComponent<MeshGenerator>().vertices = vertices;
            //meshGeneratorObject.GetComponent<MeshGenerator>().triangles = triangles;
            //meshGeneratorObject.GetComponent<MeshGenerator>().initiateMesh = true;

            //meshGeneratorObject.AddComponent<MeshCollider>();
            //meshGeneratorObject.GetComponent<MeshCollider>().convex = true;
            

            //meshGeneratorObject.AddComponent<RealtimeView>();
            //meshGeneratorObject.AddComponent<RealtimeTransform>();

            foreach (GameObject obj in boxPointsArray){
                Destroy(obj);
            }
            boxPointsArray.Clear();
        }

        

        /*
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));

            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                isButtonPressable = false;
                Debug.Log("Trigger button is pressed.");
                //test.SetActive(false);



                GameObject go = Instantiate(boxPointPrefab, transform.position, transform.rotation);
                boxPointsArray.Add(go);


            }
        }
        */
    }

    void CreateShape(Vector3[] vertices, int[] triangles)
    {
        vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1)
        };

        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2

        };
    }
}
