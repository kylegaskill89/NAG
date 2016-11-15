using UnityEngine;
using System.Collections;
using System.ComponentModel;

namespace ItemSystem
{
    [SerializeField]
    interface IISObject
    {

        string ISName { get; set; }
        int ISValue { get; set; }
        Sprite ISIcon { get; set;}

        //equip
        //quest item
    }
}