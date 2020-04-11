﻿using UnityEngine;
using System.Collections;

public class Bandit1 : MonoBehaviour {

    [SerializeField] float      m_speed = 1.0f;
    [SerializeField] float      m_jumpForce = 2.0f;
    public float dashSpeed;

    public string horizontalmovement = "Horizontal";
    public string verticalmovement = "Vertical";
    public string JumpInput = "Jump_2";
    public string attackInput = "attack_2";
    public string dashInput = "dash";
    public string shoryukenInput = "shoryuken";
    bool canDash = false;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;
    public bool killed = false;
    public int dahForce = 5;
    public GameObject Hitbox;
    Transform mytransform;
    public GameObject lightHandler;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        mytransform = GetComponent<Transform>();
        lightHandler = GameObject.FindGameObjectWithTag("LightManager");
    }
	
	// Update is called once per frame
	void Update () {
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis(horizontalmovement);

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e")) {
            if(!m_isDead)
                m_animator.SetTrigger("Death");
            else
                m_animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }

        if (this.killed == true)
        {
            if (!m_isDead)
                m_animator.SetTrigger("Death");
            if (killed == true) ;
       
        }

        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");

        //Attack
        else if (Input.GetButtonDown(attackInput))
        {
            m_animator.SetTrigger("Attack");
            Attacking();
        }
        // dash
        else if (Input.GetButtonDown(dashInput))
        {

            if (!lightHandler.GetComponent<LightHandler>().shadow)
            {
                canDash = true;
                dash();
            }
        }

        //shoryuken
        else if (Input.GetButtonDown(shoryukenInput))
        {
            shoryuken();
            Attacking();
        }


        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        //Jump
        else if (Input.GetButtonDown(JumpInput) && m_grounded)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
       
    }

    private void Attacking()
    {
        Hitbox.SetActive(true);
    }

    void dash()
    {
        if (canDash)
        {
            float inputX = Input.GetAxis(horizontalmovement);
            if (inputX < 0)
            {
                m_body2d.velocity = Vector2.left * dashSpeed;
                canDash = false;
            }
            else if (inputX > 0)
            {
                m_body2d.velocity = Vector2.right * dashSpeed;
                canDash = false;

            }
          
           
        }
    }

    void shoryuken()
    {
        float inputY = Input.GetAxis(verticalmovement);
        m_body2d.velocity = Vector2.up * dashSpeed;
        Attacking();
    }

}
