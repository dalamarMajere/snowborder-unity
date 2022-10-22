using UnityEngine;

namespace Variables
{
    public abstract class AVariable<T> : ScriptableObject
    {
        public T Value { get; set; }
    }
}