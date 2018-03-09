using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sounds : MonoBehaviour {

	public AudioSource _AudioSource1;
	public AudioSource _AudioSource2;
	public AudioSource _AudioSource3;
	public Rigidbody rb;
	public float time =20f;
	public float time2 =5f;

	public Transform objectTransform;
	private float noMovementThreshold = 0.0001f;
	private const int noMovementFrames = 3;
	Vector3[] previousLocations = new Vector3[noMovementFrames];
	private bool isMoving;

	void Awake()
	{
		objectTransform = GetComponent<Transform> ();
		//For good measure, set the previous locations
		for(int i = 0; i < previousLocations.Length; i++)
		{
			previousLocations[i] = Vector3.zero;
		}
	}

	public bool IsMoving
	{
		get{ return isMoving; }
	}


	void Update () 
	{
		if (time > 0) {
			time -= Time.deltaTime;
		}
		Debug.Log ("Se esta moviendo " + isMoving);
	//Store the newest vector at the end of the list of vectors
	for(int i = 0; i < previousLocations.Length - 1; i++)
	{
		previousLocations[i] = previousLocations[i+1];
	}
	previousLocations[previousLocations.Length - 1] = objectTransform.position;

	//Check the distances between the points in your previous locations
	//If for the past several updates, there are no movements smaller than the threshold,
	//you can most likely assume that the object is not moving
	for(int i = 0; i < previousLocations.Length - 1; i++)
	{
		if(Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= noMovementThreshold)
		{
			//The minimum movement has been detected between frames
			isMoving = true;
			//_AudioSource2.Play();
			break;
		}
		else
		{

			isMoving = false;

			if (time <= 0) {
				_AudioSource2.Stop();
				_AudioSource3.Play ();
				//_AudioSource3.Play();
			}
				if (time2 > 0) {
					time2 -= Time.deltaTime;
				} else {
					SceneManager.LoadScene ("NewCitybanca", LoadSceneMode.Additive);					
				}



			}
		}
	}
}