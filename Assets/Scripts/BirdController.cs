using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float upwardForce = 5f; // Upward force to be applied
    public AudioClip jumpSound;
    public GameObject retryMenu;
    public GameObject pauseMenu;
    public AudioSource backgroundMusic;

    private Rigidbody2D rb2d;
    private bool isJumping = false;
    private AudioSource audioSource;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Get input from update method
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 0;
            backgroundMusic.Pause();
            retryMenu.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // 
        if (isJumping && rb2d.velocity.y <= 2f)
        {
            if (audioSource.clip != jumpSound)
            {
                audioSource.Stop();
                audioSource.clip = jumpSound;
            }
            audioSource.Play();

            rb2d.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
