using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    public GameObject[] hero;

    public Vector2 maxPos;
    public Vector2 minPos;
    public float something;

    void Start()
    {
        StateHero(0);
    }

    public void StateHero(int newHero)
    {
        target = hero[newHero].transform;
    }

    private void LateUpdate() 
    {
        CameraMove();
    }

    private void CameraMove()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, something);
        }
    }
}
