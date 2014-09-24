using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public static int muertes=0;
	public static int vida=100;
	public static float combustible=1000;
	public static bool acelerando=false;


	static public void Cerrar(){
		Application.Quit();
	}

}
