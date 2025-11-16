using System;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator animator;

    public float horizontal;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        animator.SetFloat("Horizontal", horizontal);
    }
}