using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject bullet;

    private float timePassed;
    private bool dead;
    private bool jump;
    private bool shot;

    public bool Dead
    {
        get
        {
            return dead;
        }
        set
        {
            dead = value;
        }
    }

    void Start() {
        speed = 10;
        timePassed = 0;
        dead = false;
        jump = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Trap"))
            Debug.Log("Morreu");
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

    void Jump()
    {        
        timePassed += Time.deltaTime;

        if (timePassed < 0.3f)
        {
            this.transform.position += Vector3.up * 1.25f * speed * Time.deltaTime;
        }

        else
        {
            this.transform.position += Vector3.down * 1.25f * speed * Time.deltaTime;
        }

        if (timePassed >= 0.6f)
        {
            jump = false;
            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        }
    }

    void Shot()
    {
        bullet.transform.position = this.transform.position;
        Instantiate(bullet);
        shot = false;
    }

    void Control()
    {
        #region MoveDirection
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -7)
        {
            this.transform.position += Vector3.left* speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && this.transform.position.x <= 7)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        #endregion

        #region SpecialMoves
        if(Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            jump = true;
            timePassed = 0;
        }

        if(Input.GetMouseButtonDown(0) && shot == false)
        {
            shot = true;
            Shot();
        }

        #endregion
        #region LookAtDirection
        /*Quaternion target;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 315, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 45, 0);
            else target = Quaternion.Euler(0,0,0);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 225, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 135, 0);
            else target = Quaternion.Euler(0, 180, 0);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 315, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 225, 0);
            else target = Quaternion.Euler(0, 270, 0);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 45, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 135, 0);
            else target = Quaternion.Euler(0, 90, 0);
            transform.rotation = target;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 270, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 90, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 180, 0);
            else target = transform.rotation;
            transform.rotation = target;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 270, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 90, 0);
            else if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 0, 0);
            else target = transform.rotation;
            transform.rotation = target;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 0, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 180, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 90, 0);
            else target = Quaternion.Euler(0, 270, 0);
            transform.rotation = target;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 0, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 180, 0);
            else if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 270, 0);
            else target = transform.rotation;
            transform.rotation = target;
        }*/
        #endregion
    }

    void Update () {
        
        if(dead)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= 1.3f)
            {
                Application.LoadLevel("Menu");
            }
        }
        else Control();

        if (jump) Jump();

    }
}