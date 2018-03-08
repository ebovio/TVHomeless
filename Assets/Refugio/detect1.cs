using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect1 : MonoBehaviour {

	private int tiempostart;
	private int bandera;

    public GameObject puerta;


	void Start(){
		tiempostart = 0;
		bandera = 0;

	}

	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Vector3 distancia = transform.TransformDirection (Vector3.forward) * 10;

		if(Physics.Raycast(transform.position,(distancia),out hit)){
			Debug.DrawLine (transform.position,distancia,Color.red);

            if (hit.collider.gameObject.name == puerta.name && waitingTime(3))
            {
                Debug.Log("I was selected after 3 seconds");
				StartCoroutine ("ChangeLevel");
            }

        }
        else{
			Debug.DrawLine (transform.position,distancia,Color.green);
			bandera = 0;
		}
	}


	IEnumerator ChangeLevel(){
		print ("corutina empezo");
		float fadeTime = GameObject.Find ("GvrEditorEmulator").GetComponent<fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("Dormir");
		print ("corrutina termino");
	}


    public bool waitingTime(int wait)
    {
        if (bandera == 0)
        {
            tiempostart = (int)Time.realtimeSinceStartup;
            bandera = 1;
        }

        if ((tiempostart + wait) <= (int)Time.realtimeSinceStartup)
        {
            return true;
        }
        return false;
    }
}
