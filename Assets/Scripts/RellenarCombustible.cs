using UnityEngine;
using System.Collections;

public class RellenarCombustible : MonoBehaviour {
	public float carga=0.01f;
	void OnTriggerStay(Collider other)
	{
		if(GameMaster.combustible<1000)
		{
			if(other.gameObject.tag == "defensa")
			{
				GameMaster.combustible+=carga;
			}

		}

	}
}
