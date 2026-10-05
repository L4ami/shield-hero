using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

// Construit la version Web (WebGL) du jeu dans le dossier docs/,
// celui que GitHub Pages publie. Lancé sans interface par build-web.bat :
// Unity.exe -batchmode -quit -projectPath <projet> -buildTarget WebGL -executeMethod BuildWeb.Build
public static class BuildWeb
{
    const string Scene = "Assets/Scenes/Dungeon.unity";

    public static void Build()
    {
        // La scène du jeu est la seule scène exportée
        EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(Scene, true) };

        // 1280 x 720 (16:9) : en 960 x 600, le premier cœur sort de l'écran
        PlayerSettings.defaultWebScreenWidth = 1280;
        PlayerSettings.defaultWebScreenHeight = 720;

        // GitHub Pages ne sait pas servir les fichiers compressés par Unity
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
        AssetDatabase.SaveAssets();

        BuildReport report = BuildPipeline.BuildPlayer(new BuildPlayerOptions
        {
            scenes = new[] { Scene },
            locationPathName = "docs",
            target = BuildTarget.WebGL,
            options = BuildOptions.None
        });

        Debug.Log("Build Web : " + report.summary.result + " (" + report.summary.totalSize / (1024UL * 1024UL) + " Mo)");
        EditorApplication.Exit(report.summary.result == BuildResult.Succeeded ? 0 : 1);
    }
}
