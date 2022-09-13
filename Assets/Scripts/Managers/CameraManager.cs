using System;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public float forwardSpeed = 2.5f;
    private Vector3 startRotation;
    private Camera cam;
    
    #region Singleton
    public static CameraManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        cam = GetComponent<Camera>();
        startRotation = transform.rotation.eulerAngles;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, forwardSpeed * Time.fixedDeltaTime);
    }

    public void Fail()
    {
        forwardSpeed = 0;
        cam.DOShakeRotation(.4f, 10, 5).OnComplete(() =>
        {
            transform.DORotate(startRotation, .2f);
        });
    }
}
