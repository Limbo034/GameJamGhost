using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimTheft : MonoBehaviour
{
    private MovementTheft movement;
    private Animator anim;

    public LetGo contextOn;
    public LetGo contextOff;

    private bool playerInRange;
    private GameObject ghost;

    private bool ghostInside = false;

    public CameraMovement mainHero;

    private enum MovementState {idle, running, rising}

    private void Awake()
    {
        movement = GetComponentInParent<MovementTheft>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovementState state;

        if (movement.running && movement.enabled)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("states", (int)state);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            movement.enabled = true;
            ghost.SetActive(false);
            ghostInside = true;
            mainHero.StateHero(2);
        }

        if (Input.GetKeyDown(KeyCode.Q) && ghostInside)
        {
            ghost.SetActive(true);
            ghost.transform.position = new Vector3(gameObject.transform.position.x, ghost.transform.position.y, 0);
            movement.enabled = false;
            ghostInside = false;
            mainHero.StateHero(0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            contextOn.Raise();
            playerInRange = true;
            ghost = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            contextOff.Raise();
            playerInRange = false;
        }      
    }
}
