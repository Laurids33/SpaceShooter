using UnityEngine;

public class Geschoss : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, 0);
        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector3(-9.5f, 0, 0);
            gameObject.SetActive(false);
        }
    }
}
