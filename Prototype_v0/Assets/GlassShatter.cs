using UnityEngine;
using System.Collections;

public class GlassShatter : MonoBehaviour {

	public AudioClip glassShatter;
	bool firsttime=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (firsttime)
			audio.PlayOneShot (glassShatter);

	}

}
