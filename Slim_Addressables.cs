using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine.AddressableAssets.Initialization;
using System.Collections;


namespace UnityEngine.AddressableAssets
{

    /// <summary>
    /// Entry point for Addressable API, this provides a simpler interface than using ResourceManager directly as it assumes string address type.
    /// </summary>
    public static class Addressables
    {


        /// <summary>
        /// Used to resolve a string using addressables config values
        /// </summary>
        /// <param name="id">The internal id to resolve.</param>
        /// <returns>Returns the string that the internal id represents.</returns>
        public static string ResolveInternalId(string id)
        {
            var path = AddressablesRuntimeProperties.EvaluateString(id);
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || UNITY_XBOXONE
            if (path.Length >= 260 && path.StartsWith(Application.dataPath))
                path = path.Substring(Application.dataPath.Length + 1);
#endif
            return path;
        }

       
    }
}
