using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    public float distance = 10;
    public float angle = 10;
    public float height = 10;
    public Color meshColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

        int numTriangules = 8;
        int numVertices = numTriangules * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangules = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up *height;
        Vector3 topLeft =  bottomLeft + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;

        int vert = 0;
    }*/
}
