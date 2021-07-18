using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject CamHPivot;
    public GameObject CamVPivot;

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

        Player.transform.eulerAngles = new Vector3(Player.transform.eulerAngles.x, Player.transform.eulerAngles.y, 0);
    }

    public void PlayerMovement()
    {
        Vector3 HMove = Vector3.zero;
        Vector3 VMove = Vector3.zero;
        Vector3 OriginPos;

        bool IsHInput = false;
        bool IsVInput = false;

        OriginPos = Player.transform.localPosition;

        Vector3 HTest = Vector3.zero;
        Vector3 VTest = Vector3.zero;

        if (Mathf.Abs(MoveHInput) > 0.1f)
        {
            IsHInput = true;
            HMove = Player.transform.localPosition + GameManager.Instance.camManager.DirPivot.transform.right * MoveHInput * Time.deltaTime * 10.0f;
            HTest = HMove - Player.transform.localPosition;
            Player.transform.localPosition = HMove;

            //if(MoveHInput > 0)
            //{
            //    Player.transform.forward = GameManager.Instance.camManager.CamHPivot.transform.right;
            //}
            //else
            //{
            //    Player.transform.forward = -GameManager.Instance.camManager.CamHPivot.transform.right;
            //}
        }
        else
        {
            IsHInput = false;
        }

        if (Mathf.Abs(MoveVInput) > 0.1f)
        {
            IsVInput = true;
            VMove = Player.transform.localPosition + GameManager.Instance.camManager.DirPivot.transform.forward * MoveVInput * Time.deltaTime * 10.0f;
            VTest = VMove - Player.transform.localPosition;
            Player.transform.localPosition = VMove;

            //if (MoveVInput > 0)
            //{
            //    Player.transform.forward = GameManager.Instance.camManager.CamHPivot.transform.forward;
            //}
            //else
            //{
            //    Player.transform.forward = -GameManager.Instance.camManager.CamHPivot.transform.forward;
            //}
        }
        else
        {
            IsVInput = false;
        }

        if(IsHInput || IsVInput) // 이동 방향으로 바라보게 하기
        {
            Vector3 MoveVec = HTest + VTest;

            Player.transform.forward = Vector3.Lerp(Player.transform.forward ,MoveVec.normalized, Time.deltaTime*20);
        }
        


    }

    public void PlayerRotation()
    {
        if (CamVPivot.transform.eulerAngles.x >= 30.0f && CamVPivot.transform.eulerAngles.x <= 340.0f) // 시야범위 바깥
        {
            if (CamVPivot.transform.eulerAngles.x >= 330.0f)
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
            CamVPivot.transform.Rotate(new Vector3(-RotVControl * Time.deltaTime * Sensitivity, 0, 0));
        }

        if (Mathf.Abs(RotHInput) > 0.1f)
        {
            GameManager.Instance.camManager.DirPivot.transform.Rotate(0, RotHInput * Time.deltaTime * Sensitivity * 3, 0);
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
