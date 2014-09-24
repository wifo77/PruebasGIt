using UnityEngine;
using System.Collections;

public class Incializar : MonoBehaviour {

	static public bool primero=true;
	public GameObject prefab;
	void Start()
	{
		if(primero==true)
		{
			Instantiate(prefab);
			primero=false;
		}
	}
}
