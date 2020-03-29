using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator m_animator;
    CharacterController m_characterController;

    public float lookAngel = 60;
    public float lookDistance = 5;

    private float m_fTime = 0;
    float hor = 0;
    float ver = 0;
    // Start is called before the first frame update

    GameObject[] enemies;
    GameObject lockedEnemy;
   
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_fTime += Time.deltaTime;
        float speed = m_animator.GetFloat("speed");
      

        hor = 5*Input.GetAxis("Horizontal");  
        ver = 5*Input.GetAxis("Vertical"); 

        if (hor != 0 || ver != 0)
        {
            Vector3 dir = new Vector3 (hor,0,ver);  
            //将方向转换为四元数  
            Quaternion quaDir = Quaternion.LookRotation(dir,Vector3.up);  
            //缓慢转动到目标点  
            transform.rotation = Quaternion.Lerp(transform.rotation,quaDir,Time.fixedDeltaTime*5);
            Vector3 velocity = Vector3.Lerp(m_characterController.velocity,dir,Time.fixedDeltaTime*5);
            m_animator.SetFloat("speed",7);
            m_characterController.SimpleMove(velocity);  

            
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach(GameObject enemy in enemies)
            {
                if (isInView(enemy.transform))
                {
                    if (lockedEnemy != null)
                    {
                        if (Vector3.Magnitude(enemy.transform.position - this.transform.position) < Vector3.Magnitude(lockedEnemy.transform.position - this.transform.position))
                        {
                            Debug.Log("the current lock is"+enemy.transform.name);
                        }
                    }
                    else
                    {
                        lockedEnemy = enemy;
                        Debug.Log("the current lock is"+enemy.transform.name);
                    }

                   Debug.Log("in view is"+enemy.transform.name);
                }
            }
        }
        else
        {
            m_animator.SetFloat("speed",0);
            m_characterController.SimpleMove(new Vector3(0,0,0));
        }


       /* if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            m_animator.SetFloat("speed",7);

            if (Input.GetKey(KeyCode.A))
            {
                m_characterController.SimpleMove(new Vector3(-1,0,0));
                this.transform.forward = m_characterController.velocity;
            }

            if (Input.GetKey(KeyCode.D))
            {
                m_characterController.SimpleMove(new Vector3(1,0,0));
                this.transform.forward = m_characterController.velocity;
            }
            if (Input.GetKey(KeyCode.W))
            {
                m_characterController.SimpleMove(new Vector3(0,0,1));
                this.transform.forward = m_characterController.velocity;
            } 

            if (Input.GetKey(KeyCode.S))
            {
                m_characterController.SimpleMove(new Vector3(0,0,-1));
                this.transform.forward = m_characterController.velocity;
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) 
            {
                //this.transform.forward = new Vector3(-1,0,1);
                Quaternion quaDir = Quaternion.LookRotation(new Vector3(-1,0,1),Vector3.up);  
                //缓慢转动到目标点  
                transform.rotation = Quaternion.Lerp(transform.rotation,quaDir,Time.fixedDeltaTime); 
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                this.transform.forward = new Vector3(1,0,1);
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                this.transform.forward = new Vector3(-1,0,-1);
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                this.transform.forward = new Vector3(1,0,-1);
            }
        }
        else
        {
            m_animator.SetFloat("speed",0);
            m_characterController.SimpleMove(new Vector3(0,0,0));
        }
        */
    }

    bool isInView(Transform TargetTransform)
    {
        Vector3 leftEdge = Quaternion.Euler(0,-1*lookAngel/2,0)*this.transform.forward;
        Vector3 rightEdge = Quaternion.Euler(0,lookAngel/2,0)*this.transform.forward;
        Vector3 target = TargetTransform.position - this.transform.position;

        if (Vector3.Magnitude(TargetTransform.position - this.transform.position) <= lookDistance && Vector3.Angle(leftEdge,target) >= 0 && Vector3.Angle(leftEdge,target) < Vector3.Angle(leftEdge,rightEdge))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

  
}
