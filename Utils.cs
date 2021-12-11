using UnityEngine;

using VRC;
using VRC.UI.Elements.Menus;

namespace DBMod
{
    public static class Utils
    {

        public static Player GetSelectedUser()
        {
            var iuser = GameObject.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>().field_Private_IUser_0;
            var userID = iuser.prop_String_0;
            foreach (Player player in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0)
            {
                if (!player) continue;
                if (player.prop_APIUser_0.id.Equals(userID)) return player;
            }
            return null;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                return gameObject.AddComponent<T>();
            }
            return component;
        }

        public static string GetPath(this Transform current)
        { //http://answers.unity.com/answers/261847/view.html
            if (current.parent == null)
                return "/" + current.name;
            return current.parent.GetPath() + "/" + current.name;
        }
    }
}
