using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMenu : MonoBehaviour
{

	private int tiempostart;
	private int bandera;

	public GameObject player;

	public GameObject boton;

	void Start()
	{
		tiempostart = 0;
		bandera = 0;

	}

	// Update is called once per frame
	void Update()
	{

		RaycastHit hit;
		Vector3 distancia = transform.TransformDirection(Vector3.forward) * 10;

		if (Physics.Raycast(transform.position, (distancia), out hit))
		{
			Debug.DrawLine(transform.position, distancia, Color.red);

			if (hit.collider.gameObject.name == boton.name && waitingTime(3))
			{
				Debug.Log("Empezar juego");
			}

		}
		else
		{
			Debug.DrawLine(transform.position, distancia, Color.green);
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
}
