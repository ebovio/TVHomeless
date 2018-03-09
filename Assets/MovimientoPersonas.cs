using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonas : MonoBehaviour
{
    // Patrol
    public Node[] patrol;
    public int start = 0;
    public int speed;
    public float threshold;
    private float distance;
    private bool keepPatrol = true;


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
        goingTo = patrol[(start) % patrol.Length];
    }

    // Update is called once per frame
    void Update()
    {
        goingTo = patrol[(start) % patrol.Length];
        if (keepPatrol)
        {
            Vector3 myPosition = transform.position;
            Vector3 nodePosition = patrol[start % patrol.Length].transform.position;
            distance = Vector3.Distance(myPosition, nodePosition);
            Vector3 moveDir = (nodePosition - transform.position).normalized;
            if (distance < threshold)
            {
                start++;
                distance = 3.0f;
            }
            else
            {
                transform.position += moveDir * speed * Time.deltaTime;
                transform.LookAt(patrol[(start) % patrol.Length].transform);
                goingTo = patrol[(start) % patrol.Length];
                transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
        }
    }
}