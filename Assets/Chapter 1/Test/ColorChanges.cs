using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanges : MonoBehaviour {

    public Material notLooking;
    public Material looking;


    void Start()
    {
        GetComponent<Renderer>().material = notLooking;
    }

    public void objectBeingWatched()
    {
        GetComponent<Renderer>().material = looking;
    }

    public void objectNotBeingWatched()
    {
        GetComponent<Renderer>().material = notLooking;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
