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
    int levelsBeat = 0;
    
    void Start()
    {
        
      agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
   
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
        if (levelsBeat == 0)
        {
            SceneManager.LoadScene("Apartment");
        }
        if (levelsBeat > 0)
        {
            SceneManager.LoadScene(4);
        }
        levelsBeat++;
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
        if (turts >=2)
        {
            Debug.Log("Game Over");
            GameOver();
        }
        if (timesLooped == 1)
        {
            if (turts >= 1)
            {
                //you ded
                Debug.Log("Game Over");
                GameOver();
            }
            if (turts < 1)
            {
                //next level
                Debug.Log("Time for Next level");
                NextLevel();
                levelsBeat++;
            }

        }
    }
}
