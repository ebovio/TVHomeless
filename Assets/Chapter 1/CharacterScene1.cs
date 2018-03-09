using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScene1 : MonoBehaviour
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
    private Node goingTo;

    // Use this for initialization
    void Start()
    {
       goingTo = patrol[start];
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
        if (goingTo == patrol[patrol.Length - 1])
        {
            Vector3 moveDir = (nodePosition - transform.position).normalized;
            transform.position += moveDir * speed * Time.deltaTime;
            keepPatrol = false;
            StartCoroutine("ChangeLevel");

        }
        if (start == 3)
        {
            keepPatrol = false;
            start++;
        }
        if (start == 13)
        {
            keepPatrol = false;
            start++;
        }
    }

    public void setPatrol(bool patrol)
    {
        this.keepPatrol = patrol;
    }

   IEnumerator ChangeLevel()
    {
        float fadeTime = GameObject.Find("GvrEditorEmulator").GetComponent<fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel("NewCitybanca");
    }
}