using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] ob_fish_right;
    public GameObject[] ob_fish_left;
    public GameObject ob_oxygen;
    public GameObject ob_star;
    private Vector3 left, right;
    // Start is called before the first frame update
    void Start()
    {
        left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        right = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));

        //Instantiate(ob_star,new Vector2(Random.Range(left.x, right.x), Random.Range(right.y, left.y)), Quaternion.identity);

        StartCoroutine(spawn_fish_left());
        StartCoroutine(spawn_fish_right());
        StartCoroutine(spawn_oxygen());
        StartCoroutine(spawn_star());
    }
    IEnumerator spawn_fish_right()
    {
        while (true)
        {

            Instantiate(ob_fish_right[Random.Range(0, ob_fish_right.Length)], new Vector2(11, Random.Range(right.y - 1f, left.y + 1f)), Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }
    IEnumerator spawn_fish_left()
    {
        while (true)
        {

            Instantiate(ob_fish_left[Random.Range(0, ob_fish_left.Length)], new Vector2(-11, Random.Range(right.y - 1f, left.y + 1f)), Quaternion.identity);
            yield return new WaitForSeconds(12f);
        }
    }
    IEnumerator spawn_oxygen()
    {
        while (true)
        {

            Instantiate(ob_oxygen, new Vector2(Random.Range(left.x + 0.5f, right.x - 0.5f), Random.Range(right.y - 0.5f, left.y + 0.5f)), Quaternion.identity);
            yield return new WaitForSeconds(12f);
        }
    }

    IEnumerator spawn_star()
    {
        while (true)
        {

            Instantiate(ob_star, new Vector2(Random.Range(left.x + 0.5f, right.x - 0.5f), Random.Range(right.y - 0.5f, left.y + 0.5f)), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

