using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacerMgr : MonoBehaviour
{
    public GameObject solarSystem;
    public TouchMgr touchMgr;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            //레이캐스팅
            if (raycastManager.Raycast(touch.position, hits, TrackableType.All))
            {
                GameObject obj = Instantiate(solarSystem, hits[0].pose.position, hits[0].pose.rotation);
                touchMgr.targetTr = obj.transform;
                this.enabled = false;
            }
        }
    }
}
