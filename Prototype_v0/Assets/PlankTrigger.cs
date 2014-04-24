using UnityEngine;
using System.Collections;

public class PlankTrigger : MonoBehaviour {

	// Use this for initialization
	public int count = 0;
	public GameObject plankGameObj;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collidable)
	{
		if(collidable.gameObject.tag.ToLower().Contains("player") || collidable.gameObject.tag.ToLower().Contains("enemy"))
		{
			count++;
			if(count >= 2 )
			{
				plankGameObj.GetComponent<BoxCollider>().isTrigger = true;
				
			}
		}
	}
}
