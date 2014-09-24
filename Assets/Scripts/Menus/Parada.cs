using UnityEngine;
using System.Collections;

public class Parada : MonoBehaviour {

	public Parada siguiente;
	public bool primero;
	
	void OnDrawGizmos()
	{
		Gizmos.DrawIcon(transform.position, "punto.jpg");
		Gizmos.color=Color.green;
		Gizmos.DrawLine(transform.position, siguiente.transform.position);
	}
}
