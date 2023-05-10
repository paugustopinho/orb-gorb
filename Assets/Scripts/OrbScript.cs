using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbScript : MonoBehaviour
{
    float speed = .1f;
    [SerializeField] GameObject ship;
    Vector3 originalpos;

    private void Start()
    {
        originalpos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            GetComponent<MeshRenderer>().enabled = false;
            ship.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, -1000f));
            StartCoroutine(waitforEnd());
        }
    }

    private void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, .5f);
        transform.position = new Vector3(originalpos.x, originalpos.y - y, originalpos.z);
    }

    IEnumerator waitforEnd()
    {
        GameObject.FindGameObjectWithTag("DebtController").GetComponent<DebtController>().currentDebt += GameObject.FindGameObjectWithTag("DebtController").GetComponent<DebtController>().salary;
        yield return new WaitForSeconds(3f);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
