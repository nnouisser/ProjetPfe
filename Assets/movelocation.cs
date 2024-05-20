using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movelocation : MonoBehaviour
{
    Vector3 EndPoint;

    void Start()
    {
        EndPoint = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, EndPoint, 0.2f);
    }

    public void NewPoint(Vector3 n)
    {
        EndPoint = n;
    }
}
