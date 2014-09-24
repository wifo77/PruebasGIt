using UnityEngine;
using System.Collections;

public class Salir : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel("Menu0.1");
		}
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			GameMaster.Cerrar();
		}

	}
	void OnGUI(){
		if(GUI.Button(new Rect((Screen.width/2)-250,20,500,20),"Pulsa la barra espaciadora para volver al menu principal"))
		{
			Application.LoadLevel("Menu0.1");
		}
		else if(GUI.Button(new Rect((Screen.width/2)-250,50,500,20),"Pulsa escape para salir"))
		{
			GameMaster.Cerrar();
		}
		GUILayout.TextField("Muertes: "+GameMaster.muertes);
		GUILayout.TextField("Vida: "+GameMaster.vida);
		GUILayout.TextField("Litros de gasolina: "+(int)GameMaster.combustible);
	
	}
}
