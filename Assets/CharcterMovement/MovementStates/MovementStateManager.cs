using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    #region Movement
    public float currentMoveSpeed;
    public float walkSpeed = 2, walkBackSpeed =1;
    public float runSpeed = 5, runBackSpeed = 3;

    [HideInInspector] public Vector3 dir;
    [HideInInspector] public float hzInput, vInput;
    CharacterController controller;
    #endregion

    #region GroundCheck
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;
    #endregion

    #region Gravity
    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    #endregion

    MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public RunState Run = new RunState();
    public SitState Sit = new SitState();
    public OpeningState Open = new OpeningState();
    
    [HideInInspector] public bool blocked;
    [HideInInspector] public bool enableOpen=false;
    [HideInInspector] public bool enableSit=false;

    [HideInInspector] public Animator anim;

    SceneController sceneController;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //animator controlling blend tree
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

    // Update is called once per frame
    void Update(){
        
        if(enableSit){
            if(blocked)DBmanager.prompt="Press C to stand";
            else DBmanager.prompt="Press C to sit";
        }
  
        GetDirectionAndMove();
        Gravity();

        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);

        currentState.UpdateState(this);

    }

    public void SwitchState(MovementBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove(){   
        
        if(!blocked){
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;
        
        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
        }
        
    }

    bool IsGrounded(){
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity(){
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
         if (other.tag=="Door")
         {  
             enableOpen=true;
 
         }
         if (other.tag=="Sit")
         {
            enableSit=true;             
         }
    }

    void OnTriggerExit(Collider other){
         if (other.tag=="Door")
         {  
             enableOpen=false;
             
 
         }
         if (other.tag=="Sit")
         {
            enableSit=false;
            DBmanager.prompt="";
         }
    }

}
