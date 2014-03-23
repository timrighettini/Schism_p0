using UnityEngine;
using System.Collections;

public class SwingNodeScript : MonoBehaviour {

    PlayerManager player;

	// Use this for initialization
	void Start () {
        player = transform.parent.gameObject.GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void StartSwingAnimation()
    {
        player.StartSwing();
    }

    void EndSwingAnimation()
    {
        player.EndSwing();        
    }
}
