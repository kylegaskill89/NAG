using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISStackable
    {
        int maxStack { get; }
        int stack(int amount);
    }
}