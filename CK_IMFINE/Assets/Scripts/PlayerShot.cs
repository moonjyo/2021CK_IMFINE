using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class PlayerShot : MonoBehaviour
{
    Vector3 Aim;

    int AmmoCount;
    int AmmoMaxCount;

    GameObject CamPivot;

    float Times = 0;

    float RecoilTimes = 0.1f;

    public void Start()
    {
        CamPivot = PlayerManager.Instance.playerMove.CamHPivot;
    }

    public void Update()
    {
        //if(T)
        //{
        //    Times += Time.deltaTime;
        //    CamPivot.transform.localEulerAngles = Vector3.Lerp(CamPivot.transform.localEulerAngles, CamPivot.transform.localEulerAngles - new Vector3(15, 0, 0), Time.deltaTime* 2);
        //}

        //if(Times > 0.2f)
        //{
        //    T = false;
        //    Times = 0;
        //}
    }

    public void Shot()
    {
        Aim = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        Ray ray = Camera.main.ScreenPointToRay(Aim);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.name);
        }

        Times = 0;
        StartCoroutine(VerticalRecoil());        


    }

    IEnumerator VerticalRecoil()
    {        
        while(Times < RecoilTimes)
        {
            Times += Time.deltaTime;
            CamPivot.transform.localEulerAngles = Vector3.Lerp(CamPivot.transform.localEulerAngles, CamPivot.transform.localEulerAngles - new Vector3(15, 0, 0), Time.deltaTime*5);

            yield return null;
        }

        StartCoroutine(ReturnAim());
    }

    IEnumerator ReturnAim()
    {
        Times = 0;
        while (Times < RecoilTimes)
        {
            Times += Time.deltaTime;
            CamPivot.transform.localEulerAngles = Vector3.Lerp(CamPivot.transform.localEulerAngles, CamPivot.transform.localEulerAngles + new Vector3(15, 0, 0), Time.deltaTime * 5);

            yield return null;
        }
    }
}
