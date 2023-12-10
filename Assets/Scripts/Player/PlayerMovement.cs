using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    DialogueManager dialogueManager;
    Animator playerAnim;

    float horizontal;
    float vertical;

    public float moveSpeed = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (dialogueManager.dialogueIsPlaying) return;

        horizontal = Input.GetAxisRaw("Horizontal"); 
        playerAnim.SetFloat("Horizontal", horizontal);

        vertical = Input.GetAxisRaw("Vertical");
        playerAnim.SetFloat("Vertical", vertical);
    }

    void FixedUpdate()
    {
        if (dialogueManager.dialogueIsPlaying) return;

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}