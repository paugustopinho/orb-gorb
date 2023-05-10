using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI output, currentDebt;
    [SerializeField] List<string> lines;
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
        string str = "";
        if (hasWon)
            str = lines[0];
        else
            str = lines[1];

        foreach (char c in str.ToCharArray())
        {
            output.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 2f);
    }
}
