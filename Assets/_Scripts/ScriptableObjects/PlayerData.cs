using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData")]
public class PlayerData : ScriptableObject 
{
    public int robotID = 1;
    public float energy = 0;
    public float maxEnergy = 60;
}
