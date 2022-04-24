using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace HyperCasualDeveloperKit.EditorSetup
{
    public class SwitchingPlatform
    {
        private static AddRequest Request;
        
        [DidReloadScripts]
        public static void SwitchPlatform()
        {
            if (EditorUserBuildSettings.activeBuildTarget != UnityEditor.BuildTarget.Android)
            {
                if (EditorUtility.DisplayDialog("Switch to Android", "You need to switch a platfrom to android.", "Yes", "Cancel"))
                {
                    EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android); 
                }
            }
        }
    }
}