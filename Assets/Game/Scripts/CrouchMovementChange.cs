using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;
using TMPro;
public class CrouchMovementChange : MonoBehaviour
{
      private PlayerMovement _player;
    [SerializeField]
    private PlayerData[] playerTypes;
  
    private Transform spawnPoint;



    private int _currentPlayerTypeIndex;
  

    private void Awake()
    {
        
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Start()
    {
 
        SwitchPlayerType(0);
    }

    public void SwitchPlayerType(int index)
    {
        _player.Data = playerTypes[index];
        _currentPlayerTypeIndex = index;

       
    }




    private void Update()
    {
      

        if (Input.GetButton("Fire3"))
        {
           
                SwitchPlayerType(1);
            
           
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {

                SwitchPlayerType(2);


            }
            else
            SwitchPlayerType(0);
        }
    }
  
}
