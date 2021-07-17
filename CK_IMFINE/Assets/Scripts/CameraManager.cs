using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera PlayerCam;
    public GameObject DirPivot;
    public GameObject CamHPivot;
    public GameObject CamVPivot;

    private void Start()
    {
        PlayerCam = Camera.main;
    }

    private void Update()
    {
        DirPivot.transform.position = PlayerManager.Instance.transform.position;

        DirPivot.transform.eulerAngles = new Vector3(DirPivot.transform.eulerAngles.x, DirPivot.transform.eulerAngles.y, 0);
    }
}
