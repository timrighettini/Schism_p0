using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    #region public variables

    public float m_movementSpeed;
    public enum playerType { LIGHT, SHADOW, TWILIGHT };
    public playerType e_PlayerType;

    #endregion



    #region private variables

    private GameObject m_playerGameobject;
            
    #endregion



    #region unity overrides

    // Use this for initialization
    void Start()
    {
        m_playerGameobject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {        

    }

    #endregion



    #region public methods

    public void Move(float dx, float dy)
    {        
        m_playerGameobject.transform.Translate(dx * m_movementSpeed * Time.deltaTime, 0, dy * m_movementSpeed * Time.deltaTime);
    }

    public void UseWeapon()
    {
        // Swing weapon if one is currently held
    }

    #endregion



    #region private methods



    #endregion
}
