using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGameController : MonoBehaviour
{
    public Transform canvas;
    public float spawnInterval;
    public GameObject bubblePrefab;
    public Transform[] spawnPoints;
    Vector2 chosenSpawn;
    Vector2 previousSpawn;


    // Start is called before the first frame update
    void Start()
    {
        SpawnBubble();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBubble()
    {
        //for (int i = 0; i < spawnPoints.Length; i++
        while(chosenSpawn == previousSpawn)
        {
            chosenSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        }
        
        previousSpawn = chosenSpawn;
        GameObject clone = Instantiate(bubblePrefab,chosenSpawn,Quaternion.identity);
        clone.transform.SetParent(canvas);
        clone.transform.localScale = new Vector3(2, 2, 2);
        Destroy(clone, 8f);
        spawnInterval = Random.Range(0, 3);
        Invoke("SpawnBubble", spawnInterval);
    }
}
