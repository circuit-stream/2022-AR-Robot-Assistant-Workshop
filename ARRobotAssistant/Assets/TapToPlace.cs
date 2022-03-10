using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapToPlace : MonoBehaviour
{
    public GameObject robotPrefab;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARRaycastManager raycastManager;

    private GameObject spawnedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnedPrefab == null)
        {
            // detecting a touch on the screen
            if (Input.touchCount > 0)
            {
                // raycasting to hit a plane the phone has detected
                if (raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    // creating the robot sphere at the raycast hit point
                    spawnedPrefab = Instantiate(robotPrefab, hits[0].pose.position, robotPrefab.transform.rotation);
                }
            }
        }
    }
}
