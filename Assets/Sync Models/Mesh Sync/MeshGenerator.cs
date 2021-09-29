using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    [SerializeField]
    public Vector3[] vertices;
    public Vector3[] previousVertices;

    private MeshSync _meshSync;

    public int[] triangles;
    Mesh mesh;

    private void Awake()
    {
        _meshSync = GetComponent<MeshSync>();


        triangles = new int[]
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

        //UpdateMesh();
        
    }

    private void Update()
    {
        // If the color has changed (via the inspector), call SetColor on the color sync component.

        if (vertices != previousVertices)
        {
            _meshSync.SetMesh(vertices);
            previousVertices = vertices;
        }

    }
    public void UpdateMesh(Vector3 [] vertices)
    {
        
        //mesh.Clear();

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        

        GetComponent<MeshCollider>().sharedMesh = mesh;
 
    }
}
