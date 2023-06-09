using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Text livesText;
    [SerializeField] private Text rockText;
    [SerializeField] private string text1;
    [SerializeField] private string text2;
    [SerializeField] private string text3;
    private static int livesNumber = 3;

    void Start()
    {
        livesText.text = livesNumber.ToString();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(livesNumber >=3)
        {
            rockText.text = text1;
        } else if (livesNumber == 2)
        {
            rockText.text = text2;
        } else if (livesNumber == 1)
        {
            rockText.text = text3;
        }
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

        livesNumber = Int32.Parse(livesText.text);
        livesNumber--;
    }

    private void RestartLevel()
    {
        if(Int32.Parse(livesText.text) > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        else
        {
            Debug.Log(SceneManager.GetSceneByName("Death Screen"));
            SceneManager.LoadScene("Death Screen");
        }
        
    }

}
