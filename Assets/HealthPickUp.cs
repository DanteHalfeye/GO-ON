using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerInmunity player = other.gameObject.GetComponent<PlayerInmunity>();


        if (player != null)
        {
            player.ChangeHealth(1);
            player.RegenHealth(-1);
            player.PickUp();
        }
        Destroy(this.gameObject);
    }
}
