using UnityEngine;
using System.Collections;

public class SpawnControllerScript : MonoBehaviour
{

    #region public variables

    [System.Serializable]
    public class SpawnerToActivate
    {
        public GameObject m_Spawner;
        public float      m_DelayTime;
    };

    public SpawnerToActivate[] m_SpawnersToActivate;

    #endregion



    #region private variables



    #endregion



    #region unity overrides

    // Use this for initialization
    void Awake()
    {
        foreach (SpawnerToActivate s in m_SpawnersToActivate)
        {
            s.m_Spawner.SetActive(false);
        }
    }

    //-------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        foreach (SpawnerToActivate s in m_SpawnersToActivate)
        {
            s.m_DelayTime -= Time.deltaTime;
            if (s.m_DelayTime <= 0 && !s.m_Spawner.activeSelf)
            {
                s.m_Spawner.SetActive(true);
            }
        }
    }

    //-------------------------------------------------------------------------

    #endregion



    #region public methods

    public void TurnOffSpawners()
    {
        foreach (SpawnerToActivate s in m_SpawnersToActivate)
        {
            s.m_Spawner.SetActive(false);
        }
    }

    #endregion



    #region private methods



    #endregion
}
