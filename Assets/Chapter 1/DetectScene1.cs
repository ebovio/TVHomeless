using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScene1 : MonoBehaviour
{

    private int tiempostart;
    private int bandera;

    public CharacterScene1 player;

    public GameObject phone;
    public GameObject mailPapers;
    public GameObject fridgeItem;
    public GameObject door;

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

            if (hit.collider.gameObject.name == phone.name && waitingTime(3))
            {
                Debug.Log("Ring Ring Ring");
                player.setPatrol(true);
            }
            if (hit.collider.gameObject.name == mailPapers.name && waitingTime(4))
            {
                Debug.Log("Fucking debts");
                player.setPatrol(true);
            }
            if (hit.collider.gameObject.name == fridgeItem.name && waitingTime(4))
            {
                Debug.Log("I was hungry");
                player.setPatrol(true);
            }
            if (hit.collider.gameObject.name == door.name && waitingTime(4))
            {
                Debug.Log("Kicked out of my house");
                player.setPatrol(true);
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
