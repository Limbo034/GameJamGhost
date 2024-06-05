using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTheft : MonoBehaviour
{
    public Rigidbody2D rb;
    private CapsuleCollider2D _cap;
    private PlayerAnim anim;
    [SerializeField] private AudioSource walkSound;
    
    public Vector2 vel;
    private Vector2 position;

    private float inputAxis;

    public float moveSpeed = 8f;
    public float acceleration = 1f;
    public float timer = 0;

    public bool running => Mathf.Abs(vel.x) > 0f || Mathf.Abs(inputAxis) > 0f;
    private bool FacingRight = true;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _cap = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<PlayerAnim>();
    }

    private void Update()
    {
        //if (ghost_Test)
            HorizontalMov();
    }

    private void HorizontalMov()
    {
        inputAxis = Input.GetAxis("Horizontal");
        vel.x = Mathf.MoveTowards(vel.x, inputAxis * moveSpeed, acceleration * moveSpeed * Time.deltaTime);

        if (FacingRight && inputAxis < 0)
            Flip();

        else if (!FacingRight && inputAxis > 0)
            Flip();
    }

    private void FixedUpdate()
    {
        HeroPosition();
    }

    private void HeroPosition()
    {
        position = rb.position;
        position += vel * Time.fixedDeltaTime;

        rb.MovePosition(position);
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
