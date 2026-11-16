// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2026 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
namespace WebSharper.ThreeJs

open WebSharper
open WebSharper.InterfaceGenerator

/// <summary>Typed bindings for <a href="https://threejs.org/">three.js</a> 0.187.</summary>
/// <remarks>
/// The binding is npm based: every class is a named import from the
/// <c>three</c> package (<c>import { Vector3 } from "three"</c>) and the
/// addons come from <c>three/addons/…</c>. The sample bundles the npm package
/// with esbuild; there is no global <c>THREE</c> object and no CDN
/// <c>&lt;script&gt;</c>.
/// </remarks>
module Definition =

    let Unit = T<unit>

    /// Imports a named export of the `three` package.
    let c3 (name: string) : CodeModel.Class =
        Class name |> Import name "three"

    /// Imports a named export of a three.js addon module.
    let a3 (moduleName: string) (name: string) : CodeModel.Class =
        Class name |> Import name moduleName

    /// A common typed array, as accepted by buffers and textures.
    let TypedArray =
        T<JavaScript.Float32Array> +
        T<JavaScript.Float64Array> +
        T<JavaScript.Int8Array> +
        T<JavaScript.Int16Array> +
        T<JavaScript.Int32Array> +
        T<JavaScript.Uint8Array> +
        T<JavaScript.Uint8ClampedArray> +
        T<JavaScript.Uint16Array> +
        T<JavaScript.Uint32Array>

    // ------------------------------------------------------------------
    // Constants and enumerations
    // ------------------------------------------------------------------

    /// Which faces of a mesh are rendered.
    let Side =
        Pattern.EnumInlines "Side" [
            "FrontSide", "0"
            "BackSide", "1"
            "DoubleSide", "2"
        ]

    /// How a material is blended with what is already in the buffer.
    let Blending =
        Pattern.EnumInlines "Blending" [
            "NoBlending", "0"
            "NormalBlending", "1"
            "AdditiveBlending", "2"
            "SubtractiveBlending", "3"
            "MultiplyBlending", "4"
            "CustomBlending", "5"
        ]

    /// The shadow map algorithm used by the renderer.
    /// `PCFSoftShadowMap` was removed in three.js 0.187 (it falls back to
    /// `PCFShadowMap`), so it is deliberately not exposed here.
    let ShadowMapType =
        Pattern.EnumInlines "ShadowMapType" [
            "BasicShadowMap", "0"
            "PCFShadowMap", "1"
            "VSMShadowMap", "3"
        ]

    /// The tone mapping operator applied by the renderer.
    let ToneMapping =
        Pattern.EnumInlines "ToneMapping" [
            "NoToneMapping", "0"
            "LinearToneMapping", "1"
            "ReinhardToneMapping", "2"
            "CineonToneMapping", "3"
            "ACESFilmicToneMapping", "4"
            "AgXToneMapping", "6"
            "NeutralToneMapping", "7"
        ]

    /// How a texture is sampled outside of the [0, 1] range.
    let Wrapping =
        Pattern.EnumInlines "Wrapping" [
            "RepeatWrapping", "1000"
            "ClampToEdgeWrapping", "1001"
            "MirroredRepeatWrapping", "1002"
        ]

    /// Texture magnification/minification filters.
    let TextureFilter =
        Pattern.EnumInlines "TextureFilter" [
            "NearestFilter", "1003"
            "NearestMipmapNearestFilter", "1004"
            "NearestMipmapLinearFilter", "1005"
            "LinearFilter", "1006"
            "LinearMipmapNearestFilter", "1007"
            "LinearMipmapLinearFilter", "1008"
        ]

    /// How a texture is mapped onto a surface.
    let TextureMapping =
        Pattern.EnumInlines "TextureMapping" [
            "UVMapping", "300"
            "CubeReflectionMapping", "301"
            "CubeRefractionMapping", "302"
            "EquirectangularReflectionMapping", "303"
            "EquirectangularRefractionMapping", "304"
        ]

    /// CPU-side pixel layouts.
    let TextureFormat =
        Pattern.EnumInlines "TextureFormat" [
            "AlphaFormat", "1021"
            "RGBFormat", "1022"
            "RGBAFormat", "1023"
            "DepthFormat", "1026"
            "DepthStencilFormat", "1027"
            "RedFormat", "1028"
            "RGFormat", "1030"
        ]

    /// Storage type of the pixel components.
    let TextureType =
        Pattern.EnumInlines "TextureType" [
            "UnsignedByteType", "1009"
            "FloatType", "1015"
            "HalfFloatType", "1016"
        ]

    /// GPU buffer usage hints.
    let Usage =
        Pattern.EnumInlines "Usage" [
            "StaticDrawUsage", "35044"
            "DynamicDrawUsage", "35048"
            "StreamDrawUsage", "35040"
        ]

    /// Animation loop modes.
    let LoopMode =
        Pattern.EnumInlines "LoopMode" [
            "LoopOnce", "2200"
            "LoopRepeat", "2201"
            "LoopPingPong", "2202"
        ]

    /// Keyframe interpolation modes.
    let InterpolationMode =
        Pattern.EnumInlines "InterpolationMode" [
            "InterpolateDiscrete", "2300"
            "InterpolateLinear", "2301"
            "InterpolateSmooth", "2302"
        ]

    /// Color spaces understood by the renderer and the textures.
    let ColorSpace =
        Pattern.EnumInlines "ColorSpace" [
            "NoColorSpace", "''"
            "SRGBColorSpace", "'srgb'"
            "LinearSRGBColorSpace", "'srgb-linear'"
        ]

    /// The roles the controls assign to mouse buttons (the `mouseButtons` map).
    /// `Left`/`Middle`/`Right` mirror `OrbitControls`; `Rotate`/`Dolly`/`Pan`
    /// are the equivalent `TrackballControls` aliases.
    let MouseButton =
        Pattern.EnumInlines "MouseButton" [
            "Left", "0"
            "Middle", "1"
            "Right", "2"
            "Rotate", "0"
            "Dolly", "1"
            "Pan", "2"
        ]

    /// The roles the controls assign to touch gestures (the `touches` map).
    let TouchAction =
        Pattern.EnumInlines "TouchAction" [
            "Rotate", "0"
            "Pan", "1"
            "DollyPan", "2"
            "DollyRotate", "3"
        ]

    // ------------------------------------------------------------------
    // Class handles — every three.js value we bind, with its npm import.
    // ------------------------------------------------------------------

    // Math
    let Vector2 = c3 "Vector2"
    let Vector3 = c3 "Vector3"
    let Vector4 = c3 "Vector4"
    let Matrix3 = c3 "Matrix3"
    let Matrix4 = c3 "Matrix4"
    let Quaternion = c3 "Quaternion"
    let Euler = c3 "Euler"
    let Color = c3 "Color"
    let Box2 = c3 "Box2"
    let Box3 = c3 "Box3"
    let Sphere = c3 "Sphere"
    let Plane = c3 "Plane"
    let Ray = c3 "Ray"
    let Line3 = c3 "Line3"
    let Triangle = c3 "Triangle"
    let Frustum = c3 "Frustum"
    let Spherical = c3 "Spherical"
    let MathUtils = c3 "MathUtils"
    let Clock =
        c3 "Clock"
        |> ObsoleteWithMessage "Clock is deprecated in three.js 0.187; use Timer instead."

    let Timer = c3 "Timer"
    let Layers = c3 "Layers"

    // Core
    let EventDispatcher = c3 "EventDispatcher"
    let Object3D = c3 "Object3D"
    let Group = c3 "Group"
    let Scene = c3 "Scene"
    let Camera = c3 "Camera"
    let PerspectiveCamera = c3 "PerspectiveCamera"
    let OrthographicCamera = c3 "OrthographicCamera"
    let BufferAttribute = c3 "BufferAttribute"
    let BufferGeometry = c3 "BufferGeometry"
    let Raycaster = c3 "Raycaster"

    // Textures and loaders
    let Texture = c3 "Texture"
    let CanvasTexture = c3 "CanvasTexture"
    let DataTexture = c3 "DataTexture"
    let VideoTexture = c3 "VideoTexture"
    let CubeTexture = c3 "CubeTexture"
    let Loader = c3 "Loader"
    let LoadingManager = c3 "LoadingManager"
    let TextureLoader = c3 "TextureLoader"

    // Materials
    let Material = c3 "Material"
    let MeshBasicMaterial = c3 "MeshBasicMaterial"
    let MeshStandardMaterial = c3 "MeshStandardMaterial"
    let MeshPhysicalMaterial = c3 "MeshPhysicalMaterial"
    let MeshPhongMaterial = c3 "MeshPhongMaterial"
    let MeshLambertMaterial = c3 "MeshLambertMaterial"
    let MeshNormalMaterial = c3 "MeshNormalMaterial"
    let MeshDepthMaterial = c3 "MeshDepthMaterial"
    let MeshToonMaterial = c3 "MeshToonMaterial"
    let MeshMatcapMaterial = c3 "MeshMatcapMaterial"
    let PointsMaterial = c3 "PointsMaterial"
    let LineBasicMaterial = c3 "LineBasicMaterial"
    let LineDashedMaterial = c3 "LineDashedMaterial"
    let SpriteMaterial = c3 "SpriteMaterial"
    let ShadowMaterial = c3 "ShadowMaterial"
    let ShaderMaterial = c3 "ShaderMaterial"

    // Objects
    let Mesh = c3 "Mesh"
    let Line = c3 "Line"
    let LineSegments = c3 "LineSegments"
    let LineLoop = c3 "LineLoop"
    let Points = c3 "Points"
    let Sprite = c3 "Sprite"
    let LOD = c3 "LOD"
    let InstancedMesh = c3 "InstancedMesh"

    // Lights and shadows
    let Light = c3 "Light"
    let AmbientLight = c3 "AmbientLight"
    let DirectionalLight = c3 "DirectionalLight"
    let HemisphereLight = c3 "HemisphereLight"
    let PointLight = c3 "PointLight"
    let SpotLight = c3 "SpotLight"
    let RectAreaLight = c3 "RectAreaLight"
    let LightShadow = c3 "LightShadow"
    let DirectionalLightShadow = c3 "DirectionalLightShadow"
    let PointLightShadow = c3 "PointLightShadow"
    let SpotLightShadow = c3 "SpotLightShadow"

    // Scenes, fog
    let Fog = c3 "Fog"
    let FogExp2 = c3 "FogExp2"

    // Renderers
    let WebGLRenderer = c3 "WebGLRenderer"
    let WebGLShadowMap = c3 "WebGLShadowMap"
    let WebGLInfo = c3 "WebGLInfo"
    let WebGLRenderInfo = c3 "WebGLRenderInfo"
    let WebGLMemoryInfo = c3 "WebGLMemoryInfo"
    let WebGLRenderTarget = c3 "WebGLRenderTarget"

    // Animation
    let AnimationMixer = c3 "AnimationMixer"
    let AnimationClip = c3 "AnimationClip"
    let AnimationAction = c3 "AnimationAction"
    let KeyframeTrack = c3 "KeyframeTrack"
    let NumberKeyframeTrack = c3 "NumberKeyframeTrack"
    let VectorKeyframeTrack = c3 "VectorKeyframeTrack"
    let ColorKeyframeTrack = c3 "ColorKeyframeTrack"
    let QuaternionKeyframeTrack = c3 "QuaternionKeyframeTrack"
    let BooleanKeyframeTrack = c3 "BooleanKeyframeTrack"
    let StringKeyframeTrack = c3 "StringKeyframeTrack"

    // Curves
    let Curve = c3 "Curve"
    let CatmullRomCurve3 = c3 "CatmullRomCurve3"
    let LineCurve3 = c3 "LineCurve3"
    let QuadraticBezierCurve3 = c3 "QuadraticBezierCurve3"
    let CubicBezierCurve3 = c3 "CubicBezierCurve3"

    // Geometries
    let BoxGeometry = c3 "BoxGeometry"
    let SphereGeometry = c3 "SphereGeometry"
    let PlaneGeometry = c3 "PlaneGeometry"
    let CircleGeometry = c3 "CircleGeometry"
    let CylinderGeometry = c3 "CylinderGeometry"
    let ConeGeometry = c3 "ConeGeometry"
    let TorusGeometry = c3 "TorusGeometry"
    let TorusKnotGeometry = c3 "TorusKnotGeometry"
    let RingGeometry = c3 "RingGeometry"
    let CapsuleGeometry = c3 "CapsuleGeometry"
    let IcosahedronGeometry = c3 "IcosahedronGeometry"
    let OctahedronGeometry = c3 "OctahedronGeometry"
    let TetrahedronGeometry = c3 "TetrahedronGeometry"
    let DodecahedronGeometry = c3 "DodecahedronGeometry"
    let PolyhedronGeometry = c3 "PolyhedronGeometry"
    let EdgesGeometry = c3 "EdgesGeometry"
    let WireframeGeometry = c3 "WireframeGeometry"
    let LatheGeometry = c3 "LatheGeometry"
    let TubeGeometry = c3 "TubeGeometry"

    // Helpers
    let AxesHelper = c3 "AxesHelper"
    let GridHelper = c3 "GridHelper"
    let PolarGridHelper = c3 "PolarGridHelper"
    let ArrowHelper = c3 "ArrowHelper"
    let Box3Helper = c3 "Box3Helper"
    let BoxHelper = c3 "BoxHelper"
    let CameraHelper = c3 "CameraHelper"
    let DirectionalLightHelper = c3 "DirectionalLightHelper"
    let PointLightHelper = c3 "PointLightHelper"
    let SpotLightHelper = c3 "SpotLightHelper"

    // Controls (addons)
    let Controls = c3 "Controls"
    let OrbitControls = a3 "three/addons/controls/OrbitControls.js" "OrbitControls"
    let MapControls = a3 "three/addons/controls/MapControls.js" "MapControls"
    let TrackballControls = a3 "three/addons/controls/TrackballControls.js" "TrackballControls"
    let FlyControls = a3 "three/addons/controls/FlyControls.js" "FlyControls"
    let FirstPersonControls = a3 "three/addons/controls/FirstPersonControls.js" "FirstPersonControls"
    let PointerLockControls = a3 "three/addons/controls/PointerLockControls.js" "PointerLockControls"
    let ArcballControls = a3 "three/addons/controls/ArcballControls.js" "ArcballControls"
    let DragControls = a3 "three/addons/controls/DragControls.js" "DragControls"
    let TransformControls = a3 "three/addons/controls/TransformControls.js" "TransformControls"

    // ------------------------------------------------------------------
    // Option and event shapes
    // ------------------------------------------------------------------

    /// <summary>An HSL color, as returned by <c>Color.GetHSL</c>.</summary>
    let HSL =
        Pattern.Config "HSL" {
            Required = []
            Optional = [
                "h", T<float>
                "s", T<float>
                "l", T<float>
            ]
        }

    /// <summary>An RGB color, as returned by <c>Color.GetRGB</c>.</summary>
    let RGB =
        Pattern.Config "RGB" {
            Required = []
            Optional = [
                "r", T<float>
                "g", T<float>
                "b", T<float>
            ]
        }

    /// <summary>Anything three.js accepts where a color is expected.</summary>
    let ColorRepresentation = Color + T<int> + T<string>

    /// <summary>
    /// The payload of an event dispatched by an <c>EventDispatcher</c>.
    /// three.js event objects are plain objects with at least a <c>type</c>.
    /// </summary>
    let ThreeEvent =
        Pattern.Config "ThreeEvent" {
            Required = [
                "type", T<string>
            ]
            Optional = [
                "target", Object3D.Type
            ]
        }

    /// The mouse-button roles the controls assign in their `mouseButtons` map.
    let MouseButtons =
        Pattern.Config "MouseButtons" {
            Required = []
            Optional = [
                "LEFT", MouseButton.Type
                "MIDDLE", MouseButton.Type
                "RIGHT", MouseButton.Type
            ]
        }

    /// The touch-gesture roles the controls assign in their `touches` map.
    let Touches =
        Pattern.Config "Touches" {
            Required = []
            Optional = [
                "ONE", TouchAction.Type
                "TWO", TouchAction.Type
            ]
        }

    /// The screen rectangle `TrackballControls` maintains for its gestures.
    let TrackballControlsScreen =
        Pattern.Config "TrackballControlsScreen" {
            Required = []
            Optional = [
                "left", T<float>
                "top", T<float>
                "width", T<float>
                "height", T<float>
            ]
        }

    // Event names of the addon controls. Each enum stands in for the event-name
    // string, so `AddEventListener` stays strongly typed per control.

    /// Events of `OrbitControls` and `MapControls`.
    let OrbitControlsEvent =
        Pattern.EnumInlines "OrbitControlsEvent" [
            "Change", "'change'"
            "Start", "'start'"
            "End", "'end'"
        ]

    /// Events of `TrackballControls`.
    let TrackballControlsEvent =
        Pattern.EnumInlines "TrackballControlsEvent" [
            "Change", "'change'"
            "Start", "'start'"
            "End", "'end'"
        ]

    /// Events of `ArcballControls`.
    let ArcballControlsEvent =
        Pattern.EnumInlines "ArcballControlsEvent" [
            "Change", "'change'"
            "Start", "'start'"
            "End", "'end'"
        ]

    /// Events of `FlyControls`.
    let FlyControlsEvent =
        Pattern.EnumInlines "FlyControlsEvent" [
            "Change", "'change'"
        ]

    /// Events of `PointerLockControls`.
    let PointerLockControlsEvent =
        Pattern.EnumInlines "PointerLockControlsEvent" [
            "Change", "'change'"
            "Lock", "'lock'"
            "Unlock", "'unlock'"
        ]

    /// Events of `DragControls`.
    let DragControlsEvent =
        Pattern.EnumInlines "DragControlsEvent" [
            "HoverOn", "'hoveron'"
            "HoverOff", "'hoveroff'"
            "DragStart", "'dragstart'"
            "Drag", "'drag'"
            "DragEnd", "'dragend'"
        ]

    /// Events of `TransformControls`.
    let TransformControlsEvent =
        Pattern.EnumInlines "TransformControlsEvent" [
            "Change", "'change'"
            "MouseDown", "'mouseDown'"
            "MouseUp", "'mouseUp'"
            "ObjectChange", "'objectChange'"
            "DraggingChanged", "'dragging-changed'"
        ]

    /// Payload of a `DragControls` event: the object being hovered or dragged.
    let DragControlsObjectEvent =
        Pattern.Config "DragControlsObjectEvent" {
            Required = [
                "type", T<string>
            ]
            Optional = [
                "target", Object3D.Type
                "object", Object3D.Type
            ]
        }

    /// Payload of a `TransformControls` event. Only the field relevant to the
    /// fired event is set: `mode` on `mouseDown`/`mouseUp`, `value` on
    /// `dragging-changed`.
    let TransformControlsEventPayload =
        Pattern.Config "TransformControlsEventPayload" {
            Required = [
                "type", T<string>
            ]
            Optional = [
                "target", Object3D.Type
                "mode", T<string>
                "value", T<bool>
            ]
        }

    /// <summary>A triangle face, as reported by the raycaster.</summary>
    let Face =
        Pattern.Config "Face" {
            Required = []
            Optional = [
                "a", T<int>
                "b", T<int>
                "c", T<int>
                "normal", Vector3.Type
                "materialIndex", T<int>
            ]
        }

    /// <summary>A raycasting hit.</summary>
    let Intersection =
        Pattern.Config "Intersection" {
            Required = []
            Optional = [
                "distance", T<float>
                "distanceToRay", T<float>
                "point", Vector3.Type
                "index", T<int>
                "face", Face.Type
                "faceIndex", T<int>
                "object", Object3D.Type
                "uv", Vector2.Type
                "uv1", Vector2.Type
                "normal", Vector3.Type
                "instanceId", T<int>
                "pointOnLine", Vector3.Type
            ]
        }

    /// <summary>Per-object-type raycaster thresholds.</summary>
    let RaycasterThreshold =
        Pattern.Config "RaycasterThreshold" {
            Required = [
                "threshold", T<float>
            ]
            Optional = []
        }

    /// <summary>Raycaster tuning parameters.</summary>
    let RaycasterParameters =
        Pattern.Config "RaycasterParameters" {
            Required = []
            Optional = [
                "Line", RaycasterThreshold.Type
                "Points", RaycasterThreshold.Type
            ]
        }

    /// <summary>A named collection of vertex attributes of a geometry.</summary>
    let BufferAttributes =
        Class "BufferAttributes"
        |+> Instance [
            Property "" BufferAttribute.Type |> Indexed T<string>
        ]

    /// <summary>A group of a geometry's index buffer rendering with one material.</summary>
    let GeometryGroup =
        Pattern.Config "GeometryGroup" {
            Required = [
                "start", T<int>
                "count", T<int>
            ]
            Optional = [
                "materialIndex", T<int>
            ]
        }

    /// <summary>One level of detail of a <c>LOD</c> object.</summary>
    let LODLevel =
        Pattern.Config "LODLevel" {
            Required = [
                "distance", T<float>
                "object", Object3D.Type
            ]
            Optional = []
        }

    /// <summary>The frames returned by <c>Curve.ComputeFrenetFrames</c>.</summary>
    let FrenetFrames =
        Pattern.Config "FrenetFrames" {
            Required = [
                "tangents", !| Vector3
                "normals", !| Vector3
                "binormals", !| Vector3
            ]
            Optional = []
        }

    /// <summary>What the current WebGL context can do.</summary>
    let WebGLCapabilities =
        Class "WebGLCapabilities"
        |+> Instance [
            "isWebGL2" =? T<bool>
            "maxTextures" =? T<int>
            "maxVertexTextures" =? T<int>
            "maxTextureSize" =? T<int>
            "maxCubemapSize" =? T<int>
            "maxAttributes" =? T<int>
            "maxVertexUniforms" =? T<int>
            "maxVaryings" =? T<int>
            "maxFragmentUniforms" =? T<int>
            "vertexTextures" =? T<bool>
            "floatFragmentTextures" =? T<bool>
            "floatVertexTextures" =? T<bool>
            "maxSamples" =? T<int>
            "precision" =? T<string>
        ]

    /// <summary>A sub-range of the index buffer to draw.</summary>
    let DrawRange =
        Pattern.Config "DrawRange" {
            Required = [
                "start", T<int>
                "count", T<int>
            ]
            Optional = []
        }

    /// <summary>Options of a WebGL render target.</summary>
    let RenderTargetOptions =
        Pattern.Config "RenderTargetOptions" {
            Required = []
            Optional = [
                "minFilter", TextureFilter.Type
                "magFilter", TextureFilter.Type
                "format", TextureFormat.Type
                "type", TextureType.Type
                "wrapS", Wrapping.Type
                "wrapT", Wrapping.Type
                "anisotropy", T<int>
                "colorSpace", ColorSpace.Type
                "depthBuffer", T<bool>
                "stencilBuffer", T<bool>
                "generateMipmaps", T<bool>
                "samples", T<int>
            ]
        }

    /// <summary>The preferred power profile of the WebGL context.</summary>
    let WebGLPowerPreference =
        Pattern.EnumInlines "WebGLPowerPreference" [
            "Default", "'default'"
            "HighPerformance", "'high-performance'"
            "LowPower", "'low-power'"
        ]

    /// <summary>Shader precision requested from the GPU.</summary>
    let ShaderPrecision =
        Pattern.EnumStrings "ShaderPrecision" [
            "highp"
            "mediump"
            "lowp"
        ]

    /// <summary>Options accepted by the <c>WebGLRenderer</c> constructor.</summary>
    let WebGLRendererOptions =
        Pattern.Config "WebGLRendererOptions" {
            Required = []
            Optional = [
                "canvas", T<JavaScript.HTMLCanvasElement>
                "context", T<JavaScript.WebGL.RenderingContext>
                "alpha", T<bool>
                "premultipliedAlpha", T<bool>
                "antialias", T<bool>
                "stencil", T<bool>
                "depth", T<bool>
                "preserveDrawingBuffer", T<bool>
                "powerPreference", WebGLPowerPreference.Type
                "failIfMajorPerformanceCaveat", T<bool>
                "logarithmicDepthBuffer", T<bool>
                "precision", ShaderPrecision.Type
                "outputBufferType", TextureType.Type
            ]
        }

    /// <summary>Options shared by every material.</summary>
    let MaterialParameters =
        Pattern.Config "MaterialParameters" {
            Required = []
            Optional = [
                "name", T<string>
                "side", Side.Type
                "shadowSide", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "alphaTest", T<float>
                "alphaHash", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "colorWrite", T<bool>
                "polygonOffset", T<bool>
                "polygonOffsetFactor", T<float>
                "polygonOffsetUnits", T<float>
                "vertexColors", T<bool>
                "dithering", T<bool>
                "toneMapped", T<bool>
                "visible", T<bool>
                "premultipliedAlpha", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshBasicMaterial</c>.</summary>
    let MeshBasicMaterialParameters =
        Pattern.Config "MeshBasicMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "map", Texture.Type
                "lightMap", Texture.Type
                "lightMapIntensity", T<float>
                "aoMap", Texture.Type
                "aoMapIntensity", T<float>
                "specularMap", Texture.Type
                "alphaMap", Texture.Type
                "envMap", Texture.Type
                "combine", T<int>
                "reflectivity", T<float>
                "refractionRatio", T<float>
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "wireframeLinecap", T<string>
                "wireframeLinejoin", T<string>
                "fog", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
                "toneMapped", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshStandardMaterial</c>.</summary>
    let MeshStandardMaterialParameters =
        Pattern.Config "MeshStandardMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "roughness", T<float>
                "metalness", T<float>
                "map", Texture.Type
                "lightMap", Texture.Type
                "lightMapIntensity", T<float>
                "aoMap", Texture.Type
                "aoMapIntensity", T<float>
                "emissive", ColorRepresentation
                "emissiveIntensity", T<float>
                "emissiveMap", Texture.Type
                "bumpMap", Texture.Type
                "bumpScale", T<float>
                "normalMap", Texture.Type
                "normalScale", Vector2.Type
                "displacementMap", Texture.Type
                "displacementScale", T<float>
                "displacementBias", T<float>
                "roughnessMap", Texture.Type
                "metalnessMap", Texture.Type
                "alphaMap", Texture.Type
                "envMap", Texture.Type
                "envMapIntensity", T<float>
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "flatShading", T<bool>
                "fog", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
                "toneMapped", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshPhysicalMaterial</c>.</summary>
    let MeshPhysicalMaterialParameters =
        Pattern.Config "MeshPhysicalMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "roughness", T<float>
                "metalness", T<float>
                "map", Texture.Type
                "emissive", ColorRepresentation
                "emissiveIntensity", T<float>
                "normalMap", Texture.Type
                "normalScale", Vector2.Type
                "envMap", Texture.Type
                "envMapIntensity", T<float>
                "clearcoat", T<float>
                "clearcoatMap", Texture.Type
                "clearcoatRoughness", T<float>
                "clearcoatRoughnessMap", Texture.Type
                "clearcoatNormalMap", Texture.Type
                "clearcoatNormalScale", Vector2.Type
                "ior", T<float>
                "sheen", T<float>
                "sheenColor", ColorRepresentation
                "sheenRoughness", T<float>
                "transmission", T<float>
                "transmissionMap", Texture.Type
                "thickness", T<float>
                "attenuationColor", ColorRepresentation
                "attenuationDistance", T<float>
                "specularIntensity", T<float>
                "specularColor", ColorRepresentation
                "iridescence", T<float>
                "iridescenceIOR", T<float>
                "iridescenceThicknessMinimum", T<float>
                "iridescenceThicknessMaximum", T<float>
                "anisotropy", T<float>
                "anisotropyRotation", T<float>
                "dispersion", T<float>
                "wireframe", T<bool>
                "flatShading", T<bool>
                "fog", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
                "toneMapped", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshPhongMaterial</c>.</summary>
    let MeshPhongMaterialParameters =
        Pattern.Config "MeshPhongMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "specular", ColorRepresentation
                "shininess", T<float>
                "emissive", ColorRepresentation
                "emissiveIntensity", T<float>
                "map", Texture.Type
                "lightMap", Texture.Type
                "aoMap", Texture.Type
                "emissiveMap", Texture.Type
                "bumpMap", Texture.Type
                "bumpScale", T<float>
                "normalMap", Texture.Type
                "normalScale", Vector2.Type
                "specularMap", Texture.Type
                "alphaMap", Texture.Type
                "envMap", Texture.Type
                "envMapIntensity", T<float>
                "reflectivity", T<float>
                "refractionRatio", T<float>
                "combine", T<int>
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "flatShading", T<bool>
                "fog", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshLambertMaterial</c>.</summary>
    let MeshLambertMaterialParameters =
        Pattern.Config "MeshLambertMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "emissive", ColorRepresentation
                "emissiveIntensity", T<float>
                "map", Texture.Type
                "lightMap", Texture.Type
                "aoMap", Texture.Type
                "emissiveMap", Texture.Type
                "alphaMap", Texture.Type
                "envMap", Texture.Type
                "combine", T<int>
                "reflectivity", T<float>
                "refractionRatio", T<float>
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "flatShading", T<bool>
                "fog", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshNormalMaterial</c>.</summary>
    let MeshNormalMaterialParameters =
        Pattern.Config "MeshNormalMaterialParameters" {
            Required = []
            Optional = [
                "bumpMap", Texture.Type
                "bumpScale", T<float>
                "normalMap", Texture.Type
                "normalScale", Vector2.Type
                "displacementMap", Texture.Type
                "displacementScale", T<float>
                "displacementBias", T<float>
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "flatShading", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshDepthMaterial</c>.</summary>
    let MeshDepthMaterialParameters =
        Pattern.Config "MeshDepthMaterialParameters" {
            Required = []
            Optional = [
                "map", Texture.Type
                "alphaMap", Texture.Type
                "displacementMap", Texture.Type
                "displacementScale", T<float>
                "displacementBias", T<float>
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshToonMaterial</c>.</summary>
    let MeshToonMaterialParameters =
        Pattern.Config "MeshToonMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "map", Texture.Type
                "gradientMap", Texture.Type
                "emissive", ColorRepresentation
                "emissiveIntensity", T<float>
                "normalMap", Texture.Type
                "normalScale", Vector2.Type
                "alphaMap", Texture.Type
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "fog", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
            ]
        }

    /// <summary>Options of a <c>MeshMatcapMaterial</c>.</summary>
    let MeshMatcapMaterialParameters =
        Pattern.Config "MeshMatcapMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "matcap", Texture.Type
                "map", Texture.Type
                "alphaMap", Texture.Type
                "normalMap", Texture.Type
                "normalScale", Vector2.Type
                "wireframe", T<bool>
                "flatShading", T<bool>
                "fog", T<bool>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
            ]
        }

    /// <summary>Options of a <c>PointsMaterial</c>.</summary>
    let PointsMaterialParameters =
        Pattern.Config "PointsMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "map", Texture.Type
                "alphaMap", Texture.Type
                "size", T<float>
                "sizeAttenuation", T<bool>
                "fog", T<bool>
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
            ]
        }

    /// <summary>Options of a <c>LineBasicMaterial</c>.</summary>
    let LineBasicMaterialParameters =
        Pattern.Config "LineBasicMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "map", Texture.Type
                "linewidth", T<float>
                "linecap", T<string>
                "linejoin", T<string>
                "fog", T<bool>
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
            ]
        }

    /// <summary>Options of a <c>LineDashedMaterial</c>.</summary>
    let LineDashedMaterialParameters =
        Pattern.Config "LineDashedMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "map", Texture.Type
                "scale", T<float>
                "dashSize", T<float>
                "gapSize", T<float>
                "fog", T<bool>
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
            ]
        }

    /// <summary>Options of a <c>SpriteMaterial</c>.</summary>
    let SpriteMaterialParameters =
        Pattern.Config "SpriteMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "map", Texture.Type
                "alphaMap", Texture.Type
                "rotation", T<float>
                "sizeAttenuation", T<bool>
                "fog", T<bool>
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
            ]
        }

    /// <summary>Options of a <c>ShadowMaterial</c>.</summary>
    let ShadowMaterialParameters =
        Pattern.Config "ShadowMaterialParameters" {
            Required = []
            Optional = [
                "color", ColorRepresentation
                "fog", T<bool>
                "opacity", T<float>
                "transparent", T<bool>
                "depthWrite", T<bool>
            ]
        }

    /// <summary>Options of a <c>ShaderMaterial</c>.</summary>
    let ShaderMaterialParameters =
        Pattern.Config "ShaderMaterialParameters" {
            Required = [
                "vertexShader", T<string>
                "fragmentShader", T<string>
            ]
            Optional = [
                "uniforms", T<obj>
                "defines", T<obj>
                "linewidth", T<float>
                "wireframe", T<bool>
                "wireframeLinewidth", T<float>
                "fog", T<bool>
                "lights", T<bool>
                "clipping", T<bool>
                "glslVersion", T<string>
                "side", Side.Type
                "opacity", T<float>
                "transparent", T<bool>
                "blending", Blending.Type
                "depthTest", T<bool>
                "depthWrite", T<bool>
                "vertexColors", T<bool>
            ]
        }

    // ------------------------------------------------------------------
    // Inheritance
    // ------------------------------------------------------------------

    Group |=> Inherits Object3D |> ignore
    Scene |=> Inherits Object3D |> ignore
    Camera |=> Inherits Object3D |> ignore
    PerspectiveCamera |=> Inherits Camera |> ignore
    OrthographicCamera |=> Inherits Camera |> ignore
    Light |=> Inherits Object3D |> ignore
    Mesh |=> Inherits Object3D |> ignore
    Line |=> Inherits Object3D |> ignore
    LineSegments |=> Inherits Line |> ignore
    LineLoop |=> Inherits Line |> ignore
    Points |=> Inherits Object3D |> ignore
    Sprite |=> Inherits Object3D |> ignore
    LOD |=> Inherits Object3D |> ignore
    InstancedMesh |=> Inherits Mesh |> ignore
    AmbientLight |=> Inherits Light |> ignore
    DirectionalLight |=> Inherits Light |> ignore
    HemisphereLight |=> Inherits Light |> ignore
    PointLight |=> Inherits Light |> ignore
    SpotLight |=> Inherits Light |> ignore
    RectAreaLight |=> Inherits Light |> ignore
    DirectionalLightShadow |=> Inherits LightShadow |> ignore
    PointLightShadow |=> Inherits LightShadow |> ignore
    SpotLightShadow |=> Inherits LightShadow |> ignore
    CanvasTexture |=> Inherits Texture |> ignore
    DataTexture |=> Inherits Texture |> ignore
    VideoTexture |=> Inherits Texture |> ignore
    CubeTexture |=> Inherits Texture |> ignore
    Controls |=> Inherits EventDispatcher |> ignore
    OrbitControls |=> Inherits Controls |> ignore
    MapControls |=> Inherits OrbitControls |> ignore
    TrackballControls |=> Inherits Controls |> ignore
    FlyControls |=> Inherits Controls |> ignore
    FirstPersonControls |=> Inherits Controls |> ignore
    PointerLockControls |=> Inherits Controls |> ignore
    ArcballControls |=> Inherits Controls |> ignore
    DragControls |=> Inherits Controls |> ignore
    TransformControls |=> Inherits Controls |> ignore

    MeshBasicMaterial |=> Inherits Material |> ignore
    MeshStandardMaterial |=> Inherits Material |> ignore
    MeshPhysicalMaterial |=> Inherits MeshStandardMaterial |> ignore
    MeshPhongMaterial |=> Inherits Material |> ignore
    MeshLambertMaterial |=> Inherits Material |> ignore
    MeshNormalMaterial |=> Inherits Material |> ignore
    MeshDepthMaterial |=> Inherits Material |> ignore
    MeshToonMaterial |=> Inherits Material |> ignore
    MeshMatcapMaterial |=> Inherits Material |> ignore
    PointsMaterial |=> Inherits Material |> ignore
    LineBasicMaterial |=> Inherits Material |> ignore
    LineDashedMaterial |=> Inherits LineBasicMaterial |> ignore
    SpriteMaterial |=> Inherits Material |> ignore
    ShadowMaterial |=> Inherits Material |> ignore
    ShaderMaterial |=> Inherits Material |> ignore

    BoxGeometry |=> Inherits BufferGeometry |> ignore
    SphereGeometry |=> Inherits BufferGeometry |> ignore
    PlaneGeometry |=> Inherits BufferGeometry |> ignore
    CircleGeometry |=> Inherits BufferGeometry |> ignore
    CylinderGeometry |=> Inherits BufferGeometry |> ignore
    ConeGeometry |=> Inherits CylinderGeometry |> ignore
    TorusGeometry |=> Inherits BufferGeometry |> ignore
    TorusKnotGeometry |=> Inherits BufferGeometry |> ignore
    RingGeometry |=> Inherits BufferGeometry |> ignore
    CapsuleGeometry |=> Inherits LatheGeometry |> ignore
    PolyhedronGeometry |=> Inherits BufferGeometry |> ignore
    IcosahedronGeometry |=> Inherits PolyhedronGeometry |> ignore
    OctahedronGeometry |=> Inherits PolyhedronGeometry |> ignore
    TetrahedronGeometry |=> Inherits PolyhedronGeometry |> ignore
    DodecahedronGeometry |=> Inherits PolyhedronGeometry |> ignore
    EdgesGeometry |=> Inherits BufferGeometry |> ignore
    WireframeGeometry |=> Inherits BufferGeometry |> ignore
    LatheGeometry |=> Inherits BufferGeometry |> ignore
    TubeGeometry |=> Inherits BufferGeometry |> ignore

    CatmullRomCurve3 |=> Inherits Curve |> ignore
    LineCurve3 |=> Inherits Curve |> ignore
    QuadraticBezierCurve3 |=> Inherits Curve |> ignore
    CubicBezierCurve3 |=> Inherits Curve |> ignore

    NumberKeyframeTrack |=> Inherits KeyframeTrack |> ignore
    VectorKeyframeTrack |=> Inherits KeyframeTrack |> ignore
    ColorKeyframeTrack |=> Inherits KeyframeTrack |> ignore
    QuaternionKeyframeTrack |=> Inherits KeyframeTrack |> ignore
    BooleanKeyframeTrack |=> Inherits KeyframeTrack |> ignore
    StringKeyframeTrack |=> Inherits KeyframeTrack |> ignore

    AxesHelper |=> Inherits LineSegments |> ignore
    GridHelper |=> Inherits LineSegments |> ignore
    PolarGridHelper |=> Inherits LineSegments |> ignore
    ArrowHelper |=> Inherits Object3D |> ignore
    Box3Helper |=> Inherits LineSegments |> ignore
    BoxHelper |=> Inherits LineSegments |> ignore
    CameraHelper |=> Inherits LineSegments |> ignore
    DirectionalLightHelper |=> Inherits Object3D |> ignore
    PointLightHelper |=> Inherits Mesh |> ignore
    SpotLightHelper |=> Inherits Object3D |> ignore
    // ------------------------------------------------------------------
    // Math
    // ------------------------------------------------------------------

    Vector2
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>
            "width" =@ T<float>
            "height" =@ T<float>

            "set"                   => T<float>?x * T<float>?y ^-> TSelf
            "setScalar"             => T<float>?scalar ^-> TSelf
            "setX"                  => T<float>?x ^-> TSelf
            "setY"                  => T<float>?y ^-> TSelf
            "setComponent"          => T<int>?index * T<float>?value ^-> TSelf
            "getComponent"          => T<int>?index ^-> T<float>
            "clone"                 => Unit ^-> TSelf
            "copy"                  => Vector2?v ^-> TSelf
            "add"                   => Vector2?v ^-> TSelf
            "addScalar"             => T<float>?s ^-> TSelf
            "addVectors"            => Vector2?a * Vector2?b ^-> TSelf
            "addScaledVector"       => Vector2?v * T<float>?s ^-> TSelf
            "sub"                   => Vector2?v ^-> TSelf
            "subScalar"             => T<float>?s ^-> TSelf
            "subVectors"            => Vector2?a * Vector2?b ^-> TSelf
            "multiply"              => Vector2?v ^-> TSelf
            "multiplyScalar"        => T<float>?s ^-> TSelf
            "divide"                => Vector2?v ^-> TSelf
            "divideScalar"          => T<float>?s ^-> TSelf
            "min"                   => Vector2?v ^-> TSelf
            "max"                   => Vector2?v ^-> TSelf
            "clamp"                 => Vector2?min * Vector2?max ^-> TSelf
            "clampScalar"           => T<float>?min * T<float>?max ^-> TSelf
            "clampLength"           => T<float>?min * T<float>?max ^-> TSelf
            "floor"                 => Unit ^-> TSelf
            "ceil"                  => Unit ^-> TSelf
            "round"                 => Unit ^-> TSelf
            "roundToZero"           => Unit ^-> TSelf
            "negate"                => Unit ^-> TSelf
            "dot"                   => Vector2?v ^-> T<float>
            "cross"                 => Vector2?v ^-> T<float>
            "lengthSq"              => Unit ^-> T<float>
            "length"                => Unit ^-> T<float>
            "manhattanLength"       => Unit ^-> T<float>
            "normalize"             => Unit ^-> TSelf
            "angle"                 => Unit ^-> T<float>
            "angleTo"               => Vector2?v ^-> T<float>
            "distanceTo"            => Vector2?v ^-> T<float>
            "distanceToSquared"     => Vector2?v ^-> T<float>
            "manhattanDistanceTo"   => Vector2?v ^-> T<float>
            "setLength"             => T<float>?length ^-> TSelf
            "lerp"                  => Vector2?v * T<float>?alpha ^-> TSelf
            "lerpVectors"           => Vector2?v1 * Vector2?v2 * T<float>?alpha ^-> TSelf
            "equals"                => Vector2?v ^-> T<bool>
            "fromArray"             => (!| T<float>)?array * !? T<int>?offset ^-> TSelf
            "toArray"               => !? (!| T<float>)?array * !? T<int>?offset ^-> !| T<float>
            "fromBufferAttribute"   => BufferAttribute?attribute * T<int>?index ^-> TSelf
            "rotateAround"          => Vector2?center * T<float>?angle ^-> TSelf
            "random"                => Unit ^-> TSelf
        ]
        |> ignore

    Vector3
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>

            "set"                     => T<float>?x * T<float>?y * !? T<float>?z ^-> TSelf
            "setScalar"               => T<float>?scalar ^-> TSelf
            "setX"                    => T<float>?x ^-> TSelf
            "setY"                    => T<float>?y ^-> TSelf
            "setZ"                    => T<float>?z ^-> TSelf
            "setComponent"            => T<int>?index * T<float>?value ^-> TSelf
            "getComponent"            => T<int>?index ^-> T<float>
            "clone"                   => Unit ^-> TSelf
            "copy"                    => Vector3?v ^-> TSelf
            "add"                     => Vector3?v ^-> TSelf
            "addScalar"               => T<float>?s ^-> TSelf
            "addVectors"              => Vector3?a * Vector3?b ^-> TSelf
            "addScaledVector"         => Vector3?v * T<float>?s ^-> TSelf
            "sub"                     => Vector3?v ^-> TSelf
            "subScalar"               => T<float>?s ^-> TSelf
            "subVectors"              => Vector3?a * Vector3?b ^-> TSelf
            "multiply"                => Vector3?v ^-> TSelf
            "multiplyScalar"          => T<float>?s ^-> TSelf
            "multiplyVectors"         => Vector3?a * Vector3?b ^-> TSelf
            "applyEuler"              => Euler?euler ^-> TSelf
            "applyAxisAngle"          => Vector3?axis * T<float>?angle ^-> TSelf
            "applyNormalMatrix"       => Matrix3?m ^-> TSelf
            "applyMatrix3"            => Matrix3?m ^-> TSelf
            "applyMatrix4"            => Matrix4?m ^-> TSelf
            "applyQuaternion"         => Quaternion?q ^-> TSelf
            "project"                 => Camera?camera ^-> TSelf
            "unproject"               => Camera?camera ^-> TSelf
            "transformDirection"      => Matrix4?m ^-> TSelf
            "divide"                  => Vector3?v ^-> TSelf
            "divideScalar"            => T<float>?s ^-> TSelf
            "min"                     => Vector3?v ^-> TSelf
            "max"                     => Vector3?v ^-> TSelf
            "clamp"                   => Vector3?min * Vector3?max ^-> TSelf
            "clampScalar"             => T<float>?min * T<float>?max ^-> TSelf
            "clampLength"             => T<float>?min * T<float>?max ^-> TSelf
            "floor"                   => Unit ^-> TSelf
            "ceil"                    => Unit ^-> TSelf
            "round"                   => Unit ^-> TSelf
            "roundToZero"             => Unit ^-> TSelf
            "negate"                  => Unit ^-> TSelf
            "dot"                     => Vector3?v ^-> T<float>
            "lengthSq"                => Unit ^-> T<float>
            "length"                  => Unit ^-> T<float>
            "manhattanLength"         => Unit ^-> T<float>
            "normalize"               => Unit ^-> TSelf
            "setLength"               => T<float>?l ^-> TSelf
            "lerp"                    => Vector3?v * T<float>?alpha ^-> TSelf
            "lerpVectors"             => Vector3?v1 * Vector3?v2 * T<float>?alpha ^-> TSelf
            "cross"                   => Vector3?v ^-> TSelf
            "crossVectors"            => Vector3?a * Vector3?b ^-> TSelf
            "projectOnVector"         => Vector3?v ^-> TSelf
            "projectOnPlane"           => Vector3?planeNormal ^-> TSelf
            "reflect"                 => Vector3?normal ^-> TSelf
            "angleTo"                 => Vector3?v ^-> T<float>
            "distanceTo"              => Vector3?v ^-> T<float>
            "distanceToSquared"       => Vector3?v ^-> T<float>
            "manhattanDistanceTo"     => Vector3?v ^-> T<float>
            "setFromSpherical"        => Spherical?s ^-> TSelf
            "setFromSphericalCoords"  => T<float>?r * T<float>?phi * T<float>?theta ^-> TSelf
            "setFromMatrixPosition"   => Matrix4?m ^-> TSelf
            "setFromMatrixScale"      => Matrix4?m ^-> TSelf
            "setFromMatrixColumn"     => Matrix4?matrix * T<int>?index ^-> TSelf
            "setFromEuler"            => Euler?e ^-> TSelf
            "equals"                  => Vector3?v ^-> T<bool>
            "fromArray"               => (!| T<float>)?array * !? T<int>?offset ^-> TSelf
            "toArray"                 => !? (!| T<float>)?array * !? T<int>?offset ^-> !| T<float>
            "fromBufferAttribute"     => BufferAttribute?attribute * T<int>?index ^-> TSelf
            "random"                  => Unit ^-> TSelf
            "randomDirection"         => Unit ^-> TSelf
        ]
        |> ignore

    Vector4
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<float>?w)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>
            "w" =@ T<float>
            "width" =@ T<float>
            "height" =@ T<float>

            "set"                            => T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> TSelf
            "setScalar"                      => T<float>?scalar ^-> TSelf
            "setX"                           => T<float>?x ^-> TSelf
            "setY"                           => T<float>?y ^-> TSelf
            "setZ"                           => T<float>?z ^-> TSelf
            "setW"                           => T<float>?w ^-> TSelf
            "setComponent"                   => T<int>?index * T<float>?value ^-> TSelf
            "getComponent"                   => T<int>?index ^-> T<float>
            "clone"                          => Unit ^-> TSelf
            "copy"                           => Vector4?v ^-> TSelf
            "add"                            => Vector4?v ^-> TSelf
            "addScalar"                      => T<float>?s ^-> TSelf
            "addVectors"                     => Vector4?a * Vector4?b ^-> TSelf
            "addScaledVector"                => Vector4?v * T<float>?s ^-> TSelf
            "sub"                            => Vector4?v ^-> TSelf
            "subScalar"                      => T<float>?s ^-> TSelf
            "subVectors"                     => Vector4?a * Vector4?b ^-> TSelf
            "multiply"                       => Vector4?v ^-> TSelf
            "multiplyScalar"                 => T<float>?s ^-> TSelf
            "divide"                         => Vector4?v ^-> TSelf
            "divideScalar"                   => T<float>?s ^-> TSelf
            "setAxisAngleFromQuaternion"     => Quaternion?q ^-> TSelf
            "setAxisAngleFromRotationMatrix" => Matrix4?m ^-> TSelf
            "setFromMatrixPosition"          => Matrix4?m ^-> TSelf
            "min"                            => Vector4?v ^-> TSelf
            "max"                            => Vector4?v ^-> TSelf
            "clamp"                          => Vector4?min * Vector4?max ^-> TSelf
            "clampScalar"                    => T<float>?min * T<float>?max ^-> TSelf
            "floor"                          => Unit ^-> TSelf
            "ceil"                           => Unit ^-> TSelf
            "round"                          => Unit ^-> TSelf
            "roundToZero"                    => Unit ^-> TSelf
            "negate"                         => Unit ^-> TSelf
            "dot"                            => Vector4?v ^-> T<float>
            "lengthSq"                       => Unit ^-> T<float>
            "length"                         => Unit ^-> T<float>
            "manhattanLength"                => Unit ^-> T<float>
            "normalize"                      => Unit ^-> TSelf
            "setLength"                      => T<float>?length ^-> TSelf
            "lerp"                           => Vector4?v * T<float>?alpha ^-> TSelf
            "lerpVectors"                    => Vector4?v1 * Vector4?v2 * T<float>?alpha ^-> TSelf
            "equals"                         => Vector4?v ^-> T<bool>
            "fromArray"                      => (!| T<float>)?array * !? T<int>?offset ^-> TSelf
            "toArray"                        => !? (!| T<float>)?array * !? T<int>?offset ^-> !| T<float>
            "fromBufferAttribute"            => BufferAttribute?attribute * T<int>?index ^-> TSelf
            "random"                         => Unit ^-> TSelf
        ]
        |> ignore

    Matrix3
        |+> Static [
            Constructor Unit
            Constructor (T<float>?n11 * T<float>?n12 * T<float>?n13 * T<float>?n21 * T<float>?n22 * T<float>?n23 * T<float>?n31 * T<float>?n32 * T<float>?n33)
        ]
        |+> Instance [
            "elements" =@ !| T<float>

            "set"                  => T<float>?n11 * T<float>?n12 * T<float>?n13 * T<float>?n21 * T<float>?n22 * T<float>?n23 * T<float>?n31 * T<float>?n32 * T<float>?n33 ^-> TSelf
            "identity"             => Unit ^-> TSelf
            "copy"                 => Matrix3?m ^-> TSelf
            "extractBasis"         => Vector3?xAxis * Vector3?yAxis * Vector3?zAxis ^-> TSelf
            "multiply"             => Matrix3?m ^-> TSelf
            "premultiply"          => Matrix3?m ^-> TSelf
            "multiplyMatrices"     => Matrix3?a * Matrix3?b ^-> TSelf
            "multiplyScalar"       => T<float>?s ^-> TSelf
            "determinant"          => Unit ^-> T<float>
            "invert"               => Unit ^-> TSelf
            "transpose"            => Unit ^-> TSelf
            "getNormalMatrix"      => Matrix4?matrix4 ^-> TSelf
            "transposeIntoArray"   => (!| T<float>)?r ^-> TSelf
            "setUvTransform"       => T<float>?tx * T<float>?ty * T<float>?sx * T<float>?sy * T<float>?rotation * T<float>?cx * T<float>?cy ^-> TSelf
            "scale"                => T<float>?sx * T<float>?sy ^-> TSelf
                                      |> ObsoleteWithMessage "Matrix3.scale is deprecated in three.js; use MakeScale."
            "rotate"               => T<float>?theta ^-> TSelf
                                      |> ObsoleteWithMessage "Matrix3.rotate is deprecated in three.js; use MakeRotation."
            "translate"            => T<float>?tx * T<float>?ty ^-> TSelf
                                      |> ObsoleteWithMessage "Matrix3.translate is deprecated in three.js; use MakeTranslation."
            "makeTranslation"      => Vector2?v ^-> TSelf
            "makeRotation"         => T<float>?theta ^-> TSelf
            "makeScale"            => T<float>?x * T<float>?y ^-> TSelf
            "equals"               => Matrix3?matrix ^-> T<bool>
            "fromArray"            => (!| T<float>)?array * !? T<int>?offset ^-> TSelf
            "toArray"              => Unit ^-> !| T<float>
            "clone"                => Unit ^-> TSelf
        ]
        |> ignore

    Matrix4
        |+> Static [
            Constructor Unit
            Constructor (T<float>?n11 * T<float>?n12 * T<float>?n13 * T<float>?n14 * T<float>?n21 * T<float>?n22 * T<float>?n23 * T<float>?n24 * T<float>?n31 * T<float>?n32 * T<float>?n33 * T<float>?n34 * T<float>?n41 * T<float>?n42 * T<float>?n43 * T<float>?n44)
        ]
        |+> Instance [
            "elements" =@ !| T<float>

            "set"                        => T<float>?n11 * T<float>?n12 * T<float>?n13 * T<float>?n14 * T<float>?n21 * T<float>?n22 * T<float>?n23 * T<float>?n24 * T<float>?n31 * T<float>?n32 * T<float>?n33 * T<float>?n34 * T<float>?n41 * T<float>?n42 * T<float>?n43 * T<float>?n44 ^-> TSelf
            "identity"                   => Unit ^-> TSelf
            "clone"                      => Unit ^-> TSelf
            "copy"                       => Matrix4?m ^-> TSelf
            "copyPosition"               => Matrix4?m ^-> TSelf
            "extractBasis"               => Vector3?xAxis * Vector3?yAxis * Vector3?zAxis ^-> TSelf
            "makeBasis"                  => Vector3?xAxis * Vector3?yAxis * Vector3?zAxis ^-> TSelf
            "extractRotation"            => Matrix4?m ^-> TSelf
            "makeRotationFromEuler"      => Euler?euler ^-> TSelf
            "makeRotationFromQuaternion" => Quaternion?q ^-> TSelf
            "lookAt"                     => Vector3?eye * Vector3?target * Vector3?up ^-> TSelf
            "multiply"                   => Matrix4?m ^-> TSelf
            "premultiply"                => Matrix4?m ^-> TSelf
            "multiplyMatrices"           => Matrix4?a * Matrix4?b ^-> TSelf
            "multiplyScalar"             => T<float>?s ^-> TSelf
            "determinant"                => Unit ^-> T<float>
            "transpose"                  => Unit ^-> TSelf
            "setPosition"                => Vector3?v ^-> TSelf
            "invert"                     => Unit ^-> TSelf
            "scale"                      => Vector3?v ^-> TSelf
            "getMaxScaleOnAxis"          => Unit ^-> T<float>
            "makeTranslation"            => Vector3?v ^-> TSelf
            "makeRotationX"              => T<float>?theta ^-> TSelf
            "makeRotationY"              => T<float>?theta ^-> TSelf
            "makeRotationZ"              => T<float>?theta ^-> TSelf
            "makeRotationAxis"           => Vector3?axis * T<float>?angle ^-> TSelf
            "makeScale"                  => T<float>?x * T<float>?y * T<float>?z ^-> TSelf
            "makeShear"                  => T<float>?xy * T<float>?xz * T<float>?yx * T<float>?yz * T<float>?zx * T<float>?zy ^-> TSelf
            "compose"                    => Vector3?position * Quaternion?quaternion * Vector3?scale ^-> TSelf
            "decompose"                  => Vector3?position * Quaternion?quaternion * Vector3?scale ^-> TSelf
            "makePerspective"            => T<float>?left * T<float>?right * T<float>?top * T<float>?bottom * T<float>?near * T<float>?far ^-> TSelf
            "makeOrthographic"           => T<float>?left * T<float>?right * T<float>?top * T<float>?bottom * T<float>?near * T<float>?far ^-> TSelf
            "equals"                     => Matrix4?matrix ^-> T<bool>
            "fromArray"                  => (!| T<float>)?array * !? T<int>?offset ^-> TSelf
            "toArray"                    => Unit ^-> !| T<float>
        ]
        |> ignore

    Quaternion
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<float>?w)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>
            "w" =@ T<float>

            "set"                   => T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> TSelf
            "clone"                 => Unit ^-> TSelf
            "copy"                  => Quaternion?q ^-> TSelf
            "setFromEuler"          => Euler?euler * !? T<bool>?update ^-> TSelf
            "setFromAxisAngle"      => Vector3?axis * T<float>?angle ^-> TSelf
            "setFromRotationMatrix" => Matrix4?m ^-> TSelf
            "setFromUnitVectors"    => Vector3?vFrom * Vector3?vTo ^-> TSelf
            "angleTo"               => Quaternion?q ^-> T<float>
            "rotateTowards"         => Quaternion?q * T<float>?step ^-> TSelf
            "identity"              => Unit ^-> TSelf
            "invert"                => Unit ^-> TSelf
            "conjugate"             => Unit ^-> TSelf
            "dot"                   => Quaternion?v ^-> T<float>
            "lengthSq"              => Unit ^-> T<float>
            "length"                => Unit ^-> T<float>
            "normalize"             => Unit ^-> TSelf
            "multiply"              => Quaternion?q ^-> TSelf
            "premultiply"           => Quaternion?q ^-> TSelf
            "multiplyQuaternions"   => Quaternion?a * Quaternion?b ^-> TSelf
            "slerp"                 => Quaternion?qb * T<float>?t ^-> TSelf
            "slerpQuaternions"      => Quaternion?qa * Quaternion?qb * T<float>?t ^-> TSelf
            "equals"                => Quaternion?v ^-> T<bool>
            "fromArray"             => (!| T<float>)?array * !? T<int>?offset ^-> TSelf
            "toArray"               => Unit ^-> !| T<float>
            "random"                => Unit ^-> TSelf
        ]
        |> ignore

    Euler
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<string>?order)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>
            "order" =@ T<string>

            "set"                   => T<float>?x * T<float>?y * T<float>?z * !? T<string>?order ^-> TSelf
            "clone"                 => Unit ^-> TSelf
            "copy"                  => Euler?euler ^-> TSelf
            "setFromRotationMatrix" => Matrix4?m * !? T<string>?order * !? T<bool>?update ^-> TSelf
            "setFromQuaternion"     => Quaternion?q * !? T<string>?order * !? T<bool>?update ^-> TSelf
            "setFromVector3"        => Vector3?v ^-> TSelf
            "reorder"               => T<string>?newOrder ^-> TSelf
            "equals"                => Euler?euler ^-> T<bool>
            "fromArray"             => (!| T<float>)?array ^-> TSelf
            "toArray"               => Unit ^-> !| T<float>
        ]
        |> ignore

    Color
        |+> Static [
            Constructor (!? ColorRepresentation?color)
            Constructor (T<float>?r * T<float>?g * T<float>?b)
        ]
        |+> Instance [
            "r" =@ T<float>
            "g" =@ T<float>
            "b" =@ T<float>

            "set"                 => ColorRepresentation?value ^-> TSelf
            "setScalar"           => T<float>?scalar ^-> TSelf
            "setHex"              => T<int>?hex ^-> TSelf
            "setRGB"              => T<float>?r * T<float>?g * T<float>?b ^-> TSelf
            "setHSL"              => T<float>?h * T<float>?s * T<float>?l ^-> TSelf
            "setStyle"            => T<string>?style ^-> TSelf
            "setColorName"        => T<string>?style ^-> TSelf
            "clone"               => Unit ^-> TSelf
            "copy"                => Color?color ^-> TSelf
            "convertSRGBToLinear" => Unit ^-> TSelf
            "convertLinearToSRGB" => Unit ^-> TSelf
            "getHex"              => Unit ^-> T<int>
            "getHexString"        => Unit ^-> T<string>
            "getHSL"              => HSL?target ^-> HSL
            "getRGB"              => RGB?target ^-> RGB
            "getStyle"            => Unit ^-> T<string>
            "offsetHSL"           => T<float>?h * T<float>?s * T<float>?l ^-> TSelf
            "add"                 => Color?color ^-> TSelf
            "addColors"           => Color?color1 * Color?color2 ^-> TSelf
            "addScalar"           => T<float>?s ^-> TSelf
            "multiply"            => Color?color ^-> TSelf
            "multiplyScalar"      => T<float>?s ^-> TSelf
            "lerp"                => Color?color * T<float>?alpha ^-> TSelf
            "lerpColors"          => Color?color1 * Color?color2 * T<float>?alpha ^-> TSelf
            "lerpHSL"             => Color?color * T<float>?alpha ^-> TSelf
            "equals"              => Color?color ^-> T<bool>
            "fromArray"           => (!| T<float>)?array * !? T<int>?offset ^-> TSelf
            "toArray"             => !? (!| T<float>)?array * !? T<int>?offset ^-> !| T<float>
        ]
        |> ignore

    Box2
        |+> Static [
            Constructor (!? Vector2?min * !? Vector2?max)
        ]
        |+> Instance [
            "min" =@ Vector2
            "max" =@ Vector2

            "set"                  => Vector2?min * Vector2?max ^-> TSelf
            "setFromPoints"        => (!| Vector2)?points ^-> TSelf
            "setFromCenterAndSize" => Vector2?center * Vector2?size ^-> TSelf
            "clone"                => Unit ^-> TSelf
            "copy"                 => Box2?box ^-> TSelf
            "makeEmpty"            => Unit ^-> TSelf
            "isEmpty"              => Unit ^-> T<bool>
            "getCenter"            => Vector2?target ^-> Vector2
            "getSize"              => Vector2?target ^-> Vector2
            "expandByPoint"        => Vector2?point ^-> TSelf
            "expandByVector"       => Vector2?vector ^-> TSelf
            "expandByScalar"       => T<float>?scalar ^-> TSelf
            "containsPoint"        => Vector2?point ^-> T<bool>
            "containsBox"          => Box2?box ^-> T<bool>
            "getParameter"         => Vector2?point * Vector2?target ^-> Vector2
            "intersectsBox"        => Box2?box ^-> T<bool>
            "clampPoint"           => Vector2?point * Vector2?target ^-> Vector2
            "distanceToPoint"      => Vector2?point ^-> T<float>
            "intersect"            => Box2?box ^-> TSelf
            "union"                => Box2?box ^-> TSelf
            "translate"            => Vector2?offset ^-> TSelf
            "equals"               => Box2?box ^-> T<bool>
        ]
        |> ignore

    Box3
        |+> Static [
            Constructor (!? Vector3?min * !? Vector3?max)
        ]
        |+> Instance [
            "min" =@ Vector3
            "max" =@ Vector3

            "set"                  => Vector3?min * Vector3?max ^-> TSelf
            "setFromArray"         => (!| T<float>)?array ^-> TSelf
            "setFromBufferAttribute" => BufferAttribute?attribute ^-> TSelf
            "setFromPoints"        => (!| Vector3)?points ^-> TSelf
            "setFromCenterAndSize" => Vector3?center * Vector3?size ^-> TSelf
            "setFromObject"        => Object3D?``object`` * !? T<bool>?precise ^-> TSelf
            "clone"                => Unit ^-> TSelf
            "copy"                 => Box3?box ^-> TSelf
            "makeEmpty"            => Unit ^-> TSelf
            "isEmpty"              => Unit ^-> T<bool>
            "getCenter"            => Vector3?target ^-> Vector3
            "getSize"              => Vector3?target ^-> Vector3
            "expandByPoint"        => Vector3?point ^-> TSelf
            "expandByVector"       => Vector3?vector ^-> TSelf
            "expandByScalar"       => T<float>?scalar ^-> TSelf
            "expandByObject"       => Object3D?``object`` * !? T<bool>?precise ^-> TSelf
            "containsPoint"        => Vector3?point ^-> T<bool>
            "containsBox"          => Box3?box ^-> T<bool>
            "getParameter"         => Vector3?point * Vector3?target ^-> Vector3
            "intersectsBox"        => Box3?box ^-> T<bool>
            "intersectsSphere"     => Sphere?sphere ^-> T<bool>
            "intersectsPlane"      => Plane?plane ^-> T<bool>
            "intersectsTriangle"   => Triangle?triangle ^-> T<bool>
            "clampPoint"           => Vector3?point * Vector3?target ^-> Vector3
            "distanceToPoint"      => Vector3?point ^-> T<float>
            "getBoundingSphere"    => Sphere?target ^-> Sphere
            "intersect"            => Box3?box ^-> TSelf
            "union"                => Box3?box ^-> TSelf
            "translate"            => Vector3?offset ^-> TSelf
            "equals"               => Box3?box ^-> T<bool>
        ]
        |> ignore

    Sphere
        |+> Static [
            Constructor (!? Vector3?center * !? T<float>?radius)
        ]
        |+> Instance [
            "center" =@ Vector3
            "radius" =@ T<float>

            "set"              => Vector3?center * T<float>?radius ^-> TSelf
            "setFromPoints"    => (!| Vector3)?points * !? Vector3?optionalCenter ^-> TSelf
            "clone"            => Unit ^-> TSelf
            "copy"             => Sphere?sphere ^-> TSelf
            "expandByPoint"    => Vector3?point ^-> TSelf
            "isEmpty"          => Unit ^-> T<bool>
            "makeEmpty"        => Unit ^-> TSelf
            "containsPoint"    => Vector3?point ^-> T<bool>
            "distanceToPoint"  => Vector3?point ^-> T<float>
            "intersectsSphere" => Sphere?sphere ^-> T<bool>
            "intersectsBox"    => Box3?box ^-> T<bool>
            "intersectsPlane"  => Plane?plane ^-> T<bool>
            "clampPoint"       => Vector3?point * Vector3?target ^-> Vector3
            "getBoundingBox"   => Box3?target ^-> Box3
            "translate"        => Vector3?offset ^-> TSelf
            "equals"           => Sphere?sphere ^-> T<bool>
            "union"            => Sphere?sphere ^-> TSelf
        ]
        |> ignore

    Plane
        |+> Static [
            Constructor (!? Vector3?normal * !? T<float>?constant)
        ]
        |+> Instance [
            "normal" =@ Vector3
            "constant" =@ T<float>

            "set"                         => Vector3?normal * T<float>?constant ^-> TSelf
            "setComponents"               => T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> TSelf
            "setFromNormalAndCoplanarPoint" => Vector3?normal * Vector3?point ^-> TSelf
            "setFromCoplanarPoints"       => Vector3?a * Vector3?b * Vector3?c ^-> TSelf
            "clone"                       => Unit ^-> TSelf
            "copy"                        => Plane?plane ^-> TSelf
            "normalize"                   => Unit ^-> TSelf
            "negate"                      => Unit ^-> TSelf
            "distanceToPoint"             => Vector3?point ^-> T<float>
            "distanceToSphere"            => Sphere?sphere ^-> T<float>
            "projectPoint"                => Vector3?point * Vector3?target ^-> Vector3
            "intersectLine"               => Line3?line * Vector3?target * !? T<bool>?clampToLine ^-> Vector3
            "intersectsLine"              => Line3?line ^-> T<bool>
            "intersectsBox"               => Box3?box ^-> T<bool>
            "intersectsSphere"            => Sphere?sphere ^-> T<bool>
            "coplanarPoint"               => Vector3?target ^-> Vector3
            "applyMatrix4"                => Matrix4?matrix * !? Matrix3?optionalNormalMatrix ^-> TSelf
            "translate"                   => Vector3?offset ^-> TSelf
            "equals"                      => Plane?plane ^-> T<bool>
        ]
        |> ignore

    Ray
        |+> Static [
            Constructor (!? Vector3?origin * !? Vector3?direction)
        ]
        |+> Instance [
            "origin" =@ Vector3
            "direction" =@ Vector3

            "set"                  => Vector3?origin * Vector3?direction ^-> TSelf
            "clone"                => Unit ^-> TSelf
            "copy"                 => Ray?ray ^-> TSelf
            "at"                   => T<float>?t * Vector3?target ^-> Vector3
            "lookAt"               => Vector3?v ^-> TSelf
            "recast"               => T<float>?t ^-> TSelf
            "closestPointToPoint"  => Vector3?point * Vector3?target ^-> Vector3
            "distanceToPoint"      => Vector3?point ^-> T<float>
            "distanceSqToPoint"    => Vector3?point ^-> T<float>
            "distanceSqToSegment"  => Vector3?v0 * Vector3?v1 * !? Vector3?optionalPointOnRay * !? Vector3?optionalPointOnSegment ^-> T<float>
            "intersectSphere"      => Sphere?sphere * Vector3?target ^-> Vector3
            "intersectsSphere"     => Sphere?sphere ^-> T<bool>
            "distanceToPlane"      => Plane?plane ^-> T<float>
            "intersectPlane"       => Plane?plane * Vector3?target ^-> Vector3
            "intersectsPlane"      => Plane?plane ^-> T<bool>
            "intersectBox"         => Box3?box * Vector3?target ^-> Vector3
            "intersectsBox"        => Box3?box ^-> T<bool>
            "intersectTriangle"    => Vector3?a * Vector3?b * Vector3?c * T<bool>?backfaceCulling * Vector3?target ^-> Vector3
            "equals"               => Ray?ray ^-> T<bool>
        ]
        |> ignore

    Line3
        |+> Static [
            Constructor (!? Vector3?start * !? Vector3?``end``)
        ]
        |+> Instance [
            "start" =@ Vector3
            "end" =@ Vector3

            "set"                          => Vector3?start * Vector3?``end`` ^-> TSelf
            "clone"                        => Unit ^-> TSelf
            "copy"                         => Line3?line ^-> TSelf
            "getCenter"                    => Vector3?target ^-> Vector3
            "delta"                        => Vector3?target ^-> Vector3
            "distanceSq"                   => Unit ^-> T<float>
            "distance"                     => Unit ^-> T<float>
            "at"                           => T<float>?t * Vector3?target ^-> Vector3
            "closestPointToPointParameter" => Vector3?point * !? T<bool>?clampToLine ^-> T<float>
            "closestPointToPoint"          => Vector3?point * T<bool>?clampToLine * Vector3?target ^-> Vector3
            "equals"                       => Line3?line ^-> T<bool>
        ]
        |> ignore

    Triangle
        |+> Static [
            Constructor (!? Vector3?a * !? Vector3?b * !? Vector3?c)
            "getNormal"       => Vector3?a * Vector3?b * Vector3?c * Vector3?target ^-> Vector3
            "getBarycoord"    => Vector3?point * Vector3?a * Vector3?b * Vector3?c * Vector3?target ^-> Vector3
            "containsPoint"   => Vector3?point * Vector3?a * Vector3?b * Vector3?c ^-> T<bool>
            "isFrontFacing"   => Vector3?a * Vector3?b * Vector3?c * Vector3?direction ^-> T<bool>
        ]
        |+> Instance [
            "a" =@ Vector3
            "b" =@ Vector3
            "c" =@ Vector3

            "set"                     => Vector3?a * Vector3?b * Vector3?c ^-> TSelf
            "setFromPointsAndIndices" => (!| Vector3)?points * T<int>?i0 * T<int>?i1 * T<int>?i2 ^-> TSelf
            "clone"                   => Unit ^-> TSelf
            "copy"                    => Triangle?triangle ^-> TSelf
            "getArea"                 => Unit ^-> T<float>
            "getMidpoint"             => Vector3?target ^-> Vector3
            "getNormal"               => Vector3?target ^-> Vector3
            "getPlane"                => Plane?target ^-> Plane
            "getBarycoord"            => Vector3?point * Vector3?target ^-> Vector3
            "containsPoint"           => Vector3?point ^-> T<bool>
            "intersectsBox"           => Box3?box ^-> T<bool>
            "isFrontFacing"           => Vector3?direction ^-> T<bool>
            "closestPointToPoint"     => Vector3?point * Vector3?target ^-> Vector3
            "equals"                  => Triangle?triangle ^-> T<bool>
        ]
        |> ignore

    Frustum
        |+> Static [
            Constructor (!? Plane?p0 * !? Plane?p1 * !? Plane?p2 * !? Plane?p3 * !? Plane?p4 * !? Plane?p5)
        ]
        |+> Instance [
            "planes" =@ !| Plane

            "set"                     => Plane?p0 * Plane?p1 * Plane?p2 * Plane?p3 * Plane?p4 * Plane?p5 ^-> TSelf
            "clone"                   => Unit ^-> TSelf
            "copy"                    => Frustum?frustum ^-> TSelf
            "setFromProjectionMatrix" => Matrix4?m ^-> TSelf
            "intersectsObject"        => Object3D?``object`` ^-> T<bool>
            "intersectsSphere"        => Sphere?sphere ^-> T<bool>
            "intersectsBox"           => Box3?box ^-> T<bool>
            "containsPoint"           => Vector3?point ^-> T<bool>
        ]
        |> ignore

    Spherical
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?phi * !? T<float>?theta)
        ]
        |+> Instance [
            "radius" =@ T<float>
            "phi" =@ T<float>
            "theta" =@ T<float>

            "set"                   => T<float>?radius * T<float>?phi * T<float>?theta ^-> TSelf
            "clone"                 => Unit ^-> TSelf
            "copy"                  => Spherical?other ^-> TSelf
            "makeSafe"              => Unit ^-> TSelf
            "setFromCartesianCoords" => T<float>?x * T<float>?y * T<float>?z ^-> TSelf
        ]
        |> ignore

    MathUtils
        |+> Static [
            "generateUUID"    => Unit ^-> T<string>
            "clamp"           => T<float>?value * T<float>?min * T<float>?max ^-> T<float>
            "euclideanModulo" => T<float>?n * T<float>?m ^-> T<float>
            "mapLinear"       => T<float>?x * T<float>?a1 * T<float>?a2 * T<float>?b1 * T<float>?b2 ^-> T<float>
            "inverseLerp"     => T<float>?x * T<float>?y * T<float>?value ^-> T<float>
            "lerp"            => T<float>?x * T<float>?y * T<float>?t ^-> T<float>
            "damp"            => T<float>?x * T<float>?y * T<float>?lambda * T<float>?dt ^-> T<float>
            "pingpong"        => T<float>?x * T<float>?length ^-> T<float>
            "smoothstep"      => T<float>?x * T<float>?min * T<float>?max ^-> T<float>
            "smootherstep"    => T<float>?x * T<float>?min * T<float>?max ^-> T<float>
            "randInt"         => T<int>?low * T<int>?high ^-> T<int>
            "randFloat"       => T<float>?low * T<float>?high ^-> T<float>
            "randFloatSpread" => T<float>?range ^-> T<float>
            "seededRandom"    => T<int>?seed ^-> T<float>
            "degToRad"        => T<float>?degrees ^-> T<float>
            "radToDeg"        => T<float>?radians ^-> T<float>
            "isPowerOfTwo"    => T<int>?value ^-> T<bool>
            "ceilPowerOfTwo"  => T<float>?value ^-> T<float>
            "floorPowerOfTwo" => T<float>?value ^-> T<float>
        ]
        |> ignore

    Clock
        |+> Static [
            Constructor !? T<bool>?autoStart
        ]
        |+> Instance [
            "autoStart"   =@ T<bool>
            "startTime"   =@ T<float>
            "oldTime"     =@ T<float>
            "elapsedTime" =? T<float>
            "running"     =? T<bool>

            "start"          => Unit ^-> Unit
            "stop"           => Unit ^-> Unit
            "getElapsedTime" => Unit ^-> T<float>
            "getDelta"       => Unit ^-> T<float>
        ]
        |> ignore

    Timer
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "connect"      => T<JavaScript.Dom.Document>?document ^-> Unit
            "disconnect"   => Unit ^-> Unit
            "getDelta"     => Unit ^-> T<float>
            "getElapsed"   => Unit ^-> T<float>
            "getTimescale" => Unit ^-> T<float>
            "setTimescale" => T<float>?timescale ^-> TSelf
            "reset"        => Unit ^-> TSelf
            "dispose"      => Unit ^-> Unit
            "update"       => !? T<float>?timestamp ^-> TSelf
        ]
        |> ignore

    Layers
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "mask" =@ T<int>

            "set"        => T<int>?layer ^-> Unit
            "enable"     => T<int>?layer ^-> Unit
            "enableAll"  => Unit ^-> Unit
            "toggle"     => T<int>?layer ^-> Unit
            "disable"    => T<int>?layer ^-> Unit
            "disableAll" => Unit ^-> Unit
            "test"       => Layers?layers ^-> T<bool>
            "isEnabled"  => T<int>?layer ^-> T<bool>
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Core scene graph
    // ------------------------------------------------------------------

    EventDispatcher
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "addEventListener"    => T<string>?``type`` * (ThreeEvent ^-> Unit)?listener ^-> TSelf
            "hasEventListener"    => T<string>?``type`` * (ThreeEvent ^-> Unit)?listener ^-> T<bool>
            "removeEventListener" => T<string>?``type`` * (ThreeEvent ^-> Unit)?listener ^-> TSelf
            "dispatchEvent"       => ThreeEvent?``event`` ^-> TSelf
        ]
        |> ignore

    Object3D
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "id" =? T<int>
            "uuid" =@ T<string>
            "name" =@ T<string>
            "parent" =? Object3D
            "children" =? !| Object3D
            "up" =@ Vector3
            "position" =? Vector3
            "rotation" =? Euler
            "quaternion" =? Quaternion
            "scale" =? Vector3
            "modelViewMatrix" =? Matrix4
            "normalMatrix" =? Matrix3
            "matrix" =@ Matrix4
            "matrixWorld" =@ Matrix4
            "matrixAutoUpdate" =@ T<bool>
            "matrixWorldAutoUpdate" =@ T<bool>
            "matrixWorldNeedsUpdate" =@ T<bool>
            "layers" =? Layers
            "visible" =@ T<bool>
            "castShadow" =@ T<bool>
            "receiveShadow" =@ T<bool>
            "frustumCulled" =@ T<bool>
            "renderOrder" =@ T<int>
            "userData" =@ T<obj>

            "applyMatrix4"                => Matrix4?matrix ^-> Unit
            "applyQuaternion"             => Quaternion?quaternion ^-> TSelf
            "setRotationFromAxisAngle"    => Vector3?axis * T<float>?angle ^-> Unit
            "setRotationFromEuler"        => Euler?euler ^-> Unit
            "setRotationFromMatrix"       => Matrix4?m ^-> Unit
            "setRotationFromQuaternion"   => Quaternion?q ^-> Unit
            "rotateOnAxis"                => Vector3?axis * T<float>?angle ^-> TSelf
            "rotateOnWorldAxis"           => Vector3?axis * T<float>?angle ^-> TSelf
            "rotateX"                     => T<float>?angle ^-> TSelf
            "rotateY"                     => T<float>?angle ^-> TSelf
            "rotateZ"                     => T<float>?angle ^-> TSelf
            "translateOnAxis"             => Vector3?axis * T<float>?distance ^-> TSelf
            "translateX"                  => T<float>?distance ^-> TSelf
            "translateY"                  => T<float>?distance ^-> TSelf
            "translateZ"                  => T<float>?distance ^-> TSelf
            "localToWorld"                => Vector3?vector ^-> Vector3
            "worldToLocal"                => Vector3?vector ^-> Vector3
            "lookAt"                      => Vector3?vector ^-> Unit
            "add"                         => Object3D?``object`` ^-> TSelf
            "remove"                      => Object3D?``object`` ^-> TSelf
            "removeFromParent"            => Unit ^-> TSelf
            "clear"                       => Unit ^-> TSelf
            "attach"                      => Object3D?``object`` ^-> TSelf
            "getObjectById"               => T<int>?id ^-> Object3D
            "getObjectByName"             => T<string>?name ^-> Object3D
            "getWorldPosition"            => Vector3?target ^-> Vector3
            "getWorldQuaternion"          => Quaternion?target ^-> Quaternion
            "getWorldScale"               => Vector3?target ^-> Vector3
            "getWorldDirection"           => Vector3?target ^-> Vector3
            "traverse"                    => (Object3D ^-> Unit)?callback ^-> Unit
            "traverseVisible"             => (Object3D ^-> Unit)?callback ^-> Unit
            "traverseAncestors"           => (Object3D ^-> Unit)?callback ^-> Unit
            "updateMatrix"                => Unit ^-> Unit
            "updateMatrixWorld"           => !? T<bool>?force ^-> Unit
            "updateWorldMatrix"           => T<bool>?updateParents * T<bool>?updateChildren * !? T<bool>?force ^-> Unit
            "clone"                       => !? T<bool>?``recursive`` ^-> TSelf
            "copy"                        => Object3D?``object`` * !? T<bool>?``recursive`` ^-> TSelf
            "dispose"                     => Unit ^-> Unit
        ]
        |> ignore

    Group
        |+> Static [
            Constructor Unit
        ]
        |> ignore

    Scene
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "background" =@ (Color + Texture)
            "environment" =@ Texture
            "fog" =@ (Fog + FogExp2)
            "overrideMaterial" =@ Material
        ]
        |> ignore

    Camera
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "matrixWorldInverse" =? Matrix4
            "projectionMatrix" =? Matrix4

            "lookAt" => Vector3?vector ^-> Unit
        ]
        |> ignore

    PerspectiveCamera
        |+> Static [
            Constructor (!? T<float>?fov * !? T<float>?aspect * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "fov" =@ T<float>
            "aspect" =@ T<float>
            "near" =@ T<float>
            "far" =@ T<float>
            "zoom" =@ T<float>
            "focus" =@ T<float>
            "filmGauge" =@ T<float>
            "filmOffset" =@ T<float>

            "setFocalLength"         => T<float>?focalLength ^-> Unit
            "getFocalLength"         => Unit ^-> T<float>
            "getFilmWidth"           => Unit ^-> T<float>
            "getFilmHeight"          => Unit ^-> T<float>
            "setViewOffset"          => T<float>?fullWidth * T<float>?fullHeight * T<float>?x * T<float>?y * T<float>?width * T<float>?height ^-> Unit
            "clearViewOffset"        => Unit ^-> Unit
            "updateProjectionMatrix" => Unit ^-> Unit
            "clone"                  => Unit ^-> TSelf
        ]
        |> ignore

    OrthographicCamera
        |+> Static [
            Constructor (!? T<float>?left * !? T<float>?right * !? T<float>?top * !? T<float>?bottom * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "left" =@ T<float>
            "right" =@ T<float>
            "top" =@ T<float>
            "bottom" =@ T<float>
            "near" =@ T<float>
            "far" =@ T<float>
            "zoom" =@ T<float>

            "setViewOffset"          => T<float>?fullWidth * T<float>?fullHeight * T<float>?x * T<float>?y * T<float>?width * T<float>?height ^-> Unit
            "clearViewOffset"        => Unit ^-> Unit
            "updateProjectionMatrix" => Unit ^-> Unit
            "clone"                  => Unit ^-> TSelf
        ]
        |> ignore

    BufferAttribute
        |+> Static [
            Constructor (TypedArray?array * T<int>?itemSize * !? T<bool>?normalized)
        ]
        |+> Instance [
            "name" =@ T<string>
            "array" =? TypedArray
            "itemSize" =? T<int>
            "count" =? T<int>
            "normalized" =? T<bool>
            "usage" =@ Usage
            "needsUpdate" =@ T<bool>

            "onUpload"                      => (Unit ^-> Unit)?callback ^-> TSelf
            "setUsage"                      => Usage?usage ^-> TSelf
            "clone"                         => Unit ^-> TSelf
            "copy"                          => BufferAttribute?source ^-> TSelf
            "copyAt"                        => T<int>?index1 * BufferAttribute?attribute * T<int>?index2 ^-> TSelf
            "copyArray"                     => TypedArray?array ^-> TSelf
            "applyNormalMatrix"             => Matrix3?m ^-> TSelf
            "transformDirection"            => Matrix4?m ^-> TSelf
            "set"                           => (!| T<float>)?value * !? T<int>?offset ^-> TSelf
            "getComponent"                  => T<int>?index * T<int>?componentIndex ^-> T<float>
            "setComponent"                  => T<int>?index * T<int>?componentIndex * T<float>?value ^-> Unit
            "getX"                          => T<int>?index ^-> T<float>
            "getY"                          => T<int>?index ^-> T<float>
            "getZ"                          => T<int>?index ^-> T<float>
            "getW"                          => T<int>?index ^-> T<float>
            "setX"                          => T<int>?index * T<float>?x ^-> TSelf
            "setY"                          => T<int>?index * T<float>?y ^-> TSelf
            "setZ"                          => T<int>?index * T<float>?z ^-> TSelf
            "setW"                          => T<int>?index * T<float>?w ^-> TSelf
            "setXY"                         => T<int>?index * T<float>?x * T<float>?y ^-> TSelf
            "setXYZ"                        => T<int>?index * T<float>?x * T<float>?y * T<float>?z ^-> TSelf
            "setXYZW"                       => T<int>?index * T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> TSelf
            "dispose"                       => Unit ^-> Unit
        ]
        |> ignore

    BufferGeometry
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "id" =? T<int>
            "uuid" =@ T<string>
            "name" =@ T<string>
            "index" =@ BufferAttribute
            "attributes" =? BufferAttributes
            "groups" =? !| GeometryGroup
            "boundingBox" =@ Box3
            "boundingSphere" =@ Sphere
            "drawRange" =@ DrawRange
            "morphTargetsRelative" =@ T<bool>
            "userData" =@ T<obj>

            "getIndex"              => Unit ^-> BufferAttribute
            "setIndex"              => !? (BufferAttribute + (!| T<int>))?index ^-> TSelf
            "setAttribute"          => T<string>?name * BufferAttribute?attribute ^-> TSelf
            "getAttribute"          => T<string>?name ^-> BufferAttribute
            "deleteAttribute"       => T<string>?name ^-> TSelf
            "hasAttribute"          => T<string>?name ^-> T<bool>
            "addGroup"              => T<int>?start * T<int>?count * !? T<int>?materialIndex ^-> Unit
            "clearGroups"           => Unit ^-> Unit
            "setDrawRange"          => T<int>?start * T<int>?count ^-> Unit
            "applyMatrix4"          => Matrix4?matrix ^-> TSelf
            "applyQuaternion"       => Quaternion?quaternion ^-> TSelf
            "rotateX"               => T<float>?angle ^-> TSelf
            "rotateY"               => T<float>?angle ^-> TSelf
            "rotateZ"               => T<float>?angle ^-> TSelf
            "translate"             => T<float>?x * T<float>?y * T<float>?z ^-> TSelf
            "scale"                 => T<float>?x * T<float>?y * T<float>?z ^-> TSelf
            "lookAt"                => Vector3?vector ^-> TSelf
            "center"                => Unit ^-> TSelf
            "setFromPoints"         => (!| Vector3)?points ^-> TSelf
            "computeBoundingBox"    => Unit ^-> Unit
            "computeBoundingSphere" => Unit ^-> Unit
            "computeTangents"       => Unit ^-> Unit
            "computeVertexNormals"  => Unit ^-> Unit
            "normalizeNormals"      => Unit ^-> Unit
            "toNonIndexed"          => Unit ^-> TSelf
            "clone"                 => Unit ^-> TSelf
            "copy"                  => BufferGeometry?source ^-> TSelf
            "dispose"               => Unit ^-> Unit
        ]
        |> ignore

    Raycaster
        |+> Static [
            Constructor (!? Vector3?origin * !? Vector3?direction * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "ray" =? Ray
            "near" =@ T<float>
            "far" =@ T<float>
            "camera" =? Camera
            "layers" =@ Layers
            "params" =@ RaycasterParameters

            "set"             => Vector3?origin * Vector3?direction ^-> Unit
            "setFromCamera"   => Vector2?coords * Camera?camera ^-> Unit
            "intersectObject" => Object3D?``object`` * !? T<bool>?``recursive`` ^-> !| Intersection
            "intersectObjects" => (!| Object3D)?objects * !? T<bool>?``recursive`` ^-> !| Intersection
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Textures and loaders
    // ------------------------------------------------------------------

    Texture
        |+> Static [
            Constructor Unit
            Constructor (T<JavaScript.HTMLCanvasElement>?image)
        ]
        |+> Instance [
            "id" =? T<int>
            "uuid" =? T<string>
            "name" =@ T<string>
            "image" =@ T<obj>
            "mapping" =@ TextureMapping
            "channel" =@ T<int>
            "wrapS" =@ Wrapping
            "wrapT" =@ Wrapping
            "magFilter" =@ TextureFilter
            "minFilter" =@ TextureFilter
            "anisotropy" =@ T<int>
            "format" =@ TextureFormat
            "type" =@ TextureType
            "colorSpace" =@ ColorSpace
            "offset" =? Vector2
            "repeat" =? Vector2
            "center" =? Vector2
            "rotation" =@ T<float>
            "matrix" =? Matrix3
            "matrixAutoUpdate" =@ T<bool>
            "generateMipmaps" =@ T<bool>
            "premultiplyAlpha" =@ T<bool>
            "flipY" =@ T<bool>
            "unpackAlignment" =@ T<int>
            "needsUpdate" =@ T<bool>
            "userData" =@ T<obj>

            "clone"       => Unit ^-> TSelf
            "copy"        => Texture?source ^-> TSelf
            "updateMatrix" => Unit ^-> Unit
            "dispose"     => Unit ^-> Unit
        ]
        |> ignore

    CanvasTexture
        |+> Static [
            Constructor (T<JavaScript.HTMLCanvasElement>?canvas)
        ]
        |> ignore

    DataTexture
        |+> Static [
            Constructor (TypedArray?data * T<int>?width * T<int>?height * !? TextureFormat?format * !? TextureType?``type``)
        ]
        |> ignore

    VideoTexture
        |+> Static [
            Constructor (T<JavaScript.HTMLVideoElement>?video)
        ]
        |> ignore

    CubeTexture
        |+> Static [
            Constructor (!? (!| T<JavaScript.HTMLImageElement>)?images)
        ]
        |> ignore

    Loader
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "manager" =? LoadingManager
            "crossOrigin" =@ T<string>
            "path" =@ T<string>
            "resourcePath" =@ T<string>

            "setCrossOrigin"     => T<string>?crossOrigin ^-> TSelf
            "setPath"            => T<string>?path ^-> TSelf
            "setResourcePath"    => T<string>?resourcePath ^-> TSelf
            "setRequestHeader"   => T<string>?name * T<string>?value ^-> TSelf
        ]
        |> ignore

    LoadingManager
        |+> Static [
            Constructor (!? (Unit ^-> Unit)?onLoad * !? (T<string> * T<int> * T<int> ^-> Unit)?onProgress * !? (T<string> ^-> Unit)?onError)
        ]
        |+> Instance [
            "onStart" =@ (T<string> * T<int> * T<int> ^-> Unit)
            "onLoad" =@ (Unit ^-> Unit)
            "onProgress" =@ (T<string> * T<int> * T<int> ^-> Unit)
            "onError" =@ (T<string> ^-> Unit)

            "itemStart"      => T<string>?url ^-> Unit
            "itemEnd"        => T<string>?url ^-> Unit
            "itemError"      => T<string>?url ^-> Unit
            "resolveURL"     => T<string>?url ^-> T<string>
            "setURLModifier" => !? (T<string> ^-> T<string>)?callback ^-> TSelf
        ]
        |> ignore

    TextureLoader
        |+> Static [
            Constructor !? LoadingManager?manager
        ]
        |+> Instance [
            "load" => T<string>?url * !? (Texture ^-> Unit)?onLoad * !? (T<JavaScript.ProgressEvent> ^-> Unit)?onProgress * !? (T<string> ^-> Unit)?onError ^-> Texture
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Materials
    // ------------------------------------------------------------------

    Material
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "name" =@ T<string>
            "side" =@ Side
            "shadowSide" =@ Side
            "opacity" =@ T<float>
            "transparent" =@ T<bool>
            "alphaTest" =@ T<float>
            "alphaHash" =@ T<bool>
            "blending" =@ Blending
            "depthTest" =@ T<bool>
            "depthWrite" =@ T<bool>
            "colorWrite" =@ T<bool>
            "polygonOffset" =@ T<bool>
            "polygonOffsetFactor" =@ T<float>
            "polygonOffsetUnits" =@ T<float>
            "vertexColors" =@ T<bool>
            "dithering" =@ T<bool>
            "toneMapped" =@ T<bool>
            "visible" =@ T<bool>
            "premultipliedAlpha" =@ T<bool>
            "needsUpdate" =@ T<bool>
            "userData" =@ T<obj>

            "setValues" => MaterialParameters?values ^-> Unit
            "clone"     => Unit ^-> TSelf
            "dispose"   => Unit ^-> Unit
        ]
        |> ignore

    MeshBasicMaterial
        |+> Static [
            Constructor !? MeshBasicMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "map" =@ Texture
            "lightMap" =@ Texture
            "lightMapIntensity" =@ T<float>
            "aoMap" =@ Texture
            "aoMapIntensity" =@ T<float>
            "specularMap" =@ Texture
            "alphaMap" =@ Texture
            "envMap" =@ Texture
            "combine" =@ T<int>
            "reflectivity" =@ T<float>
            "refractionRatio" =@ T<float>
            "wireframe" =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "wireframeLinecap" =@ T<string>
            "wireframeLinejoin" =@ T<string>
            "fog" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    MeshStandardMaterial
        |+> Static [
            Constructor !? MeshStandardMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "roughness" =@ T<float>
            "metalness" =@ T<float>
            "map" =@ Texture
            "lightMap" =@ Texture
            "lightMapIntensity" =@ T<float>
            "aoMap" =@ Texture
            "aoMapIntensity" =@ T<float>
            "emissive" =@ Color
            "emissiveIntensity" =@ T<float>
            "emissiveMap" =@ Texture
            "bumpMap" =@ Texture
            "bumpScale" =@ T<float>
            "normalMap" =@ Texture
            "normalScale" =@ Vector2
            "displacementMap" =@ Texture
            "displacementScale" =@ T<float>
            "displacementBias" =@ T<float>
            "roughnessMap" =@ Texture
            "metalnessMap" =@ Texture
            "alphaMap" =@ Texture
            "envMap" =@ Texture
            "envMapIntensity" =@ T<float>
            "wireframe" =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "flatShading" =@ T<bool>
            "fog" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    MeshPhysicalMaterial
        |+> Static [
            Constructor !? MeshPhysicalMaterialParameters?parameters
        ]
        |+> Instance [
            "clearcoat" =@ T<float>
            "clearcoatMap" =@ Texture
            "clearcoatRoughness" =@ T<float>
            "clearcoatRoughnessMap" =@ Texture
            "clearcoatNormalMap" =@ Texture
            "clearcoatNormalScale" =@ Vector2
            "ior" =@ T<float>
            "sheen" =@ T<float>
            "sheenColor" =@ Color
            "sheenRoughness" =@ T<float>
            "transmission" =@ T<float>
            "transmissionMap" =@ Texture
            "thickness" =@ T<float>
            "thicknessMap" =@ Texture
            "attenuationDistance" =@ T<float>
            "attenuationColor" =@ Color
            "specularIntensity" =@ T<float>
            "specularColor" =@ Color
            "iridescence" =@ T<float>
            "iridescenceIOR" =@ T<float>
            "iridescenceThicknessMinimum" =@ T<float>
            "iridescenceThicknessMaximum" =@ T<float>
            "anisotropy" =@ T<float>
            "anisotropyRotation" =@ T<float>
            "dispersion" =@ T<float>
        ]
        |> ignore

    MeshPhongMaterial
        |+> Static [
            Constructor !? MeshPhongMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "specular" =@ Color
            "shininess" =@ T<float>
            "emissive" =@ Color
            "emissiveIntensity" =@ T<float>
            "map" =@ Texture
            "lightMap" =@ Texture
            "aoMap" =@ Texture
            "emissiveMap" =@ Texture
            "bumpMap" =@ Texture
            "bumpScale" =@ T<float>
            "normalMap" =@ Texture
            "normalScale" =@ Vector2
            "specularMap" =@ Texture
            "alphaMap" =@ Texture
            "envMap" =@ Texture
            "envMapIntensity" =@ T<float>
            "combine" =@ T<int>
            "reflectivity" =@ T<float>
            "refractionRatio" =@ T<float>
            "wireframe" =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "flatShading" =@ T<bool>
            "fog" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    MeshLambertMaterial
        |+> Static [
            Constructor !? MeshLambertMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "emissive" =@ Color
            "emissiveIntensity" =@ T<float>
            "map" =@ Texture
            "lightMap" =@ Texture
            "aoMap" =@ Texture
            "emissiveMap" =@ Texture
            "alphaMap" =@ Texture
            "envMap" =@ Texture
            "combine" =@ T<int>
            "reflectivity" =@ T<float>
            "refractionRatio" =@ T<float>
            "wireframe" =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "flatShading" =@ T<bool>
            "fog" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    MeshNormalMaterial
        |+> Static [
            Constructor !? MeshNormalMaterialParameters?parameters
        ]
        |+> Instance [
            "bumpMap" =@ Texture
            "bumpScale" =@ T<float>
            "normalMap" =@ Texture
            "normalScale" =@ Vector2
            "displacementMap" =@ Texture
            "displacementScale" =@ T<float>
            "displacementBias" =@ T<float>
            "wireframe" =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "flatShading" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    MeshDepthMaterial
        |+> Static [
            Constructor !? MeshDepthMaterialParameters?parameters
        ]
        |+> Instance [
            "map" =@ Texture
            "alphaMap" =@ Texture
            "displacementMap" =@ Texture
            "displacementScale" =@ T<float>
            "displacementBias" =@ T<float>
            "wireframe" =@ T<bool>
            "wireframeLinewidth" =@ T<float>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    MeshToonMaterial
        |+> Static [
            Constructor !? MeshToonMaterialParameters?parameters
        ]
        |+> Instance [
            "gradientMap" =@ Texture
            "normalScale" =@ Vector2
        ]
        |> ignore

    MeshMatcapMaterial
        |+> Static [
            Constructor !? MeshMatcapMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "matcap" =@ Texture
            "map" =@ Texture
            "alphaMap" =@ Texture
            "normalMap" =@ Texture
            "normalScale" =@ Vector2
            "flatShading" =@ T<bool>
            "fog" =@ T<bool>
        ]
        |> ignore

    PointsMaterial
        |+> Static [
            Constructor !? PointsMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "map" =@ Texture
            "alphaMap" =@ Texture
            "size" =@ T<float>
            "sizeAttenuation" =@ T<bool>
            "fog" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    LineBasicMaterial
        |+> Static [
            Constructor !? LineBasicMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "map" =@ Texture
            "linewidth" =@ T<float>
            "linecap" =@ T<string>
            "linejoin" =@ T<string>
            "fog" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    LineDashedMaterial
        |+> Static [
            Constructor !? LineDashedMaterialParameters?parameters
        ]
        |+> Instance [
            "scale" =@ T<float>
            "dashSize" =@ T<float>
            "gapSize" =@ T<float>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    SpriteMaterial
        |+> Static [
            Constructor !? SpriteMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "map" =@ Texture
            "alphaMap" =@ Texture
            "rotation" =@ T<float>
            "sizeAttenuation" =@ T<bool>
            "fog" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    ShadowMaterial
        |+> Static [
            Constructor !? ShadowMaterialParameters?parameters
        ]
        |+> Instance [
            "color" =@ Color
            "fog" =@ T<bool>
        ]
        |> ignore

    ShaderMaterial
        |+> Static [
            Constructor !? ShaderMaterialParameters?parameters
        ]
        |+> Instance [
            "vertexShader" =@ T<string>
            "fragmentShader" =@ T<string>
            "uniforms" =@ T<obj>
            "defines" =@ T<obj>
            "linewidth" =@ T<float>
            "wireframe" =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "fog" =@ T<bool>
            "lights" =@ T<bool>
            "clipping" =@ T<bool>
            "glslVersion" =@ T<string>
            "uniformsNeedUpdate" =@ T<bool>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Renderable objects
    // ------------------------------------------------------------------

    Mesh
        |+> Static [
            Constructor (!? BufferGeometry?geometry * !? Material?material)
        ]
        |+> Instance [
            "geometry" =@ BufferGeometry
            "material" =@ Material

            "updateMorphTargets" => Unit ^-> Unit
            "clone"              => !? T<bool>?``recursive`` ^-> TSelf
        ]
        |> ignore

    Line
        |+> Static [
            Constructor (!? BufferGeometry?geometry * !? Material?material)
        ]
        |+> Instance [
            "geometry" =@ BufferGeometry
            "material" =@ Material

            "computeLineDistances" => Unit ^-> TSelf
            "clone"                => !? T<bool>?``recursive`` ^-> TSelf
        ]
        |> ignore

    LineSegments
        |+> Static [
            Constructor (!? BufferGeometry?geometry * !? Material?material)
        ]
        |> ignore

    LineLoop
        |+> Static [
            Constructor (!? BufferGeometry?geometry * !? Material?material)
        ]
        |> ignore

    Points
        |+> Static [
            Constructor (!? BufferGeometry?geometry * !? Material?material)
        ]
        |+> Instance [
            "geometry" =@ BufferGeometry
            "material" =@ Material

            "updateMorphTargets" => Unit ^-> Unit
            "clone"              => !? T<bool>?``recursive`` ^-> TSelf
        ]
        |> ignore

    Sprite
        |+> Static [
            Constructor (!? SpriteMaterial?material)
        ]
        |+> Instance [
            "geometry" =@ BufferGeometry
            "material" =@ SpriteMaterial
            "center" =@ Vector2

            "clone" => !? T<bool>?``recursive`` ^-> TSelf
        ]
        |> ignore

    LOD
        |+> Static [
            Constructor Unit
        ]
        |+> Instance [
            "levels" =? !| LODLevel
            "autoUpdate" =@ T<bool>

            "addLevel"             => Object3D?``object`` * !? T<float>?distance ^-> TSelf
            "getObjectForDistance" => T<float>?distance ^-> Object3D
            "update"               => Camera?camera ^-> Unit
            "clone"                => !? T<bool>?``recursive`` ^-> TSelf
        ]
        |> ignore

    InstancedMesh
        |+> Static [
            Constructor (!? BufferGeometry?geometry * !? Material?material * !? T<int>?count)
        ]
        |+> Instance [
            "count" =@ T<int>
            "instanceMatrix" =? BufferAttribute
            "instanceColor" =@ BufferAttribute

            "setMatrixAt" => T<int>?index * Matrix4?matrix ^-> Unit
            "getMatrixAt" => T<int>?index * Matrix4?matrix ^-> Unit
            "setColorAt"  => T<int>?index * Color?color ^-> Unit
            "getColorAt"  => T<int>?index * Color?color ^-> Unit
            "computeBoundingBox"    => Unit ^-> Unit
            "computeBoundingSphere" => Unit ^-> Unit
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Lights
    // ------------------------------------------------------------------

    Light
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?intensity)
        ]
        |+> Instance [
            "color" =@ Color
            "intensity" =@ T<float>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    LightShadow
        |+> Instance [
            "bias" =@ T<float>
            "normalBias" =@ T<float>
            "radius" =@ T<float>
            "blurSamples" =@ T<float>
            "mapSize" =? Vector2
            "map" =? Texture
            "autoUpdate" =@ T<bool>
            "needsUpdate" =@ T<bool>
        ]
        |> ignore

    DirectionalLightShadow
        |+> Instance [
            "camera" =@ OrthographicCamera
        ]
        |> ignore

    PointLightShadow
        |+> Instance [
            "camera" =@ PerspectiveCamera
        ]
        |> ignore

    SpotLightShadow
        |+> Instance [
            "camera" =@ PerspectiveCamera
        ]
        |> ignore

    AmbientLight
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?intensity)
        ]
        |> ignore

    DirectionalLight
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?intensity)
        ]
        |+> Instance [
            "target" =@ Object3D
            "shadow" =@ DirectionalLightShadow
        ]
        |> ignore

    HemisphereLight
        |+> Static [
            Constructor (!? ColorRepresentation?skyColor * !? ColorRepresentation?groundColor * !? T<float>?intensity)
        ]
        |+> Instance [
            "groundColor" =@ Color
        ]
        |> ignore

    PointLight
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?intensity * !? T<float>?distance * !? T<float>?decay)
        ]
        |+> Instance [
            "distance" =@ T<float>
            "decay" =@ T<float>
            "shadow" =@ PointLightShadow
        ]
        |> ignore

    SpotLight
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?intensity * !? T<float>?distance * !? T<float>?angle * !? T<float>?penumbra * !? T<float>?decay)
        ]
        |+> Instance [
            "target" =@ Object3D
            "distance" =@ T<float>
            "angle" =@ T<float>
            "penumbra" =@ T<float>
            "decay" =@ T<float>
            "shadow" =@ SpotLightShadow
        ]
        |> ignore

    RectAreaLight
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?intensity * !? T<float>?width * !? T<float>?height)
        ]
        |+> Instance [
            "width" =@ T<float>
            "height" =@ T<float>
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Fog
    // ------------------------------------------------------------------

    Fog
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "name" =@ T<string>
            "color" =@ Color
            "near" =@ T<float>
            "far" =@ T<float>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    FogExp2
        |+> Static [
            Constructor (!? ColorRepresentation?color * !? T<float>?density)
        ]
        |+> Instance [
            "name" =@ T<string>
            "color" =@ Color
            "density" =@ T<float>

            "clone" => Unit ^-> TSelf
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Renderer
    // ------------------------------------------------------------------

    WebGLShadowMap
        |+> Instance [
            "enabled" =@ T<bool>
            "autoUpdate" =@ T<bool>
            "needsUpdate" =@ T<bool>
            "type" =@ ShadowMapType
        ]
        |> ignore

    WebGLMemoryInfo
        |+> Instance [
            "geometries" =? T<int>
            "textures" =? T<int>
        ]
        |> ignore

    WebGLRenderInfo
        |+> Instance [
            "calls" =? T<int>
            "frame" =? T<int>
            "lines" =? T<int>
            "points" =? T<int>
            "triangles" =? T<int>
        ]
        |> ignore

    WebGLInfo
        |+> Instance [
            "autoReset" =@ T<bool>
            "memory" =? WebGLMemoryInfo
            "render" =? WebGLRenderInfo
            "programs" =? !| T<obj>

            "reset" => Unit ^-> Unit
        ]
        |> ignore

    WebGLRenderer
        |+> Static [
            Constructor !? WebGLRendererOptions?parameters
        ]
        |+> Instance [
            "domElement" =? T<JavaScript.HTMLCanvasElement>
            "autoClear" =@ T<bool>
            "autoClearColor" =@ T<bool>
            "autoClearDepth" =@ T<bool>
            "autoClearStencil" =@ T<bool>
            "sortObjects" =@ T<bool>
            "clippingPlanes" =@ !| Plane
            "localClippingEnabled" =@ T<bool>
            "outputColorSpace" =@ ColorSpace
            "toneMapping" =@ ToneMapping
            "toneMappingExposure" =@ T<float>
            "info" =? WebGLInfo
            "shadowMap" =? WebGLShadowMap
            "capabilities" =? WebGLCapabilities
            "xr" =? T<obj>

            "getContext"            => Unit ^-> T<JavaScript.WebGL.RenderingContext>
            "getPixelRatio"         => Unit ^-> T<float>
            "setPixelRatio"         => T<float>?value ^-> Unit
            "getSize"               => Vector2?target ^-> Vector2
            "setSize"               => T<int>?width * T<int>?height * !? T<bool>?updateStyle ^-> Unit
            "getDrawingBufferSize"  => Vector2?target ^-> Vector2
            "setDrawingBufferSize"  => T<int>?width * T<int>?height * T<float>?pixelRatio ^-> Unit
            "getViewport"           => Vector4?target ^-> Vector4
            "setViewport"           => T<int>?x * T<int>?y * T<int>?width * T<int>?height ^-> Unit
            "getScissor"            => Vector4?target ^-> Vector4
            "setScissor"            => T<int>?x * T<int>?y * T<int>?width * T<int>?height ^-> Unit
            "setScissorTest"        => T<bool>?enable ^-> Unit
            "getClearColor"         => Color?target ^-> Color
            "setClearColor"         => ColorRepresentation?color * !? T<float>?alpha ^-> Unit
            "getClearAlpha"         => Unit ^-> T<float>
            "setClearAlpha"         => T<float>?alpha ^-> Unit
            "clear"                 => !? T<bool>?color * !? T<bool>?depth * !? T<bool>?stencil ^-> Unit
            "clearColor"            => Unit ^-> Unit
            "clearDepth"            => Unit ^-> Unit
            "clearStencil"          => Unit ^-> Unit
            "render"                => Object3D?scene * Camera?camera ^-> Unit
            "setAnimationLoop"      => (T<float> ^-> Unit)?callback ^-> Unit
            "compile"               => Object3D?scene * Camera?camera ^-> T<obj>
            "setRenderTarget"       => WebGLRenderTarget?renderTarget * !? T<int>?activeCubeFace * !? T<int>?activeMipmapLevel ^-> Unit
            "getRenderTarget"       => Unit ^-> WebGLRenderTarget
            "forceContextLoss"      => Unit ^-> Unit
            "forceContextRestore"   => Unit ^-> Unit
            "dispose"               => Unit ^-> Unit
        ]
        |> ignore

    WebGLRenderTarget
        |+> Static [
            Constructor (!? T<int>?width * !? T<int>?height * !? RenderTargetOptions?options)
        ]
        |+> Instance [
            "width" =@ T<int>
            "height" =@ T<int>
            "texture" =? Texture
            "depthBuffer" =@ T<bool>
            "stencilBuffer" =@ T<bool>
            "samples" =@ T<int>

            "setSize" => T<int>?width * T<int>?height ^-> Unit
            "clone"   => Unit ^-> TSelf
            "dispose" => Unit ^-> Unit
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Animation
    // ------------------------------------------------------------------

    KeyframeTrack
        |+> Static [
            Constructor (T<string>?name * (!| T<float>)?times * (!| T<float>)?values * !? InterpolationMode?interpolation)
        ]
        |+> Instance [
            "name" =@ T<string>
            "times" =? T<JavaScript.Float32Array>
            "values" =? T<JavaScript.Float32Array>
            "getValueSize" => Unit ^-> T<int>
        ]
        |> ignore

    NumberKeyframeTrack
        |+> Static [
            Constructor (T<string>?name * (!| T<float>)?times * (!| T<float>)?values * !? InterpolationMode?interpolation)
        ]
        |> ignore

    VectorKeyframeTrack
        |+> Static [
            Constructor (T<string>?name * (!| T<float>)?times * (!| T<float>)?values * !? InterpolationMode?interpolation)
        ]
        |> ignore

    ColorKeyframeTrack
        |+> Static [
            Constructor (T<string>?name * (!| T<float>)?times * (!| T<float>)?values * !? InterpolationMode?interpolation)
        ]
        |> ignore

    QuaternionKeyframeTrack
        |+> Static [
            Constructor (T<string>?name * (!| T<float>)?times * (!| T<float>)?values * !? InterpolationMode?interpolation)
        ]
        |> ignore

    BooleanKeyframeTrack
        |+> Static [
            Constructor (T<string>?name * (!| T<float>)?times * (!| T<float>)?values)
        ]
        |> ignore

    StringKeyframeTrack
        |+> Static [
            Constructor (T<string>?name * (!| T<float>)?times * (!| T<float>)?values * !? InterpolationMode?interpolation)
        ]
        |> ignore

    AnimationClip
        |+> Static [
            Constructor (!? T<string>?name * !? T<float>?duration * !? (!| KeyframeTrack)?tracks * !? LoopMode?blendMode)
        ]
        |+> Instance [
            "name" =@ T<string>
            "duration" =@ T<float>
            "tracks" =@ !| KeyframeTrack
            "uuid" =? T<string>
            "blendMode" =@ LoopMode
            "userData" =@ T<obj>

            "resetDuration" => Unit ^-> TSelf
            "trim"          => Unit ^-> TSelf
            "clone"         => Unit ^-> TSelf
        ]
        |> ignore

    AnimationAction
        |+> Instance [
            "enabled" =@ T<bool>
            "paused" =@ T<bool>
            "time" =@ T<float>
            "timeScale" =@ T<float>
            "weight" =@ T<float>
            "repetitions" =@ T<int>
            "loop" =@ LoopMode
            "clampWhenFinished" =@ T<bool>
            "zeroSlopeAtStart" =@ T<bool>
            "zeroSlopeAtEnd" =@ T<bool>

            "play"                => Unit ^-> TSelf
            "stop"                => Unit ^-> TSelf
            "reset"               => Unit ^-> TSelf
            "isRunning"           => Unit ^-> T<bool>
            "isScheduled"         => Unit ^-> T<bool>
            "startAt"             => T<float>?time ^-> TSelf
            "setLoop"             => LoopMode?mode * T<int>?repetitions ^-> TSelf
            "setEffectiveWeight"  => T<float>?weight ^-> TSelf
            "getEffectiveWeight"  => Unit ^-> T<float>
            "fadeIn"              => T<float>?duration ^-> TSelf
            "fadeOut"             => T<float>?duration ^-> TSelf
            "crossFadeFrom"       => AnimationAction?fadeOutAction * T<float>?duration * !? T<bool>?warp ^-> TSelf
            "crossFadeTo"         => AnimationAction?fadeInAction * T<float>?duration * !? T<bool>?warp ^-> TSelf
            "setEffectiveTimeScale" => T<float>?timeScale ^-> TSelf
            "getEffectiveTimeScale" => Unit ^-> T<float>
            "setDuration"         => T<float>?duration ^-> TSelf
            "syncWith"            => AnimationAction?action ^-> TSelf
            "halt"                => T<float>?duration ^-> TSelf
            "getMixer"            => Unit ^-> AnimationMixer
            "getClip"             => Unit ^-> AnimationClip
        ]
        |> ignore

    AnimationMixer
        |+> Static [
            Constructor Object3D?root
        ]
        |+> Instance [
            "time" =@ T<float>
            "timeScale" =@ T<float>

            "clipAction"      => AnimationClip?clip * !? Object3D?optionalRoot * !? LoopMode?blendMode ^-> AnimationAction
            "existingAction"  => AnimationClip?clip * !? Object3D?optionalRoot ^-> AnimationAction
            "stopAllAction"   => Unit ^-> TSelf
            "update"          => T<float>?deltaTime ^-> TSelf
            "setTime"         => T<float>?time ^-> TSelf
            "getRoot"         => Unit ^-> Object3D
            "uncacheClip"     => AnimationClip?clip ^-> Unit
            "uncacheRoot"     => Object3D?root ^-> Unit
            "uncacheAction"   => AnimationClip?clip * !? Object3D?optionalRoot ^-> Unit
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Curves
    // ------------------------------------------------------------------

    Curve
        |+> Instance [
            "arcLengthDivisions" =@ T<int>
            "needsUpdate" =@ T<bool>

            "getPoint"        => T<float>?t * !? Vector3?optionalTarget ^-> Vector3
            "getPointAt"      => T<float>?u * !? Vector3?optionalTarget ^-> Vector3
            "getPoints"       => !? T<int>?divisions ^-> !| Vector3
            "getSpacedPoints" => !? T<int>?divisions ^-> !| Vector3
            "getLength"       => Unit ^-> T<float>
            "getLengths"      => !? T<int>?divisions ^-> !| T<float>
            "updateArcLengths" => Unit ^-> Unit
            "getTangent"      => T<float>?t * !? Vector3?optionalTarget ^-> Vector3
            "getTangentAt"    => T<float>?u * !? Vector3?optionalTarget ^-> Vector3
            "computeFrenetFrames" => T<int>?segments * T<bool>?closed ^-> FrenetFrames
            "clone"           => Unit ^-> TSelf
        ]
        |> ignore

    CatmullRomCurve3
        |+> Static [
            Constructor (!? (!| Vector3)?points * !? T<bool>?closed * !? T<string>?curveType * !? T<float>?tension)
        ]
        |+> Instance [
            "points" =@ !| Vector3
            "closed" =@ T<bool>
            "curveType" =@ T<string>
            "tension" =@ T<float>
        ]
        |> ignore

    LineCurve3
        |+> Static [
            Constructor (!? Vector3?v1 * !? Vector3?v2)
        ]
        |+> Instance [
            "v1" =@ Vector3
            "v2" =@ Vector3
        ]
        |> ignore

    QuadraticBezierCurve3
        |+> Static [
            Constructor (!? Vector3?v0 * !? Vector3?v1 * !? Vector3?v2)
        ]
        |+> Instance [
            "v0" =@ Vector3
            "v1" =@ Vector3
            "v2" =@ Vector3
        ]
        |> ignore

    CubicBezierCurve3
        |+> Static [
            Constructor (!? Vector3?v0 * !? Vector3?v1 * !? Vector3?v2 * !? Vector3?v3)
        ]
        |+> Instance [
            "v0" =@ Vector3
            "v1" =@ Vector3
            "v2" =@ Vector3
            "v3" =@ Vector3
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Geometries
    // ------------------------------------------------------------------

    BoxGeometry
        |+> Static [
            Constructor (!? T<float>?width * !? T<float>?height * !? T<float>?depth * !? T<int>?widthSegments * !? T<int>?heightSegments * !? T<int>?depthSegments)
        ]
        |> ignore

    SphereGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?widthSegments * !? T<int>?heightSegments * !? T<float>?phiStart * !? T<float>?phiLength * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |> ignore

    PlaneGeometry
        |+> Static [
            Constructor (!? T<float>?width * !? T<float>?height * !? T<int>?widthSegments * !? T<int>?heightSegments)
        ]
        |> ignore

    CircleGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?segments * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |> ignore

    CylinderGeometry
        |+> Static [
            Constructor (!? T<float>?radiusTop * !? T<float>?radiusBottom * !? T<float>?height * !? T<int>?radialSegments * !? T<int>?heightSegments * !? T<bool>?openEnded * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |> ignore

    ConeGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?height * !? T<int>?radialSegments * !? T<int>?heightSegments * !? T<bool>?openEnded * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |> ignore

    TorusGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?tube * !? T<int>?radialSegments * !? T<int>?tubularSegments * !? T<float>?arc * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |> ignore

    TorusKnotGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?tube * !? T<int>?tubularSegments * !? T<int>?radialSegments * !? T<int>?p * !? T<int>?q)
        ]
        |> ignore

    RingGeometry
        |+> Static [
            Constructor (!? T<float>?innerRadius * !? T<float>?outerRadius * !? T<int>?thetaSegments * !? T<int>?phiSegments * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |> ignore

    CapsuleGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?height * !? T<int>?capSegments * !? T<int>?radialSegments * !? T<int>?heightSegments)
        ]
        |> ignore

    PolyhedronGeometry
        |+> Static [
            Constructor (!? (!| T<float>)?vertices * !? (!| T<float>)?indices * !? T<float>?radius * !? T<int>?detail)
        ]
        |> ignore

    IcosahedronGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?detail)
        ]
        |> ignore

    OctahedronGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?detail)
        ]
        |> ignore

    TetrahedronGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?detail)
        ]
        |> ignore

    DodecahedronGeometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?detail)
        ]
        |> ignore

    EdgesGeometry
        |+> Static [
            Constructor (!? BufferGeometry?geometry * !? T<float>?thresholdAngle)
        ]
        |> ignore

    WireframeGeometry
        |+> Static [
            Constructor (!? BufferGeometry?geometry)
        ]
        |> ignore

    LatheGeometry
        |+> Static [
            Constructor (!? (!| Vector2)?points * !? T<int>?segments * !? T<float>?phiStart * !? T<float>?phiLength)
        ]
        |> ignore

    TubeGeometry
        |+> Static [
            Constructor (!? Curve?path * !? T<int>?tubularSegments * !? T<float>?radius * !? T<int>?radialSegments * !? T<bool>?closed)
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Helpers
    // ------------------------------------------------------------------

    AxesHelper
        |+> Static [
            Constructor !? T<float>?size
        ]
        |+> Instance [
            "setColors" => ColorRepresentation?xAxisColor * ColorRepresentation?yAxisColor * ColorRepresentation?zAxisColor ^-> TSelf
        ]
        |> ignore

    GridHelper
        |+> Static [
            Constructor (!? T<float>?size * !? T<int>?divisions * !? ColorRepresentation?color1 * !? ColorRepresentation?color2)
        ]
        |> ignore

    PolarGridHelper
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?sectors * !? T<int>?rings * !? T<int>?divisions * !? ColorRepresentation?color1 * !? ColorRepresentation?color2)
        ]
        |> ignore

    ArrowHelper
        |+> Static [
            Constructor (!? Vector3?dir * !? Vector3?origin * !? T<float>?length * !? ColorRepresentation?color * !? T<float>?headLength * !? T<float>?headWidth)
        ]
        |+> Instance [
            "setDirection" => Vector3?dir ^-> TSelf
            "setLength"    => T<float>?length * !? T<float>?headLength * !? T<float>?headWidth ^-> TSelf
            "setColor"     => ColorRepresentation?color ^-> TSelf
        ]
        |> ignore

    Box3Helper
        |+> Static [
            Constructor (Box3?box * !? ColorRepresentation?color)
        ]
        |+> Instance [
            "box" =@ Box3
        ]
        |> ignore

    BoxHelper
        |+> Static [
            Constructor (!? Object3D?``object`` * !? ColorRepresentation?color)
        ]
        |+> Instance [
            "object" =@ Object3D

            "update"        => Unit ^-> Unit
            "setFromObject" => Object3D?``object`` ^-> TSelf
        ]
        |> ignore

    CameraHelper
        |+> Static [
            Constructor Camera?camera
        ]
        |+> Instance [
            "camera" =@ Camera

            "update" => Unit ^-> Unit
        ]
        |> ignore

    DirectionalLightHelper
        |+> Static [
            Constructor (DirectionalLight?light * !? T<float>?size * !? ColorRepresentation?color)
        ]
        |+> Instance [
            "light" =@ DirectionalLight

            "update" => Unit ^-> Unit
        ]
        |> ignore

    PointLightHelper
        |+> Static [
            Constructor (PointLight?light * !? T<float>?sphereSize * !? ColorRepresentation?color)
        ]
        |+> Instance [
            "light" =@ PointLight

            "update" => Unit ^-> Unit
        ]
        |> ignore

    SpotLightHelper
        |+> Static [
            Constructor (SpotLight?light * !? ColorRepresentation?color)
        ]
        |+> Instance [
            "light" =@ SpotLight

            "update" => Unit ^-> Unit
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Controls (addons)
    // ------------------------------------------------------------------

    /// The `keys` map of `OrbitControls` (the four arrow keys by default).
    let OrbitControlsKeys =
        Pattern.Config "OrbitControlsKeys" {
            Required = []
            Optional = [
                "LEFT", T<string>
                "UP", T<string>
                "RIGHT", T<string>
                "BOTTOM", T<string>
            ]
        }

    Controls
        |+> Instance [
            "object" =? Camera
            "domElement" =@ T<JavaScript.HTMLElement>
            "enabled" =@ T<bool>

            "connect"    => T<JavaScript.HTMLElement>?element ^-> Unit
            "disconnect" => Unit ^-> Unit
            "dispose"    => Unit ^-> Unit
        ]
        |> ignore

    OrbitControls
        |+> Static [
            Constructor (Camera?``object`` * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |+> Instance [
            "target" =@ Vector3
            "cursor" =? Vector3
            "minDistance" =@ T<float>
            "maxDistance" =@ T<float>
            "minTargetRadius" =@ T<float>
            "maxTargetRadius" =@ T<float>
            "minZoom" =@ T<float>
            "maxZoom" =@ T<float>
            "minPolarAngle" =@ T<float>
            "maxPolarAngle" =@ T<float>
            "minAzimuthAngle" =@ T<float>
            "maxAzimuthAngle" =@ T<float>
            "enableDamping" =@ T<bool>
            "dampingFactor" =@ T<float>
            "enableZoom" =@ T<bool>
            "zoomSpeed" =@ T<float>
            "enableRotate" =@ T<bool>
            "rotateSpeed" =@ T<float>
            "keyRotateSpeed" =@ T<float>
            "enablePan" =@ T<bool>
            "panSpeed" =@ T<float>
            "screenSpacePanning" =@ T<bool>
            "keyPanSpeed" =@ T<float>
            "zoomToCursor" =@ T<bool>
            "autoRotate" =@ T<bool>
            "autoRotateSpeed" =@ T<float>
            "cursorStyle" =@ T<string>
            "keys" =@ OrbitControlsKeys
            "mouseButtons" =@ MouseButtons
            "touches" =@ Touches

            "getPolarAngle"        => Unit ^-> T<float>
            "getAzimuthalAngle"    => Unit ^-> T<float>
            "getDistance"          => Unit ^-> T<float>
            "listenToKeyEvents"    => T<JavaScript.HTMLElement>?element ^-> Unit
            "stopListenToKeyEvents" => Unit ^-> Unit
            "saveState"            => Unit ^-> Unit
            "reset"                => Unit ^-> Unit
            "pan"                  => T<float>?deltaX * T<float>?deltaY ^-> Unit
            "dollyIn"              => T<float>?dollyScale ^-> Unit
            "dollyOut"             => T<float>?dollyScale ^-> Unit
            "rotateLeft"           => T<float>?angle ^-> Unit
            "rotateUp"             => T<float>?angle ^-> Unit
            "update"               => !? T<float>?deltaTime ^-> T<bool>

            "addEventListener" => OrbitControlsEvent?``event`` * (ThreeEvent ^-> Unit)?listener ^-> TSelf
        ]
        |> ignore

    // MapControls is OrbitControls with map-style mouse/touch bindings.
    MapControls
        |+> Static [
            Constructor (Camera?``object`` * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |> ignore

    TrackballControls
        |+> Static [
            Constructor (Camera?camera * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |+> Instance [
            "screen" =@ TrackballControlsScreen
            "rotateSpeed" =@ T<float>
            "zoomSpeed" =@ T<float>
            "panSpeed" =@ T<float>
            "rollSpeed" =@ T<float>
            "noRotate" =@ T<bool>
            "noZoom" =@ T<bool>
            "noPan" =@ T<bool>
            "multiTouchRoll" =@ T<bool>
            "staticMoving" =@ T<bool>
            "dynamicDampingFactor" =@ T<float>
            "minDistance" =@ T<float>
            "maxDistance" =@ T<float>
            "minZoom" =@ T<float>
            "maxZoom" =@ T<float>
            "keys" =@ !| T<string>
            "mouseButtons" =@ MouseButtons
            "target" =@ Vector3

            "handleResize" => Unit ^-> Unit
            "update"       => Unit ^-> Unit
            "reset"        => Unit ^-> Unit

            "addEventListener" => TrackballControlsEvent?``event`` * (ThreeEvent ^-> Unit)?listener ^-> TSelf
        ]
        |> ignore

    FlyControls
        |+> Static [
            Constructor (Camera?``object`` * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |+> Instance [
            "movementSpeed" =@ T<float>
            "rollSpeed" =@ T<float>
            "dragToLook" =@ T<bool>
            "autoForward" =@ T<bool>

            "update" => T<float>?delta ^-> Unit

            "addEventListener" => FlyControlsEvent?``event`` * (ThreeEvent ^-> Unit)?listener ^-> TSelf
        ]
        |> ignore

    FirstPersonControls
        |+> Static [
            Constructor (Camera?``object`` * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |+> Instance [
            "movementSpeed" =@ T<float>
            "lookSpeed" =@ T<float>
            "dampingFactor" =@ T<float>
            "lookVertical" =@ T<bool>
            "autoForward" =@ T<bool>
            "heightSpeed" =@ T<bool>
            "heightCoef" =@ T<float>
            "heightMin" =@ T<float>
            "heightMax" =@ T<float>
            "constrainVertical" =@ T<bool>
            "verticalMin" =@ T<float>
            "verticalMax" =@ T<float>
            "mouseDragOn" =? T<bool>

            "update" => T<float>?delta ^-> Unit
            "lookAt" => Vector3?vector ^-> TSelf
            "lookAt" => T<float>?x * T<float>?y * T<float>?z ^-> TSelf
            "handleResize" => Unit ^-> Unit
        ]
        |> ignore

    PointerLockControls
        |+> Static [
            Constructor (Camera?camera * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |+> Instance [
            "isLocked" =? T<bool>
            "minPolarAngle" =@ T<float>
            "maxPolarAngle" =@ T<float>
            "pointerSpeed" =@ T<float>

            "getDirection" => Vector3?v ^-> Vector3
            "moveForward"  => T<float>?distance ^-> Unit
            "moveRight"    => T<float>?distance ^-> Unit
            "lock"         => !? T<bool>?unadjustedMovement ^-> Unit
            "unlock"       => Unit ^-> Unit

            "addEventListener" => PointerLockControlsEvent?``event`` * (ThreeEvent ^-> Unit)?listener ^-> TSelf
        ]
        |> ignore

    ArcballControls
        |+> Static [
            Constructor (Camera?camera * !? T<JavaScript.HTMLElement>?domElement * !? Scene?scene)
        ]
        |+> Instance [
            "scene" =@ !? Scene
            "radiusFactor" =@ T<float>
            "focusAnimationTime" =@ T<float>
            "adjustNearFar" =@ T<bool>
            "scaleFactor" =@ T<float>
            "dampingFactor" =@ T<float>
            "wMax" =@ T<float>
            "enableAnimations" =@ T<bool>
            "enableFocus" =@ T<bool>
            "enableGrid" =@ T<bool>
            "cursorZoom" =@ T<bool>
            "rotateSpeed" =@ T<float>
            "enablePan" =@ T<bool>
            "enableRotate" =@ T<bool>
            "enableZoom" =@ T<bool>
            "minDistance" =@ T<float>
            "maxDistance" =@ T<float>
            "minZoom" =@ T<float>
            "maxZoom" =@ T<float>

            "setMouseAction"    => T<string>?operation * (T<int> + T<string>)?mouse * !? T<string>?key ^-> T<bool>
            "unsetMouseAction"  => (T<int> + T<string>)?mouse * !? T<string>?key ^-> T<bool>
            "activateGizmos"    => T<bool>?isActive ^-> Unit
            "setCamera"         => Camera?camera ^-> Unit
            "setGizmosVisible"  => T<bool>?value ^-> Unit
            "setTbRadius"       => T<float>?value ^-> Unit
            "reset"             => Unit ^-> Unit
            "copyState"         => Unit ^-> Unit
            "pasteState"        => Unit ^-> Unit
            "saveState"         => Unit ^-> Unit
            "getRaycaster"      => Unit ^-> Raycaster
            "update"            => Unit ^-> Unit

            "addEventListener" => ArcballControlsEvent?``event`` * (ThreeEvent ^-> Unit)?listener ^-> TSelf
        ]
        |> ignore

    DragControls
        |+> Static [
            Constructor ((!| Object3D)?objects * Camera?camera * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |+> Instance [
            "objects" =@ !| Object3D
            "recursive" =@ T<bool>
            "transformGroup" =@ T<bool>
            "rotateSpeed" =@ T<float>
            "raycaster" =? Raycaster
            "mouseButtons" =@ MouseButtons
            "touches" =@ Touches

            "addEventListener" => DragControlsEvent?``event`` * (DragControlsObjectEvent ^-> Unit)?listener ^-> TSelf
        ]
        |> ignore

    TransformControls
        |+> Static [
            Constructor (Camera?camera * !? T<JavaScript.HTMLElement>?domElement)
        ]
        |+> Instance [
            "camera" =@ Camera
            "axis" =? T<string>
            "mode" =@ T<string>
            "translationSnap" =@ !? T<float>
            "rotationSnap" =@ !? T<float>
            "scaleSnap" =@ !? T<float>
            "space" =@ T<string>
            "size" =@ T<float>
            "viewport" =@ !? Vector4
            "dragging" =? T<bool>
            "showX" =@ T<bool>
            "showY" =@ T<bool>
            "showZ" =@ T<bool>
            "showXY" =@ T<bool>
            "showYZ" =@ T<bool>
            "showXZ" =@ T<bool>
            "showXYZE" =@ T<bool>
            "showE" =@ T<bool>
            "minX" =@ T<float>
            "maxX" =@ T<float>
            "minY" =@ T<float>
            "maxY" =@ T<float>
            "minZ" =@ T<float>
            "maxZ" =@ T<float>

            "getHelper"          => Unit ^-> Object3D
            "attach"             => Object3D?``object`` ^-> TSelf
            "detach"             => Unit ^-> TSelf
            "reset"              => Unit ^-> Unit
            "getRaycaster"       => Unit ^-> Raycaster
            "getMode"            => Unit ^-> T<string>
            "setMode"            => T<string>?mode ^-> Unit
            "setTranslationSnap" => !? T<float>?translationSnap ^-> Unit
            "setRotationSnap"    => !? T<float>?rotationSnap ^-> Unit
            "setScaleSnap"       => !? T<float>?scaleSnap ^-> Unit
            "setSize"            => T<float>?size ^-> Unit
            "setSpace"           => T<string>?space ^-> Unit
            "setColors"          => ColorRepresentation?xAxis * ColorRepresentation?yAxis * ColorRepresentation?zAxis * ColorRepresentation?active ^-> Unit

            "addEventListener" => TransformControlsEvent?``event`` * (TransformControlsEventPayload ^-> Unit)?listener ^-> TSelf
        ]
        |> ignore

    // ------------------------------------------------------------------
    // Assembly
    // ------------------------------------------------------------------

    let Assembly =
        Assembly [
            Namespace "WebSharper.ThreeJs" [
                // Enumerations and shared shapes
                Side
                Blending
                ShadowMapType
                ToneMapping
                Wrapping
                TextureFilter
                TextureMapping
                TextureFormat
                TextureType
                Usage
                LoopMode
                InterpolationMode
                ColorSpace
                MouseButton
                TouchAction
                WebGLPowerPreference
                ShaderPrecision
                HSL
                RGB
                ThreeEvent
                MouseButtons
                Touches
                TrackballControlsScreen
                OrbitControlsEvent
                TrackballControlsEvent
                ArcballControlsEvent
                FlyControlsEvent
                PointerLockControlsEvent
                DragControlsEvent
                TransformControlsEvent
                DragControlsObjectEvent
                TransformControlsEventPayload
                Face
                Intersection
                RaycasterThreshold
                RaycasterParameters
                BufferAttributes
                GeometryGroup
                LODLevel
                FrenetFrames
                WebGLCapabilities
                DrawRange
                RenderTargetOptions
                WebGLRendererOptions
                MaterialParameters
                MeshBasicMaterialParameters
                MeshStandardMaterialParameters
                MeshPhysicalMaterialParameters
                MeshPhongMaterialParameters
                MeshLambertMaterialParameters
                MeshNormalMaterialParameters
                MeshDepthMaterialParameters
                MeshToonMaterialParameters
                MeshMatcapMaterialParameters
                PointsMaterialParameters
                LineBasicMaterialParameters
                LineDashedMaterialParameters
                SpriteMaterialParameters
                ShadowMaterialParameters
                ShaderMaterialParameters
                // Math
                Vector2
                Vector3
                Vector4
                Matrix3
                Matrix4
                Quaternion
                Euler
                Color
                Box2
                Box3
                Sphere
                Plane
                Ray
                Line3
                Triangle
                Frustum
                Spherical
                MathUtils
                Clock
                Timer
                Layers
                // Core scene graph
                EventDispatcher
                Object3D
                Group
                Scene
                Camera
                PerspectiveCamera
                OrthographicCamera
                BufferAttribute
                BufferGeometry
                Raycaster
                // Textures and loaders
                Texture
                CanvasTexture
                DataTexture
                VideoTexture
                CubeTexture
                Loader
                LoadingManager
                TextureLoader
                // Materials
                Material
                MeshBasicMaterial
                MeshStandardMaterial
                MeshPhysicalMaterial
                MeshPhongMaterial
                MeshLambertMaterial
                MeshNormalMaterial
                MeshDepthMaterial
                MeshToonMaterial
                MeshMatcapMaterial
                PointsMaterial
                LineBasicMaterial
                LineDashedMaterial
                SpriteMaterial
                ShadowMaterial
                ShaderMaterial
                // Objects
                Mesh
                Line
                LineSegments
                LineLoop
                Points
                Sprite
                LOD
                InstancedMesh
                // Lights
                Light
                LightShadow
                DirectionalLightShadow
                PointLightShadow
                SpotLightShadow
                AmbientLight
                DirectionalLight
                HemisphereLight
                PointLight
                SpotLight
                RectAreaLight
                // Fog
                Fog
                FogExp2
                // Renderer
                WebGLShadowMap
                WebGLMemoryInfo
                WebGLRenderInfo
                WebGLInfo
                WebGLRenderer
                WebGLRenderTarget
                // Animation
                KeyframeTrack
                NumberKeyframeTrack
                VectorKeyframeTrack
                ColorKeyframeTrack
                QuaternionKeyframeTrack
                BooleanKeyframeTrack
                StringKeyframeTrack
                AnimationClip
                AnimationAction
                AnimationMixer
                // Curves
                Curve
                CatmullRomCurve3
                LineCurve3
                QuadraticBezierCurve3
                CubicBezierCurve3
                // Geometries
                BoxGeometry
                SphereGeometry
                PlaneGeometry
                CircleGeometry
                CylinderGeometry
                ConeGeometry
                TorusGeometry
                TorusKnotGeometry
                RingGeometry
                CapsuleGeometry
                PolyhedronGeometry
                IcosahedronGeometry
                OctahedronGeometry
                TetrahedronGeometry
                DodecahedronGeometry
                EdgesGeometry
                WireframeGeometry
                LatheGeometry
                TubeGeometry
                // Helpers
                AxesHelper
                GridHelper
                PolarGridHelper
                ArrowHelper
                Box3Helper
                BoxHelper
                CameraHelper
                DirectionalLightHelper
                PointLightHelper
                SpotLightHelper
                // Controls addons
                Controls
                OrbitControls
                MapControls
                TrackballControls
                FlyControls
                FirstPersonControls
                PointerLockControls
                ArcballControls
                DragControls
                TransformControls
                OrbitControlsKeys
            ]
        ]

[<Sealed>]
type Extension () =
    interface IExtension with
        member x.Assembly = Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
