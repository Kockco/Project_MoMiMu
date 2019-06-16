using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CH_STATE { Stand,Collsion_False, Airborne, Sticking, Throw_Force, }
public class PlayerMovement : MonoBehaviour
{
    Animator ani;
    Vector2 chPos;
    Rigidbody2D rb;
    ConstantForce2D constForce;
    public FixedJoint2D joint;
    Vector2 startPos;
    public float h, v;
    public bool jumpCol; // 점프중에 부딪혓는지?

    //오디오
    public AudioSource jump;
    public AudioSource Move;

    public int playerNumber;

    [Header("Move")]
    public float speed = 20;

    [Header("Jump")]
    public float jumpPower = 0;
    public float jumpTime = 0;
    public float jump_gauge2Up_delay = 0;
    public float jump_gauge3Up_delay = 0;
    public float gauging_deceleration = 0; //감속량
    public float jump1Level_Force = 0;
    public float jump2Level_Force = 0;
    public float jump3Level_Force = 0;

    public float rotationSpeed = 3;
    public float gravitySpeed = 4;
    public float jumpSpeed = 20;

    [Header("Bounce")] // 
    public Vector2 bounce_skip_velocity;
    public Vector2 ch_before_velocity;
    
    [Header("Throw_Force")] // 
    public bool isStickKeyDown;

    public Vector2 throw_force_value;
    public Vector2 cur_throw_force_value;
    public Vector2 throw_torque_value;
    public Vector2 cur_throw_torque_value;
    public float throw_force_action_time;
    public float throw_force_decrease_time;
    public float max_throw_force_value;
    public float max_throw_torque_value;
    float forceTime;

    [Header("Collsion_False")]
    public float collisionFalseTime = 0;


    //바닥 콜리젼의 노멀값
    Vector2 collisionNormal;

    //그냥 움직일떄 필요한거
    Vector2 movement;

    //중력 곱배기
    const float gravity = -9.8f;

    //캐릭터 상태정의
    public CH_STATE eState;

    //GetKey(키관련)
    bool DownKey;
    public bool JumpKeyDown;
    bool JumpKeyUp;
    bool JumpCancelKey;
    bool StickKeyDown;
    bool StickKeyUp;
    
    //움직일떄 사운드 시간초
    float moveSoundTime;

    public GameObject DownCollider;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        constForce = GetComponent<ConstantForce2D>();
        ani = transform.GetChild(0).GetComponent<Animator>();

        eState = CH_STATE.Stand;

        forceTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        chPos = transform.position;
        KeyDown();
        switch (eState)
        {
            case CH_STATE.Stand:
                CheckGround();
                OnStickKey();
                break;
            case CH_STATE.Collsion_False:
                OnStickKey();
                CollsionFalse();
                break;
            case CH_STATE.Airborne:
                CheckGround();
                OnStickKey();
                break;
            case CH_STATE.Sticking:
                OnStickKey();
                break;
            case CH_STATE.Throw_Force:
                OnStickKey();
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (eState)
        {
            case CH_STATE.Stand:
                MoveUpdate();
                JumpUpdate();
                break;
            case CH_STATE.Collsion_False:
                break;
            case CH_STATE.Airborne:
                CrashPowerCheck();
                AirMoveUpdate();
                GravityUpdate();
                AirRotation();
                break;
            case CH_STATE.Sticking:
                SetConstantForce();
                ObjectStickAction();
                break;
            case CH_STATE.Throw_Force:
                break;
            default:
                break;
        }
    }

    //바닥에서 이동하는 기능- velocity 강제 적용(x,y둘다)
    public void MoveUpdate(float onGauge_SpeedLoss = 0)
    {
        //이동 가능할때 이동해주고 아닐때는 반환
        if (playerNumber == 1)
        {
            h = Input.GetAxisRaw("Horizontal");
        }
        else if (playerNumber == 2)
        {
            h = Input.GetAxisRaw("Horizontal2");
        }

        //돌려주는 부분 대각선이동을 처리
        if (collisionNormal == Vector2.zero) return;
        //Debug.DrawRay(transform.position,Quaternion.AngleAxis(90, transform.forward) * -collisionNormal, Color.cyan,10f);
        Vector2 rightForce = Quaternion.AngleAxis(90, transform.forward) * -collisionNormal;
        Debug.DrawLine(chPos, chPos + rightForce, Color.blue, Time.fixedDeltaTime, false);
        Debug.DrawLine(chPos, chPos + collisionNormal, Color.red, Time.fixedDeltaTime, false);

        //이동속도를 계속 초기화 시켜줌으로써 같은 이동속도를 내어줌!
        rb.velocity = Vector2.zero;
        movement = rightForce * h * (speed - onGauge_SpeedLoss);

        //rb.velocity = movement;
        rb.AddForce(movement, ForceMode2D.Impulse);
    }

