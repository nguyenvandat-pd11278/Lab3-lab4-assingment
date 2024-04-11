using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1.5f;
    public Vector3 offset = new Vector3(0f, 0f, 0f);
    private SpriteRenderer spriteRenderer;
    public float followDistance = 12f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("square").GetComponent<Transform>();
        }

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer > followDistance)
        {
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;

        if (direction.x < 0)
            spriteRenderer.flipX = true;
        else if (direction.x > 0)
            spriteRenderer.flipX = false;

        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
