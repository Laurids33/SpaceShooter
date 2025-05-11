using UnityEngine;

public class Spieler : MonoBehaviour
{
    readonly float eingabeFaktor = 10;
    public GameObject[] geschoss = new GameObject[3];

    public GefahrGewinn gefahrGewinnKlasse;
    int energie = 10;
    public GameObject balkenWert;

    void Update()
    {
        float yEingabe = Input.GetAxis("Vertical");
        float yNeu = transform.position.y + yEingabe * eingabeFaktor * Time.deltaTime;
        if (yNeu > 4.75f) yNeu = 4.75f;
        else if (yNeu < -4.75f) yNeu = -4.75f;
        transform.position = new Vector3(transform.position.x, yNeu, 0);
        if (Input.GetButtonDown("Fire1"))
        {
            for(int i = 0; i < 3; i++)
            {
                if (!geschoss[i].activeSelf)
                {
                    Vector3 positionNeu = new Vector3(transform.position.x + 1.7f, transform.position.y, 0);
                    geschoss[i].transform.position = positionNeu;
                    geschoss[i].SetActive(true);
                    break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.transform.position = new Vector3(Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
        gefahrGewinnKlasse.xAenderungBasis *= 1.01f;
        if (coll.gameObject.CompareTag("Gefahr"))
        {
            EnergieAnzeige(-1);
        }
        else if (coll.gameObject.CompareTag("Gewinn"))
        {
            EnergieAnzeige(1);
        }
        Debug.Log(energie);
    }

    public void EnergieAnzeige(int wert)
    {
        energie += wert;
        balkenWert.transform.localScale = new Vector3(0.8f, energie / 2.0f, 0);
    }
}
