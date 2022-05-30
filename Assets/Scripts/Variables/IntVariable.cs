using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(fileName = "New Game Variable (int)", menuName = "Game Variable/New Game Variable (int)")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField] private int intValue;

        public int IntValue
        {
            get { return this.intValue; }
            set { this.intValue = value; }
        }

        public IntVariable(int intValue)
        {
            this.intValue = intValue;
        }

        public static implicit operator int(IntVariable v)
        { return v.IntValue; }
    }
}