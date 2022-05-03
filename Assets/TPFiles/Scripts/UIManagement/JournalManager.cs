using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    [SerializeField] Button[] journalEntryButtons;

    private void Awake()
    {
        FossilHolder holder = FindObjectOfType<FossilHolder>();
        foreach (var jEB in journalEntryButtons)
        {
            jEB.interactable = holder.IsFound(jEB.name);
        }
    }
}
