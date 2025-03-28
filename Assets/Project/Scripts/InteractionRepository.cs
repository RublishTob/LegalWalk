using System.Collections.Generic;
using BerserkPixel.Prata;
using UnityEngine;

public class InteractionRepository : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Interaction> _interactions;

    public Interaction GetInteraction(string key)
    {
        return _interactions[key];
    }
}
