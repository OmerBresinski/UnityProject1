using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    public Animator animator;
    public bool isOpen;

    void Start()
    {
        animator = GameObject.FindWithTag("doorAxis").GetComponent<Animator>();
        isOpen = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        if (other.CompareTag("MainCamera"))
        {
            animator.SetTrigger("DoorOpen");
            isOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit");
        if (isOpen)
        {
            animator.SetTrigger("DoorClose");
            isOpen = false;
        }
    }
}