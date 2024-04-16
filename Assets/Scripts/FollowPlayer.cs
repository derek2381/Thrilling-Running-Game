using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public PlayerController playerController;

    void Start()
    {


    }

    // Update is called once per frame


    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(-5, 4, 0) ;


    }


}
