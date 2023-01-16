﻿using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace XenoIK.Editor
{
    [CustomEditor(typeof(LookAtIK))]
    public class LookAtInspector : IKInspector
    {
        public LookAtIK script => target as LookAtIK;
        
        protected override MonoBehaviour GetMonoScript()
        {
            return script;
        }

        protected override void DrawInspector()
        {
            IKSolverLookAtInspector.DrawInspector(this.solver);
        }
    }
}