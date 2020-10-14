using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeadNotesText : MonoBehaviour
{
    public TextMeshProUGUI deadText;
    public GameObject DeadManText;
    public string DeadMansNote;
    public void NoteOpen()
    {
        DeadManText.SetActive(true);
        deadText.text = DeadMansNote;
    }
}
