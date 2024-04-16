using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Animator playerAnim;
    public Camera camera;


    void Start()
    {
      playerAnim = GetComponent<Animator>();
      camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();




    }

    private bool isOnGround = true;
    private float leftLimit = 4;

    private float rightLimit = -4;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && isOnGround && !isGameOver){
            GetComponent<Rigidbody>().AddForce(Vector3.up * 360, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) && !isGameOver && transform.position.z < leftLimit && isOnGround){
            transform.position += (new Vector3(0, 0, 4));
        }else if(Input.GetKeyDown(KeyCode.RightArrow) && !isGameOver && transform.position.z > rightLimit && isOnGround){
            transform.position += (new Vector3(0, 0, -4));
        }

        if(!isGameOver){
            transform.position += Vector3.right * Time.deltaTime * 10;
        }
    }
    public bool isGameOver = false;
    private void OnCollisionEnter(Collision collision){
    if(collision.gameObject.CompareTag("Ground")){
        isOnGround = true;
    }else if(collision.gameObject.CompareTag("Obstacle")){
        isGameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);


        // camera.transform.Translate(Vector3.back * 12, Space.World);

    }
}

}
