using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // gerakkanan kiri
    private Rigidbody2D rb;
    public float kecepatan;
    public Vector2 gerakan;

    // Touch
    private float speed = 10;
    private Vector3 targetPosition;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // gerak kanan kiri
        gerakan.x = Input.GetAxisRaw("Horizontal");
        gerakan.y = Input.GetAxisRaw("Vertical");

        // kursor touch
        if (Input.GetMouseButton(0))
        {
            SetTargerPosiotion();
        }
        if (isMoving)
        {
            Move();
        }
    }

    // kursor touch
    void SetTargerPosiotion()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }
    // kursor touch
    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    // gerak kanan kiri
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + gerakan * kecepatan * Time.fixedDeltaTime);
    }

    // buat isTigger box yng Tag kotak
    // kalau di sentuh hilang
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kotak"))
        {
            Destroy(other.gameObject);
        }
    }
}

