# AutoMountNext

A modernized mod for Owlcat's Pathfinder: Wrath of the Righteous that provides automatic mounting for animal companions with both manual controls and combat automation.

Based on AutoMount_for_TabletopTweaks (https://github.com/DarthParametric/AutoMount_for_TabletopTweaks)

## Overview

AutoMountNext (v2.0.0) is a an alternative take on the original AutoMount mod, offering mount management that adapts to combat and exploration. The mod provides both immediate manual control and automation.

## Key Features

### 🎯 Individual Character Control
- **Per-Character Automation**: Each party member can have their own mounting preferences
- **Combat Mount Toggle**: Characters can automatically mount when combat begins
- **Post-Combat Mount Toggle**: Characters can automatically mount after combat ends
- **Visual Feedback**: Active preferences shown as toggable ability with clear descriptions

### ⚡ Emergency Manual Controls
- **Ctrl+Shift+A**: Instantly mount all party members (overrides individual preferences)
- **Ctrl+Shift+D**: Instantly dismount all party members (essential for cutscenes and restricted areas)

### 🧠 Smart Area Detection
- **Dynamic Area Awareness**: Automatically detects problematic areas where mounts should be disabled
- **Pet Safety System**: Uses the game's etude system to prevent mounts in incompatible zones
- **Cutscene Handling**: use emergency dismount to ensure compatibility with story sequences

### 🔧 Other Compatibility
- **TabletopTweaks Integration**: Support for Undersized Mount feat (same-size mounting)
- **Multilingual Support**: Translations for all officially supported game languages

## How It Works

### Buff-Based Preference System
The mod uses the game's buff system to store and display mounting preferences. When you toggle a character's combat mounting abilities, hidden buffs are applied on their character that drives the automation.

### Safe Combat Integration
Combat automation uses a delayed-execution system that schedules mount/dismount operations safely, avoiding conflicts with the game's event system during intense combat scenarios.

### Embedded Resource Management
All mod assets are compiled directly into the DLL using embedded resources, ensuring clean deployment and eliminating external file dependencies.

## Installation

1. Ensure you have Unity Mod Manager installed
2. Extract AutoMountNext to your `Mods/` directory
4. Configure your preferences via the in-game ModMenu settings

## Usage

### Setting Up Automation
1. Open any character's character sheet
2. Look for the new "Auto Mount When In Combat" and "Auto Mount When Not In Combat" abilities
3. Toggle these abilities to set each character's preferences

### Manual Override
- Use **Ctrl+Shift+A** to force mount everyone regardless of individual settings
- Use **Ctrl+Shift+D** to force dismount everyone (crucial for cutscenes)

### ModMenu Configuration
Access additional settings through the in-game ModMenu including:
- Debug logging options
- Hotkey customization

## Technical Details

- **Target Framework**: .NET Framework 4.8.1
- **Game Integration**: Unity Mod Manager + Harmony runtime patching
- **Dependencies**: TabletopTweaks (optional), ModMenu (recommended)
- **Performance**: Minimal impact using efficient event-driven architecture

## Compatibility

- **Fully Compatible**: TabletopTweaks, More Party Slots, ModMenu
- **Game Versions**: Current Wrath of the Righteous versions
- **Save Compatibility**: Safe to add/remove from existing saves

## Version History

- **v2.0.0**: Modernization with individual character control, combat automation, and enhanced compatibility
- **v1.x**: Original AutoMount functionality with basic hotkey support and white lists


## Dependencies
Blueprint Core (https://github.com/WittleWolfie/WW-Blueprint-Core)
