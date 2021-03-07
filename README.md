# Flexible Grid Layout

## Table of Contents
- [Introduction](#introduction)
- [Installation](#installation)
    - [Enable Package Dependencies](#enable-package-dependencies)
    - [Add Flexible Grid Layout Package](#add-flexible-grid-layout-package)
    - [Recompile](#recompile)
- [Dependencies](#dependencies)
- [Usage](#usage)

## Introduction

Based on the tutorial of `GameDevGuide`: https://www.youtube.com/watch?v=CGsEJToeXmA

Also includes a CustomEditor script to make the editing in the inspector less error prone.

## Installation

### Enable Package Dependencies
This package has dependencies to other git repositories which Unity needs to resolve. The Unity Package Manager does not yet resolve packages correctly. This tool mitigates this and resolves all git dependencies correctly https://github.com/mob-sakai/GitDependencyResolverForUnity. 

To install this resolver tool you simply need to adapt the `manifest.json` file in the `Packages` directory in your project. Add the following:
```json
{
  "dependencies": {
    "com.coffee.git-dependency-resolver": "https://github.com/mob-sakai/GitDependencyResolverForUnity.git"
  }
}
```

### Add Flexible Grid Layout Package

Similar to the step above you further need to add the following line to the dependencie-section in the `manifest.json`:

```json
"com.dehagge.flexiblegirdlayout": "https://github.com/jnroesch/com.dehagge.flexiblegridlayout.git"
``` 

### Recompile

After saving the `manifest.json` Unity should automatically recompile and add the new packages. If not, it might help to restart Unity. 

## Dependencies
This package has the following dependencies:

```json
"com.dehagge.privatetestframework": "https://github.com/jnroesch/com.dehagge.privatetestframework.git#v0.1.0"
```

## Usage

Add the `FlexibleGridLayout` component to your UI object similar to any other Layout Group. Either let the system calculate the number of rows and columns needed depending on the number of child-transforms or set them manually.