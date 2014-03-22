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
        //this.renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LightPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Light in Shadow");
            }
            else
            {
                Debug.Log("Light in Light");
            }
        }

        else if (other.gameObject.CompareTag("ShadowPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Shadow in Shadow");
            }
            else
            {
                Debug.Log("Shadow in Light");
            }
        }

        else if (other.gameObject.CompareTag("TwilightPlayer"))
        {
            Debug.Log("Twilight in either light or shadow");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LightPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Light out of Shadow");
            }
            else
            {
                Debug.Log("Light out of Light");
            }
        }

        else if (other.gameObject.CompareTag("ShadowPlayer"))
        {
            if (e_ElementState == elementState.SHADOW)
            {
                Debug.Log("Shadow out of Shadow");
            }
            else
            {
                Debug.Log("Shadow out of Light");
            }
        }

        else if (other.gameObject.CompareTag("TwilightPlayer"))
        {
            Debug.Log("Twilight out of either light or shadow");
        }
    }

    #endregion



    #region public methods



    #endregion



    #region private methods



    #endregion
}
