#OUYA Unity Plugin
## Downloading the Plugin
Check out the releases section to download the compiled plugin
## Building the Plugin
If you'd like to modify any of the plugin code, you will need to compile the plugin yourself.
### Requirements
 * Android SDK (and `ANDROID_HOME` environment variable set)
 * Android NDK (and `ANDROID_NDK_HOME` environment variable set)
 * Unity
 * Mono (`mcs`, the Mono compiler will need to be in your `PATH`)

### Folder Structure
`cs/` - Unity C# scripts. Compiled with mcs against Unity's libraries into two DLL files  
`java/` - Android library. Contains Android Java and native C++ code. Compiled with Android SDK+NDK into a JAR and an SO file  
`unity/` - The unity project for the plugin package.  

### Building
This plugin relies on the gradle build system to build all of its components. A gradle wrapper is included in the repo, so no additional software should be needed.

To build the plugin, run the following command from within the root directory:  
`./gradlew clean unityPacakge`  
or on Windows:  
`gradle.bat clean unityPackage`
