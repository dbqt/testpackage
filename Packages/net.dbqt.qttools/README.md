# QT Tools
This is a collection of tools that I use when working with VRChat projects.

These tools are provided as is for free with the MIT license.

## Installation
1. Download from the releases or clone the repository to your local machine.
2. Open your Unity project.
3. Navigate to the Assets menu and select Import Package > Custom Package.
4. Browse to the location where you downloaded the repository and select the package file.
5. Follow the on-screen instructions to import the package into your project.

## QT Reassign Armature Unity Tool
The QT Armature Reassigner is a Unity tool to simplify the process of reassigning an armature to a skinned mesh. This tool is particularly useful for scenarios where you need to switch armatures while preserving the animation setup of your skinned mesh.

### Features
- Reassign armature to skinned meshes quickly and efficiently.
- Option to ignore missing bones, although this might lead to unexpected results if important bones are missing.

### Usage
1. In the Unity Editor, navigate to the QT Tools menu.
2. Select the Reassign armature option.
3. The QT Reassign Armature window will open.
4. Specify the skinned mesh renderer that you want to modify.
5. Specify the armature GameObject that you want to assign to the mesh renderer.
6. Use the "Ignore missing bones" option with caution. If important bones are missing, unexpected behavior may occur.
7. Click the Assign armature button to reassign the armature.

## QT Reset Prefab Unity Tool
The QT Reset Prefab tool is a Unity utility to streamline the process of resetting the transforms of selected objects to their original prefab values. This tool proves valuable when you need to revert your objects back to their initial prefab configuration.

### Features
Reset transforms of selected objects to their prefab values with a single click.

### Usage
1. In the Unity Editor, navigate to the QT Tools menu.
2. Select the Reset transforms to prefab option.
3. The QT Reset Prefab window will open.
4. The window will display a list of transforms that can be reset to their prefab values.
5. To select objects, populate the transforms array with the desired Transform components.
6. Click the Reset to prefab state button to revert the selected objects to their prefab configuration.

## QT Auto-Assign Physbones Unity Tool
The QT Auto-Assign Physbones tool is a Unity utility to streamline the process of automatically assigning root transforms to VRCPhysBone components within a specified avatar hierarchy. This tool proves valuable when you need to quickly assign the root bone to a large quantity of Physbones.

### Features
Automate the assignment of root transforms to VRCPhysBone components with missing roots.

### Usage
1. In the Unity Editor, navigate to the QT Tools menu.
2. Select the Auto-assign Physbones option.
3. The QT Auto-Assign Physbones window will open.
4. The window will display a field to specify the base GameObject (avatar) within which the assignment will occur.
5. Assign a valid GameObject, usually the avatar.
6. Click the Assign physbones button to automatically assign root transforms to VRCPhysBone components without roots.

## License
This project is licensed under the MIT License.