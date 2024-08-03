using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        virtualCamera.Follow = GameManager.Instance.Character.transform;
    }


}
