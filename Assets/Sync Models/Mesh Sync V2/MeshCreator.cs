using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    Mesh mesh;
    private GameObject meshObjectPrefab;
    Vector3[] vertices;
    int [] triangles = new int[]
        {
            //TOP
            0, 1, 2,
            1, 3, 2,

            //BACK
            0, 6, 4,
            0, 2, 6,

            //RIGHT
            6, 2, 7,
            2, 3, 7,

            //BACK
            7, 1, 5,
            7, 3, 1,

            //LEFT
            5, 1, 0,
            5, 0, 4,

            //BOTTOM
            6, 7, 5,
            6, 5, 4,

        };

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mesh CreateMesh()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();


        GetComponent<MeshCollider>().sharedMesh = mesh;
        return mesh;
    }

    public void CreateMeshObject()
    {

    }

}


