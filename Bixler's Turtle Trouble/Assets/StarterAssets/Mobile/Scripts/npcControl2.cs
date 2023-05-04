using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class npcControl2 : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    private int timesLooped;
    public GameObject NPC;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    // Update is called once per frame
    void Update()
    {
    if (Vector3.Distance(transform.position, target) < 1.8)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);

    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
            timesLooped++;
        }
        if (timesLooped == 2)
        {
            //code for transitioning to next level or lose screen should be here
        }
    }
}
