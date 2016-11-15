using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISEquippable
    {
        ISEquipmentSlot EquipmentSlot { get; }
        bool Equip();
    }
}
