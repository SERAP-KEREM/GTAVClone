using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police2Spawner : MonoBehaviour
{
    public GameObject[] AiPrefab;
    public int AiToSpawn;
    public float spawnCount;
    public float spawnProc = 60;


    private void Start()
    {
       // StartCoroutine(Spawn());
        spawnCount = spawnProc;
    }

    IEnumerator Spawn()
    {
        int count = 0;
     
        while (count < AiToSpawn)
        {
            int randomIndex = Random.Range(0, AiPrefab.Length);

            GameObject obj = Instantiate(AiPrefab[randomIndex]);

            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<Police2OfficerWaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();

            obj.transform.position = child.position;

            yield return new WaitForSeconds(5f);

            count++;
        }
    }
    private void Update()
    {
        spawnCount -= Time.deltaTime;
        if(spawnCount == 0)
        {
            StartCoroutine(Spawn());
        }
    }
}


