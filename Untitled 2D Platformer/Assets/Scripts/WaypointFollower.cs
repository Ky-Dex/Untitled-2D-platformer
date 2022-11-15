using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] float speed = 2f;

    int currentWaypointindex = 0;

    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointindex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointindex++;
            if (currentWaypointindex >= waypoints.Length)
                currentWaypointindex = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointindex].transform.position, speed * Time.deltaTime);


    }
}
