﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform TargetPoint;
    public Camera CameraLink;
    public float TargetInSkyDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            TargetPoint.position = hit.point;
        }
        else
        {
            TargetPoint.position = ray.GetPoint(TargetInSkyDistance);
        }

        transform.LookAt(TargetPoint.position);
    }
}
