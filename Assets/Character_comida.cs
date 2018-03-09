using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    AudioSource m_MyAudioSource;

    public Text texto;

    // Use this for initialization
    void Start()
    {
        texto.text = "";
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
        if (start == 2)
        {
            StartCoroutine(Example());
            
        }
        if (start == 5)
        {
           StartCoroutine(Example());
        }
        if (start == 7)
        {
            StartCoroutine(Example2());
            keepPatrol = false;
            StartCoroutine(changeScene());
           
        }
    }

    IEnumerator Example()
    {
        speed = 0;
        yield return new WaitForSeconds(2.0f);
        speed = 3;
       
    }
    IEnumerator Example2()
    {
        speed = 0;
        yield return new WaitForSeconds(1.0f);
        texto.text = "805 million people worldwide do not have enough food to eat.           More than 750 million people lack access to clean drinking water.              Hunger is the number one cause of death in the world, killing more than HIV/AIDS, malaria, and tuberculosis combined.";

    }

    public void setPatrol(bool patrol)
    {
        this.keepPatrol = patrol;
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(7);
        Application.LoadLevel("NewCitybanca_sentado");
    }
}