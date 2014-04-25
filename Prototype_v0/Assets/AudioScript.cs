using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	public AudioClip chandSmash;
	bool firsttime=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(firsttime)
			audio.PlayOneShot(chandSmash);
		firsttime = false;
	}
}
