using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    #region public variables

    PlayerManager m_LightPlayer;
    PlayerManager m_ShadowPlayer;
    PlayerManager m_TwilightPlayer;

    public enum playerState { SPLIT, FUSED };
    public playerState e_PlayerState;

    #endregion



    #region private variables



    #endregion



    #region unity overrides

    // Use this for initialization
	void Start () {
	    // Grab all of the player references, make it automated
        m_LightPlayer = GameObject.FindGameObjectWithTag("LightPlayer").GetComponent<PlayerManager>();
        m_ShadowPlayer = GameObject.FindGameObjectWithTag("ShadowPlayer").GetComponent<PlayerManager>();
        m_TwilightPlayer = GameObject.FindGameObjectWithTag("TwilightPlayer").GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    // Do Input Polling
        if (e_PlayerState == playerState.SPLIT)
        {
            m_LightPlayer.Move(Input.GetAxis("P1_Horizontal"), Input.GetAxis("P1_Vertical"));
            m_ShadowPlayer.Move(Input.GetAxis("P2_Horizontal"), Input.GetAxis("P2_Vertical"));
            
        }
        else if (e_PlayerState == playerState.FUSED)
        {
            //TODO: Add fused movement and ability usage
            m_TwilightPlayer.Move(Input.GetAxis("P1_Horizontal"), Input.GetAxis("P1_Vertical"));
        }
    }

    #endregion 



    #region public methods

    #endregion



    #region private methods

    #endregion
}
