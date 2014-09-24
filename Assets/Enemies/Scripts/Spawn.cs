using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	//aqui se inicializa el objeto que va a salir, en este caso enemigos

	public Rigidbody Enemigo1;
	public Rigidbody Enemigo2;
	public Rigidbody Enemigo3;
	public Transform target;

	//aqui esta el tiempo entre spawns

	public float TEspera1 = 3.0f;
	public float TEspera2 = 20.0f;
	public float TEspera3 = 100.0f;	
	

	void Update () 
	{
		TEspera1 -= Time.deltaTime;
		TEspera2 -= Time.deltaTime;
		TEspera3 -= Time.deltaTime;
		
		if(TEspera1 <= 0.0f)
		{
			// crea el enemigo en la posicion y rotacion de el Spawn
			Instantiate(Enemigo1,transform.position,transform.rotation);
			//Enemigo1.target = target;
			TEspera1 = 3.0f;

			//lo comentado abajo es un experimento con fuerzas para generaros y que caigan sobre la ciudad.
			//res.AddForce(Vector3.left * 100);
		}
		/*
		//Enemigo 2
		if(TEspera2 <= 0.0f)
		{
			Rigidbody res = Instantiate(Enemigo2,transform.position,transform.rotation)as Rigidbody;
			
			TEspera2 = 20.0f;
		}

		//Enemigo 3
		if(TEspera3 <= 0.0f)
		{
			Rigidbody res = Instantiate(Enemigo3,transform.position,transform.rotation)as Rigidbody;
			
			TEspera1 = 100.0f;
		}
		*/

	}
}
