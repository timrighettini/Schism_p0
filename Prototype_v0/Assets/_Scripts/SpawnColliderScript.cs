using UnityEngine;
using System.Collections;

public class SpawnColliderScript : MonoBehaviour
{


    #region public variables

    public GameObject[] m_SpawnManagers;

    #endregion



    #region private variables



    #endregion



    #region unity overrides


    // Use this for initialization
    void Start()
    {
        foreach (GameObject g in m_SpawnManagers)
        {
            g.SetActive(false);
        }
        this.renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            foreach (GameObject g in m_SpawnManagers)
            {
                if (!g.activeSelf)
                {
                    g.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            foreach (GameObject g in m_SpawnManagers)
            {
                if (g.activeSelf)
                {
                    g.GetComponent<SpawnControllerScript>().TurnOffSpawners();
                    g.SetActive(false);
                }
            }
        }
    }


    #endregion



    #region public methods

    #endregion



    #region private methods



    #endregion
}
