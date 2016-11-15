using UnityEngine;
using System.Collections;


namespace ItemSystem    
{
    public partial class ISObjectEditor
    {
        void TopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            SItemsTab();
            ItemsTab();
            BusterPartsTab();
            Weapons();
            GUILayout.EndHorizontal();
        }

        void SItemsTab()
        {
            GUILayout.Button("Special Items");
        }

        void ItemsTab()
        {
            GUILayout.Button("Items");
        }

        void BusterPartsTab()
        {
            GUILayout.Button("Buster Parts");
        }

        void Weapons()
        {
            GUILayout.Button("Weapons");
        }
    }
}
