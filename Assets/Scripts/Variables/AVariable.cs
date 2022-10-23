using UnityEngine;

namespace Player
{
    public abstract class AVariable<T>: ScriptableObject
    {
        public T Value { get; set; }
    }
}