using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextPhone : MonoBehaviour {

    public CharacterScene1 player;
    public float showOnDistance = 3;
    private MeshRenderer textMesh;

    
    //----------------------------------------------------------------------------------
    function Update()
    {

        if (Vector3.Distance(transform.position, player.position) < showOnDistance)
            textMesh.enabled = true;
        else
            textMesh.enabled = false;

    }
    // Use this for initialization
    void Start () {
        textMesh = gameObject.GetComponent(MeshRenderer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
