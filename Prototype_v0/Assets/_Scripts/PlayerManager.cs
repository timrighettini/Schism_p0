using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {    

    #region public variables

    public float m_movementSpeed;
    public float m_HealthMax;
    public float m_HealthToModifyPerSecond;
    public float m_OppositeElementModifier;
    public enum playerType { LIGHT, SHADOW, TWILIGHT };
    public playerType e_PlayerType;

    #endregion



    #region private variables

    private GameObject m_playerGameobject;
    private GameObject m_NearWeapon;
    private GameObject m_EquippedWeapon;
    private GameObject m_SwingNode;
    private GameObject m_CurrentSwitch;
    private ParticleSystem m_Particles;
    private WeaponScript m_EquippedWeaponScript;
    private float m_CurrentHealth;
    private bool m_InLightHazard = false;
    private bool m_InShadeHazard = false;
    private bool m_IsNearWeapon = false;
                   
    #endregion



    #region unity overrides

    void Start()
    {
        m_playerGameobject = this.gameObject;
        m_CurrentHealth = m_HealthMax;
        m_SwingNode = transform.FindChild("SwingNode").gameObject;
        m_Particles = transform.GetComponentInChildren<ParticleSystem>();
    }

    //-------------------------------------------------------------------------
    
    void FixedUpdate()
    {        
        if (m_InLightHazard)
        {
            if (e_PlayerType == playerType.SHADOW)
            {
                m_CurrentHealth -= (m_HealthToModifyPerSecond * m_OppositeElementModifier) * Time.deltaTime;

                m_Particles.startColor = Color.red;
                if (m_Particles.isStopped)
                {
                    m_Particles.Play();
                }

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else if (e_PlayerType == playerType.TWILIGHT)
            {
                m_CurrentHealth -= m_HealthToModifyPerSecond * Time.deltaTime;

                m_Particles.startColor = Color.red;
                if (m_Particles.isStopped)
                {
                    m_Particles.Play();
                }

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else
            {
                m_CurrentHealth += m_HealthToModifyPerSecond * Time.deltaTime;

                m_Particles.startColor = Color.green;
                if (m_Particles.isStopped)
                {
                    m_Particles.Play();
                }

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

                m_Particles.startColor = Color.red;
                if (m_Particles.isStopped)
                {
                    m_Particles.Play();
                }

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else if (e_PlayerType == playerType.TWILIGHT)
            {
                m_CurrentHealth -= m_HealthToModifyPerSecond * Time.deltaTime;

                m_Particles.startColor = Color.red;
                if (m_Particles.isStopped)
                {
                    m_Particles.Play();
                }

                if (m_CurrentHealth < 0)
                {
                    m_CurrentHealth = 0;
                }
            }
            else
            {
                m_CurrentHealth += m_HealthToModifyPerSecond * Time.deltaTime;

                m_Particles.startColor = Color.green;
                if (m_Particles.isStopped)
                {
                    m_Particles.Play();
                }

                if (m_CurrentHealth > m_HealthMax)
                {
                    m_CurrentHealth = m_HealthMax;
                }
            }
        }
        else
        {
            if (m_Particles.isPlaying)
            {
                m_Particles.Play();
            };
        }
    }

    //-------------------------------------------------------------------------

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            m_IsNearWeapon = true;
            m_NearWeapon = other.gameObject;
        }  
        else if (other.CompareTag("Switch"))
        {
            m_CurrentSwitch = other.gameObject;
        }
    }

    //-------------------------------------------------------------------------

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            m_IsNearWeapon = false;
            m_NearWeapon = null;
        }
        else if (other.CompareTag("Switch"))
        {
            m_CurrentSwitch = null;
        }
    }

    //-------------------------------------------------------------------------

    #endregion



    #region public methods

    public void Move(float dx, float dy)
    {
        if (dx == 0 && dy == 0)
        {
            return;
        }
        
        m_playerGameobject.transform.position += new Vector3(dx * m_movementSpeed * Time.deltaTime, 0, dy * m_movementSpeed * Time.deltaTime);
        if (dy > 0)
        {
            if (dx > 0)
            {
                transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            else if (dx < 0)
            {
                transform.rotation = Quaternion.Euler(0, -45, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (dy < 0)
        {
            if (dx > 0)
            {
                transform.rotation = Quaternion.Euler(0, 135, 0);
            }
            else if (dx < 0)
            {
                transform.rotation = Quaternion.Euler(0, -135, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            if (dx < 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }

    //-------------------------------------------------------------------------

    public void UseWeapon()
    {
        if (!m_EquippedWeapon)
        {
            return;
        }
        
        if (m_EquippedWeaponScript.e_WeaponType == WeaponScript.WeaponType.MELEE)
        {
            // Swing the weapon
            m_EquippedWeapon.transform.parent = m_SwingNode.transform;
            m_EquippedWeapon.transform.localPosition = m_EquippedWeaponScript.m_AnimationOffset;
            foreach (AnimationState state in m_SwingNode.animation)
            {
                state.speed = m_EquippedWeaponScript.m_UsageSpeed;
            }            
            m_SwingNode.animation.Play();
        }
        else if (m_EquippedWeaponScript.e_WeaponType == WeaponScript.WeaponType.RANGED)
        {
            // Shoot a projectile
        }
    }

    //-------------------------------------------------------------------------

    public void StartSwing()
    {        
        m_EquippedWeaponScript.e_PickupState = WeaponScript.PickupState.IN_USE;        
    }

    //-------------------------------------------------------------------------

    public void EndSwing()
    {
        m_EquippedWeapon.transform.parent = transform;
        m_EquippedWeapon.transform.localRotation = Quaternion.Euler(m_EquippedWeaponScript.m_BaseRotation);
        m_EquippedWeapon.transform.localPosition = m_EquippedWeaponScript.m_PlacementOffset;
        m_EquippedWeaponScript.e_PickupState = WeaponScript.PickupState.PICKED_UP;
    }

    //-------------------------------------------------------------------------

    public void PickUpWeapon()
    {
        if (m_IsNearWeapon)
        {
            print("here1");
            if (m_EquippedWeapon && m_EquippedWeaponScript.e_PickupState != WeaponScript.PickupState.IN_USE)
            {
                DequipWeapon(m_EquippedWeapon);
            }

            EquipWeapon(m_NearWeapon);
        }
        else
        {
            print("here2");
            if (m_EquippedWeapon && m_EquippedWeaponScript.e_PickupState != WeaponScript.PickupState.IN_USE)
            {
                DequipWeapon(m_EquippedWeapon);
            }
        }
    }

    //-------------------------------------------------------------------------

    public void SetInShadeHazard(bool val)
    {
        m_InShadeHazard = val;
    }

    //-------------------------------------------------------------------------

    public void SetInLightHazard(bool val)
    {
        m_InLightHazard = val;
    }

    //-------------------------------------------------------------------------

    public float GetCurrentHealth()
    {
        return m_CurrentHealth;
    }

    //-------------------------------------------------------------------------

    public void MinusCurrentHealth(float minusVal)
    {
        if (minusVal < 0)
        {
            Debug.Log("ERROR: Cannot minus health with a negative value");
            return;
        }

        m_CurrentHealth -= minusVal;
        if (m_CurrentHealth < 0)
        {
            m_CurrentHealth = 0;
        }
    }

    //-------------------------------------------------------------------------

    public void PlusCurrentHealth(float plusVal)
    {
        if (plusVal < 0)
        {
            Debug.Log("ERROR: Cannot plus health with a negative value");
            return;
        }

        m_CurrentHealth += plusVal;
        if (m_CurrentHealth > m_HealthMax)
        {
            m_CurrentHealth = m_HealthMax;
        }
    }

    //-------------------------------------------------------------------------

    public void Activate()
    {
        if (m_CurrentSwitch)
        {
            m_CurrentSwitch.GetComponent<SwitchScript>().FlipSwitch();
        }
    }

    //-------------------------------------------------------------------------

    #endregion



    #region private methods

    private void EquipWeapon(GameObject weapon)
    {
        m_EquippedWeapon = weapon;
        m_EquippedWeaponScript = m_EquippedWeapon.GetComponent<WeaponScript>();

        // Place the weapon in the correct place        
        m_EquippedWeapon.transform.parent = transform;
        m_EquippedWeapon.transform.localRotation = Quaternion.Euler(m_EquippedWeaponScript.m_BaseRotation);
        m_EquippedWeapon.transform.localPosition = m_EquippedWeaponScript.m_PlacementOffset;
        m_EquippedWeaponScript.e_PickupState = WeaponScript.PickupState.PICKED_UP;

        m_EquippedWeapon.rigidbody.isKinematic = true;

        // Same exit condition for exit weapon trigger
        m_IsNearWeapon = false;
        m_NearWeapon = null;
    }

    //-------------------------------------------------------------------------

    private void DequipWeapon(GameObject weapon)
    {
        m_EquippedWeapon.rigidbody.isKinematic = false;
        m_EquippedWeaponScript.e_PickupState = WeaponScript.PickupState.ON_GROUND;
        m_EquippedWeaponScript = null;
        m_EquippedWeapon.transform.parent = null;
        m_EquippedWeapon = null;
    }

    //-------------------------------------------------------------------------

    #endregion
}
