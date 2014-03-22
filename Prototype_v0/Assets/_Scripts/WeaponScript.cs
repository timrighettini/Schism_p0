using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{

    #region public variables

    public float m_Damage;
    public float m_UsageSpeed;
    public enum WeaponType { MELEE, RANGED };
    public WeaponType e_WeaponType;
    
    #endregion



    #region private variables
        
    private enum PickupState { ON_GROUND, PICKED_UP, IN_USE };
    PickupState e_PickupState = PickupState.ON_GROUND;    

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


    #endregion



    #region public methods

    #endregion



    #region private methods



    #endregion
}
