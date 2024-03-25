using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class circlecontroller : MonoBehaviour
{
    private int diretion = 1;
    private float movespeed = 3;
    private int health = 100; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "map")
        {
            diretion *= -1;
        }
        else if (collision.gameObject.CompareTag("bullet"))
        {
            TakeDamage(100);
        }
            
    }
    
    
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
