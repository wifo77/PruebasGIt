using UnityEngine;
using System.Collections;

public class GameSound : MonoBehaviour {

	static public bool silencio;
	public AudioClip cancion;



	//static public float tiempo;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {


		silencio=false;
		audio.clip=cancion;
		//audio.time=tiempo;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		//tiempo=audio.time;
		if(silencio)
		{
			audio.Pause();
		}
		if(audio.isPlaying==false)
		{
			if(!silencio)
			{
				audio.Play();
			}
		}
	}



}
