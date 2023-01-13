﻿using System;
using UnityEngine;

namespace XenoIK
{
    [Serializable]
    public class Bone
    {
        public Transform Transform;
        
        public float Length;
        [Range(0, 1f)]
        public float Weight = 1f;

        public Vector3 Position
        {
            get => this.Transform.position;
            set => this.Transform.position = value;
        }

        public Quaternion Rotation
        {
            get => this.Transform.rotation;
            set => this.Transform.rotation = value;
        }

        public Bone() { }

        public Bone(Transform trans)
        {
            this.Transform = trans;
        }
    }
}