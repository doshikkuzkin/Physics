using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;
    [SerializeField] private float m_JumpForce = 400f;
    [SerializeField] private LayerMask m_WhatIsGround;  
    
    private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded;           
    private Transform m_CeilingCheck;   
    const float k_CeilingRadius = .01f; 
    private Animator m_Anim;            
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    private Transform m_Transform;
    private bool jump = false;
    private ShootController _shootController;
    
    private readonly int m_Speed = Animator.StringToHash("Speed");

    private float shootDirection = 1f;
    
    private void Awake()
    {
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Transform = transform;
        _shootController = GetComponent<ShootController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) jump = true;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shootController.Shoot(shootDirection);
        }
    }

    private void FixedUpdate()
    {
        m_Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        
        var moveX = Input.GetAxis("Horizontal");

        var jumpSpeed = m_Grounded ? 1 : 0.7f;
        
        m_Rigidbody2D.velocity = new Vector2(moveX * m_MaxSpeed * jumpSpeed, m_Rigidbody2D.velocity.y);

        if (moveX < 0 && m_FacingRight)
        {
            Flip();
            m_FacingRight = false;
        }

        if (moveX > 0 && !m_FacingRight)
        {
            Flip();
            m_FacingRight = true;
        }

        if (jump)
        {
            if (m_Grounded)
            {
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                jump = false;
            }
        }

        m_Anim.SetFloat(m_Speed, Mathf.Abs(moveX));
    }

    private void Flip()
    {
        Vector3 scale = m_Transform.localScale;
        scale.x *= -1;
        shootDirection *= -1;
        m_Transform.localScale = scale;
    }
}
