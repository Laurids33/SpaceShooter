using UnityEngine;

public class GefahrGewinn : MonoBehaviour
{
    public float xAenderungBasis;
    float xAenderung;
    public Spieler spielerKlasse;

    void Start()
    {
        xAenderungBasis = 2.5f * Time.deltaTime;
        xAenderung = 2.5f * Time.deltaTime;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - xAenderung, transform.position.y, 0);
        if (transform.position.x < -9.0f)
        {
            transform.position = new Vector3(Random.Range(10.0f, 19.0f), Random.Range(-4.5f, 4.5f), 0);
            xAenderungBasis *= 1.01f;
            xAenderung = xAenderungBasis * Random.Range(0.9f, 1.1f);
            if(gameObject.CompareTag("Gefahr"))
            {
                spielerKlasse.EnergieAnzeige(-1);
            }
        }
    }
}
