using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    #region public variables

    public float m_SpawnPeriod;
    public float m_SpawnPeriodJitter;
    public GameObject m_EnemyType; // THIS MUST BE A PREFAB!

    public Vector3 m_EnemyStartingDirection = new Vector3(0,0,-1);
    public float m_StartingMovementTime = 0.0f;
    public Vector3 m_StartingDirectionJitter = Vector3.zero;
    public float m_EnemySpeedPerSecond = 5.0f;

    #endregion



    #region private variables

    Vector3 m_SpawnerPosition = new Vector3();
    private float m_StartTime;
    private float m_ActualSpawnTime;

    #endregion



    #region unity overrides


    // Use this for initialization
    void Start()
    {
        m_SpawnerPosition = this.transform.position;
        m_StartTime = 0;
        m_ActualSpawnTime = m_SpawnPeriod + Random.Range(-m_SpawnPeriodJitter, m_SpawnPeriodJitter);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_StartTime > m_ActualSpawnTime)
        {
            SpawnEnemy();
            m_ActualSpawnTime = m_SpawnPeriod + Random.Range(-m_SpawnPeriodJitter, m_SpawnPeriodJitter);
            m_StartTime = 0;
        }
        else
        {
            m_StartTime += Time.deltaTime;
        }
    }


    #endregion



    #region public methods

    #endregion



    #region private methods

    private void SpawnEnemy()
    {
        GameObject enemy = (GameObject)Instantiate(m_EnemyType);
        BasicEnemyBehavior enemyBehavior = enemy.GetComponent<BasicEnemyBehavior>();
        enemy.transform.position = m_SpawnerPosition;
        enemyBehavior.m_DelayForStartingMovement = m_StartingMovementTime;
        enemyBehavior.m_SpeedPerSecond = m_EnemySpeedPerSecond;
        enemyBehavior.m_StartingMovement = new Vector3(
            m_EnemyStartingDirection.x + Random.Range(-m_StartingDirectionJitter.x, m_StartingDirectionJitter.x),
            m_EnemyStartingDirection.y + Random.Range(-m_StartingDirectionJitter.y, m_StartingDirectionJitter.y),
            m_EnemyStartingDirection.z + Random.Range(-m_StartingDirectionJitter.z, m_StartingDirectionJitter.z)
        );
    }

    #endregion
}
