using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_banca : MonoBehaviour
{
    // Patrol
    public Node[] patrol;
    public int start = 0;
    public int speed;
    public float threshold;
    private float distance;
    private bool keepPatrol = true;
	private bool bandera;
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
		bandera = true;
    }

    // Update is called once per frame
    void Update()
    {        
		if (keepPatrol && bandera)
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
                //transform.LookAt(patrol[(start) % patrol.Length].transform);
                goingTo = patrol[start];
                //transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
        }
		if(goingTo.transform.position == patrol[patrol.Length-1].transform.position && bandera)
        {
			Vector3 moveDir = (nodePosition - transform.position).normalized;
			transform.position += moveDir * speed * Time.deltaTime;
			print (transform.position + " "+ patrol[patrol.Length-1].transform.position);

			if((int)transform.position.x == (int)patrol[patrol.Length-1].transform.position.x 
				&& (int)transform.position.y == (int)patrol[patrol.Length-1].transform.position.y 
				&& (int)transform.position.y == (int)patrol[patrol.Length-1].transform.position.y){
				bandera = false;
				if(!GameObject.Find ("GvrEditorEmulator").GetComponent<fading> ().TieneOpciones){
					StartCoroutine ("ChangeLevel");
				}
			}

            keepPatrol = false;

        }
    }


	IEnumerator ChangeLevel(){
		print ("corutina empezo");
		float fadeTime = GameObject.Find ("GvrEditorEmulator").GetComponent<fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("NewCitybanca_sentado");
		print ("corrutina termino");
	}
}