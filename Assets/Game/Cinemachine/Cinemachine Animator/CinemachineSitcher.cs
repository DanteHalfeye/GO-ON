using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSitcher : MonoBehaviour
{
    [SerializeField]
    private InputAction action;

    private Animator animator;

    private bool playerCamera = true;



    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

    }
    private void OnEnable() {
        action.Enable();
    
    }

    private void OnDisable()
    {
        action.Disable();

    }
    void Start()
    {
        action.performed += _ => SwitchState();
        animator.Play("bossCamera");

    }
    private void SwitchState()
    {
        if (playerCamera)
        {

            animator.Play("bossCamera");
        }
        else
        {
            animator.Play("Player");
        }
        playerCamera = !playerCamera;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
