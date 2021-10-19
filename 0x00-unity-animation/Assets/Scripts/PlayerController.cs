using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/// <summary>
/// Start and update the Player
/// </summary>
public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public CharacterController controller;
    public Rigidbody x;
    public Transform Camera;
    public float speed = 6.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Vector3 playerVelocity;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;
    public bool isGrounded;
    public Transform AlbertFrancis;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator animator;
    public bool falling = false;
    public bool isWalking;
    public bool mobile = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        animator.SetBool("isJumping", !isGrounded);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask, QueryTriggerInteraction.Ignore);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded && playerVelocity.y < -1.5f)
        {
            playerVelocity.y = -1f;
            animator.SetBool("falling", true);
        }

        if (mobile)
        {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            isWalking = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        animator.SetBool("isWalking", true);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            // animator.SetTrigger("jump");
            animator.SetBool("isJumping", true);
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (player.transform.position.y < -15)
        {
            x.velocity = new Vector3(0, 0, 0);
            player.transform.position = AlbertFrancis.transform.position;      
        }
    }
}
