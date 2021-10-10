using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private float speed = 4;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargerPosiotion();
        }
        if (isMoving)
        {
            Move();
        }
    }

    void SetTargerPosiotion()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
