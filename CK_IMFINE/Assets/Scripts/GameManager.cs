using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CameraManager camManager;

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        if(!Instance)
        {
            Instance = this;
        }
    }
   
}
