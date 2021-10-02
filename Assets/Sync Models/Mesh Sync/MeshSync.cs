
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

public class MeshSync : RealtimeComponent<MeshSyncModel>
{
    private MeshGenerator _meshGenerator;

    private void Awake()
    {
        _meshGenerator = GetComponent<MeshGenerator>();
    }
    protected override void OnRealtimeModelReplaced(MeshSyncModel previousModel, MeshSyncModel currentModel)
    {
        //base.OnRealtimeModelReplaced(previousModel, currentModel);
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.boxCornerPosition1DidChange -= Vertice1DidChange;
            previousModel.boxCornerPosition2DidChange -= Vertice2DidChange;
            previousModel.boxCornerPosition3DidChange -= Vertice3DidChange;
            previousModel.boxCornerPosition4DidChange -= Vertice4DidChange;
            previousModel.boxCornerPosition5DidChange -= Vertice5DidChange;
            previousModel.boxCornerPosition6DidChange -= Vertice6DidChange;
            previousModel.boxCornerPosition7DidChange -= Vertice7DidChange;
            previousModel.boxCornerPosition8DidChange -= Vertice8DidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
            currentModel.boxCornerPosition1 = _meshGenerator.vertices[0];
            currentModel.boxCornerPosition2 = _meshGenerator.vertices[1];
            currentModel.boxCornerPosition3 = _meshGenerator.vertices[2];
            currentModel.boxCornerPosition4 = _meshGenerator.vertices[3];
            currentModel.boxCornerPosition5 = _meshGenerator.vertices[4];
            currentModel.boxCornerPosition6 = _meshGenerator.vertices[5];
            currentModel.boxCornerPosition7 = _meshGenerator.vertices[6];
            currentModel.boxCornerPosition8 = _meshGenerator.vertices[7];


            /*
        currentModel.boxCornerPosition1 = GetComponent<MeshFilter>().mesh.vertices[0];
        currentModel.boxCornerPosition2 = GetComponent<MeshFilter>().mesh.vertices[1];
        currentModel.boxCornerPosition3 = GetComponent<MeshFilter>().mesh.vertices[2];
        currentModel.boxCornerPosition4 = GetComponent<MeshFilter>().mesh.vertices[3];
        currentModel.boxCornerPosition5 = GetComponent<MeshFilter>().mesh.vertices[4];
        currentModel.boxCornerPosition6 = GetComponent<MeshFilter>().mesh.vertices[5];
        currentModel.boxCornerPosition7 = GetComponent<MeshFilter>().mesh.vertices[6];
        currentModel.boxCornerPosition8 = GetComponent<MeshFilter>().mesh.vertices[7];
        */
            /*
            if (previousModel != null)
            {
                currentModel.boxCornerPosition1 = previousModel.boxCornerPosition1;
                currentModel.boxCornerPosition2 = previousModel.boxCornerPosition2;
                currentModel.boxCornerPosition3 = previousModel.boxCornerPosition3;
                currentModel.boxCornerPosition4 = previousModel.boxCornerPosition4;
                currentModel.boxCornerPosition5 = previousModel.boxCornerPosition5;
                currentModel.boxCornerPosition6 = previousModel.boxCornerPosition6;
                currentModel.boxCornerPosition7 = previousModel.boxCornerPosition7;
                currentModel.boxCornerPosition8 = previousModel.boxCornerPosition8;
            } else
            {
                currentModel.boxCornerPosition1 = _meshGenerator.vertices[0];
                currentModel.boxCornerPosition2 = _meshGenerator.vertices[1];
                currentModel.boxCornerPosition3 = _meshGenerator.vertices[2];
                currentModel.boxCornerPosition4 = _meshGenerator.vertices[3];
                currentModel.boxCornerPosition5 = _meshGenerator.vertices[4];
                currentModel.boxCornerPosition6 = _meshGenerator.vertices[5];
                currentModel.boxCornerPosition7 = _meshGenerator.vertices[6];
                currentModel.boxCornerPosition8 = _meshGenerator.vertices[7];
            }
            */



            // Update the mesh render to match the new model
            UpdateMeshVertices();
            

            // Register for events so we'll know if the color changes later
            currentModel.boxCornerPosition1DidChange += Vertice1DidChange;
            currentModel.boxCornerPosition2DidChange += Vertice2DidChange;
            currentModel.boxCornerPosition3DidChange += Vertice3DidChange;
            currentModel.boxCornerPosition4DidChange += Vertice4DidChange;
            currentModel.boxCornerPosition5DidChange += Vertice5DidChange;
            currentModel.boxCornerPosition6DidChange += Vertice6DidChange;
            currentModel.boxCornerPosition7DidChange += Vertice7DidChange;
            currentModel.boxCornerPosition8DidChange += Vertice8DidChange;

            
            
        }

    }

    

    private void Vertice1DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }
    private void Vertice2DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }
    private void Vertice3DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }
    private void Vertice4DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }
    private void Vertice5DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }
    private void Vertice6DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }
    private void Vertice7DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }
    private void Vertice8DidChange(MeshSyncModel model, Vector3 value)
    {
        // Update the mesh renderer
        UpdateMeshVertices();
    }

    /*
    private void UpdateMeshVertice1()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[0] = model.boxCornerPosition1;
        _meshGenerator.UpdateMesh();
    }
    private void UpdateMeshVertice2()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[1] = model.boxCornerPosition2;
        _meshGenerator.UpdateMesh();
    }
    private void UpdateMeshVertice3()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[2] = model.boxCornerPosition3;
        _meshGenerator.UpdateMesh();
    }
    private void UpdateMeshVertice4()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[3] = model.boxCornerPosition4;
        _meshGenerator.UpdateMesh();
    }
    private void UpdateMeshVertice5()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[4] = model.boxCornerPosition5;
        _meshGenerator.UpdateMesh();
    }
    private void UpdateMeshVertice6()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[5] = model.boxCornerPosition6;
        _meshGenerator.UpdateMesh();
    }
    private void UpdateMeshVertice7()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[6] = model.boxCornerPosition7;
        _meshGenerator.UpdateMesh();
    }
    private void UpdateMeshVertice8()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshGenerator.vertices[7] = model.boxCornerPosition8;
        _meshGenerator.UpdateMesh();
    }
    */

    private void UpdateMeshVertices()
    {
        /*
        _meshGenerator.vertices[0] = model.boxCornerPosition1;
        _meshGenerator.vertices[1] = model.boxCornerPosition2;
        _meshGenerator.vertices[2] = model.boxCornerPosition3;
        _meshGenerator.vertices[3] = model.boxCornerPosition4;
        _meshGenerator.vertices[4] = model.boxCornerPosition5;
        _meshGenerator.vertices[5] = model.boxCornerPosition6;
        _meshGenerator.vertices[6] = model.boxCornerPosition7;
        _meshGenerator.vertices[7] = model.boxCornerPosition8;
        */

        Vector3[] vertices = new Vector3[]
        {
            model.boxCornerPosition1,
            model.boxCornerPosition2,
            model.boxCornerPosition3,
            model.boxCornerPosition4,
            model.boxCornerPosition5,
            model.boxCornerPosition6,
            model.boxCornerPosition7,
            model.boxCornerPosition8
        };


        _meshGenerator.UpdateMesh(vertices);







    }

    public void SetMesh(Vector3[] vertices)
    {
        model.boxCornerPosition1 = vertices[0];
        model.boxCornerPosition2 = vertices[1];
        model.boxCornerPosition3 = vertices[2];
        model.boxCornerPosition4 = vertices[3];
        model.boxCornerPosition5 = vertices[4];
        model.boxCornerPosition6 = vertices[5];
        model.boxCornerPosition7 = vertices[6];
        model.boxCornerPosition8 = vertices[7];


    }

}
