using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMeshGenerator : MonoBehaviour
{
    [SerializeField]Material spike_mat;
    [SerializeField]float width = 1;
    [SerializeField]float height = 3;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter spike_meshfilter = GetComponent<MeshFilter>();

        Mesh spike_mesh = new Mesh();

        Vector3[] vertices = new Vector3[3] {new Vector3(0, height), new Vector3(width, 0), new Vector3(-width, 0)};

        spike_mesh.vertices = vertices;

        spike_mesh.triangles = new int[] {0, 1, 2};

        GetComponent<MeshRenderer>().material = spike_mat;
        spike_meshfilter.mesh = spike_mesh;
    }
}
