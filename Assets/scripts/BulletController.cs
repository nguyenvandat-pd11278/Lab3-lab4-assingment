using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public GameObject bulletPrefrab;
    public float fireRate = 1f;
    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= 1f / fireRate)
        {
            Instantiate(bulletPrefrab, gameObject.transform.position, Quaternion.identity);
            fireTimer = 0f;
        }
    }
}
    
