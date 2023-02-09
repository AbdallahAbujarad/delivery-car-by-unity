using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float boostSpeed = 20;
    [SerializeField] float slowSpeed = 4;

    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.Translate(0,moveAmount,0);
        if(moveAmount>=0)
            transform.Rotate(0,0, -steerAmount);
        else
            transform.Rotate(0,0,steerAmount);
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}
