using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMov : MonoBehaviour
{
    private float speedBase =0.1f;
    public Transform sphere;
    public GameObject prefab;
    public Slider slider;
    
    private float _sphereRay = 100f;
    private float _tamanhoNave = 2.5f;
    private Vector3 _movPlayer;
    private GameObject _instantiateObject;
    private float _speedEscalar,_x,_y,_z,_turnSpeed,_turnValueVertical,_turnValueHorizontal,_angle;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(sphere.transform.position, _sphereRay);
    }
    void Awake()
    {
        _instantiateObject = Instantiate(prefab, transform);
        _instantiateObject.transform.localScale = -Vector3.one * _tamanhoNave;
        _instantiateObject.transform.position = _instantiateObject.transform.up * _sphereRay;
    }
    void Update()
    {
        // Capturando teclas
        _turnValueVertical = Input.GetAxis("Vertical");
        _turnValueHorizontal = Input.GetAxis("Horizontal");

        speedBase = slider.value;

        // Movimentação Vertical
        if ( Input.GetAxis("Vertical") > 0 )
        {
            _speedEscalar = speedBase * _turnValueVertical * 1.5f;
            _angle -= _speedEscalar * Time.deltaTime;
        } else if (Input.GetAxis("Vertical") < 0)
        {
            _speedEscalar = speedBase * (-_turnValueVertical) * 0.5f;
            _angle -= _speedEscalar * Time.deltaTime;
        }
        else 
        {
            _speedEscalar = speedBase;
            _angle -= _speedEscalar * Time.deltaTime;
        }
        
        // Definição do Ângulo
        _x = 0;
        _y = Mathf.Sin(_angle);
        _z = Mathf.Cos(_angle);
        
        // Movimentação Horizontal
        _turnSpeed = 20;
        float rotateSpeedFinal = _turnValueHorizontal != 0 ? _turnSpeed * Time.deltaTime * _turnValueHorizontal : 0;
        sphere.Rotate(0f,0f,rotateSpeedFinal);
        
        // Rotação do Objeto ao longo da circunferência
        _instantiateObject.transform.LookAt(sphere, _instantiateObject.transform.forward);

        // Movimentação Constante
        _movPlayer = new Vector3( _x, _y, _z ) * _sphereRay;
        _instantiateObject.transform.position = _movPlayer;
    }
    
    public float atualizarSpeedBase()
    {
        return 0f;
    }
}
