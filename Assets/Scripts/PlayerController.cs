using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float Speed = 5f;
    [SerializeField] float Rotation = 10f;

    CharacterController cc;
    Vector3 rotation;
    Vector3 movement = Vector3.zero;
    bool running = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        running = false;

        if (Input.GetKey(KeyCode.W)) movement += transform.forward;
        if (Input.GetKey(KeyCode.A)) movement += transform.right * -1;
        if (Input.GetKey(KeyCode.S)) movement += transform.forward * -1;
        if (Input.GetKey(KeyCode.D)) movement += transform.right;
        if (Input.GetKey(KeyCode.LeftShift)) running = true;

        movement = movement.normalized * Speed * (running ? 1.5f : 1) * Time.deltaTime;
        movement.y = 0;

        cc.Move(movement);        

        rotation.y += Input.GetAxis("Horizontal") * Rotation * Time.deltaTime;
        rotation.x += -Input.GetAxis("Vertical") * Rotation * Time.deltaTime;
        rotation.z = 0;

        rotation.x = Mathf.Clamp(rotation.x, -45, 45);
        transform.rotation = Quaternion.Euler(rotation);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2))
        {
            InteractiveObject io;
            if (hit.transform.TryGetComponent<InteractiveObject>(out io))
            {
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    io.Activate();
                }
            }
        }

    }

    public bool IsRunning() => running;
    public bool IsMoving() => movement.magnitude > 0;
    public float GetCurrentSpeed() => Speed * (running ? 1.5f : 1);
}
