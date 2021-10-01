using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxSlider : PropertyAttribute
{
    

        public float min;
        public float max;

        public MinMaxSlider(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    
}
