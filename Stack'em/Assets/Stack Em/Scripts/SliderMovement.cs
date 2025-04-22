using UnityEngine;
using UnityEngine.UI;

public class SliderMovement : MonoBehaviour
{
    public GameObject prefab;        // Asigna el prefab desde el Inspector
    public Slider slider;            // Asigna el slider desde el Inspector
    private GameObject instancia;    // Referencia al objeto instanciado
    private Rigidbody rb;
    public float smoothSpeed = 0.1f;

    void Start()
    {

        instancia = Instantiate(prefab, new Vector3(0, 0.45f, 0), Quaternion.identity);

        rb = instancia.GetComponent<Rigidbody>();

        slider.onValueChanged.AddListener(MoverObjeto);
    }

    void MoverObjeto(float valor)
    {
        if (rb != null)
        {
            // Define la posición objetivo
            Vector3 targetPosition = new Vector3(valor, rb.position.y, rb.position.z);

            // Usamos MoveTowards para un movimiento suave pero rápido hacia la posición
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, smoothSpeed));
        }
    }
}
