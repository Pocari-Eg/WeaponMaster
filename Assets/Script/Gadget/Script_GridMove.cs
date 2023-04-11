using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GridMove : MonoBehaviour
{
    private bool IsMoving = false;
    private Vector3 curPos, targetPos;
    private float time2Move = 0.2f;

    // Start is called before the first frame update

    private void Start()
    {
         

    }
    // Update is called once per frame
    void Update()
    {
        
    }

        IEnumerator MoveObject(Vector3 direction)
        {
            IsMoving = true;
            float elapsedTime = 0;
            curPos = transform.position;
            targetPos = curPos + direction;
            while (elapsedTime < time2Move)
            {
                transform.position = Vector3.Lerp(curPos, targetPos, (elapsedTime / time2Move));
            elapsedTime += 0.1f;   // time.delta 를 더해야 하나 다른 오브젝트는 멈추고 이 오브젝트만 움직이도록 0.1f를 더함.
                yield return null;
            }

            transform.position = targetPos;
            IsMoving = false;

        }

   public void LeftMove()
    {
        StartCoroutine(MoveObject(Vector3.left));
    }
    public void RightMove()
    {
        StartCoroutine(MoveObject(Vector3.right));
    }
    public void UpMove()
    {
        StartCoroutine(MoveObject(Vector3.up));
    }
    public void DownMove()
    {
        StartCoroutine(MoveObject(Vector3.down));
    }
    public void timeStop()
    {
        Time.timeScale = 0;
    }
    public void timego()
    {
        Time.timeScale = 1;
    }
}