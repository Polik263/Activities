using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private Rigidbody Player;
    public float speed = 2f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())

        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.L))

        {

            RaycastHit result;
            bool thereWasHit = Physics.Raycast(transform.position, Vector3.forward, out result, Mathf.Infinity);

            Debug.DrawRay(transform.position, transform.forward * 50f, Color.yellow, 0.05f);


            if (thereWasHit)
            {
                Destroy(result.collider.gameObject);
            }
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))

        {
            Player.AddForce(Vector3.up * 300f);
        }
    }

    private bool IsTouchingFloor()
    {
        Vector3 position = transform.position + Vector3.down * 1f;
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.15f, Vector3.down, out hit, 0.5f);
    }
}
