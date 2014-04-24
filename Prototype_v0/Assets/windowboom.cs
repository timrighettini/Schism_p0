using UnityEngine;
using System.Collections;

public class windowboom : MonoBehaviour {

	public GameObject wall,cb1,cb2,cb3;
	// Use this for initialization
	void Start () {
	
		GameObject[] w = GameObject.FindGameObjectsWithTag("Windowlight");
		for(int i=0;i<w.Length;i++)
		{
			w[i].gameObject.GetComponent<Light>().enabled = false;
			
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag=="ShadowPlayer" || c.gameObject.tag=="LightPlayer" || c.gameObject.tag=="TwilightPlayer" )
		{
			GameObject[] w = GameObject.FindGameObjectsWithTag("Window");
			for(int i=0;i<w.Length;i++)
			{
				w[i].gameObject.rigidbody.isKinematic=false;
				w[i].gameObject.rigidbody.useGravity = true;
				w[i].gameObject.rigidbody.AddForce(new Vector3(0,-1,-575));

			}
			GameObject[] w1 = GameObject.FindGameObjectsWithTag("Windowlight");
			for(int i=0;i<w1.Length;i++)
			{
				//w1[i].gameObject.SetActive(true);
				w1[i].gameObject.GetComponent<Light>().enabled = true;
			}
			wall.SetActive(false);
			cb1.gameObject.rigidbody.isKinematic=false;
			cb1.gameObject.rigidbody.useGravity = true;
			cb2.gameObject.rigidbody.isKinematic=false;
			cb2.gameObject.rigidbody.useGravity = true;
			cb3.gameObject.rigidbody.isKinematic=false;
			cb3.gameObject.rigidbody.useGravity = true;

			cb1.gameObject.rigidbody.AddForce(new Vector3(1000,0,0));
			cb2.gameObject.rigidbody.AddForce(new Vector3(1000,0,0));
			cb3.gameObject.rigidbody.AddForce(new Vector3(1000,0,0));
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
