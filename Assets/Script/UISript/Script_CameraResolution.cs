using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_CameraResolution : MonoBehaviour
{

    public float ShakeAmount;
    float ShakeTime;
    Vector3 InitPos;


    Camera m_camera;
    private void Awake()
    {
        m_camera = GetComponent<Camera>();

        ScreenSet(Screen.width);
        Application.targetFrameRate = 120;
    }

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }

    private void Start()
    {
        InitPos = this.transform.position;
    }
    private void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + InitPos;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = InitPos;
        }
    }


    void ScreenSet(int s)
    {
        if (s == 1920 || s == 2560)
        {
            m_camera.orthographicSize = 16.9f;
        }
        else if (s == 2960)
        {
            m_camera.orthographicSize = 14.6f;
        }
        else if (s == 2280 || s == 3040)
        {
            m_camera.orthographicSize = 14.2f;
        }
        else if (s == 2400 || s == 3200)
        {
            m_camera.orthographicSize = 13.5f;
        }
        else
        {
            m_camera.orthographicSize = 13.5f;

        }
    }
}
