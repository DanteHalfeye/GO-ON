using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInterface : MonoBehaviour
{
    [SerializeField] int damagepoints = -1;
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerInmunity player = other.gameObject.GetComponent<PlayerInmunity>();


        if (player != null)
        {
            player.ChangeHealth(damagepoints);


        }
    }
}
