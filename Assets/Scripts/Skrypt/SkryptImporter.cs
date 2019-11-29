using UnityEngine;
using UnityEditor.Experimental.AssetImporters;
using System.IO;

[ScriptedImporter(1, "skt")]
public class SkryptImporter : ScriptedImporter {
    public override void OnImportAsset(AssetImportContext ctx) {
        var textAsset = Instantiate<TextAsset>(new TextAsset(File.ReadAllText(ctx.assetPath)));

        ctx.AddObjectToAsset("text", textAsset);
        ctx.SetMainObject(textAsset);
    }
}