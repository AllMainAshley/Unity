using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;
    public ParticleSystem exposionParticle;
    public ParticleSystem dirtPartical;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public float jumpforce=10;
    public float gravityModifier=1;
    private bool isOnGround=true;
    public bool gameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround&&!gameOver)
        {
            playerRb.AddForce(Vector3.up * 10,ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtPartical.Play();
            playerAudio.PlayOneShot(jumpSound, 1.0f);//1.0f指的是Volum音量
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtPartical.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!!!");
            playerAnimator.SetBool("Death_b",true);
            playerAnimator.SetInteger("DeathType_int", 1);
            exposionParticle.Play();
            dirtPartical.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
