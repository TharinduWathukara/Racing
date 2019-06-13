using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject[] cars;
    int carNo;
    //public float maxPos = 2.0f;
    public float delayTimer = 1.2f;
    float timer;
    public float[] positions = { -1.96f, -0.71f, 0.57f, 1.87f };
    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            int index = Random.Range(0, 4);
            Vector3 carPos = new Vector3(positions[index], transform.position.y, transform.position.z);
            carNo = Random.Range(0, cars.Length);
            Instantiate(cars[carNo], carPos, transform.rotation);

            timer = delayTimer;
        }
        
    }
}
