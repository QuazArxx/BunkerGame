using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public static int BunkerSize { get; set; }

    public static bool isFiend { get; set; }
    public static bool isPlayersTurn { get; set; }

    public static List<GameObject> hand = new List<GameObject>();
    public static List<GameObject> field = new List<GameObject>();
}
