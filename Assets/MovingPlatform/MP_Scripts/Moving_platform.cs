using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{

    public Vector3 startPos;
    public float moveSpeed;
    private bool forward;
    public Target[] targets;
    public Vector3[] targetPoses;
    public bool pingPong;
   // public Vector3[] tempPoses;
    public int index;
    private void Awake()
    {
        startPos = transform.position;
        targets = GetComponentsInChildren<Target>();
        targetPoses = new Vector3[targets.Length+1];
        //tempPoses = new Vector3[targets.Length];
        forward = true;
        index = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < targets.Length; i++)
        {
            tempPoses[i] = targets[i].transform.position;
        }*/


        targetPoses[0] = startPos;
        for (int i = 1; i <= targets.Length; i++)
        {

            print(i);
            targetPoses[i] = targets[i-1].transform.position;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        move();

    }

    private void move()
    {
        

        transform.position = Vector3.MoveTowards(transform.position, targetPoses[index], moveSpeed * Time.deltaTime);
        if (transform.position == targetPoses[index])
        {
            if (forward)
            {
                index++;

                if (index >= targetPoses.Length)
                {
                    if (pingPong)
                    {
                        index = targetPoses.Length - 2;
                    }
                    else
                    {
                        index = 0;
                    }
                    forward = false;
                }
            }
            else
            {
                index--;

                if (index <= 0)
                {
                    index = 0;
                    forward = true;
                }
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            collision.transform.SetParent(transform);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
