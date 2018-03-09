//----------------------------------------------------------------------------------
//----------------------------------------------------------------------------------
// POP UP TEXT//----------------------------------------------------------------------------------

#pragma strict

var player: Transform;
var showOnDistance: float = 2;
private var textMesh: MeshRenderer;

var audioSource: AudioSource;

//----------------------------------------------------------------------------------
function Start () 
{
  textMesh = gameObject.GetComponent(MeshRenderer);
  audioSource = GetComponent.<AudioSource>();

  audioSource.PlayDelayed(12);
}

//----------------------------------------------------------------------------------
function Update () 
{
 Debug.Log ("Distancia" + Vector3.Distance(transform.position, player.position));
  if (Vector3.Distance(transform.position, player.position) < showOnDistance) {
    textMesh.enabled = true;
    audioSource.Play();
    }
    else{
     textMesh.enabled = false;
     }
}
//--------------------------------------------------------------------