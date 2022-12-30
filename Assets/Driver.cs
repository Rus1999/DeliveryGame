using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpped = 10f;
    [SerializeField] float boostSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        // float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       moveSpeed = slowSpped;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            Debug.Log("!!!!!!!!!!!!");
            moveSpeed = boostSpeed;
        }    
    }
}