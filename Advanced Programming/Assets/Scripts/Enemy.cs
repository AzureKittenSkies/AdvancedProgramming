using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int Health
    {
        get
        {
            return health;
        }
    }

    public NavMeshAgent agent;
    public Transform target;
    public float distanceToWaypoint;
    public Transform waypointParent;
    public bool loop = false;

    public bool pingPong = false;
    private Transform[] waypoints;
    private int currentIndex = 1;

    private int health = 100;

    private void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        // if a target is set
        if (target)
        {
            // update ai's target position
            agent.SetDestination(target.position);
        }
        else
        {
            // if currentindex exceeds size of array
            if (currentIndex >= waypoints.Length)
            {
                if (loop)
                {
                    // reset back to element one (zero based array)
                    currentIndex = 1;
                }
                else
                {
                    // cap the index if it's greater
                    currentIndex = waypoints.Length - 1;
                    // reverse order
                    pingPong = true;
                }
            }
            // if currentindex exceeds size of array
            if (currentIndex <= waypoints.Length)
            {
                if (loop)
                {
                    // reset back to element one (zero based array)
                    currentIndex = 1;
                }
                else
                {
                    // cap the index if it's greater
                    currentIndex = waypoints.Length - 1;
                    // reverse order
                    pingPong = false;
                }
            }
            Transform point = waypoints[currentIndex];
            float distance = Vector3.Distance(transform.position, point.position);
            if (distance <= distanceToWaypoint)
            {
                if (pingPong)
                {
                    // move to previous waypoint
                    currentIndex--;
                }
                else
                {
                    // move to next waypoint
                    currentIndex++;
                }
            }


            // set new target to next waypoint
            agent.SetDestination(point.position);
        }
    }

    public void DealDamage(int dealDamage)
    {
        health -= dealDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
