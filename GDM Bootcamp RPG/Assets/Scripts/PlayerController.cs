using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public float wasdForwardSpeed = 150;

    Camera cam;
    PlayerMotor motor;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // TODO: May need to explain what the "out" keyword does. Passing by value / ref
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                // Stop focusing any objects
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit an interactable
                // If we did, set it as our focusg
            }
        }

        //////////////////
        // WASD control
        //////////////////

        Vector3 camForward = new Vector3(cam.transform.forward.x, 0.0f, cam.transform.forward.z);
        Vector3 velocity = camForward * Input.GetAxis("Vertical") * wasdForwardSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + velocity;
        motor.MoveToPoint(newPosition);
    }
}
