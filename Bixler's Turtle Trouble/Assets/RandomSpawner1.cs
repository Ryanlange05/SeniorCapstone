using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner1 : MonoBehaviour
{
    public GameObject counterTurt;
    public GameObject[] myObjects;
    public GameObject[] Player;
   
    public void spawnTurts()
    {
        for (int i = 0; i < 8; i++)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(8, -8), 5, Random.Range(8, -8));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            Debug.Log("spawning a turt!");
        }
    }
}
