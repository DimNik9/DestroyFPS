using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight_Manager : MonoBehaviour
{
    [Header("Skyboxes")]
    public Material daySkybox;
    public Material nightSkybox;

    [Header("Lights")]
    public GameObject day;
    public GameObject night;

    public bool isDay;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (!isDay)
            {
                SwitchToDay();
            }
            else
            {
                SwitchToNight();
            }

            isDay = !isDay;
        }
    }

    public void SwitchToDay()
    {
        RenderSettings.skybox = daySkybox;
        day.SetActive(true);
        night.SetActive(false);
    }

    public void SwitchToNight()
    {
        RenderSettings.skybox = nightSkybox;
        day.SetActive(false);
        night.SetActive(true);
    }
}
