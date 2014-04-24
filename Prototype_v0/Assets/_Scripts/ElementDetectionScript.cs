using UnityEngine;
using System.Collections;

public class ElementDetectionScript : MonoBehaviour {


    #region public variables
	public int id;
    public enum elementState { LIGHT, SHADOW };
    public elementState e_ElementState;

    #endregion



    #region private variables



    #endregion



    #region unity overrides

    // Use this for initialization
    void Start()
    {
        this.renderer.enabled = false;
    }

    //-------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {

    }

    //-------------------------------------------------------------------------

    void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        PlayerManager playerManager = player.GetComponent<PlayerManager>();

        if (player.CompareTag("LightPlayer"))
        {
            if (e_ElementState == elementState.LIGHT)
            {
				Debug.Log("Light in Light");
				playerManager.SetInLightHazard(true);
				playerManager.SetInShadeHazard(false);
			}
			else
			{
				
				Debug.Log("Light in Shadow");
				playerManager.SetInShadeHazard(true);
				playerManager.SetInLightHazard(false);
			}
		}
		
		else if (player.CompareTag("ShadowPlayer"))
        {
            if (e_ElementState == elementState.LIGHT)
            {
				Debug.Log("Shadow in Light");
				playerManager.SetInLightHazard(true);
				playerManager.SetInShadeHazard(false);

            }
            else
            {
				Debug.Log("Shadow in Shadow");
				playerManager.SetInShadeHazard(true);
				playerManager.SetInLightHazard(false);
			}
		}
		
		else if (player.CompareTag("TwilightPlayer"))
        {            
            if (e_ElementState == elementState.LIGHT)
            {
				Debug.Log("Twilight in Light");
				playerManager.SetInLightHazard(true);
				playerManager.SetInShadeHazard(false);
			}
			else
			{
				
				Debug.Log("Twilight in Shadow");
				playerManager.SetInShadeHazard(true);
				playerManager.SetInLightHazard(false);
			}
		}
	}
	
	//-------------------------------------------------------------------------

    void OnTriggerStay(Collider other)
    {
        GameObject player = other.gameObject;
        PlayerManager playerManager = player.GetComponent<PlayerManager>();

        if (player.CompareTag("LightPlayer"))
        {
            if (e_ElementState == elementState.LIGHT)
            {                
				playerManager.SetInLightHazard(true);
				playerManager.SetInShadeHazard(false);
			}
			else
			{                
               
				playerManager.SetInShadeHazard(true);
				playerManager.SetInLightHazard(false);
			}
		}
		
		else if (player.CompareTag("ShadowPlayer"))
        {
            if (e_ElementState == elementState.LIGHT)
            {                
				playerManager.SetInLightHazard(true);
				playerManager.SetInShadeHazard(false);
			}
			else
			{       
				playerManager.SetInShadeHazard(true);
				playerManager.SetInLightHazard(false);

            }
        }

        else if (player.CompareTag("TwilightPlayer"))
        {
            if (e_ElementState == elementState.LIGHT)
            {                
				playerManager.SetInLightHazard(true);
				playerManager.SetInShadeHazard(false);
			}
			else
			{
				
				playerManager.SetInShadeHazard(true);
				playerManager.SetInLightHazard(false);
			}
		}
	}

    //-------------------------------------------------------------------------

    void OnTriggerExit(Collider other)
    {
        GameObject player = other.gameObject;
        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        
        if (player.CompareTag("LightPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Light out of Shadow");
                playerManager.SetInShadeHazard(false);
            }
            else
            {
                Debug.Log("Light out of Light");
                playerManager.SetInLightHazard(false);
            }
        }

        else if (player.CompareTag("ShadowPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Shadow out of Shadow");
                playerManager.SetInShadeHazard(false);
            }
            else
            {
                Debug.Log("Shadow out of Light");
                playerManager.SetInLightHazard(false);
            }
        }

        else if (player.CompareTag("TwilightPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Twilight out of Shadow");
                playerManager.SetInShadeHazard(false);
            }
            else
            {
                Debug.Log("Twilight out of Light");
                playerManager.SetInLightHazard(false);
            }
        }
    }

    //-------------------------------------------------------------------------

    #endregion



    #region public methods



    #endregion



    #region private methods



    #endregion
}
