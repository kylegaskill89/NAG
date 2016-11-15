﻿using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISWeapon
    {
        int MinDamage { get; set; }
        int Attack();
    }
}