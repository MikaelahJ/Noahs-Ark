using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UnityEditor
{
    [CustomEditor(typeof(SiblingRuleTile))]
    [CanEditMultipleObjects]

    public class SiblingRuleTileEditor : RuleTileEditor
    {
        public Texture2D any;
        public Texture2D specified;
        public Texture2D nothing;

        public override void RuleOnGUI(Rect rect, Vector3Int position, int neighbor)
        {
            switch (neighbor)
            {
                case 3:
                    GUI.DrawTexture(rect, any);
                    return;
                case 4:
                    GUI.DrawTexture(rect, specified);
                    return;
                case 5:
                    GUI.DrawTexture(rect, nothing);
                    return;
            }
            base.RuleOnGUI(rect, position, neighbor);
        }
    }
}