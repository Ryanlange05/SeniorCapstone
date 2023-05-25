using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner1 : MonoBehaviour
{
    public GameObject[] myObjects;
    public GameObject[] Player;
    void Start()
    {
        //should make this when the turtle on the counter is picked up not on start, but idk where the code for that is 
        for (int i = 0; i < 20; i++)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(8, -8), 5, Random.Range(8, -8));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            Debug.Log("spawning a turt!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