    //공중에서 이동하는 기능- velocity 강제 적용(x만! y는 중력에서 건드려야함)
    public void AirMoveUpdate()
    {
        //이동 가능할때 이동해주고 아닐때는 반환
        if (playerNumber == 1)
        {
            h = Input.GetAxisRaw("Horizontal");
        }
        else if (playerNumber == 2)
        {
            h = Input.GetAxisRaw("Horizontal2");
        }

        
        //이동속도를 계속 초기화 시켜줌으로써 같은 이동속도를 내어줌!
        movement = rb.velocity;

        movement.x = h * jumpSpeed;
        if(jumpCol == false)
            rb.velocity = movement;
    }

    //중력을 받게하는 부분 - velocity 강제 적용(y만)
    void GravityUpdate()
    {
        //점프 중 중력을 더 많이 받게함
        Vector3 velocity = rb.velocity;
        velocity.y += gravity * gravitySpeed * Time.fixedDeltaTime;
        rb.velocity = velocity;
    }

    //공중에서 회전하는부분
    void AirRotation()
    {
        Quaternion rotation = Quaternion.Euler(5,0,0);
        rotation.eulerAngles = new Vector3(0, 0, -rb.velocity.x * rotationSpeed);
        transform.rotation *= rotation;
    }

    //점프하기
    void JumpUpdate()
    {
        if (JumpKeyDown == true)
        {
            jump.Play();
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode2D.Impulse);

            eState = CH_STATE.Collsion_False;
        }
    }

    //바닥인지 판단하기
    void CheckGround()
    {
        if(DownCollider.GetComponent<DownCollider>().onCol == true)
        {
            if(eState == CH_STATE.Airborne)
                 eState = CH_STATE.Stand;
        }
        else
        {
            eState = CH_STATE.Airborne;
        }
    }

    // 충돌전 속도 저장
    void CrashPowerCheck()
    {
        if (rb.velocity.y > bounce_skip_velocity.y || rb.velocity.y < -bounce_skip_velocity.y)
        {
            ch_before_velocity.y = rb.velocity.y;
        }
        else
        {
            ch_before_velocity.y = 0;
        }

        if (rb.velocity.x > bounce_skip_velocity.x || rb.velocity.x < -bounce_skip_velocity.x)
        {
            ch_before_velocity.x = rb.velocity.x;
        }
        else
        {
            ch_before_velocity.x = 0;
        }
    }

    //스틱키를 입력하는 부분
    void OnStickKey()
    {
        if (StickKeyDown)
        {
            isStickKeyDown = true;
        }

        else if (StickKeyUp)
        {
            isStickKeyDown = false;
            if (joint != null)
            {
                Destroy(joint);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                constForce.force = Vector2.zero;
                constForce.torque = 0;
                cur_throw_force_value = Vector2.zero;

            }

            eState = CH_STATE.Airborne;
        }
    }

    //오브젝트들에 붙엇을 시 각각 다른 행동
    void ObjectStickAction()
    {
        forceTime += Time.fixedDeltaTime;

        if(forceTime > throw_force_decrease_time)
        {
            if(cur_throw_force_value.x < 0)
                cur_throw_force_value += new Vector2(1,0);
            else if (cur_throw_force_value.x > 0)
                cur_throw_force_value -= new Vector2(1, 0);

            if (cur_throw_force_value.y < 0)
                cur_throw_force_value += new Vector2(0, 5);

            forceTime = 0;
        }

        if (playerNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (cur_throw_force_value.x < max_throw_force_value)
                    cur_throw_force_value.x += throw_force_value.x;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (cur_throw_force_value.x > -max_throw_force_value)
                    cur_throw_force_value.x -= throw_force_value.x;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (cur_throw_force_value.y > -max_throw_force_value)
                    cur_throw_force_value.y -= throw_force_value.y;
            }
        }
        if(playerNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (cur_throw_force_value.x < max_throw_force_value)
                    cur_throw_force_value.x += throw_force_value.x;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (cur_throw_force_value.x > -max_throw_force_value)
                    cur_throw_force_value.x -= throw_force_value.x;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (cur_throw_force_value.y > -max_throw_force_value)
                    cur_throw_force_value.y -= throw_force_value.y;
            }
        }
    }

    //붙었을때 힘주는 부분
    public void SetConstantForce()
    {
        if (joint)
        {
            if (joint.connectedBody.tag != "Rever")
            {
                constForce.force = new Vector2(cur_throw_force_value.x, cur_throw_force_value.y);
            }
        }
    }

    //조인트 붙이는 부분
    public void OnStick(Collision2D col)
    {
        if (col.transform.tag != "Player" && col.transform.tag != "Ground")
        {
            joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = col.rigidbody;
            joint.enableCollision = true;
            //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints2D.None;
            eState = CH_STATE.Sticking;
        }
    }

    //잠시시간동안 아무기능도 작동하지않음
    void CollsionFalse()
    {
        collisionFalseTime += Time.deltaTime;
         if (collisionFalseTime > 0.1f)
        {
            collisionFalseTime = 0;
            eState = CH_STATE.Airborne;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         jumpCol = true;
        switch (eState)
        {
            case CH_STATE.Stand:
                break;
            case CH_STATE.Airborne:
                //탄성 충돌 (수정)
                if (isStickKeyDown == false)
                {
                    if (Mathf.Abs(ch_before_velocity.y) > bounce_skip_velocity.y)
                    {
                        eState = CH_STATE.Collsion_False;
                        rb.velocity = Vector3.Reflect(new Vector3(ch_before_velocity.x, ch_before_velocity.y, 0), collision.contacts[0].normal);
                        float velY = rb.velocity.y * 0.7f;
                        rb.velocity = new Vector2(rb.velocity.x, velY);
                    }
                }
                break;
            case CH_STATE.Sticking:
                break;
            case CH_STATE.Throw_Force:
                break;
            default:
                break;
        }
        //외부 충돌하면 제자리로
        if (collision.transform.name == "OutSide")
        {
            transform.position = startPos;
            rb.velocity = Vector2.zero;
        }
    }

    //회전 부분 수정이 필요함!! 벽도올라가고 거꾸로도 붙음!!
    private void OnCollisionStay2D(Collision2D collision)
    {
        //붙은곳과 외적하여 수직선을 알아내기
        var pos = collision.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
        if (pos.y < 0 && (pos.x <= 0.199f && pos.x >= -0.199f))
        {
            //Debug.Log(pos);
            collisionNormal = collision.contacts[0].normal;

            //붙은 곳에대해 회전
            transform.up = collision.contacts[0].normal;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z));
        }
        
        switch (eState)
        {
            case CH_STATE.Stand:
                if (isStickKeyDown == true && eState != CH_STATE.Sticking)
                {
                    OnStick(collision);
                }
                break;
            case CH_STATE.Airborne:
                if (isStickKeyDown == true && eState != CH_STATE.Sticking)
                {
                    OnStick(collision);
                }
                break;
            case CH_STATE.Sticking:
                break;
            case CH_STATE.Throw_Force:
                break;
            default:
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        jumpCol = false;
    }
    //키셋팅
    void KeyDown()
    {
        if (playerNumber == 1)
        {
            JumpKeyDown = Input.GetKeyDown(KeyCode.UpArrow);
            JumpKeyUp = Input.GetKeyUp(KeyCode.UpArrow);
            StickKeyDown = Input.GetKeyDown(KeyCode.Slash);
            StickKeyUp = Input.GetKeyUp(KeyCode.Slash);
            JumpCancelKey = Input.GetKeyDown(KeyCode.DownArrow);
            DownKey = Input.GetKey(KeyCode.DownArrow);
        }
        else if (playerNumber == 2)
        {
            JumpKeyDown = Input.GetKeyDown(KeyCode.R);
            JumpKeyUp = Input.GetKeyUp(KeyCode.R);
            StickKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
            StickKeyUp = Input.GetKeyUp(KeyCode.LeftShift);
            JumpCancelKey = Input.GetKeyDown(KeyCode.F);
            DownKey = Input.GetKey(KeyCode.F);
        }
        else
        {
            Debug.Log("NoKeySetting");
        }
    }

    //붙은 오브젝트 태그 판단
    bool CheckJointTag(string a)
    {
        if (joint.connectedBody != null)
        {
            if (joint.connectedBody.gameObject.tag == a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log("Error! Not found connectedBody");
            return false;
        }

    }
}
