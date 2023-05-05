using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class npcControl2 : MonoBehaviour
{
    public NPCDetection script;
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
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Apartment");
    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);

    }
    void IterateWaypointIndex()
    {
        int turts = script.turts;
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
            timesLooped++;
        }
        if (timesLooped == 2)
        {
           if (turts >= 2)
            {
                //you ded
                Debug.Log("Game Over");
                GameOver();
            }
           if (turts < 2)
            {
                //next level
                Debug.Log("Time for Next level");
                NextLevel();
            }
            
        }
    }
}
