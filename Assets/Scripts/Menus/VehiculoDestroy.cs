using UnityEngine;
using System.Collections;

public class VehiculoDestroy : MonoBehaviour {
	public int x=0;
	public int y=0;
	public int ancho=200;
	public int alto=25;

	void OnGUI()
	{
		GUI.TextArea(new Rect(x,y,ancho,alto),"Tu vehiculo ha sido destruido por los aliens!!");
	}

}
