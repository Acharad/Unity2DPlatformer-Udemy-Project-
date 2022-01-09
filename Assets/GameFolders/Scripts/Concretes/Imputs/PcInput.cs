using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Inputs
{
    public class PcInput 
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    }
}
