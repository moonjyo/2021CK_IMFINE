using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerMove playerMove;
    public PlayerShot playerShot;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
}
