using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDir;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 moveDirPostCalc;
    public float dashSpeed;
    public E_Player_SO player_SO;
    public InputAction dashAction;
    public InputAction moveDirAction;
    public bool canDash = true;
    public bool canMove = true;
    public float dashTimer = 5;
    public float dashDelay;
    public float moveDelay;
    public float moveTimer = 1.5f ;

    private void Awake()
    {
        dashAction = InputSystem.actions.FindAction("Dash");
        moveDirAction = InputSystem.actions.FindAction("Move");
        moveSpeed = player_SO.eMoveSpeed;
    }

    private void Update()
    {

       if (dashAction.ReadValue<float>() > 0 && canDash)
        {
            Dash();
            canMove = false;
            moveDelay = 0;
            
        }

        if (!canDash && dashDelay < dashTimer)
        {
            dashDelay += Time.deltaTime;
            if (dashDelay >= dashTimer)
            {
                canDash = true;
            }
        }

        if (canMove)
        {
            Move();
        }

        if (!canMove && moveDelay < moveTimer)
        {
            moveDelay += Time.deltaTime;
            if (moveDelay >= moveTimer) 
            { 
                canMove = true;
            }
        }
    }

    private void Move()
    {
        moveDir = moveDirAction.ReadValue<Vector2>();
        moveDirPostCalc = moveDir * moveSpeed * Time.deltaTime;

        Vector2 playerVelocity = new Vector2(moveDirPostCalc.x, moveDirPostCalc.y);
        playerRB.linearVelocity = transform.TransformDirection(playerVelocity);
    }

    private void Dash()
    {
        playerRB.linearVelocity = transform.TransformDirection(playerRB.linearVelocity * dashSpeed);
            
        dashDelay = 0f;
        canDash = false;

    }
}
