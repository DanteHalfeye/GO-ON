using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    [SerializeField] int damage = -1;
  void OnTriggerStay2D(Collider2D other)
    {
        {
            PlayerInmunity controller = other.GetComponent<PlayerInmunity>();
            

            if (controller != null)
            {
                controller.ChangeHealth(damage);
               
            }
        }
    }
}
