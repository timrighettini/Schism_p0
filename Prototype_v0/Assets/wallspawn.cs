using UnityEngine;
using System.Collections;

public class wallspawn : MonoBehaviour {

	public GameObject wall,player,cb1,cb2,cb3;
	public enum elementState { LIGHT, SHADOW };
	// Use this for initialization
	void Start () {

		wall.SetActive(false);
		cb1.SetActive(false);
		cb3.SetActive(false);
		cb2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
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
			player.GetComponent<PlayerManager>().PlusCurrentHealth(60);
			wall.SetActive(true);
			cb1.SetActive(true);
			cb3.SetActive(true);
			cb2.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
