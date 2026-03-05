using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float turnSpeed = 60f;

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            move = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            turn = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            turn = 1f;
        }

        transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * turnSpeed * Time.deltaTime);
    }
}