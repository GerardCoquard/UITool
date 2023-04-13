using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDistance : MonoBehaviour
{
    private void Awake() {
        DisableAllMeshes();
        SetMeshRendering(GetComponent<Collider>(),false);
    }
    private void OnTriggerEnter(Collider other) {
        SetMeshRendering(other,false);
    }
    private void OnTriggerExit(Collider other) {
        SetMeshRendering(other,true);
    }
    void SetMeshRendering(Collider coll,bool state)
    {
        MeshRenderer mesh = coll.GetComponent<MeshRenderer>();
        if(mesh!=null) mesh.forceRenderingOff = state;
    }
    void DisableAllMeshes()
    {
        MeshRenderer[] meshes = FindObjectsOfType<MeshRenderer>();
        foreach (MeshRenderer mesh in meshes)
        {
            mesh.forceRenderingOff = true;
        }
    }
}
