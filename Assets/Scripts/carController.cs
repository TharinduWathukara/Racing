using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float carSpeed;
    public float maxPos = 2.0f;
    Vector3 position;
    public uiManager ui;
    public audioManager am;
    public float powerTime = 5f;
    float timer;
    public Sprite car, powerCar;

    //Rigidbody2D rb;

    //bool currentPlatformAndroid;

    // Start is called before the first frame update
    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = car;
        am.carSound.Play();
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        changeSprite();

        /*position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        transform.position = position;*/
        
        
        float x = Input.acceleration.x;

        if (x < -0.2f)
        {
            //MoveRight();
            position.x += -carSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
            transform.position = position;
        }
        else if (x > 0.2f)
        {
            //MoveLeft();
            position.x += carSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
            transform.position = position;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy Car")
        {
            if(timer > 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
                //gameObject.SetActive(false);
                ui.gameOverFN();
                am.carSound.Stop();
            }
        }
        if(collision.gameObject.tag == "Power")
        {
            Destroy(collision.gameObject);
            timer = powerTime;
        }
    }

    void changeSprite()
    {
        if(timer > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = powerCar;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = car;
        }
    }

    /*void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }*/
}
