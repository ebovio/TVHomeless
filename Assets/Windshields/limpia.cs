using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limpia : MonoBehaviour
{

    private int tmpstart;
    private int banderaa;

    public CharacterW player;

    public GameObject carro_1;
    public GameObject carro_2;
    public GameObject persona;


    void Start()
    {
        tmpstart = 0;
        banderaa = 0;

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 distancia = transform.TransformDirection(Vector3.forward) * 10;

        if (Physics.Raycast(transform.position, (distancia), out hit))
        {
            Debug.DrawLine(transform.position, distancia, Color.red);

            if (hit.collider.gameObject.name == carro_1.name && waitTime(3))
            {
                if (player.coche1)
                {
                    Debug.Log("Coche 1");
                    player.setPatrol(true);
                }

            }
            if (hit.collider.gameObject.name == carro_2.name && waitTime(3))
            {

                if (player.coche2)
                {
                    Debug.Log("Coche 2");
                    player.setPatrol(true);
                }

            }
            if (hit.collider.gameObject.name == persona.name && waitTime(3))
            {
                player.setPatrol(true);
                /*
                if (!player.coche1 && !player.coche2)
                {
                    Debug.Log("Persona");
                    player.setPatrol(true);
                }
                */
            }

        }
        else
        {
            Debug.DrawLine(transform.position, distancia, Color.green);
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
