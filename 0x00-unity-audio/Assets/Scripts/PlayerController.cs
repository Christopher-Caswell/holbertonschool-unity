using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


/// <summary>
/// Start and update the Player
/// </summary>
public class PlayerController : MonoBehaviour
{
    // public AudioMixer audioMixer;

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
    public bool falling;
    public bool isWalking;
    public bool mobile = true;

    // public AudioSource footsteps;
    // public AudioSource landPlatform;

    void Start()
    {
        // audioMixer.SetFloat("bgmVol", PlayerPrefs.GetFloat("bgmVol", Mathf.Log10(1f) * 20f));
        // audioMixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("sfxVol", Mathf.Log10(1f) * 20f));
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        animator.SetBool("isJumping", !isGrounded);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask, QueryTriggerInteraction.Ignore);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded && playerVelocity.y < -0f)
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

            // if (isGrounded && !footsteps.isPlaying)
            // {
            //     footsteps.Play();
            // }
        }
        // if (Input.GetKeyDown(KeyCode.W && isGrounded))
        // {
        //     animator.SetBool("isWalking", true);
        // }
        // if (Input.GetKeyDown(KeyCode.A && isGrounded))
        // {
        //     animator.SetBool("isWalking", true);
        // }
        // if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        // {
        //     animator.SetBool("isWalking", true);
        // }
        // if (Input.GetKeyDown(KeyCode.D) && isGrounded)
        // {
        //     animator.SetBool("isWalking", true);
        // }
        else
        {
            isWalking = false;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            // animator.SetBool("isJumping", true);
            animator.SetTrigger("jump");
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if  (player.transform.position.y < -1)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
        }
    }

    void FixedUpdate()
    {
        if (player.transform.position.y < -15)
        {
            x.velocity = new Vector3(0, 0, 0);
            player.transform.position = AlbertFrancis.transform.position;
            animator.SetBool("falling", true);      
        }
    }
}
