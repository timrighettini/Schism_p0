using UnityEngine;
using System.Collections;

public class ElementDetectionScript : MonoBehaviour {


    #region public variables

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
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Light in Shadow");
                playerManager.SetInShadeHazard(true);
            }
            else
            {
                Debug.Log("Light in Light");
                playerManager.SetInLightHazard(true);
            }
        }

        else if (player.CompareTag("ShadowPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Shadow in Shadow");
                playerManager.SetInShadeHazard(true);
            }
            else
            {
                Debug.Log("Shadow in Light");
                playerManager.SetInLightHazard(true);
            }
        }

        else if (player.CompareTag("TwilightPlayer"))
        {            
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Twilight in Shadow");
                playerManager.SetInShadeHazard(true);
            }
            else
            {
                Debug.Log("Twilight in Light");
                playerManager.SetInLightHazard(true);
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
