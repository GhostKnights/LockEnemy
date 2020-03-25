/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator m_animator;
    CharacterController m_characterController;
    
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                m_animator.SetFloat("speedY",0);
                m_animator.SetFloat("speedX",-30);
                m_characterController.SimpleMove(new Vector3(-1,0,0));
            }

            if (Input.GetKey(KeyCode.D))
            {
                m_animator.SetFloat("speedY",0);
                m_animator.SetFloat("speedX",30);
                m_characterController.SimpleMove(new Vector3(1,0,0));
            }
            if (Input.GetKey(KeyCode.W))
            {
                m_animator.SetFloat("speedY",50);
                m_animator.SetFloat("speedX",0);
                m_characterController.SimpleMove(new Vector3(0,0,1));
            } 

            if (Input.GetKey(KeyCode.S))
            {
                m_animator.SetFloat("speedY",-25);
                m_animator.SetFloat("speedX",0);
                m_characterController.SimpleMove(new Vector3(0,0,-1));
            }
        }
        else
        {
            m_animator.SetFloat("speedY",0);
            m_animator.SetFloat("speedX",0);
            m_characterController.SimpleMove(new Vector3(0,0,0));
        }
     

    
        


    }

    void FixedUpdate()
    {

    }
}
*/