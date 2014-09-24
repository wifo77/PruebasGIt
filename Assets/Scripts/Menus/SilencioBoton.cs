using UnityEngine;
using System.Collections;

public class SilencioBoton : MonoBehaviour {
	public int x=100, y=100;


	void OnGUI()
	{
		bool booleano=GameSound.silencio;
		if(!booleano)
		{
			if(GUI.Button(new Rect(x,y,60,20),"Silencio"))
			{
				GameSound.silencio=true;
			}
		}
		else if(booleano)
		{
			if(GUI.Button(new Rect(x,y,60,20),"Sonido"))
			{
				GameSound.silencio=false;
			}
		}
	}
}
