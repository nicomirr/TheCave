using UnityEngine;

public class ObstacleDisabler : MonoBehaviour
{
    //IMPORTANTE: cuando detectamos colisiones, el objeto que detecta las colisiones DEBE TENER RIGIDBODY.
    //Si el objeto que detecta no tiene rigidbody, no se detecta la colisión, ya que no hay física simulada.
    //El rigidboy debe ser kinemático o dinámico. Estático no, ya que con este las físicas no se simulan,
    //por lo que tampoco funcionan las colisiones.   

    //Si se usa movimiento con transform.translate es mas seguro ontriggerenter
    //El rigidbody funciona mejor como dynamic y continuous
       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
