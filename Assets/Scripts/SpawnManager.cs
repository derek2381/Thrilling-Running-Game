using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject roadPrefab;
    public float spawnPos = 50;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(roadPrefab, transform.position +new Vector3(spawnPos, 0, 0 ), roadPrefab.transform.rotation);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRoad", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRoad(){

        if(playerControllerScript.isGameOver == false){
            spawnPos += 50;
            Instantiate(roadPrefab,  roadPrefab.transform.position +new Vector3(spawnPos,0, 0), roadPrefab.transform.rotation);
        }
    }
}
