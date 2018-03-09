using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScene1 : MonoBehaviour
{

    // Notes 
    public AudioClip pickUpNote;
    private AudioSource source;

    // Use this for initialization
    private int tiempostart;
    private int bandera;

    public CharacterScene1 player;

    public GameObject phone;
    public GameObject mailPapers;
    public GameObject door;

    void Start()
    {
        tiempostart = 0;
        bandera = 0;
        source = GetComponent<AudioSource>();
    }

    private void playNote()
    {
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Vector3 distancia = transform.TransformDirection(Vector3.forward) * 10;

        if (Physics.Raycast(transform.position, (distancia), out hit))
        {
            Debug.DrawLine(transform.position, distancia, Color.red);

            if (hit.collider.gameObject.name == phone.name && waitingTime(4))
            {
                player.setPatrol(true);
            }
            if (hit.collider.gameObject.name == mailPapers.name) {
                playNote();
                if (hit.collider.gameObject.name == mailPapers.name && waitingTime(4))
                {
                    player.setPatrol(true);
                }
            }
            if (hit.collider.gameObject.name == door.name && waitingTime(4))
            {
                                
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
            tiempostart = 0;
            return true;
        }
        return false;
    }
}
