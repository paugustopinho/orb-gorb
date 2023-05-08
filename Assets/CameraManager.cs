using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Area, Sphere;
    [SerializeField] Material on, off;
    [SerializeField] float timerMax;
    float timer;

    public void activate()
    {
        Area.SetActive(!Area.activeSelf);
        if (Area.activeSelf)
        {
            Sphere.GetComponent<MeshRenderer>().material = on;
        }
        else
        {
            Sphere.GetComponent<MeshRenderer>().material = off;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            activate();
            timer = 0f;
        }
    }
}
