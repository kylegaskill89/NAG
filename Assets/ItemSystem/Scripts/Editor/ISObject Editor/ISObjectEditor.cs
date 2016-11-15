using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem    
{
    public partial class ISObjectEditor : EditorWindow
    {
        ISWeaponDatabase database;

        const string DATABASE_NAME = @"WeaponDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_NAME;


        [MenuItem("Item System/Database/Item System Editor %#i")]
        public static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent.text = "Item System";
            window.Show();
        }

        ISObjectDatabase objectDatabase;
       // Texture2D selectedTexture;
       //int selectedIndex = -1;
       // Vector2 _scrollPos;




        void OnEnable()
        {
            if (database == null)
            {
                database = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_FOLDER_NAME, DATABASE_NAME);
            }
        }

        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();

            ListView();
            ItemDetails();

            GUILayout.EndHorizontal();

            BottomBar();
        }
    }
}
