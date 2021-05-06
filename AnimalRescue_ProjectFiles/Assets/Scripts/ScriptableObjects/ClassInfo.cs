using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassInfo : ScriptableObject
{
    public string ClassName;

    private static int classSize = 18;

    public string[] students = new string[classSize];

    public bool usePicture = true;
}
