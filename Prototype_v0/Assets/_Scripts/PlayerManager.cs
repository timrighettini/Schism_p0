using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    #region public variables

    public float m_movementSpeed;
    public enum playerType { LIGHT, SHADOW, TWILIGHT };
    public playerType e_PlayerType;
    public float m_HealthMax;
    public float m_HealthToModifyPerSecond;
    public float m_OppositeElementModifier;

    #endregion



    #region private variables

    private GameObject m_playerGameobject;
    private bool m_InLightHazard = false;
    private bool m_InShadeHazard = false;

    public float m_CurrentHealth;
            
    #endregion



    #region unity overrides

    void Start()
    {
        m_playerGameobject = this.gameObject;
        m_CurrentHealth = m_HealthMax;
    }
    
    void FixedUpdate()
    {
        if (m_InLightHazard)
        {
            if (e_PlayerType == playerType.SHADOW)
            {
                m_CurrentHealth -= (m_HealthToModifyPerSecond * m_OppositeElementModifier) * Time.deltaTime;

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else if (e_PlayerType == playerType.TWILIGHT)
            {
                m_CurrentHealth -= m_HealthToModifyPerSecond * Time.deltaTime;

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else
            {
                m_CurrentHealth += m_HealthToModifyPerSecond * Time.deltaTime;

                if (m_CurrentHealth > m_HealthMax)
                {
                    m_CurrentHealth = m_HealthMax;
                }
            }
        }
        else if (m_InShadeHazard)
        {
            if (e_PlayerType == playerType.LIGHT)
            {
                m_CurrentHealth -= (m_HealthToModifyPerSecond * m_OppositeElementModifier) * Time.deltaTime;

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else if (e_PlayerType == playerType.TWILIGHT)
            {
                m_CurrentHealth -= m_HealthToModifyPerSecond * Time.deltaTime;

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else
            {
                m_CurrentHealth += m_HealthToModifyPerSecond * Time.deltaTime;

                if (m_CurrentHealth > m_HealthMax)
                {
                    m_CurrentHealth = m_HealthMax;
                }
            }
        }
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

    public void SetInShadeHazard(bool val)
    {
        m_InShadeHazard = val;
    }

    public void SetInLightHazard(bool val)
    {
        m_InLightHazard = val;
    }

    public float GetCurrentHealth()
    {
        return m_CurrentHealth;
    }

    #endregion



    #region private methods



    #endregion
}
