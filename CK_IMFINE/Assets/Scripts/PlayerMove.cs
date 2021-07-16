using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject CamPivot;

    [HideInInspector]
    public float RotHInput;
    [HideInInspector]
    public float RotVInput;
    [HideInInspector]
    public float MoveHInput;
    [HideInInspector]
    public float MoveVInput;

    bool IsUpEndAim = false;
    bool IsDownEndAim = false;

    float RotVControl = 10.0f;
    float Sensitivity = 10.0f;

    void Update()
    {
        PlayerMovement();
        PlayerRotation();
    }

    public void PlayerMovement()
    {
        if (Mathf.Abs(MoveHInput) > 0.1f)
        {
            Player.transform.localPosition += Player.transform.right * MoveHInput * Time.deltaTime * 10.0f;
        }

        if (Mathf.Abs(MoveVInput) > 0.1f)
        {
            Player.transform.localPosition += Player.transform.forward * MoveVInput * Time.deltaTime * 10.0f;
        }
    }

    public void PlayerRotation()
    {
        if (CamPivot.transform.eulerAngles.x >= 30.0f && CamPivot.transform.eulerAngles.x <= 340.0f) // 시야범위 바깥
        {
            if (CamPivot.transform.eulerAngles.x >= 330.0f)
            {
                // value (0,1) 못하게
                IsUpEndAim = true;
            }
            else
            {
                // value (0,-1) 못하게
                IsDownEndAim = true;
            }
        }
        else
        {
            IsUpEndAim = false;
            IsDownEndAim = false;
        }

        if (Mathf.Abs(RotVInput) > 0.1f)
        {
            if (RotVInput < 0)
            {
                if (!IsDownEndAim)
                {
                    RotVControl = -10.0f;
                }
                else
                    RotVControl = 0;
            }
            else
            {
                if (!IsUpEndAim)
                {
                    RotVControl = 10.0f;
                }
                else
                    RotVControl = 0;
            }
            CamPivot.transform.Rotate(new Vector3(-RotVControl * Time.deltaTime * Sensitivity, 0, 0));
        }

        if (Mathf.Abs(RotHInput) > 0.1f)
        {
            Player.transform.Rotate(0, RotHInput * Time.deltaTime * Sensitivity * 3, 0);
        }
    }

    public void SetMoveInput(Vector2 value)
    {
        MoveHInput = value.x;
        MoveVInput = value.y;
    }

    public void SetRotInput(Vector2 value)
    {
        RotHInput = value.x;
        RotVInput = value.y;
    }
}
