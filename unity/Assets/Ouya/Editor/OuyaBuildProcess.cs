using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System;
using System.IO;
using System.Xml;

public class OuyaBuildProcess {
	[PostProcessBuild(999)]
	static void OnPostProcessBuildPlayer(BuildTarget target, string buildPath) {
		if(target == BuildTarget.Android) {
			CheckKey();
			CheckAndroidManifest();
			CheckOuyaIcon();
		}
	}

	static void CheckKey() {
		if(!File.Exists("Assets/Plugins/Android/assets/key.der")) {
			EditorUtility.DisplayDialog("Missing OUYA Signing Key", "We didn't find your signing key. Please place your key.der in the Plugins/Android/assets/ folder", "Continue");
		}
	}

	static void CheckAndroidManifest() {
		SyncBundleId(true);
	}

	static void CheckOuyaIcon() {
		if(!File.Exists("Assets/Plugins/Android/res/drawable-xhdpi/ouya_icon.png")) {
			EditorUtility.DisplayDialog("Missing OUYA Icon", "We didn't find an OUYA icon in your plugin folder. Please place your icon in the Plugins/Android/res/drawable-xhdpi/ folder with the filename ouya_icon.png", "Continue");
		}
	}

	[MenuItem("Edit/Sync Android Bundle ID")]
	static void SyncBundleId() {
		SyncBundleId(false);
	}

	static void SyncBundleId(Boolean promptUser) {
		XmlDocument manifest = new XmlDocument();
		manifest.Load("Assets/Plugins/Android/AndroidManifest.xml");
		XmlNode manifestNode = manifest.SelectSingleNode("manifest");
		XmlAttribute pkgAttr = manifestNode.Attributes["package"];
		if(pkgAttr != null) {
			if(!PlayerSettings.bundleIdentifier.Equals(pkgAttr.Value)) {
				if(!promptUser || EditorUtility.DisplayDialog("Android Bundle ID Mismatch", "We've noticed that the package name in your AndroidManifest.xml is different than your Bundle ID.\nWould you like to update it for the next build?", "Yes", "Ignore")) {
					pkgAttr.Value = PlayerSettings.bundleIdentifier;
					manifest.Save("Assets/Plugins/Android/AndroidManifest.xml");
				}
			}
			if(!promptUser) {
				EditorUtility.DisplayDialog("Android Bundle ID Synced", "The Bundle ID was successfully synced!", "Continue");
			}
		}
	}
}
