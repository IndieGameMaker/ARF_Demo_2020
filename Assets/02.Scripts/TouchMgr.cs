using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMgr : MonoBehaviour
{
    [System.NonSerialized]
    public Transform targetTr;

    private float startingPosition;
    public float turnSpeed = 100.0f;

    void Update()
    {
        if (targetTr != null && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //터치의 상태에 따라서 계산처리
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    startingPosition = touch.position.x;
                    break;

                case TouchPhase.Moved:
                    //현재 좌푯값이 첫 터치위치보다 작을 경우
                    if (startingPosition > touch.position.x)
                    {
                        targetTr.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                    }
                    else if (startingPosition <= touch.position.x)
                    {
                        targetTr.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
                    }
                    break;

                case TouchPhase.Ended:
                    startingPosition = 0.0f;
                    break;
            }
        }
    }
}
