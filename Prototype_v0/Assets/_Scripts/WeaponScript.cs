using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{

    #region public variables

    public Vector3 m_BaseRotation = Vector3.zero;

    public Vector3 m_PlacementOffset = Vector3.zero;
    public Vector3 m_AnimationOffset = Vector3.zero;
    
    public enum WeaponType { MELEE, RANGED };
    public WeaponType e_WeaponType;

    public enum PickupState { ON_GROUND, PICKED_UP, IN_USE };
    public PickupState e_PickupState = PickupState.ON_GROUND;    

    public float m_Damage;
    public float m_UsageSpeed;
    
	public GameObject player;

	public AudioClip chandshake;
	public AudioClip chandsmash;
	#endregion



    #region private variables
        
    

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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && e_PickupState != PickupState.ON_GROUND)
        {

			BasicEnemyBehavior enemy = other.gameObject.GetComponent<BasicEnemyBehavior>();
            enemy.DestroyEnemy();
			player.GetComponent<PlayerManager>().PlusCurrentHealth(5);
        }
		if (other.gameObject.CompareTag("Rope"))
		{
			audio.PlayOneShot(chandshake);
			//audio.Play(chandshake);
			Debug.Log("rope");
			Destroy(other.gameObject);
			GameObject[] Chandelierpieces=GameObject.FindGameObjectsWithTag("Chandalier");
			if(Chandelierpieces[0])
				for(int i=0;i<Chandelierpieces.Length;i++)
				if(!Chandelierpieces[i].GetComponent<Rigidbody>())
				{
					//audio.Stop();
					Chandelierpieces[i].AddComponent<Rigidbody>();


				}
		}
    }


    #endregion



    #region public methods

    #endregion



    #region private methods



    #endregion
}
