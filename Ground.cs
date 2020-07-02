using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private RawImage ImgGround;

    [SerializeField]
    private float ScrollingVel;


    void Update()
    {
        if (Manager.MgrSingle.IsGameOver)
            return;

        GroundMoving();
    }

    private void GroundMoving()
    {
        ImgGround.uvRect = new Rect(ImgGround.uvRect.x + ScrollingVel * Time.deltaTime, ImgGround.uvRect.y, ImgGround.uvRect.width, ImgGround.uvRect.height);
    }
}
