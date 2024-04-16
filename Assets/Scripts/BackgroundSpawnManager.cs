using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawnManager : MonoBehaviour
{
    public GameObject backgroundImage;
    private PlayerController PlayerControllerScript;
    public float spawnPos = 45;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnBackground", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerScript.player.transform.position.x > spawnPos){
            Destroy(this);
        }
    }

    void SpawnBackground(){
        if(PlayerControllerScript.isGameOver == false){
            
            Instantiate(backgroundImage, transform.position + new Vector3(spawnPos, 0, 0), backgroundImage.transform.rotation);
            spawnPos += 110;
        }
    }
}
