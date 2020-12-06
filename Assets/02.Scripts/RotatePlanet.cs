using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public Transform targetTr;
    public float rotateSpeed = 10.0f;

    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();        
    }

    // Update is called once per frame
    void Update()
    {
        tr.RotateAround(targetTr.position, Vector3.up, Time.deltaTime * rotateSpeed);
    }
}
