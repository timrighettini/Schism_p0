using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour
{

    #region public variables

    public byte m_TotalPlayerNumber = 2;
    public GameManager m_Manager;

    #endregion



    #region private variables

    private byte m_NumberOfHitsByPlayers = 0;

    #endregion



    #region unity overrides

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            m_NumberOfHitsByPlayers++;
            if (m_NumberOfHitsByPlayers == m_TotalPlayerNumber)
            {
                Debug.Log("You Win");
                m_Manager.SetGameOver();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            m_NumberOfHitsByPlayers--;
        }
    }

    #endregion



    #region public methods

    #endregion



    #region private methods



    #endregion
}
