using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace HyperCasualDeveloperKit.Preferences
{
    public class Preferences : EditorWindow
    {
        const string MENU_NAME = "HyperCasualDeveloperKit/Preferences";

        [MenuItem(MENU_NAME, priority = 150)]
        private static void CallPreferencesWindow()
        {
            var window = EditorWindow.GetWindow<Preferences>();
            window.titleContent = new GUIContent("Preferences");
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private Vector2 scrollPosition;

        private void OnGUI()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            {

            }
            GUILayout.EndScrollView();
        }
    }
}
#endif