using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour {

    #region public variables

    public GameObject m_Target;    
    public float m_SpeedPerSecond;
    public string m_TagOfTarget;

    #endregion



    #region private variables

    private Vector3 m_VectorToTarget = new Vector3();
    private Transform m_ThisTransform;

    #endregion



    #region unity overrides

    // Use this for initialization
    void Start()
    {
        m_ThisTransform = this.transform;

        m_Target = GameObject.FindGameObjectWithTag(m_TagOfTarget);
        
        if (m_Target)
        {
            m_VectorToTarget = m_Target.transform.position - m_ThisTransform.position;
        }
        else
        {
            m_VectorToTarget = Vector3.zero;
        }        
    }

    //-------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        // Move in the direction towards the target, then update that direction
        if (m_Target)
        {
            m_VectorToTarget = m_Target.transform.position - m_ThisTransform.position;            
        }
        else
        {
            m_VectorToTarget = Vector3.left;            
        }        

        // For basic enemy, we will only follow on the ground, so let's
        // get rid of any y-movement

        Vector3 forwardNoY = Vector3.Normalize(m_VectorToTarget);
        forwardNoY.y = 0;
        m_ThisTransform.forward = forwardNoY;
        

        m_ThisTransform.position += (forwardNoY * m_SpeedPerSecond * Time.deltaTime);
    }

    //-------------------------------------------------------------------------

    #endregion



    #region public methods

    #endregion



    #region private methods



    #endregion
}
