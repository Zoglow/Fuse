using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmieController : MonoBehaviour {


    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float jumpSpeed;
    public float maxSpeed;

    public int desiredLane = 1; // Left = 0, Middle = 1, Right = 2
    public float laneDistance = 4; // Distance between two lanes

    public float jumpForce;
    public float gravity = -30;

    public Animator animator;

    // Start is called before the first frame update
    void Start() {

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {

        // Show that game has started
        if (!PlayerManager.isGameStarted) return;
        animator.SetBool("isGameStarted", true);

        // Increase speed with time
        if (forwardSpeed < maxSpeed) {
            forwardSpeed += 0.1f * Time.deltaTime;
            jumpSpeed += 0.1f * Time.deltaTime;
        }
        

        if (controller.isGrounded) {
            direction.z = forwardSpeed;
        } else {
            direction.z = jumpSpeed;
        }


        direction.y += gravity * Time.deltaTime;

        animator.SetBool("isGrounded", controller.isGrounded);

        // Recieve input to jump

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (controller.isGrounded) {
                Jump();
            }
            
        }

        // Check which lane

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (desiredLane < 2) {
                desiredLane++;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (desiredLane > 0) {
                desiredLane--;
            }
        }

        // Calculate future position

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0) {
            targetPosition += Vector3.left * laneDistance;
        } else if (desiredLane == 2) {
            targetPosition += Vector3.right * laneDistance;
        }

        // Move smoothly right or left

        if (transform.position == targetPosition) return;

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude) controller.Move(moveDir);
        else controller.Move(diff);

    }

    private void FixedUpdate() {

        if (!PlayerManager.isGameStarted) return;

        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump() {
        direction.y = jumpForce;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {

        if(hit.transform.tag == "Obstacle") {

            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().playSound("GameOver");
            FindObjectOfType<AudioManager>().stopSound("Theme");

        }

    }

}
