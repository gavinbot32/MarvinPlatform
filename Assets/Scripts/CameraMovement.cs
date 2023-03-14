using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Camera cam;
    Vector3 screenPos;
    float posDifx;
    float posDify;
    public Vector3 playerStartPos;
    public float playerYdif;
    public bool follow;
    public Vector3 posThreshold;
    public float posYstartThreshold = 6;
    public float startY;
    public bool startThreshBool;
    // Start is called before the first frame update
   void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        cam = GetComponent<Camera>();
        posThreshold = new Vector3(posThreshold.x,posThreshold.y,posThreshold.z);
        startY = transform.position.y;
        playerStartPos = player.position;
    }

    // Update is called once per frame
    void Update() {

        posDifx = player.position.x - transform.position.x;
        posDify = player.position.y - transform.position.y;
        playerYdif = player.position.y - playerStartPos.y;

        if(playerYdif < posYstartThreshold && playerYdif > -posYstartThreshold)
        {
            startThreshBool = true;
        }
        else
        {
            startThreshBool = false;
        }

        if (posDifx >= posThreshold.x)
        {
            transform.position = new Vector3(transform.position.x + posDifx * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if(posDifx <= posThreshold.z)
        {
            transform.position = new Vector3(transform.position.x + posDifx * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if((posDify >= posThreshold.y|| posDify <= -posThreshold.y)&& !startThreshBool) {
            transform.position = new Vector3(transform.position.x, transform.position.y + posDify * Time.deltaTime, transform.position.z);
        }
        if ((startThreshBool)&&player.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0) 
        {
            transform.position = transform.position = new Vector3(transform.position.x, transform.position.y - (transform.position.y - startY) * Time.deltaTime * 2, transform.position.z);
        }

        

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
    }

}
