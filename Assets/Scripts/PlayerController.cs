using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CharacterController controller;
    public Transform hidePointUnderDesk;
    public Transform hidePointInLocker;

    private Vector3 moveDir;
    private bool isHiding = false;
    private string currentHideType = "";
    public Blackboard globalBlackboard;
    private float hideTime = 0f;
    public float maxHideTime = 10f;



    void Update()
    {
        if (isHiding)
        {
            hideTime += Time.deltaTime;

            if (hideTime >= maxHideTime)
            {
                globalBlackboard.SetValue("ScareTriggered", true);
            }
            else
            {
                hideTime = 0f;
                globalBlackboard.SetValue("ScareTriggered", false);
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                Unhide();
            }
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDir = new Vector3(h, 0, v).normalized;
        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryHide();
        }
    }


    void TryHide()
    {

        if (Vector3.Distance(transform.position, hidePointUnderDesk.position) < 2f)
        {
            transform.position = hidePointUnderDesk.position;
            isHiding = true;
            currentHideType = "Desk";
        }
        else if (Vector3.Distance(transform.position, hidePointInLocker.position) < 2f)
        {
            transform.position = hidePointInLocker.position;
            isHiding = true;
            currentHideType = "Locker";
        }
    }

    public bool IsHiding()
    {
        return isHiding;
    }

    public string GetHideType()
    {
        return currentHideType;
    }

    public void Unhide()
    {
        isHiding = false;
        currentHideType = "";
    }
}