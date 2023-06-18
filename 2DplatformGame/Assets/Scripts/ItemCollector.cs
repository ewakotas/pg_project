using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private Text livesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();  
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log(cherries);
            cherriesText.text = "Cherries: " + cherries;
        }
        if (collision.gameObject.CompareTag("heart"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log(cherries);
            livesText.text = (Int32.Parse(livesText.text) + 1).ToString();

        }
    }
}
