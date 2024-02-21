using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VieBoss : MonoBehaviour
{
    public int health;
    public int numOfBarre;

    public Image[] barre;
    public Sprite fullBarre;
    public Sprite emptyBarre;

    public static Health instance;

    private void Update()
    {
        health = BossScript.instance.health;
        if (health > numOfBarre)
        {
            health = numOfBarre;
        }
        for (int i = 0; i < barre.Length; i++)
        {
            if (i < health)
            {
                barre[i].sprite = fullBarre;
            }
            else
            {
                barre[i].sprite = emptyBarre;
            }

            if (i < numOfBarre)
            {
                barre[i].enabled = true;
            }
            else
            {
                barre[i].enabled = false;
            }
        }
    }
}



   