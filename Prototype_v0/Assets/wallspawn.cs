using UnityEngine;
using System.Collections;

public class wallspawn : MonoBehaviour {

	public GameObject wall,player,cb1,cb2,cb3;
	public AudioClip groundbreak;
	public enum elementState { LIGHT, SHADOW };
	int onetime=0;
	// Use this for initialization
	void Start () {

		wall.SetActive(false);
		cb1.SetActive(false);
		cb3.SetActive(false);
		cb2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//if(onetime==1)
			
//		Collider[] enemiesinrange = Physics.OverlapSphere(this.transform.position,15.0f);
//		
//		for(int i=0;i<enemiesinrange.Length;i++)
//		{
//			if(enemiesinrange[i].gameObject.tag=="Detector")
//			{
//				enemiesinrange[i].gameObject.GetComponent<ElementDetectionScript>().e_ElementState=0;
//			}
//		}
		if(transform.position.y<3)
		{
			Collider[] enemiesinrange = Physics.OverlapSphere(this.transform.position,15.0f);
			
					for(int i=0;i<enemiesinrange.Length;i++)
					{
						if(enemiesinrange[i].gameObject.tag=="Detector" )
						{
							if(enemiesinrange[i].gameObject.GetComponent<ElementDetectionScript>().id==1)
								enemiesinrange[i].gameObject.GetComponent<ElementDetectionScript>().e_ElementState=ElementDetectionScript.elementState.SHADOW;
						}
					}
			GameObject.FindGameObjectWithTag("Chandalierlight").SetActive(false);
			Debug.Log("atground");
			//audio.Stop();
			//audio.PlayOneShot (groundbreak);
			player.GetComponent<PlayerManager>().PlusCurrentHealth(60);
			wall.SetActive(true);
			cb1.SetActive(true);

			cb3.SetActive(true);
			cb2.SetActive(true);
			GameObject[] Chandelierpieces=GameObject.FindGameObjectsWithTag("Chandalier");
			if(Chandelierpieces[0])
				for(int i=0;i<Chandelierpieces.Length;i++)

				{
					//audio.Stop();
				Chandelierpieces[i].SetActive(false);
					
					
				}
			this.gameObject.SetActive(false);
		}
	}
}
