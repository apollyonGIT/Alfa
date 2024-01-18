using System.Text.RegularExpressions;
using UnityEditor;

namespace Editor.AutoCreators
{
    public class Cell
    {
        static string path = "Assets/Editor/Templates/Cell_Template.cs.txt";

        //==================================================================================================

        [MenuItem("Assets/AutoScript/Cell", false, -1)]
        public static void EXE()
        {
            CreateScriptByTemplate.EXE(path, create_file_name, create_diy_fields);
        }


        static string create_file_name(string folder_name)
        {
            return $"{folder_name.TrimEnd('s')}";
        }


        static void create_diy_fields(ref string txt, string folder_name)
        {
            var cell = folder_name.TrimEnd('s');

            var iview = $"I{cell}View";
            txt = Regex.Replace(txt, "#iview#", iview);

            var mgr = $"{cell}Mgr";
            txt = Regex.Replace(txt, "#mgr#", mgr);
        }
    }
}

