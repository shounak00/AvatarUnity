using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class AvatarInteractions : MonoBehaviour
{
    public InputActionReference kick;
    private Animator _animator;
    private ThirdPersonController _tps;

    [Header("Avatar Menu")] 
    public Material [] shoeMat;
    public Material[] capMat;
    public Material[] dressMat;

    [Header("Avatar ref")] public GameObject bodyMesh;
    public GameObject shoeMesh;
    public GameObject capMesh;

    

    private void OnEnable()
    {
        kick.action.Enable();
    }

    private void OnDisable()
    {
        kick.action.Disable();
    }
    
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _tps = gameObject.GetComponent<ThirdPersonController>();
    }
    
    void Update()
    {
        if (kick.action.triggered && !_tps.isAnimating)
        {
            Kicking();
        }
    }

    public void ChangeMatShoe(int index)
    {
        shoeMesh.GetComponent<SkinnedMeshRenderer>().material = shoeMat[index];
    }
    
    public void ChangeDress(int index)
    {
        bodyMesh.GetComponent<SkinnedMeshRenderer>().material = dressMat[index];
    }
    
    public void ChangeCap(int index)
    {
        capMesh.GetComponent<MeshRenderer>().material = capMat[index];
    }

    
    

    void Kicking()
    {
        _tps.isAnimating = true;
        _animator.applyRootMotion = true; 
        _animator.PlayInFixedTime("Kick");
        StartCoroutine(WaitAndDisableRoot(.85f));

    }

    IEnumerator WaitAndDisableRoot(float time)
    {
        yield return new WaitForSeconds(time);
        _animator.applyRootMotion = false;
        _tps.isAnimating = false;
    }
    
}
