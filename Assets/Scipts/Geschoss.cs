using UnityEngine;

public class Geschoss : MonoBehaviour
{
    public GefahrGewinn gefahrGewinnKlasse;
    public GameObject explosionRot;
    public GameObject explosionGruen;

    public Spieler spielerKlasse;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, 0);
        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector3(-9.5f, 0, 0);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Gefahr"))
        {
            Instantiate(explosionRot, transform.position, Quaternion.identity);
            spielerKlasse.EnergieAnzeige(1);
        }
        else if (coll.gameObject.CompareTag("Gewinn"))
        {
            Instantiate(explosionGruen, transform.position, Quaternion.identity);
            spielerKlasse.EnergieAnzeige(-1);
        }

        transform.position = new Vector3 (-9.5f, 0, 0);
        gameObject.SetActive(false);
        coll.gameObject.transform.position = new Vector3(Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
        gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
    }
}
