using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_comida : MonoBehaviour
{
    // Patrol
    public Node[] patrol;
    public int start = 0;
    public int speed;
    public float threshold;
    private float distance;
    private bool keepPatrol = true;

    Vector3 myPosition;
    Vector3 nodePosition;
    //Go to bench once
    private bool atBench = false;

    // List of ALL Nodes
    public Node[] nodeWorld;

    private float closest;
    private Node closestNode;
    private Node goingTo;

    // Use this for initialization
    void Start()
    {
        closest = Vector3.Distance(transform.position, nodeWorld[0].transform.position);
        closestNode = nodeWorld[0];
        goingTo = patrol[start];
     
    }

    // Update is called once per frame
    void Update()
    {
        if (keepPatrol)
        {
            Vector3 myPosition = transform.position;
            Vector3 nodePosition = patrol[start].transform.position;
            distance = Vector3.Distance(myPosition, nodePosition);

            if (distance < threshold)
            {
                start++;
                distance = 3.0f;
            }
            else
            {
                Vector3 moveDir = (nodePosition - transform.position).normalized;
                transform.position += moveDir * speed * Time.deltaTime;
                goingTo = patrol[start];
            }
        }
        if(goingTo == patrol[patrol.Length-1])
        {
            Vector3 moveDir = (nodePosition - transform.position).normalized;
            transform.position += moveDir * speed * Time.deltaTime;
            keepPatrol = false;
        }
        else if (goingTo == patrol[2])
        {
            StartCoroutine(Example());
        }
        else if (goingTo == patrol[6])
        {
            StartCoroutine(Example());
        }
        else if (goingTo == patrol[7])
        {
            StartCoroutine(Example());
        }

    }

    IEnumerator Example()
    {
        speed = 0;
        yield return new WaitForSeconds(2.0f);
        speed = 3;
       
    }
}