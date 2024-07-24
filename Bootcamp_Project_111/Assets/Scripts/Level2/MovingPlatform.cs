using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private PlatformPath _platformPath;

    [SerializeField]
    private float speed;

    private int targetWaypointIndex;

    private Transform previousWayPoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;

    public bool moveable;
    private void Start()
    {
        moveable = false;
        TargetNextWaypoint();
    }
    void FixedUpdate()
    {
        if (moveable)
        {
            elapsedTime += Time.deltaTime;
            float elapsedPrcntg = elapsedTime / timeToWaypoint;
            elapsedPrcntg = Mathf.SmoothStep(0, 1, elapsedPrcntg);

            transform.position = Vector3.Lerp(previousWayPoint.position, targetWaypoint.position, elapsedPrcntg);

            if (elapsedPrcntg >= 1)
            {
                TargetNextWaypoint();
            }
        }
        
    }
    private void TargetNextWaypoint()
    {
        previousWayPoint = _platformPath.GetWaypoint(targetWaypointIndex);

        targetWaypointIndex = _platformPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = _platformPath.GetWaypoint(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWayPoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
