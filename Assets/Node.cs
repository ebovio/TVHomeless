using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Node[] neighbors;
    public List<Node> history;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < neighbors.Length; i++)
        {
            Gizmos.DrawLine(transform.position, neighbors[i].transform.position);
        }
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, 0.08f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.08f);
    }
}
