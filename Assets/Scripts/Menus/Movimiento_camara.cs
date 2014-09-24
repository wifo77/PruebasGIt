using UnityEngine;
using System.Collections;

public class Movimiento_camara : MonoBehaviour {
	public Parada punto;
	public float velocidad=30;

	public float giroDeCamara=0.1f;

	void Start ()
	{
		transform.position=punto.transform.position;
	}

	void Update () 
	{

		if(Vector3.Distance(transform.position, punto.transform.position)< 10f)
		{
			punto=punto.siguiente;
		}

		float step= velocidad*Time.deltaTime;
		transform.position=Vector3.MoveTowards(transform.position, punto.transform.position, step);

		Vector3 rotacion=transform.localEulerAngles+new Vector3(0,giroDeCamara,0);
		transform.localEulerAngles=rotacion;

	}
}
