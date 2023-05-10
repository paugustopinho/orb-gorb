using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Cinemachine.CinemachineOrbitalTransposer;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI output, currentDebt, headOut;
    [SerializeField] List<string> lines, headingTo;
    [SerializeField] float textSpeed;

    void Start()
    {
        currentDebt.text = "Current Balance:\n" + GameObject.FindGameObjectWithTag("DebtController").GetComponent<DebtController>().currentDebt;
        firstLine();
    }

    void firstLine()
    {
        bool hasWon = GameObject.FindGameObjectWithTag("DebtController").GetComponent<DebtController>().currentDebt >= 0;
        StartCoroutine(TypeLines(hasWon));
    }

    IEnumerator TypeLines(bool hasWon)
    {
        int index = 1;
        if (hasWon)
            index = 0;

        foreach (char c in lines[index].ToCharArray())
        {
            output.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 2f);
        StartCoroutine(headTo(index));
    }

    IEnumerator headTo(int index)
    {
        headOut.text = "";
        foreach (char c in headingTo[index].ToCharArray())
        {
            headOut.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 2f);
    }
}
