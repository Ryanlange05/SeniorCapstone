using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public GameObject[] Player;
    void Start()
    {
        for (int i=0; i<40; i++)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(35, 10), 50, Random.Range(20, -18));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            Debug.Log("spawning a turt!");
        }
    }
}




