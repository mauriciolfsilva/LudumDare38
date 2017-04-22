using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField]
    private float speed;

    private int life;

    public int Life
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }   
    }

    void Start()
    {
        speed = 10;
        life = 1;
    }

    void Update()
    {
        this.transform.position += Vector3.back * speed * Time.deltaTime;
        if(life < 1)
        {
            Destroy(this.gameObject);
        }
    }
}