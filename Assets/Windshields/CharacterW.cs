using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterW : MonoBehaviour
{

    // Patrol
    public Node[] patrol;
    public int start = 0;
    public int speed;
    public float threshold;
    private float distance;
    private bool keepPatrol = true;
    public bool coche1, coche2;

    public Text text;


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
        goingTo = patrol[(start) % patrol.Length];
        coche1 = false;
        coche2 = false;
        this.text.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (keepPatrol)
        {
            myPosition = transform.position;
            nodePosition = patrol[start].transform.position;
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
        

        if (start == 10)
        {
            keepPatrol = false;
            coche1 = true;
            start++;
        }
        if (start == 13)
        {
            keepPatrol = false;
            coche2 = true;
            start++;
        }
        if (start == 14)
        {
            this.text.text = "The lack of employment has caused dozens of cruisers to be plagued by people, mostly young men, that try to clean the windshields of vehicles waiting for the green light.";
        }
        if (goingTo.transform.position.x == patrol[patrol.Length - 1].transform.position.x && goingTo.transform.position.y == patrol[patrol.Length - 1].transform.position.y && goingTo.transform.position.z == patrol[patrol.Length - 1].transform.position.z)
        {
            start++;
            Vector3 moveDir = (nodePosition - transform.position).normalized;
            transform.position += moveDir * speed * Time.deltaTime;
            keepPatrol = false;
            Application.LoadLevel("NewCitybanca");

        }
    }

    public void setPatrol(bool patrol)
    {
        this.keepPatrol = patrol;
    }
    
}