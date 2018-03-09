using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterD : MonoBehaviour
{

    // Patrol
    public Node[] patrol;
    public int start = 0;
    public int speed;
    public float threshold;
    private float distance;
    private bool keepPatrol = true;
    public Text mensaje;


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
        mensaje.text = "";
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

            if (distance < threshold)
            {
                start++;
                distance = 3.0f;
            }
            else
            {
                Vector3 moveDir = (nodePosition - transform.position).normalized;
                transform.position += moveDir * speed * Time.deltaTime;
                //transform.LookAt(patrol[(start) % patrol.Length].transform);
                goingTo = patrol[(start) % patrol.Length];
                //transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
        }
        if(goingTo == patrol[patrol.Length-1])
        {
            keepPatrol = false;
            mensaje.text = "The first Street Population Census in Mexico City unveiled that 4,354 people live without a shelter and 2,400 people live in public or private wards";
            StartCoroutine(changeSceneBanca());
        }
        
    }

    IEnumerator Espera()
    {
        speed = 0;
        yield return new WaitForSeconds(3.0f);
        speed = 2;
    }

    IEnumerator changeSceneBanca()
    {
        yield return new WaitForSeconds(7);
        Application.LoadLevel("NewCitybanca_sentado");
    }
}