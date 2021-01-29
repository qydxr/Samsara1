using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    Transform trs;
    Animator anim;

    
    float speedx, speedy;

    [Header("playerPropery")]
    public float walkSpeed;
    public float power;//法力值
    public float shield;//护盾值
    public float continueConsume;//法力持续消耗值
    public float one_timeConsume;//法力瞬时消耗值

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        setWalkSpeed();

    }

    private void FixedUpdate()
    {
        walk();
    }

    void init()//初始化
    {
        rb = GetComponent<Rigidbody2D>();
        trs = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void setWalkSpeed()
    {
        if (Input.GetKey(KeyCode.D))
        {
            speedx = walkSpeed;
           
            trs.localRotation = new Quaternion(0, 0, 0, 0);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            speedx = 0;
            speedy = 0;

        }

        if (Input.GetKey(KeyCode.A))
        {
            speedx = -walkSpeed;
            
            trs.localRotation = new Quaternion(0, 180, 0, 0);
        }
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            speedx = 0;
            speedy = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            
            speedy = walkSpeed;
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            speedx = 0;
            speedy = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
           
            speedy = -walkSpeed;
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
        {
            speedx = 0;
            speedy = 0;
        }
    }//设置x，y方向的速度，设置面朝方向

    void walk()//移动玩家，设置动画
    {
        rb.velocity = new Vector2(speedx,speedy);
        
        if(Mathf.Abs(speedx)>0.1f|| Mathf.Abs(speedy) >0.1f)
        {
            anim.SetFloat("speed", 1);
        }else
        {
            anim.SetFloat("speed", 0);
        }
    }
}
