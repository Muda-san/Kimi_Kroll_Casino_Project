using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite brokenHeart;




    public static Health instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Health dans la scène");
            return;
        }

        instance = this;
    }




    void Update()
    {
        health = Player_controler.instance.health;

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = brokenHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }
}
