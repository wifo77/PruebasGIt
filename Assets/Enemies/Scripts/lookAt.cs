using UnityEngine;
using System.Collections;

public class lookAt : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	
	void Update ()
	{
		transform.LookAt(target);
	}
}
