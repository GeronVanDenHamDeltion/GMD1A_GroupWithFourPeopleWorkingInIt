using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int noteNumber;
    public BookManager bookMan;
    void onTriggerEnter(Collider collider)
    {
        bookMan.enableNote(noteNumber);
    }
}
