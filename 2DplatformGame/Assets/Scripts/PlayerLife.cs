using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Text livesText;
    private static int livesNumber = 3;

    void Start()
    {
        livesText.text = "Lives: " + livesNumber;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSoundEffect.Play();
        livesNumber--;
    }

    private void RestartLevel()
    {
        if(livesNumber > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        else
        {
            Debug.Log(SceneManager.GetSceneByName("End Screen"));
            SceneManager.LoadScene("End Screen");
        }
        
    }

}
