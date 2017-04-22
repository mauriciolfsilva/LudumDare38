using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    [SerializeField]
    private float speed;
    void Start ()
    {
        speed = 100;
    }

	void Update ()
    {
        this.transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            col.gameObject.GetComponent<EnemyBehavior>().Life -= 1;
            Destroy(this.gameObject);
        }
    }
}
