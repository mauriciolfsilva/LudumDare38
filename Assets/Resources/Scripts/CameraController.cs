using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject enemy;

    private float timeToSpawn;

    void Start()
    {
        speed = 10;
        timeToSpawn = 3;
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    void Spawn()
    {
        int sp = Random.Range(0, 3);

        enemy.transform.position = spawnPoints[sp].transform.position;
        Instantiate(enemy);

        timeToSpawn = Random.Range(2, 5);//melhorar o tempo
    }

    void Control()
    {
        #region MoveDirection
        if (Input.GetKey(KeyCode.W) && this.transform.position.y < 430)
        {
            this.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && this.transform.position.y > -428)
        {
            this.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        #endregion
    }

    void Update()
    {
        Control();
        timeToSpawn -= Time.deltaTime;

        if(timeToSpawn <= 0)
        {
            Spawn();
        }

    }
}
