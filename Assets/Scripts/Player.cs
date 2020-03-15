using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] AudioClip sfxJump;
    [SerializeField] AudioClip sfxDeath;

    string paramIsDead = "isDead";
    string paramYVelocity = "yVelocity";
    private Rigidbody rigidbody;
    private Animator animator;
    AudioSource _audioSource;
    private bool isJumping;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(_audioSource);
        Assert.IsNotNull(rigidbody);
        Assert.IsNotNull(animator);
        Assert.IsNotNull(sfxDeath);
        Assert.IsNotNull(sfxJump);
    }

    private void Update()
    {
        CheckForInput();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        HandleJump();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat(paramYVelocity, rigidbody.velocity.y);
    }

    private void HandleJump()
    {
        if (isJumping)
        {
            isJumping = false;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    private void CheckForInput()
    {
        if (!GameManager.instance.gameOver && GameManager.instance.gameStarted)
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStartedGame();
                rigidbody.useGravity = true;
                isJumping = true;
                _audioSource.PlayOneShot(sfxJump);
            }
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle" :
                _audioSource.PlayOneShot(sfxDeath);
                rigidbody.AddForce(new Vector3(jumpForce / 2, jumpForce, jumpForce / 2), ForceMode.Impulse);
                GameManager.instance.PlayerCollided();
                break;
        }
    }
}
