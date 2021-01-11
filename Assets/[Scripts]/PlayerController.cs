using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    private Vector3 direction;

    private void Update() {
        ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ReadInput() {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    private void Move() {
        transform.position += direction * moveSpeed * Time.fixedDeltaTime;
    }

}
