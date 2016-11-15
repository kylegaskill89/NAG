using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public class ISEquipmentSlot : IISEquipmentSlot
    {
        
        [SerializeField] string _name;
        [SerializeField] Sprite _icon;


        public ISEquipmentSlot()
        {
            _name = "Default Name";
            _icon = new Sprite();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
    }
}
