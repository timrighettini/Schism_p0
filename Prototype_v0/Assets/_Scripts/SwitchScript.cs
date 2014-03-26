using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour
{

    #region public variables

    public GameObject[] m_UpObjects;
    public GameObject[] m_DownObjects;

    public enum SWITCH_POSITION { UP, DOWN };
    public SWITCH_POSITION e_Switch_Position = SWITCH_POSITION.DOWN;

    #endregion



    #region private variables

    private GameObject m_Switch_Piece;
    private GameObject m_TopPoint;
    private GameObject m_BottomPoint;

    PlayerManager m_LightPlayer;
    PlayerManager m_ShadowPlayer;
    PlayerManager m_TwilightPlayer;

    #endregion



    #region unity overrides

    // Use this for initialization
    void Start()
    {
        m_Switch_Piece = transform.FindChild("Switch_Piece").gameObject;
        m_TopPoint = transform.FindChild("Top_Point").gameObject;
        m_BottomPoint = transform.FindChild("Bottom_Point").gameObject;

        // Grab all of the player references, make it automated
        m_LightPlayer = GameObject.FindGameObjectWithTag("LightPlayer").GetComponent<PlayerManager>();
        m_ShadowPlayer = GameObject.FindGameObjectWithTag("ShadowPlayer").GetComponent<PlayerManager>();
        m_TwilightPlayer = GameObject.FindGameObjectWithTag("TwilightPlayer").GetComponent<PlayerManager>();

        SetActiveObjects();
    }

    //-------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {

    }

    #endregion



    #region public methods

    public void FlipSwitch()
    {
        if (e_Switch_Position == SWITCH_POSITION.DOWN)
        {
            e_Switch_Position = SWITCH_POSITION.UP;
        }
        else
        {
            e_Switch_Position = SWITCH_POSITION.DOWN;
        }
        SetActiveObjects();
    }

    //-------------------------------------------------------------------------

    #endregion



    #region private methods

    private void SetActiveObjects()
    {
        m_LightPlayer.rigidbody.WakeUp();
        m_ShadowPlayer.rigidbody.WakeUp();
        m_TwilightPlayer.rigidbody.WakeUp();
        
        if (e_Switch_Position == SWITCH_POSITION.DOWN)
        {
            m_Switch_Piece.transform.position = m_BottomPoint.transform.position;
            m_Switch_Piece.renderer.material.color = Color.red;
            foreach (GameObject g in m_UpObjects)
            {
                //g.transform.Translate(0, -1000, 0);
                g.SetActive(false);
            }
            foreach (GameObject g in m_DownObjects)
            {
                //if (g.transform.position.y < -100)
                //{
                //    g.transform.Translate(0, 1000, 0);
                //}
                g.SetActive(true);
            }
        }
        else
        {
            m_Switch_Piece.transform.position = m_TopPoint.transform.position;
            m_Switch_Piece.renderer.material.color = Color.green;
            foreach (GameObject g in m_UpObjects)
            {
                //if (g.transform.position.y < -100)
                //{
                //    g.transform.Translate(0, 1000, 0);
                //}
                g.SetActive(true);
            }
            foreach (GameObject g in m_DownObjects)
            {
                //g.transform.Translate(0, -1000, 0);
                g.SetActive(false);
            }
        }
    }

    //-------------------------------------------------------------------------

    #endregion
}
