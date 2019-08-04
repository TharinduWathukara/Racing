using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarMove : MonoBehaviour
{
    public float speed = 5f;
    public float speedD = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speedD * Time.deltaTime);
    }
}
