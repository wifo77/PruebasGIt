using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public Transform derechaR;
	public Transform izquierdaR;


	
	
	public float potencia = 200f;
	public float anguloMaxGiro = 30f;
	private float aceleracion = 0f;

	private float gasto=0f;
	public float consumo=0.01f;
	/*
	void Start()
	{
		rigidbody.centerOfMass=Vector3.zero;
	}*/

	



	void FixedUpdate () {
		//hacia adelante y hacia atras
		Desplazamiento();
		//giro
		Giro();
		Fin();
		if(aceleracion==0)
		{
			GameMaster.acelerando=false;
		}
		else
		{
			GameMaster.acelerando=true;
		}

	}

	void Desplazamiento()
	{
		if(GameMaster.combustible>0)
		{
			if(aceleracion>=0)
			{
				aceleracion= Input.GetAxis("Vertical")*potencia*10;
				rigidbody.AddRelativeForce(new Vector3(0,0,aceleracion));
				gasto=Mathf.Abs(aceleracion)*consumo;
				GameMaster.combustible-=gasto;
			}
			else if(aceleracion<=0)
			{
				aceleracion= Input.GetAxis("Vertical")*(potencia/2)*10;
				rigidbody.AddRelativeForce(new Vector3(0,0,aceleracion));
				gasto=Mathf.Abs(aceleracion)*consumo;
				GameMaster.combustible-=gasto;
			}
		}
		else{
			aceleracion=0;
		}

	}

	void Giro()
	{

		float rotacion=Input.GetAxis("Horizontal")*anguloMaxGiro;
		if(aceleracion>0)
		{
			
			derechaR.localEulerAngles=new Vector3(0,rotacion*-1,0);
			izquierdaR.localEulerAngles=new Vector3(0,rotacion*-1,0);
			
			this.transform.eulerAngles=new Vector3(0,this.transform.eulerAngles.y+Input.GetAxis("Horizontal"),0);
		}

		else
		{
			derechaR.localEulerAngles=new Vector3(0,rotacion*-1,0);
			izquierdaR.localEulerAngles=new Vector3(0,rotacion*-1,0);
		}
	}
	void Fin()
	{
		if(GameMaster.vida<=0)
		{
			Application.LoadLevel("vehiculoDestroy");
			GameMaster.combustible=1000;
			GameMaster.vida=100;
			GameMaster.muertes=0;
		}
	}
}
