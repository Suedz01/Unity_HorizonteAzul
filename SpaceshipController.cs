using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public Transform planet; // Referência ao objeto do planeta
    public float radius = 5f; // Raio do movimento em torno do planeta
    public float speed = 2f; // Velocidade de rotação
    public float movementSpeed = 5f; // Velocidade de movimento da nave
    public KeyCode leftKey = KeyCode.LeftArrow; // Tecla para girar para a esquerda
    public KeyCode rightKey = KeyCode.RightArrow; // Tecla para girar para a direita

    private Vector3 _centerPosition; // Posição central do planeta
    private Vector3 _currentPosition; // Posição atual da nave espacial
    private float _currentAngle; // Ângulo atual da nave espacial

    private void Start()
    {
        _centerPosition = planet.position; // Armazena a posição central do planeta
        _currentPosition = transform.position; // Armazena a posição inicial da nave espacial
        _currentAngle = 0f; // Define o ângulo inicial da nave espacial
    }

    private void Update()
    {
        // Verifica se as teclas de giro estão sendo pressionadas
        if (Input.GetKey(leftKey))
        {
            // Rotaciona a nave espacial para a esquerda
            _currentAngle += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, -speed*Time.deltaTime,0f);
        }
        else if (Input.GetKey(rightKey))
        {
            // Rotaciona a nave espacial para a direita
            _currentAngle -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, speed*Time.deltaTime,0f);

        }

        // Calcula a posição atual da nave espacial em torno do planeta
        _currentPosition = _centerPosition + Quaternion.Euler(0f, _currentAngle, 0f) * (Vector3.forward * radius);

        // Orienta a nave espacial na direção do movimento
        //transform.LookAt(centerPosition);

        // Movimenta a nave espacial para a posição atual
        transform.position = _currentPosition + transform.forward * movementSpeed * Time.deltaTime;
    }
}