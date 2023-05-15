using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // If you are new to C#, you may not have seen these before. This is called an auto-property. A property is
    // a shortcut for making a variable and a pair of methods that get and set the variable's value. In this case,
    // we let anyone get Health's value, but only we are allowed to set it.
    public int Healths { get; private set; }
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void TakeDamage(int damage)
    {
        Healths -= damage; // We make this a different method so that you could do other effects in here if you want to, like play and 'oof' sound or blood animation
        Debug.Log("shdfioshfdoisai");
    }

    // Start is called before the first frame update
    void Start()
    {
        Healths = numOfHearts;
    }

    // Update is called once per frame
    void Update()
    {
        if (Healths > numOfHearts)
        {
            Healths = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Healths)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
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

