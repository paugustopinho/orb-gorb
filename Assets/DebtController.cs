using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebtController : MonoBehaviour
{
    public int currentDebt;
    public int salary;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        currentDebt = -100000;
    }
}
