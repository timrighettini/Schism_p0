using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    #region public variables

    public GameObject FollowObject;

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
        if (FollowObject)
        {
            camera.transform.position = new Vector3(FollowObject.transform.position.x, camera.transform.position.y, camera.transform.position.z);
        }
    }


    #endregion



    #region public methods

    #endregion



    #region private methods



    #endregion
}
