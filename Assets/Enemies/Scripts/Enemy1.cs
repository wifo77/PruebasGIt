using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {


	//Cada enemigo tiene una cantidad de vida, velocidad y daño acordes al documento de diseño, todo eso se cambia aqui

	public float vida = 100;
	public float dano = 50;
	public bool countdown = false;

	public Transform target;



	void Start () {
		target = GameObject.FindGameObjectWithTag("coche").transform;
	}

	// Update is called once per frame
	void Update () 
	{

		transform.LookAt(target);
		Muerte();

		if(countdown)
		{
			Dano();
		}

	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "defensa") 
		{
			
			countdown=true;
			
		}
		if(other.gameObject.tag == "coche")
		{
			GameMaster.vida--;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "defensa") 
		{
			
			countdown=false;
			
		}
	}
	void Dano()
	{
		if(GameMaster.acelerando)
		{
			vida-=dano;
		}

	}

	void Muerte()
	{
		if (vida<0)
		{
			Destroy(gameObject);
			GameMaster.muertes++;
		}
	}
	//void getTarget(Transform t){target=t;}
}
