//
//  EditorConstants.cs
//
//  Lunar Unity Mobile Console
//  https://github.com/SpaceMadness/lunar-unity-console
//
//  Copyright 2016 Alex Lementuev, SpaceMadness.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

﻿using UnityEngine;
using System.Collections;

namespace LunarConsolePluginInternal
{
    static class EditorConstants
    {
        public static readonly string PrefabPath = "Assets/" + Constants.PluginName + "/Scripts/" + Constants.PluginName + ".prefab";
        public static readonly string EditorPath = "Assets/" + Constants.PluginName + "/Editor";
        public static readonly string EditorPathIOS = EditorPath + "/iOS";
        public static readonly string EditorPathAndroid = EditorPath + "/Android";

        public static readonly string PluginAndroidPath = "Assets/Plugins/Android/" + Constants.PluginName;
    }
}