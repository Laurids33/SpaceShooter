using UnityEngine;

public class Spieler : MonoBehaviour
{
    readonly float eingabeFaktor = 10;
    public GameObject[] geschoss = new GameObject[3];

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
}
