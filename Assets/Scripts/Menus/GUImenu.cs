using UnityEngine;
using System.Collections;

public class GUImenu : MonoBehaviour {
	public int profundidad=0;
	public float x=0,y=0;
	public int alto=100,ancho=100;
	public Texture textura;
	public Rect rectangulo;

	void Start()
	{
		rectangulo= new Rect(x,y,alto,ancho);
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GameMaster.Cerrar();
		}
	}

	void OnGUI()
	{
		GUI.depth=profundidad;
		GUI.DrawTexture(rectangulo, textura);
	}
	void OnMouseDown()
	{

		if(this.name=="juegoBoton")
		{
			Application.LoadLevel("juego");
		}
		else if(this.name=="creditosBoton")
		{
			Application.LoadLevel("creditos");
		}
		else if(this.name=="opcionesBoton")
		{
			Application.LoadLevel("opciones");
		}
		else if(this.name=="rankingBoton")
		{
			print("ranking");
		}
		else if(this.name=="returnBoton")
		{
			Application.LoadLevel("Menu0.1");
		}

	}


}
