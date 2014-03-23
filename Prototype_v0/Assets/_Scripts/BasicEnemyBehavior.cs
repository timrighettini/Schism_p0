using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour {

    #region public variables

    public GameObject m_Target;    
    public float m_SpeedPerSecond;
    public string m_TagOfTarget;
    public float m_DamageToTake;
    public float m_PlayerPushBackMagnitude;
    public float m_DeathForce;

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
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            player.MinusCurrentHealth(m_DamageToTake);
            other.gameObject.rigidbody.AddForce(Vector3.up * m_PlayerPushBackMagnitude);
            other.gameObject.rigidbody.AddForce(transform.forward * m_PlayerPushBackMagnitude);
        }
    }

    //-------------------------------------------------------------------------    

    #endregion



    #region public methods

    #endregion

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
        //transform.rigidbody.AddForce(-transform.forward * m_DeathForce);
        //StartCoroutine("KillEnemy");
    }

    #region private methods

    IEnumerator KillEnemy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }

    #endregion
}
