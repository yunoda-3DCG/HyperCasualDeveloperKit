using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Reflection;

namespace HyperCasualDeveloperKit.Rooting
{
    public static class PathManager
    {
        static PathManager() { inPackage = Directory.Exists(PACKAGES_PATH); }
        static bool inPackage;

        private static readonly string PACKAGES_PATH = "Packages/com.yunoda.hypercasualdeveloperkit/";
        private static readonly string ASSETS_PATH = "Assets/VketCloudSDK/";

        //////Unityのプロジェクト内で使える相対パスを返します。ex. Packages/com.hikky.vketcloudsdk/PackageResources/bat/...
        public static string GetPackagePath { get { return PACKAGES_PATH; } }
        public static string GetAssetPath { get { return ASSETS_PATH; } }
        public static string GetBatFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/bat/");
        public static string GetIconFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/data/icon/"); 
        public static string GetImageFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/data/image/");
        public static string GetPrefabFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/data/prefab/");
        public static string GetTemplateFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/data/template/");
        public static string GetVketChanVRMFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/data/VketChanVRM/");
        public static string GetToolsFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/tools/"); 
        public static string GetProjectFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/project~/");
        public static string GetBinFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "Runtime/Exporters/HEOExporter/Editor/bin/");
        public static string GetTranslationFolderPath => Path.Combine(inPackage ? PACKAGES_PATH : ASSETS_PATH, "PackageResources/data/translations/");
        //////

        //////ディスクルートを基準としたパスを返します。ex. E:VketCloudSDK/release/...
        public static string GetReleaseFolderPath => Application.dataPath.Replace("/Assets", "") + "/release/"; 
        public static string GetReleaseFieldFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetFieldFolderRelativePath); 
        public static string GetReleaseAvatarFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetAvaterFolderRelativePath); 
        public static string GetReleaseMotionFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetMotionFolderRelativePath); 
        public static string GetReleaseSceneFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetSceneFolderRelativePath);
        public static string GetReleaseScriptFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetScriptFolderRelativePath); 
        public static string GetReleaseSoundFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetSoundFolderRelativePath); 
        public static string GetReleaseItemFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetItemFolderRelativePath); 
        public static string GetReleaseParticleFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetParticleFolderRelativePath); 
        public static string GetReleaseVideoFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetVideoFolderRelativePath);
        public static string GetReleaseImageFolderPath => Path.Combine(GetReleaseFolderPath, "data/", GetImageFolderRelativePath);
        //////

        //////releaseフォルダをルートとした、相対的なパスを返します。ex. Field/World, Particle/Snow,...
        public static string GetParticleFolderRelativePath { get { return "Particle/"; } }
        public static string GetAvaterFolderRelativePath { get { return "Avatar/"; } }
        public static string GetFieldFolderRelativePath { get { return "Field/"; } }
        public static string GetMotionFolderRelativePath { get { return "Motion/"; } }
        public static string GetSceneFolderRelativePath { get { return "Scene/"; } }
        public static string GetScriptFolderRelativePath { get { return "Script/"; } }
        public static string GetSoundFolderRelativePath { get { return "Sound/"; } }
        public static string GetVideoFolderRelativePath { get { return "Video/"; } }
        public static string GetItemFolderRelativePath { get { return "Item/"; } }
        public static string GetImageFolderRelativePath { get { return "Image/"; } }
        //////

        /// <summary>
        /// Check the extension and return the path on release folder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GeneratePath(UnityEngine.Object target)
        {
            if (target == null)
                return "";

            var targetPath = Path.GetFullPath(AssetDatabase.GetAssetPath(target));
            var targetFilename = Path.GetFileName(AssetDatabase.GetAssetPath(target));
            switch (System.IO.Path.GetExtension(targetPath))
            {
                case ".hs":
                    return Path.Combine(GetScriptFolderRelativePath, targetFilename);
                case ".vrm":
                    return Path.Combine(GetAvaterFolderRelativePath, targetFilename);
                case ".hem":
                    return Path.Combine(GetMotionFolderRelativePath, targetFilename);
                case ".hep":
                    return Path.Combine(GetParticleFolderRelativePath, Path.GetFileNameWithoutExtension(targetPath) + "/" + targetFilename);
                case ".heo":　
                    return Path.Combine(GetFieldFolderRelativePath, Path.GetFileNameWithoutExtension(targetPath) + "/" + targetFilename) ;
                case ".ogg":
                case ".wav":
                case ".aif":
                case ".aiff":
                case ".mp3":
                    return Path.Combine(GetSoundFolderRelativePath, targetFilename);
                case ".mp4":
                    return Path.Combine(GetVideoFolderRelativePath, targetFilename);
                case ".png":
                    return Path.Combine(GetImageFolderRelativePath, targetFilename);
                default:
                    Debug.LogError(target + " is not supported extension for VketCloud.");
                    return"";
            }
        }

        public static string GeneratePathForNotYetHEOed(string filename)
        {
            return Path.Combine(GetFieldFolderRelativePath, filename + "/" + filename + ".heo" );
        }
    }
}