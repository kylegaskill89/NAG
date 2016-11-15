using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem
{
    [System.Serializable]
    public class ISWeapon : ISObject, IISWeapon, IISEquippable, IISGameObject
    {
        [SerializeField] int _minDamage;
        [SerializeField] ISEquipmentSlot _equipmentSlot;
        [SerializeField] GameObject _prefab;


        public ISWeapon()
        {
            _equipmentSlot = new ISEquipmentSlot();
        }


        public ISWeapon(ISEquipmentSlot equipmentSlot, GameObject prefab)
        {
            _equipmentSlot = equipmentSlot;
            _prefab = prefab;
        }


        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }


        public int Attack()
        {
            throw new System.NotImplementedException();
        }


        public ISEquipmentSlot EquipmentSlot
        {
            get { return _equipmentSlot; }
        }

        public bool Equip()
        {
            throw new System.NotImplementedException();
        }

        public GameObject Prefab
        {
            get { return _prefab; }
        }

        //will move
        public override void OnGUI()
        {
            base.OnGUI();

            _minDamage = System.Convert.ToInt32( EditorGUILayout.TextField("Damage: ", _minDamage.ToString()) );
            DisplayEquipmentSlot();
            DisplayPrefab();
        }


        public void DisplayEquipmentSlot()
        {
            GUILayout.Label("Equipment Slot");
        }

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
        }

    }
}