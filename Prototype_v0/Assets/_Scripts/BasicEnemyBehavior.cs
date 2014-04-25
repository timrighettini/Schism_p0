using UnityEngine;
using System.Collections;

public class BasicEnemyBehavior : MonoBehaviour {

    #region public variables

	public GameObject m_Targetshadow,m_Targetlight;    
    public float m_SpeedPerSecond;
    public string m_TagOfTarget;
	public string m_shadow;
	public string m_light;
    public float m_DamageToTake;
    public float m_PlayerPushBackMagnitude;
    public float m_DeathForce;
	public AudioClip Enemyshout;
    public Vector3 m_StartingMovement = Vector3.zero;
    public float m_DelayForStartingMovement = 0.0f;

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

        m_Targetshadow = GameObject.FindGameObjectWithTag(m_shadow);
		m_Targetlight = GameObject.FindGameObjectWithTag(m_light);
		float distlight = (m_Targetlight.transform.position - this.transform.position).magnitude;
		float distshadow = (m_Targetshadow.transform.position - this.transform.position).magnitude;
		if (m_DelayForStartingMovement <= 0.0f)
        {
            if (m_Targetshadow.GetComponent<PlayerManager>().m_InLightHazard)
            {
				m_VectorToTarget = m_Targetshadow.transform.position - m_ThisTransform.position;
            }
			else if (m_Targetlight.GetComponent<PlayerManager>().m_InShadeHazard)
            {
				m_VectorToTarget = m_Targetlight.transform.position - m_ThisTransform.position;
            }
			else
			{
				if(distlight<distshadow)
					m_VectorToTarget = m_Targetlight.transform.position - m_ThisTransform.position;
				else
					m_VectorToTarget = m_Targetshadow.transform.position - m_ThisTransform.position;
			}
        }
        else
        {

            m_VectorToTarget = m_StartingMovement;
        }
    }

    //-------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        m_DelayForStartingMovement -= Time.deltaTime;
		m_Targetshadow = GameObject.FindGameObjectWithTag(m_shadow);
		m_Targetlight = GameObject.FindGameObjectWithTag(m_light);
		float distlight = (m_Targetlight.transform.position - this.transform.position).magnitude;
		float distshadow = (m_Targetshadow.transform.position - this.transform.position).magnitude;

        if (m_DelayForStartingMovement <= 0.0f)
        {
			if (m_Targetshadow.GetComponent<PlayerManager>().m_InLightHazard)
			{
				m_VectorToTarget = m_Targetshadow.transform.position - m_ThisTransform.position;
			}
			else if (m_Targetlight.GetComponent<PlayerManager>().m_InShadeHazard)
			{
				m_VectorToTarget = m_Targetlight.transform.position - m_ThisTransform.position;
			}
			else
			{
				if(distlight<distshadow)
					m_VectorToTarget = m_Targetlight.transform.position - m_ThisTransform.position;
				else
					m_VectorToTarget = m_Targetshadow.transform.position - m_ThisTransform.position;
			}
        }
        else
        {
            m_VectorToTarget = m_StartingMovement;
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
            player.StunOnCollision();
            other.gameObject.rigidbody.AddForce(Vector3.up * m_PlayerPushBackMagnitude);
            other.gameObject.rigidbody.AddForce(transform.forward * m_PlayerPushBackMagnitude);
			audio.PlayOneShot(Enemyshout);
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
