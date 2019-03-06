using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public GameObject[] bridgePrefabs;

    private Transform playerTransform;
    private float spawnZaxis = 0.0f;
    private float tileLength;
    private int numOfTracks = 10;

    private float Safe = 15.0f;

    private int lastPrefabIndex = 0;
    private List<GameObject> activeTrack;

    // Start is called before the first frame update
    void Start()
    {
        activeTrack = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < numOfTracks; i++)
        {
            if(i < 2)
            {
            spawnTrack(0);
            }
            else{
                spawnTrack();
            }
        }
    }

    // Update is called once per frame Destroy(transform.GetChild(0));
    void Update()
    {
        if(playerTransform.position.z - Safe> (spawnZaxis - numOfTracks * tileLength))
        {
            spawnTrack();
            DeleteTrack();
        }

    }

    private void spawnTrack(int prefabIndex = -1)
    {
        GameObject start;

        if(prefabIndex == -1)
        {
        start = Instantiate(bridgePrefabs[RandomPrefabIndex()] as GameObject);
        }
        else
        {
        start = Instantiate (bridgePrefabs[prefabIndex]) as GameObject;
        start.transform.SetParent(transform);
        start.transform.position = Vector3.forward * spawnZaxis;

        if(bridgePrefabs[4])
        {
            tileLength = 10.0f;
        }
        else{
            tileLength = 5.0f;
        }

        spawnZaxis += tileLength;
        activeTrack.Add(start);
        }
        
    }

    private void DeleteTrack()
    {
        Destroy(activeTrack[0]);
        activeTrack.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(bridgePrefabs.Length <= -1)
        {
            return 0;
        }
            int randomIndex = lastPrefabIndex;
            while(randomIndex == lastPrefabIndex)
            {
                randomIndex = Random.Range(0, bridgePrefabs.Length);
            }

            lastPrefabIndex = randomIndex;
            return randomIndex;
        
    }
}
