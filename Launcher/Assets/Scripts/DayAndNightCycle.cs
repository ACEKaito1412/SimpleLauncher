using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class DayAndNightCycle : MonoBehaviour
{
    public Transform parentObject;
    public Light2D DayLight;
    public Gradient DayLightGradient;
    

    public Light2D NightLight;
    public Gradient NightLightGradient;

    public GameObject rain;
    public float ratio;

    public AudioSource src;
    public AudioClip rainSound;

    public TextMeshProUGUI gameTime;
    public TextMeshProUGUI realTime;
    public GameObject menuBtn;


    private int hour, minute;
    private DateTime timeNow;
    private string formattedTime;

    // Start is called before the first frame update
    void Start()
    {
        rain.SetActive(false);
        StartCoroutine(DayAndNight());
    }

    // Update is called once per frame
    void Update()
    {
        timeNow = DateTime.Now;

        formattedTime = timeNow.ToString("hh:mm tt");

        realTime.text = formattedTime;
    }

    IEnumerator DayAndNight(){
        while(true){
            UpdateLight();
            yield return new WaitForSeconds(1f);
        }
    }

    public void UpdateLight()
    {
        if(hour == 4 ){
            rain.SetActive(true);
            src.clip = rainSound;
            src.Play();
        }

        if(hour == 6){
            rain.SetActive(false);
            src.Stop();
        }

        if(ratio > 3) {
            ratio = 0;
            hour = 0;
        }
            
        if(minute == 60){
            hour += 1;
            minute = 0; 
        }

        gameTime.text =  hour + " : " + minute;
        DayLight.color = DayLightGradient.Evaluate(ratio);
        NightLight.color = NightLightGradient.Evaluate(ratio);

        parentObject.rotation = Quaternion.Euler(0, 0, 360f * ratio);
        menuBtn.transform.rotation = Quaternion.Euler(0, 0, 360f * ratio);
        ratio += 0.001f;
        minute += 1;
    }
}
