using UnityEngine;
using System.Collections;
using UnityEditor;


namespace ItemSystem
{
    public class ISObject : IISObject
    {
        
        [SerializeField]
        string _name;
        [SerializeField] 
        int _value;
        [SerializeField]
        Sprite _icon;

        public string ISName
        {        
            get
            {   return _name;   }

            set
            {   _name = value;  }
        }

        public int ISValue
        {
            get
            {   return _value;   }

            set
            {   _value = value;  }
        }

        public Sprite ISIcon
        {
            get
            {   return _icon;   }

            set
            {   _icon = value;  }
        }




        //will be moved
        public virtual void OnGUI()
        {
            GUILayout.BeginVertical();
            ISName = EditorGUILayout.TextField("Name: ", ISName);
            ISValue = System.Convert.ToInt32( EditorGUILayout.TextField("Value: ", ISValue.ToString()) );
            DisplayIcon();
            GUILayout.EndVertical();
        }

        public void DisplayIcon()
        {
            GUILayout.Label("Icon");
        }

        public ISObject()
        {
            
        }

    }
}
