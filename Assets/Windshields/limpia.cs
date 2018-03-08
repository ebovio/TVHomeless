using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limpia : MonoBehaviour {

	private int tmpstart;
	private int banderaa;

    public GameObject carro_1;
    public GameObject carro_2;
    public GameObject persona;


	void Start(){
		tmpstart = 0;
		banderaa = 0;

	}

	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Vector3 distancia = transform.TransformDirection (Vector3.forward) * 10;

		if(Physics.Raycast(transform.position,(distancia),out hit)){
			Debug.DrawLine (transform.position,distancia,Color.red);

            if (hit.collider.gameObject.name == carro_1.name && waitTime(3))
            {
                Debug.Log("I was selected after 3 seconds");
            }
            if (hit.collider.gameObject.name == carro_2.name && waitTime(3))
            {
                Debug.Log("Do you know the way");
            }
            if (hit.collider.gameObject.name == persona.name && waitTime(3))
            {
                Debug.Log("Are you ready?");
            }

        }
        else{
			Debug.DrawLine (transform.position,distancia,Color.green);
			banderaa = 0;
		}
	}

    public bool waitTime(int wait)
    {
        if (banderaa == 0)
        {
            tmpstart = (int)Time.realtimeSinceStartup;
            banderaa = 1;
        }

        if ((tmpstart + wait) <= (int)Time.realtimeSinceStartup)
        {
            return true;
        }
        return false;
    }
}
