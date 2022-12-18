using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducSpawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> sellPoints;
    [SerializeField]
    List<GameObject> productPrefab;
    [SerializeField]
    private int cantProduct;

    public void Start()
    {
        producSpawner();
    }
    public void producSpawner()
    {
        for(int i = 0; i < cantProduct; i++)
        {

            GameObject product = Instantiate(productPrefab[Random.Range(0, productPrefab.Count)], sellPoints[(int)Random.value * sellPoints.Count].position,Quaternion.identity,transform);
            
        }
    }
}
