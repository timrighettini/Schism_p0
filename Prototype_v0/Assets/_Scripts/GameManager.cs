using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    #region public variables

	public GameObject lp,sp,tp;

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

	public Texture Energy_Light_BG_Texture;
	public Texture Energy_Shadow_BG_Texture;
	public Texture Energy_Twilight_BG_Texture;
	
	public Texture Energy_Light_FG_Texture;
	public Texture Energy_Shadow_FG_Texture;
	public Texture Energy_Twilight_FG_Texture;

    public GUIText m_YouWin;
    public GUIText m_YouWin_2;
    public CameraScript m_Camera;

    #endregion



    #region private variables

    const float rectDistance = 200;

    Vector2 Health_WidthHeight = new Vector2(200, 30);
    Vector2 Health_TopLeftOrigin = new Vector2(0, 0);

	Vector2 Energy_WidthHeight = new Vector2(200, 30);
	Vector2 Energy_TopRightOrigin = new Vector2(1, 200);
    const float ySkew = 40; // For Shadow Health Bar
    private bool m_IsGameOver = false;

    private PlayerManager m_LightManager;
    private PlayerManager m_ShadeManager;
    private PlayerManager m_TwiliManager;

    #endregion



    #region unity overrides

    // Use this for initialization
	void Start () {
	    // Grab all of the player references, make it automated
        m_LightPlayer = GameObject.FindGameObjectWithTag("LightPlayer").GetComponent<PlayerManager>();
        m_ShadowPlayer = GameObject.FindGameObjectWithTag("ShadowPlayer").GetComponent<PlayerManager>();
        m_TwilightPlayer = GameObject.FindGameObjectWithTag("TwilightPlayer").GetComponent<PlayerManager>();

        m_LightManager = m_LightPlayer.GetComponent<PlayerManager>();
        m_ShadeManager = m_ShadowPlayer.GetComponent<PlayerManager>();
        m_TwiliManager = m_TwilightPlayer.GetComponent<PlayerManager>();
	}

    //-------------------------------------------------------------------------
	
	// Update is called once per frame
	void Update () {
        if (m_LightManager.GetCurrentHealth() <= 0 || m_ShadeManager.GetCurrentHealth() <= 0 || m_TwiliManager.GetCurrentHealth() <= 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("puzzleRoom");
        }
        
		if (Input.GetButtonDown("Fire3"))
		{
			if (e_PlayerState == playerState.SPLIT)
			{
				tp.transform.position = sp.transform.position;
				sp.transform.position = new Vector3(-100,-100,-100);
				lp.transform.position = new Vector3(-100,-100,-100);
				e_PlayerState = playerState.FUSED;
				GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
				cam.GetComponent<CameraScript>().m_FollowObject= tp;
				cam.GetComponent<CameraScript>().m_ZoomObject = tp;
			}
			else if (e_PlayerState == playerState.FUSED)
			{

				sp.transform.position = new Vector3(tp.transform.position.x-1f,tp.transform.position.y,tp.transform.position.z);
				lp.transform.position = new Vector3(tp.transform.position.x+1f,tp.transform.position.y,tp.transform.position.z);
				tp.transform.position = new Vector3(-100,-100,-100);
				e_PlayerState = playerState.SPLIT;
				GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
				cam.GetComponent<CameraScript>().m_FollowObject= lp;
				cam.GetComponent<CameraScript>().m_ZoomObject = sp;
			}
		}

        if (m_IsGameOver)
        {
            // Display You Win Message            
            m_YouWin.gameObject.SetActive(true);
            m_YouWin_2.gameObject.SetActive(true);  
            m_Camera.transform.GetChild(0).gameObject.SetActive(true);
            return;
        }
        
        // TODO: Add abilities usage

	    // Do Input Polling
        if (e_PlayerState == playerState.SPLIT)
        {
            // Movement
            m_LightPlayer.Move(Input.GetAxis("P1_Horizontal"), Input.GetAxis("P1_Vertical"));
            m_ShadowPlayer.Move(Input.GetAxis("P2_Horizontal"), Input.GetAxis("P2_Vertical"));
       		
			if((m_LightPlayer.gameObject.transform.position.y < -10.0f) || (m_ShadowPlayer.gameObject.transform.position.y < -10.0f))
			{
				m_LightPlayer.gameObject.transform.position = GameObject.FindGameObjectWithTag("SpawnPos").transform.position;
				m_ShadowPlayer.gameObject.transform.position = GameObject.FindGameObjectWithTag("SpawnPos").transform.position;
				GameObject.FindGameObjectWithTag("Plank").GetComponent<PlankTrigger>().count = 0;
				GameObject.FindGameObjectWithTag("Plank").GetComponent<PlankTrigger>().plankGameObj.GetComponent<BoxCollider>().isTrigger = false;

			}
            // Weapon Pick up
            if (Input.GetButtonDown("P1_Pickup"))
            {
                m_LightPlayer.PickUpWeapon();
            }

            if (Input.GetButtonDown("P2_Pickup"))
            {
                m_ShadowPlayer.PickUpWeapon();
            }

            // Activation of Objects
            if (Input.GetButtonDown("P1_Activate"))
            {
                m_LightPlayer.Activate();
            }

            if (Input.GetButtonDown("P2_Activate"))
            {
                m_ShadowPlayer.Activate();
            }

            // Weapon Usage
            if (Input.GetButtonDown("P1_UseWeapon"))
            {
                m_LightPlayer.UseWeapon();
            }

            if (Input.GetButtonDown("P2_UseWeapon"))
            {
                m_ShadowPlayer.UseWeapon();
            }

        }
        else if (e_PlayerState == playerState.FUSED)
        {            
            // Movement
            m_TwilightPlayer.Move(Input.GetAxis("P1_Horizontal"), Input.GetAxis("P1_Vertical"));

            // Pickup Weapon
            if (Input.GetButtonDown("P1_Pickup"))
            {
                m_TwilightPlayer.PickUpWeapon();
            }

            // Activation of Objects
            if (Input.GetButtonDown("P1_Activate"))
            {
                m_LightPlayer.UseWeapon();
            }

            // Weapon Usage
            if (Input.GetButtonDown("P1_UseWeapon"))
            {
                m_TwilightPlayer.UseWeapon();
            }
        }
    }

    //-------------------------------------------------------------------------

    void OnGUI()
    {
        if (!m_IsGameOver)
        {
            DrawHealthBoxes();
			DrawEnergyBoxes();
        }
    }

    #endregion 



    #region public methods

    public void SetGameOver()
    {
        m_IsGameOver = true;
    }

    //-------------------------------------------------------------------------

    #endregion



    #region private methods

	private void DrawEnergyBoxes()
	{
		if (e_PlayerState == playerState.SPLIT)
		{
			// Draw Light Health Bar
			GUI.DrawTexture(new Rect(Energy_TopRightOrigin.x, Energy_TopRightOrigin.y, Energy_WidthHeight.x, Energy_WidthHeight.y), Energy_Light_BG_Texture, ScaleMode.ScaleAndCrop, true, 0);
			GUI.DrawTexture(new Rect(Energy_TopRightOrigin.x, Energy_TopRightOrigin.y, Energy_WidthHeight.x * (m_LightPlayer.GetCurrentEnergy() / m_LightPlayer.m_EnergyMax), Energy_WidthHeight.y), Energy_Light_FG_Texture, ScaleMode.ScaleAndCrop, true, 0);
			
			// Draw Shadow Shadow Bar
			GUI.DrawTexture(new Rect(Energy_TopRightOrigin.x, Energy_TopRightOrigin.y + ySkew, Energy_WidthHeight.x, Energy_WidthHeight.y), Energy_Shadow_BG_Texture, ScaleMode.ScaleAndCrop, true, 0);
			GUI.DrawTexture(new Rect(Energy_TopRightOrigin.x, Energy_TopRightOrigin.y + ySkew, Energy_WidthHeight.x * (m_ShadowPlayer.GetCurrentEnergy() / m_ShadowPlayer.m_EnergyMax), Energy_WidthHeight.y), Energy_Shadow_FG_Texture, ScaleMode.ScaleAndCrop, true, 0);            
		}
		else if (e_PlayerState == playerState.FUSED)
		{
			// Draw Light Energy Bar
			GUI.DrawTexture(new Rect(Energy_TopRightOrigin.x, Energy_TopRightOrigin.y, Energy_WidthHeight.x, Energy_WidthHeight.y), Energy_Twilight_BG_Texture, ScaleMode.ScaleAndCrop, true, 0);
			GUI.DrawTexture(new Rect(Energy_TopRightOrigin.x, Energy_TopRightOrigin.y, Energy_WidthHeight.x * (m_TwilightPlayer.GetCurrentEnergy() / m_TwilightPlayer.m_EnergyMax), Energy_WidthHeight.y), Energy_Twilight_FG_Texture, ScaleMode.ScaleAndCrop, true, 0);
		}
	}

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

    //-------------------------------------------------------------------------

    #endregion
}
