using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private float speed = 10; //perintah ini merupakan class untuk mengatur kecepatan gulir bola ketika di klik ke area tertentu
    private Vector3 targetPosition;
    private bool isMoving = false;

    // script perintah untuk controller mouse 
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        if (isMoving)
        {
            Move();
        }
    }

    // perintah input klik menuju area tertentu pada mouse 
    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    // menggerakan bola sesuai posisi klik yang dituju pada mouse
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