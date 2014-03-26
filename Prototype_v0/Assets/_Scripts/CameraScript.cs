using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    #region public variables

    public GameObject m_FollowObject;
    public float m_FollowDistance;

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
        if (m_FollowObject)
        {
            camera.transform.position = new Vector3(m_FollowObject.transform.position.x, camera.transform.position.y, m_FollowObject.transform.position.z + m_FollowDistance);
        }
    }


    #endregion



    #region public methods    

    #endregion



    #region private methods



    #endregion
}
