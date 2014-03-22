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

    public Texture Health_Light_BG_Texture;
    public Texture Health_Shadow_BG_Texture;
    public Texture Health_Twilight_BG_Texture;

    public Texture Health_Light_FG_Texture;
    public Texture Health_Shadow_FG_Texture;
    public Texture Health_Twilight_FG_Texture;

    #endregion



    #region private variables

    const float rectDistance = 200;

    Vector2 Health_WidthHeight = new Vector2(200, 30);
    Vector2 Health_TopLeftOrigin = new Vector2(0, 0);
    const float ySkew = 40; // For Shadow Health Bar

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

    void OnGUI()
    {
        DrawHealthBoxes();
    }

    #endregion 



    #region public methods

    #endregion



    #region private methods

    private void DrawHealthBoxes()
    {
        if (e_PlayerState == playerState.SPLIT)
        {
            // Draw Light Health Bar
            GUI.DrawTexture(new Rect(Health_TopLeftOrigin.x, Health_TopLeftOrigin.y, Health_WidthHeight.x, Health_WidthHeight.y), Health_Light_BG_Texture, ScaleMode.ScaleAndCrop, true, 0);
            GUI.DrawTexture(new Rect(Health_TopLeftOrigin.x, Health_TopLeftOrigin.y, Health_WidthHeight.x * (m_LightPlayer.GetCurrentHealth() / m_LightPlayer.m_HealthMax), Health_WidthHeight.y), Health_Light_FG_Texture, ScaleMode.ScaleAndCrop, true, 0);

            // Draw Shadow Shadow Bar
            GUI.DrawTexture(new Rect(Health_TopLeftOrigin.x, Health_TopLeftOrigin.y + ySkew, Health_WidthHeight.x, Health_WidthHeight.y), Health_Shadow_BG_Texture, ScaleMode.ScaleAndCrop, true, 0);
            GUI.DrawTexture(new Rect(Health_TopLeftOrigin.x, Health_TopLeftOrigin.y + ySkew, Health_WidthHeight.x * (m_ShadowPlayer.GetCurrentHealth() / m_ShadowPlayer.m_HealthMax), Health_WidthHeight.y), Health_Shadow_FG_Texture, ScaleMode.ScaleAndCrop, true, 0);            
        }
        else if (e_PlayerState == playerState.FUSED)
        {
            // Draw Light Health Bar
            GUI.DrawTexture(new Rect(Health_TopLeftOrigin.x, Health_TopLeftOrigin.y, Health_WidthHeight.x, Health_WidthHeight.y), Health_Twilight_BG_Texture, ScaleMode.ScaleAndCrop, true, 0);
            GUI.DrawTexture(new Rect(Health_TopLeftOrigin.x, Health_TopLeftOrigin.y, Health_WidthHeight.x * (m_TwilightPlayer.GetCurrentHealth() / m_TwilightPlayer.m_HealthMax), Health_WidthHeight.y), Health_Twilight_FG_Texture, ScaleMode.ScaleAndCrop, true, 0);
        }
    }

    #endregion
}
