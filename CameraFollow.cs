using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [FormerlySerializedAs("Sphere")] [Tooltip("Astro/ Planeta")]
    public Transform sphere;
    
    private float _x = -30f;
    private float _distance = 20.5f; // Distância da câmera em relação ao objeto
    private Transform _target; // Referência para o objeto a ser seguido
    private Vector3 _offset; // Vetor de deslocamento entre a câmera e o objeto
    
    private void Start()
    {
        // Procura o objeto na cena com a tag especificada
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        _target = targetObject.transform;
    }
    private void LateUpdate()
    {
        // Verifica se o objeto está ativo
        if (_target != null)
        {
            // Calcula a posição desejada da câmera
            Vector3 desiredPosition = _target.position - (_target.forward * _distance) - (transform.up * 10f) + (transform.forward * 16.5f);

            // Atualiza a posição da câmera
            transform.position = desiredPosition;

            // Faz a câmera olhar para o objeto
            transform.LookAt(sphere, transform.forward);

            // Obtém a rotação atual da câmera
            Quaternion currentRotation = transform.rotation;

            // Calcula a rotação com a diferença adicional de 50 graus no eixo X
            Quaternion targetRotation = currentRotation * Quaternion.Euler(_x, 0f, 0f);

            // Aplica a rotação à câmera
            transform.rotation = targetRotation;
        }
    }
}