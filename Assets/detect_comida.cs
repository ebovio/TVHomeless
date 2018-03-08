using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_comida : MonoBehaviour {

	private int tiempostart;
	private int bandera;

    public GameObject basurero_cerrado, basurero_cerrado2;
    public GameObject basurero_abierto, basurero_abierto2;


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

            if (hit.collider.gameObject.name == basurero_cerrado.name && waitingTime(1))
            {
                basurero_abierto.SetActive(true);
                basurero_cerrado.SetActive(false);
                //Debug.Log("I was selected after 2 seconds");
            } else if (hit.collider.gameObject.name == basurero_cerrado2.name && waitingTime(1)){
                basurero_abierto2.SetActive(true);
                basurero_cerrado2.SetActive(false);

            }
            
        }
        else{
			Debug.DrawLine (transform.position,distancia,Color.green);
			bandera = 0;
		}
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

    public void SetGazedAt(bool gazedAt)
    {

    }


}
