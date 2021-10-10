using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float kecepatan;
    public Vector2 gerakan;

    
    private float speed = 10;
    private Vector3 targetPosition;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    // perintah ini dapat menggunakan Arrows pada keyboard untuk menggerakan nya
    // atau juga dapat menggunakan A, W, S, D sebagai controller Movement
    // Selama Input pada File Project tidak diubah
    void Update()
    {
        gerakan.x = Input.GetAxisRaw("Horizontal");
        gerakan.y = Input.GetAxisRaw("Vertical");

        // kursor touch
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        if (isMoving)
        {
            Move();
        }
    }

    // kursor touch
    void SetTargetPosition()
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


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + gerakan * kecepatan * Time.fixedDeltaTime);
    }

    // buat isTigger box yng Tag kotak
    // kalau di sentuh hilang
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spawn"))
        {
            Destroy(other.gameObject);
        }
    }
}