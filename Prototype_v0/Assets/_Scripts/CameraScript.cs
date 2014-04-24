using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    #region public variables

    public GameObject m_FollowObject;
    public GameObject m_ZoomObject;
	public GameObject tp;

    public float m_FollowDistance;
    public float m_ZoomDistance;
    public float m_ZoomTopOff;
    public float m_MaxZoom;

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
        while (true)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            if (!GeometryUtility.TestPlanesAABB(planes, m_ZoomObject.collider.bounds))
            {
                camera.transform.Translate(0, 0, m_ZoomDistance);
            }
            else
            {
                camera.transform.Translate(0, 0, m_ZoomDistance * m_ZoomTopOff);
                if (camera.transform.position.z <= m_MaxZoom)
                {
                    camera.transform.position = new Vector3(
                        camera.transform.position.x,
                        camera.transform.position.y,
                        m_MaxZoom
                    );

                }
                break;
            }
        }        
    }


    #endregion



    #region public methods    

    #endregion



    #region private methods



    #endregion
}
