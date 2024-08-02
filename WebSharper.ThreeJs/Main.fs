// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
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
namespace ThreeJs

open WebSharper.InterfaceGenerator

module Definition =
    let THREE =
        Class "THREE"
        |> WithSourceName "THREE"
        
    let TSFunctionType = T<obj -> unit>
    
    let Float32Array = T<WebSharper.JavaScript.Float32Array>
    let TypedArray =
        T<WebSharper.JavaScript.Float32Array> +
        T<WebSharper.JavaScript.Float64Array> +
        T<WebSharper.JavaScript.Int16Array> +
        T<WebSharper.JavaScript.Int32Array> +
        T<WebSharper.JavaScript.Int8Array> +
        T<WebSharper.JavaScript.Uint16Array> +
        T<WebSharper.JavaScript.Uint32Array> +
        T<WebSharper.JavaScript.Uint8Array> +
        T<WebSharper.JavaScript.Uint8ClampedArray>
    let TSNumberKeyword = T<float>
    let TSBooleanKeyword = T<bool>
    let TSStringKeyword = T<string>
    let TSArrayType = !| T<obj>
    let TSThisType = TSelf
    let TSAnyKeyword = T<obj>
    let TSUnionType = T<obj>
    let TSVoidKeyword = T<unit>
    let TSTypeLiteral = T<obj>
    let TSLiteralType = T<obj>

    let ImportFrom g (c: CodeModel.Class) =
        c
        |> Import c.Name ("three" + "/" + g + "/" + c.Name)
        

    let AnimationClip = Class "AnimationClip" |> ImportFrom "animation"
    let AnimationMixer = Class "AnimationMixer" |> ImportFrom "animation"
    let AnimationObjectGroup = Class "AnimationObjectGroup" |> ImportFrom "animation"
    let KeyframeTrack = Class "KeyframeTrack" |> ImportFrom "animation"
    let PropertyBinding = Class "PropertyBinding" |> ImportFrom "animation"
    let PropertyMixer = Class "PropertyMixer" |> ImportFrom "animation"
    let BooleanKeyframeTrack = Class "BooleanKeyframeTrack" |> ImportFrom "animation/tracks"
    let ColorKeyframeTrack = Class "ColorKeyframeTrack" |> ImportFrom "animation/tracks"
    let NumberKeyframeTrack = Class "NumberKeyframeTrack" |> ImportFrom "animation/tracks"
    let QuaternionKeyframeTrack = Class "QuaternionKeyframeTrack" |> ImportFrom "animation/tracks"
    let StringKeyframeTrack = Class "StringKeyframeTrack" |> ImportFrom "animation/tracks"
    let VectorKeyframeTrack = Class "VectorKeyframeTrack" |> ImportFrom "animation/tracks"
    let Audio = Class "Audio" |> ImportFrom "audio"
    let AudioAnalyser = Class "AudioAnalyser" |> ImportFrom "audio"
    let AudioListener = Class "AudioListener" |> ImportFrom "audio"
    let PositionalAudio = Class "PositionalAudio" |> ImportFrom "audio"
    let ArrayCamera = Class "ArrayCamera" |> ImportFrom "camera"
    let Camera = Class "Camera" |> ImportFrom "audio"
    let CubeCamera = Class "CubeCamera" |> ImportFrom "audio"
    let OrthographicCamera = Class "OrthographicCamera" |> ImportFrom "audio"
    let PerspectiveCamera = Class "PerspectiveCamera" |> ImportFrom "audio"
    let StereoCamera = Class "StereoCamera" |> ImportFrom "audio"
    let BufferGeometry = Class "BufferGeometry" |> ImportFrom "core"
    let Clock = Class "Clock" |> ImportFrom "core"
    let EventDispatcher = Class "EventDispatcher" |> ImportFrom "core"
    let InstancedBufferAttribute = Class "InstancedBufferAttribute" |> ImportFrom "core"
    let InstancedBufferGeometry = Class "InstancedBufferGeometry" |> ImportFrom "core"
    let InstancedInterleavedBuffer = Class "InstancedInterleavedBuffer" |> ImportFrom "core"
    let Layers = Class "Layers" |> ImportFrom "core"
    let Object3D = Class "Object3D" |> ImportFrom "core"
    let Raycaster = Class "Raycaster" |> ImportFrom "core"
    let Uniform = Class "Uniform" |> ImportFrom "core"
    let PMREMGenerator = Class "PMREMGenerator" |> ImportFrom "extras"
    let Curve = Class "Curve" |> ImportFrom "extras/core"
    let CurvePath = Class "CurvePath" |> ImportFrom "extras/core"
    let Path = Class "Path" |> ImportFrom "extras/core"
    let Shape = Class "Shape" |> ImportFrom "extras/core"
    let ShapePath = Class "ShapePath" |> ImportFrom "extras/core"
    let BoxGeometry = Class "BoxGeometry" |> ImportFrom "geometries"
    let CapsuleGeometry = Class "CapsuleGeometry" |> ImportFrom "geometries"
    let CircleGeometry = Class "CircleGeometry" |> ImportFrom "geometries"
    let ConeGeometry = Class "ConeGeometry" |> ImportFrom "geometries"
    let CylinderGeometry = Class "CylinderGeometry" |> ImportFrom "geometries"
    let DodecahedronGeometry = Class "DodecahedronGeometry" |> ImportFrom "geometries"
    let EdgesGeometry = Class "EdgesGeometry" |> ImportFrom "geometries"
    let ExtrudeGeometry = Class "ExtrudeGeometry" |> ImportFrom "geometries"
    let IcosahedronGeometry = Class "IcosahedronGeometry" |> ImportFrom "geometries"
    let LatheGeometry = Class "LatheGeometry" |> ImportFrom "geometries"
    let OctahedronGeometry = Class "OctahedronGeometry" |> ImportFrom "geometries"
    let PlaneGeometry = Class "PlaneGeometry" |> ImportFrom "geometries"
    let PolyhedronGeometry = Class "PolyhedronGeometry" |> ImportFrom "geometries"
    let RingGeometry = Class "RingGeometry" |> ImportFrom "geometries"
    let ShapeGeometry = Class "ShapeGeometry" |> ImportFrom "geometries"
    let SphereGeometry = Class "SphereGeometry" |> ImportFrom "geometries"
    let TetrahedronGeometry = Class "TetrahedronGeometry" |> ImportFrom "geometries"
    let TorusGeometry = Class "TorusGeometry" |> ImportFrom "geometries"
    let TorusKnotGeometry = Class "TorusKnotGeometry" |> ImportFrom "geometries"
    let TubeGeometry = Class "TubeGeometry" |> ImportFrom "geometries"
    let WireframeGeometry = Class "WireframeGeometry" |> ImportFrom "geometries"
    let ArrowHelper = Class "ArrowHelper" |> ImportFrom "helpers"
    let AxesHelper = Class "AxesHelper" |> ImportFrom "helpers" 
    let Box3Helper = Class "Box3Helper" |> ImportFrom "helpers"
    let BoxHelper = Class "BoxHelper" |> ImportFrom "helpers"
    let CameraHelper = Class "CameraHelper" |> ImportFrom "helpers"
    let DirectionalLightHelper = Class "DirectionalLightHelper" |> ImportFrom "helpers"
    let GridHelper = Class "GridHelper" |> ImportFrom "helpers"
    let HemisphereLightHelper = Class "HemisphereLightHelper" |> ImportFrom "helpers"
    let PlaneHelper = Class "PlaneHelper" |> ImportFrom "helpers"
    let PointLightHelper = Class "PointLightHelper" |> ImportFrom "helpers"
    let PolarGridHelper = Class "PolarGridHelper" |> ImportFrom "helpers"
    let SpotLightHelper = Class "SpotLightHelper" |> ImportFrom "helpers"
    let AmbientLight = Class "AmbientLight" |> ImportFrom "lights"
    let DirectionalLight = Class "DirectionalLight" |> ImportFrom "lights"
    let DirectionalLightShadow = Class "DirectionalLightShadow" |> ImportFrom "lights"
    let HemisphereLight = Class "HemisphereLight" |> ImportFrom "lights"
    let Light = Class "Light" |> ImportFrom "lights"
    let LightProbe = Class "LightProbe" |> ImportFrom "lights"
    let LightShadow = Class "LightShadow" |> ImportFrom "lights"
    let PointLight = Class "PointLight" |> ImportFrom "lights"
    let RectAreaLight = Class "RectAreaLight" |> ImportFrom "lights"
    let SpotLight = Class "SpotLight" |> ImportFrom "lights"
    let SpotLightShadow = Class "SpotLightShadow" |> ImportFrom "lights"
    let AnimationLoader = Class "AnimationLoader" |> ImportFrom "loaders" 
    let AudioLoader = Class "AudioLoader" |> ImportFrom "loaders" 
    let BufferGeometryLoader = Class "BufferGeometryLoader" |> ImportFrom "loaders" 
    let CompressedTextureLoader = Class "CompressedTextureLoader" |> ImportFrom "loaders" 
    let CubeTextureLoader = Class "CubeTextureLoader" |> ImportFrom "loaders" 
    let DataTextureLoader = Class "DataTextureLoader" |> ImportFrom "loaders" 
    let FileLoader = Class "FileLoader" |> ImportFrom "loaders" 
    let ImageBitmapLoader = Class "ImageBitmapLoader" |> ImportFrom "loaders" 
    let ImageLoader = Class "ImageLoader" |> ImportFrom "loaders" 
    let Loader = Class "Loader" |> ImportFrom "loaders" 
    let MaterialLoader = Class "MaterialLoader" |> ImportFrom "loaders" 
    let ObjectLoader = Class "ObjectLoader" |> ImportFrom "loaders" 
    let TextureLoader = Class "TextureLoader" |> ImportFrom "loaders" 
    let LineBasicMaterial = Class "LineBasicMaterial" |> ImportFrom "materials" 
    let LineDashedMaterial = Class "LineDashedMaterial" |> ImportFrom "materials" 
    let MeshBasicMaterial = Class "MeshBasicMaterial" |> ImportFrom "materials" 
    let MeshDepthMaterial = Class "MeshDepthMaterial" |> ImportFrom "materials" 
    let MeshDistanceMaterial = Class "MeshDistanceMaterial" |> ImportFrom "materials" 
    let MeshLambertMaterial = Class "MeshLambertMaterial" |> ImportFrom "materials" 
    let MeshMatcapMaterial = Class "MeshMatcapMaterial" |> ImportFrom "materials" 
    let MeshNormalMaterial = Class "MeshNormalMaterial" |> ImportFrom "materials" 
    let MeshPhongMaterial = Class "MeshPhongMaterial" |> ImportFrom "materials" 
    let MeshStandardMaterial = Class "MeshStandardMaterial" |> ImportFrom "materials" 
    let MeshToonMaterial = Class "MeshToonMaterial" |> ImportFrom "materials" 
    let PointsMaterial = Class "PointsMaterial" |> ImportFrom "materials" 
    let RawShaderMaterial = Class "RawShaderMaterial" |> ImportFrom "materials" 
    let ShaderMaterial = Class "ShaderMaterial" |> ImportFrom "materials" 
    let ShadowMaterial = Class "ShadowMaterial" |> ImportFrom "materials" 
    let SpriteMaterial = Class "SpriteMaterial" |> ImportFrom "materials" 
    let Box2 = Class "Box2" |> ImportFrom "math" 
    let Box3 = Class "Box3" |> ImportFrom "math"
    let Cylindrical = Class "Cylindrical" |> ImportFrom "math"
    let Euler = Class "Euler" |> ImportFrom "math"
    let Frustum = Class "Frustum" |> ImportFrom "math"
    let Interpolant = Class "Interpolant" |> ImportFrom "math"
    let Line3 = Class "Line3" |> ImportFrom "math"
    let Matrix3 = Class "Matrix3" |> ImportFrom "math"
    let Matrix4 = Class "Matrix4" |> ImportFrom "math"
    let Plane = Class "Plane" |> ImportFrom "math"
    let Quaternion = Class "Quaternion" |> ImportFrom "math"
    let Ray = Class "Ray" |> ImportFrom "math"
    let Sphere = Class "Sphere" |> ImportFrom "math"
    let Spherical = Class "Spherical" |> ImportFrom "math"
    let SphericalHarmonics3 = Class "SphericalHarmonics3" |> ImportFrom "math"
    let Triangle = Class "Triangle" |> ImportFrom "math"
    let Vector2 = Class "Vector2" |> ImportFrom "math"
    let Vector3 = Class "Vector3" |> ImportFrom "math"
    let Vector4 = Class "Vector4" |> ImportFrom "math"
    let CubicInterpolant = Class "CubicInterpolant" |> ImportFrom "math/interpolants"
    let DiscreteInterpolant = Class "DiscreteInterpolant" |> ImportFrom "math/interpolants"
    let LinearInterpolant = Class "LinearInterpolant" |> ImportFrom "math/interpolants"
    let QuaternionLinearInterpolant = Class "QuaternionLinearInterpolant" |> ImportFrom "math/interpolants"
    let Bone = Class "Bone" |> ImportFrom "objects"
    let Group = Class "Group" |> ImportFrom "objects"
    let InstancedMesh = Class "InstancedMesh" |> ImportFrom "objects"
    let Line = Class "Line" |> ImportFrom "objects"
    let LineLoop = Class "LineLoop" |> ImportFrom "objects"
    let LineSegments = Class "LineSegments" |> ImportFrom "objects"
    let LOD = Class "LOD" |> ImportFrom "objects"
    let Mesh = Class "Mesh" |> ImportFrom "objects"
    let Points = Class "Points" |> ImportFrom "objects"
    let Skeleton = Class "Skeleton" |> ImportFrom "objects"
    let SkinnedMesh = Class "SkinnedMesh" |> ImportFrom "objects"
    let Sprite = Class "Sprite" |> ImportFrom "objects"
    let WebGLRenderTarget = Class "WebGLRenderTarget" |> ImportFrom "renderers" 

    let WebGLProgram = Class "WebGLProgram" |> ImportFrom "renderers/webgl" 
    let WebXRManager = Class "WebXRManager" |> ImportFrom "renderers/webgl"
    let Fog = Class "Fog"  |> ImportFrom "scenes"
    let FogExp2 = Class "FogExp2" |> ImportFrom "scenes"
    let Scene = Class "Scene" |> ImportFrom "scenes"
    let CanvasTexture = Class "CanvasTexture" |> ImportFrom "textures"
    let CompressedCubeTexture = Class "CompressedCubeTexture" |> ImportFrom "textures"
    let FramebufferTexture = Class "FramebufferTexture" |> ImportFrom "textures"

    let LoopMode =
        Pattern.EnumInlines "LoopMode"
            [
                "LoopOnce", "2200"
                "LoopRepeat", "2201"
                "LoopPingPong", "2202"
            ]

    let InterpolationMode =
        Pattern.EnumInlines "InterpolationMode"
            [
                "InterpolateDiscrete", "2300"
                "InterpolateLinear", "2301"
                "InterpolateSmooth", "2302"
            ]

    let EndingMode =
        Pattern.EnumInlines "EndingMode"
            [
                "ZeroCurvatureEnding", "2400"
                "ZeroSlopEnding", "2401"
                "WrapAroundEnding", "2402"
            ]

    let AnimationBlendMode =
        Pattern.EnumInlines "AnimationBlendMode"
            [
                "NormalAnimationBlendMode", "2500"
                "AdditiveAnimationBlendMode", "2501"
            ]

    let ColorSpace =
        Pattern.EnumInlines "ColorSpace"
            [
                "NoColorSpace", "''"
                "SRGBColorSpace", "'srgb'"
                "LinearSRGBColorSpace", "'srgb-linear'"
            ]

    let BlendingEquations =
        Pattern.EnumInlines "BlendingEquations"
            [
                "AddEquation", "100"
                "SubtractEquation", "101"
                "ReverseSubtractEquation", "102"
                "MinEquation", "103"
                "MaxEquation", "104"
            ]

    let SourceFactors =
        Pattern.EnumInlines "SourceFactors"
            [
                "ZeroFactor", "200"
                "OneFactor", "201"
                "SrcColorFactor", "202"
                "OneMinusSrcColorFactor", "203"
                "SrcAlphaFactor", "204"
                "OneMinusSrcAlphaFactor", "205"
                "DstAlphaFactor", "206"
                "OneMinusDstAlphaFactor", "207"
                "DstColorFactor", "208"
                "OneMinusDstColorFactor", "209"
                "SrcAlphaSaturateFactor", "210"
                "ConstantColorFactor", "211"
                "OneMinusConstantColorFactor", "212"
                "ConstantAlphaFactor", "213"
                "OneMinusConstantAlphaFactor", "214"
            ]

    let DestinationFactors =
        Pattern.EnumInlines "DestinationFactors"
            [
                "ZeroFactor", "200"
                "OneFactor", "201"
                "SrcColorFactor", "202"
                "OneMinusSrcColorFactor", "203"
                "OneMinusSrcAlphaFactor", "205"
                "DstAlphaFactor", "206"
                "OneMinusDstAlphaFactor", "207"
                "DstColorFactor", "208"
                "OneMinusDstColorFactor", "209"
                "SrcAlphaSaturateFactor", "210"
                "ConstantColorFactor", "211"
                "OneMinusConstantColorFactor", "212"
                "ConstantAlphaFactor", "213"
                "OneMinusConstantAlphaFactor", "214"
            ]

    let GeometryUsage =
        Pattern.EnumInlines "GeometryUsage"
            [
                "StaticDrawUsage", "35044"
                "DynamicDrawUsage", "35048"
                "StreamDrawUsage", "35040"
                "StaticReadUsage", "35045"
                "DynamicReadUsage", "35049"
                "StreamReadUsage", "35041"
                "StaticCopyUsage", "35046"
                "DynamicCopyUsage", "35050"
                "StreamCopyUsage", "35042"
            ]

    let Side =
        Pattern.EnumInlines "Side"
            [
                "FrontSide", "0"
                "BackSide", "1"
                "DoubleSide", "2"
            ]

    let BlendingMode =
        Pattern.EnumInlines "BlendingMode" [
            "NoBlending", "0"
            "NormalBlending", "1"
            "AdditiveBlending", "2"
            "SubtractiveBlending", "3"
            "MultiplyBlending", "4"
            "CustomBlending", "5"
        ]

    let DepthMode =
        Pattern.EnumInlines "DepthMode"
            [
                "NeverDepth", "0"
                "AlwaysDepth", "1"
                "LessDepth", "2"
                "LessEqualDepth", "3"
                "EqualDepth", "4"
                "GreaterEqualDepth", "5"
                "GreaterDepth", "6"
                "NotEqualDepth", "7"
            ]

    let TextureCombineOperation =
        Pattern.EnumInlines "TextureCombineOperation"
            [
                "MultiplyOperation", "0"
                "MixOperation", "1"
                "AddOperation", "2"
            ]

    let StencilFunctions =
        Pattern.EnumInlines "StencilFunctions"
            [
                "NeverStencilFunc" , "512"
                "LessStencilFunc" , "513"
                "EqualStencilFunc" , "514"
                "LessEqualStencilFunc" , "515"
                "GreaterStencilFunc" , "516"
                "NotEqualStencilFunc" , "517"
                "GreaterEqualStencilFunc" , "518"
                "AlwaysStencilFunc" , "519"
            ]
    
    let StencilOperations =
        Pattern.EnumInlines "StencilOperations"
            [
                "ZeroStencilOp" , "0"
                "KeepStencilOp" , "7680"
                "ReplaceStencilOp" , "7681"
                "IncrementStencilOp" , "7682"
                "DecrementStencilOp" , "7683"
                "IncrementWrapStencilOp" , "34055"
                "DecrementWrapStencilOp" , "34056"
                "InvertStencilOp" , "5386"
            ]

    let NormalMapType =
        Pattern.EnumInlines "NormalMapType"
            [
                "TangentSpaceNormalMap", "0"
                "ObjectSpaceNormalMap", "1"
            ]

    let CullFaceMode =
        Pattern.EnumInlines "CullFaceMode"
            [
                "CullFaceNone", "0"
                "CullFaceBack", "1"
                "CullFaceFront", "2"
                "CullFaceFrontBack", "3"
            ]

    let BasicShadowMap =
        Pattern.EnumInlines "BasicShadowMap"
            [
                "BasicShadowMap", "0"
                "PCFShadowMap", "1"
                "PCFSoftShadowMap", "2"
                "VSMShadowMap", "3"
            ]

    let ToneMapping =
        Pattern.EnumInlines "ToneMapping"
            [
                "LinearToneMapping", "1"
                "ReinhardToneMapping", "2"
                "CineonToneMapping", "3"
                "ACESFilmicToneMapping", "4"
                "CustomToneMapping", "5"
                "AgXToneMapping", "6"
                "NeutralToneMapping", "7"
            ]

    let MappingMode =
        Pattern.EnumInlines "MappingMode"
            [
                "UVMapping", "300"
                "CubeReflectionMapping", "301"
                "CubeRefractionMapping", "302"
                "EquirectangularReflectionMapping", "303"
                "EquirectangularRefractionMapping", "304"
                "CubeUVReflectionMapping", "306"
            ]

    let WrappingMode =
        Pattern.EnumInlines "WrappingMode"
            [
                "RepeatWrapping", "1000"
                "ClampToEdgeWrapping", "1001"
                "MirroredRepeatWrapping", "1002"
            ]

    let MagnificationFilter =
        Pattern.EnumInlines "MagnificationFilter"
            [
                "NearestFilter", "1003"
                "LinearFilter", "1006"
            ]

    let MinificationFilter =
        Pattern.EnumInlines "MinificationFilter"
            [
                "NearestFilter", "1003"
                "NearestMipMapNearestFilter", "1004"
                "NearestMipMapLinearFilter", "1005"
                "LinearFilter", "1006"
                "LinearMipMapNearestFilter", "1007"
                "LinearMipMapLinearFilter", "1008"
            ]

    let TextureType =
        Pattern.EnumInlines "TextureType"
            [
                "UnsignedByteType", "1009"
                "ByteType", "1010"
                "ShortType", "1011"
                "UnsignedShortType", "1012"
                "IntType", "1013"
                "UnsignedIntType", "1014"
                "FloatType", "1015"
                "HalfFloatType", "1016"
                "UnsignedShort4444Type", "1017"
                "UnsignedShort5551Type", "1018"
                "UnsignedInt248Type", "1020"
                "UnsignedInt5999Type", "35902"
            ]

    let TextureFormat =
        Pattern.EnumInlines "TextureFormat"
            [
                "AlphaFormat", "1021"
                "RGBFormat", "1022"
                "RGBAFormat", "1023"
                "LuminanceFormat", "1024"
                "LuminanceAlphaFormat", "1025"
                "DepthFormat", "1026"
                "DepthStencilFormat", "1027"
                "RedFormat", "1028"
                "RedIntegerFormat", "1029"
                "RGFormat", "1030"
                "RGIntegerFormat", "1031"
                "RGBAIntegerFormat", "1033"
            ]

    let DDSST3CCompressedTextureFormat =
        Pattern.EnumInlines "DDSST3CCompressedTextureFormat"
            [
                "RGB_S3TC_DXT1_Format", "33776"
                "RGBA_S3TC_DXT1_Format", "33777"
                "RGBA_S3TC_DXT3_Format", "33778"
                "RGBA_S3TC_DXT5_Format", "33779"
            ]

    let PVRTCCompressedTextureFormat =
        Pattern.EnumInlines "PVRTCCompressedTextureFormat"
            [
                "RGB_PVRTC_4BPPV1_Format", "35840"
                "RGB_PVRTC_2BPPV1_Format", "35841"
                "RGBA_PVRTC_4BPPV1_Format", "35842"
                "RGBA_PVRTC_2BPPV1_Format", "35843"
            ]

    let ETCCompressedTextureFormat =
        Pattern.EnumInlines "ETCCompressedTextureFormat"
            [
                "RGB_ETC1_Format", "36196"
                "RGB_ETC2_Format", "37492"
                "RGBA_ETC2_EAC_Format", "37496"
            ]

    let ASTCCompressedTextureFormat =
        Pattern.EnumInlines "ASTCCompressedTextureFormat"
            [
                "RGBA_ASTC_4x4_Format", "37808";
                "RGBA_ASTC_5x4_Format", "37809";
                "RGBA_ASTC_5x5_Format", "37810";
                "RGBA_ASTC_6x5_Format", "37811";
                "RGBA_ASTC_6x6_Format", "37812";
                "RGBA_ASTC_8x5_Format", "37813";
                "RGBA_ASTC_8x6_Format", "37814";
                "RGBA_ASTC_8x8_Format", "37815";
                "RGBA_ASTC_10x5_Format", "37816";
                "RGBA_ASTC_10x6_Format", "37817";
                "RGBA_ASTC_10x8_Format", "37818";
                "RGBA_ASTC_10x10_Format", "37819";
                "RGBA_ASTC_12x10_Format", "37820";
                "RGBA_ASTC_12x12_Format", "37821";
            ]

    let BPTCCompressedTextureFormat =
        Pattern.EnumInlines "BPTCCompressedTextureFormat"
            [
                "RGBA_BPTC_Format", "36492";
            ]

    let TextureComparison =
        Pattern.EnumInlines "TextureComparison"
            [
                "NeverCompare", "512"
                "LessCompare", "513"
                "EqualCompare", "514"
                "LessEqualCompare", "515"
                "GreaterCompare", "516"
                "NotEqualCompare", "517"
                "GreaterEqualCompare", "518"
                "AlwaysCompare", "519"
            ]

    let InternalFormat =
        Pattern.EnumStrings "InternalFormat"
            [
                "ALPHA"
                "RGB"
                "RGBA"
                "LUMINANCE"
                "LUMINANCE_ALPHA"
                "RED_INTEGER"
                "R8"
                "R8_SNORM"
                "R8I"
                "R8UI"
                "R16I"
                "R16UI"
                "R16F"
                "R32I"
                "R32UI"
                "R32F"
                "RG8"
                "RG8_SNORM"
                "RG8I"
                "RG8UI"
                "RG16I"
                "RG16UI"
                "RG16F"
                "RG32I"
                "RG32UI"
                "RG32F"
                "RGB565"
                "RGB8"
                "RGB8_SNORM"
                "RGB8I"
                "RGB8UI"
                "RGB16I"
                "RGB16UI"
                "RGB16F"
                "RGB32I"
                "RGB32UI"
                "RGB32F"
                "RGB9_E5"
                "SRGB8"
                "R11F_G11F_B10F"
                "RGBA4"
                "RGBA8"
                "RGBA8_SNORM"
                "RGBA8I"
                "RGBA8UI"
                "RGBA16I"
                "RGBA16UI"
                "RGBA16F"
                "RGBA32I"
                "RGBA32UI"
                "RGBA32F"
                "RGB5_A1"
                "RGB10_A2"
                "RGB10_A2UI"
                "SRGB8_ALPHA8"
                "DEPTH_COMPONENT16"
                "DEPTH_COMPONENT24"
                "DEPTH_COMPONENT32F"
                "DEPTH24_STENCIL8"
                "DEPTH32F_STENCIL8"
            ]

    let DepthPacking =
        Pattern.EnumInlines "DepthPacking"
            [
                "BasicDepthPacking", "3200"
                "RGBADepthPacking", "3201"
            ]

    let AnimationAction =
        Class "AnimationAction"
         |> ImportFrom "animation"
        |+> Static [
            Constructor (AnimationMixer * AnimationClip * !?Object3D * !?AnimationBlendMode)
        ]
        |+> Instance [
            "blendMode" =@ AnimationBlendMode 
            "loop" =@ LoopMode 
            "time" =@ TSNumberKeyword 
            "timeScale" =@ TSNumberKeyword 
            "weight" =@ TSNumberKeyword 
            "repetitions" =@ TSNumberKeyword 
            "paused" =@ TSBooleanKeyword 
            "enabled" =@ TSBooleanKeyword 
            "clampWhenFinished" =@ TSBooleanKeyword 
            "zeroSlopeAtStart" =@ TSBooleanKeyword 
            "zeroSlopeAtEnd" =@ TSBooleanKeyword 
    
            "play" => T<unit> ^-> TSelf
            "stop" => T<unit> ^-> TSelf
            "reset" => T<unit> ^-> TSelf
            "isRunning" => T<unit> ^-> TSBooleanKeyword
            "isScheduled" => T<unit> ^-> TSBooleanKeyword
            "startAt" => TSNumberKeyword ^-> TSelf
            "setLoop" => LoopMode * TSNumberKeyword ^-> TSelf
            "setEffectiveWeight" => TSNumberKeyword ^-> TSelf
            "getEffectiveWeight" => T<unit> ^-> TSNumberKeyword
            "fadeIn" => TSNumberKeyword ^-> TSelf
            "fadeOut" => TSNumberKeyword ^-> TSelf
            "crossFadeFrom" => TSelf * TSNumberKeyword * TSBooleanKeyword ^-> TSelf
            "crossFadeTo" => TSelf * TSNumberKeyword * TSBooleanKeyword ^-> TSelf
            "stopFading" => T<unit> ^-> TSelf
            "setEffectiveTimeScale" => TSNumberKeyword ^-> TSelf
            "getEffectiveTimeScale" => T<unit> ^-> TSNumberKeyword
            "setDuration" => TSNumberKeyword ^-> TSelf
            "syncWith" => TSelf ^-> TSelf
            "halt" => TSNumberKeyword ^-> TSelf
            "warp" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "stopWarping" => T<unit> ^-> TSelf
            "getMixer" => T<unit> ^-> AnimationMixer
            "getClip" => T<unit> ^-> AnimationClip
            "getRoot" => T<unit> ^-> Object3D
        ]
    
    
    
    AnimationClip
        |+> Static [
            Constructor (!?TSStringKeyword * !?TSNumberKeyword * !?TSArrayType * !?AnimationBlendMode)
        ]
        |+> Instance [
            "name" =@ TSStringKeyword 
            "tracks" =@ TSArrayType 
            "blendMode" =@ AnimationBlendMode 
            "duration" =@ TSNumberKeyword 
            "uuid" =@ TSStringKeyword 
            "results" =@ TSArrayType 
    
            "resetDuration" => T<unit> ^-> TSelf
            "trim" => T<unit> ^-> TSelf
            "validate" => T<unit> ^-> TSBooleanKeyword
            "optimize" => T<unit> ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "toJSON" => AnimationClip ^-> TSAnyKeyword
            "CreateFromMorphTargetSequence" => TSStringKeyword * TSArrayType * TSNumberKeyword * TSBooleanKeyword ^-> TSelf
            "findByName" => TSArrayType * TSStringKeyword ^-> TSelf
            "CreateClipsFromMorphTargetSequences" => TSArrayType * TSNumberKeyword * TSBooleanKeyword ^-> TSArrayType
            "parse" => TSAnyKeyword ^-> TSelf
            "parseAnimation" => TSAnyKeyword * TSArrayType ^-> TSelf
        ]
        |> ignore
    
    
    
    AnimationMixer
        |+> Static [
            Constructor (Object3D)
        ]
        |+> Instance [
            "time" =@ TSNumberKeyword 
            "timeScale" =@ TSNumberKeyword 
    
            "clipAction" => AnimationClip * !?Object3D * !?AnimationBlendMode ^-> AnimationAction
            "existingAction" => AnimationClip * !?Object3D ^-> AnimationAction
            "stopAllAction" => T<unit> ^-> TSelf
            "update" => TSNumberKeyword ^-> TSelf
            "setTime" => TSNumberKeyword ^-> TSelf
            "getRoot" => T<unit> ^-> Object3D
            "uncacheClip" => AnimationClip ^-> TSVoidKeyword
            "uncacheRoot" => Object3D ^-> TSVoidKeyword
            "uncacheAction" => AnimationClip * !?Object3D ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    AnimationObjectGroup
        |+> Static [
            Constructor (TSArrayType)
        ]
        |+> Instance [
            "uuid" =@ TSStringKeyword 
            "stats" =@ TSTypeLiteral 
            "isAnimationObjectGroup" =? TSLiteralType 
    
            "add" => TSArrayType ^-> TSVoidKeyword
            "remove" => TSArrayType ^-> TSVoidKeyword
            "uncache" => TSArrayType ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    KeyframeTrack
        |+> Static [
            Constructor (TSStringKeyword * T<float []> * T<float []> * !?InterpolationMode)
        ]
        |+> Instance [
            "name" =@ TSStringKeyword 
            "times" =@ Float32Array 
            "values" =@ Float32Array 
            "ValueTypeName" =@ TSStringKeyword 
            "TimeBufferType" =@ Float32Array 
            "ValueBufferType" =@ Float32Array 
            "DefaultInterpolation" =@ InterpolationMode 
    
            "InterpolantFactoryMethodDiscrete" => TSAnyKeyword ^-> DiscreteInterpolant
            "InterpolantFactoryMethodLinear" => TSAnyKeyword ^-> LinearInterpolant
            "InterpolantFactoryMethodSmooth" => TSAnyKeyword ^-> CubicInterpolant
            "setInterpolation" => InterpolationMode ^-> TSelf
            "getInterpolation" => T<unit> ^-> InterpolationMode
            "createInterpolant" => T<unit> ^-> Interpolant
            "getValueSize" => T<unit> ^-> TSNumberKeyword
            "shift" => TSNumberKeyword ^-> TSelf
            "scale" => TSNumberKeyword ^-> TSelf
            "trim" => TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "validate" => T<unit> ^-> TSBooleanKeyword
            "optimize" => T<unit> ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "toJSON" => KeyframeTrack ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    PropertyBinding
        |+> Static [
            Constructor (TSAnyKeyword * TSStringKeyword * !?TSAnyKeyword)
        ]
        |+> Instance [
            "path" =@ TSStringKeyword 
            "parsedPath" =@ TSAnyKeyword 
            "node" =@ TSAnyKeyword 
            "rootNode" =@ TSAnyKeyword 
            "BindingType" =@ TSTypeLiteral 
            "Versioning" =@ TSTypeLiteral 
            "GetterByBindingType" =@ T<obj []> 
            "SetterByBindingTypeAndVersioning" =@ T<obj []>
    
            "getValue" => TSAnyKeyword * TSNumberKeyword ^-> TSAnyKeyword
            "setValue" => TSAnyKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "bind" => T<unit> ^-> TSVoidKeyword
            "unbind" => T<unit> ^-> TSVoidKeyword
            //"create" => TSAnyKeyword * TSAnyKeyword * !?TSAnyKeyword ^-> TSUnionType
            "sanitizeNodeName" => TSStringKeyword ^-> TSStringKeyword
            //"parseTrackName" => TSStringKeyword ^-> ParseTrackNameResults
            "findNode" => TSAnyKeyword * TSStringKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    PropertyMixer
        |+> Static [
            Constructor (TSAnyKeyword * TSStringKeyword * TSNumberKeyword)
        ]
        |+> Instance [
            "binding" =@ TSAnyKeyword 
            "valueSize" =@ TSNumberKeyword 
            "buffer" =@ TSAnyKeyword 
            "cumulativeWeight" =@ TSNumberKeyword 
            "cumulativeWeightAdditive" =@ TSNumberKeyword 
            "useCount" =@ TSNumberKeyword 
            "referenceCount" =@ TSNumberKeyword 
    
            "accumulate" => TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "accumulateAdditive" => TSNumberKeyword ^-> TSVoidKeyword
            "apply" => TSNumberKeyword ^-> TSVoidKeyword
            "saveOriginalState" => T<unit> ^-> TSVoidKeyword
            "restoreOriginalState" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    
    BooleanKeyframeTrack
        |+> Static [
            Constructor (TSStringKeyword * T<float []> * T<float []>)
        ]
        |+> Instance [
            "ValueTypeName" =@ TSStringKeyword 
    
            
        ]
        |> ignore
    
    
    
    ColorKeyframeTrack
        |+> Static [
            Constructor (TSStringKeyword * T<float []> * T<float []> * !?InterpolationMode)
        ]
        |+> Instance [
            "ValueTypeName" =@ TSStringKeyword 
    
            
        ]
        |> ignore
    
    
    
    NumberKeyframeTrack
        |+> Static [
            Constructor (TSStringKeyword * T<float []> * T<float []> * !?InterpolationMode)
        ]
        |+> Instance [
            "ValueTypeName" =@ TSStringKeyword 
    
            
        ]
        |> ignore

    
    
    
    QuaternionKeyframeTrack
        |+> Static [
            Constructor (TSStringKeyword * T<float []> * T<float []> * !?InterpolationMode)
        ]
        |+> Instance [
            "ValueTypeName" =@ TSStringKeyword 
    
            
        ]
        |> ignore
    
    
    
    StringKeyframeTrack
        |+> Static [
            Constructor (TSStringKeyword * T<float []> * T<float []> * !?InterpolationMode)
        ]
        |+> Instance [
            "ValueTypeName" =@ TSStringKeyword 
    
            
        ]
        |> ignore
    
    
    
    VectorKeyframeTrack
        |+> Static [
            Constructor (TSStringKeyword * T<float []> * T<float []> * !?InterpolationMode)
        ]
        |+> Instance [
            "ValueTypeName" =@ TSStringKeyword 
    
            
        ]
        |> ignore
    
    //Audio
    //    |+> Static [
    //        Constructor (AudioListener)
    //    ]
    //    |+> Instance [
    //        "type" =? TSUnionType 
    //        "listener" =@ AudioListener 
    //        //"context" =@ AudioContext 
    //        //"gain" =@ GainNode 
    //        "autoplay" =@ TSBooleanKeyword 
    //        "buffer" =@ TSUnionType 
    //        "detune" =@ TSNumberKeyword 
    //        "loop" =@ TSBooleanKeyword 
    //        "loopStart" =@ TSNumberKeyword 
    //        "loopEnd" =@ TSNumberKeyword 
    //        "offset" =@ TSNumberKeyword 
    //        "duration" =@ TSUnionType 
    //        "playbackRate" =@ TSNumberKeyword 
    //        "isPlaying" =@ TSBooleanKeyword 
    //        "hasPlaybackControl" =@ TSBooleanKeyword 
    //        "sourceType" =@ TSStringKeyword 
    //        "source" =@ TSUnionType 
    //        "filters" =@ TSArrayType 
    
    //        //"getOutput" => T<unit> ^-> NodeType
    //        //"setNodeSource" => AudioScheduledSourceNode ^-> TSThisType
    //        "setMediaElementSource" => T<WebSharper.JavaScript.HTMLMediaElement> ^-> TSThisType
    //        "setMediaStreamSource" => MediaStream ^-> TSThisType
    //        "setBuffer" => AudioBuffer ^-> TSThisType
    //        "play" => !?TSNumberKeyword ^-> TSThisType
    //        "pause" => T<unit> ^-> TSThisType
    //        "stop" => T<unit> ^-> TSThisType
    //        "onEnded" => T<unit> ^-> TSVoidKeyword
    //        "connect" => T<unit> ^-> TSThisType
    //        "disconnect" => T<unit> ^-> TSThisType
    //        "getDetune" => T<unit> ^-> TSNumberKeyword
    //        "setDetune" => TSNumberKeyword ^-> TSThisType
    //        "getFilter" => T<unit> ^-> AudioNode
    //        "setFilter" => AudioNode ^-> TSThisType
    //        "getFilters" => T<unit> ^-> TSArrayType
    //        "setFilters" => TSArrayType ^-> TSThisType
    //        "getPlaybackRate" => T<unit> ^-> TSNumberKeyword
    //        "setPlaybackRate" => TSNumberKeyword ^-> TSThisType
    //        "getLoop" => T<unit> ^-> TSBooleanKeyword
    //        "setLoop" => TSBooleanKeyword ^-> TSThisType
    //        "setLoopStart" => TSNumberKeyword ^-> TSThisType
    //        "setLoopEnd" => TSNumberKeyword ^-> TSThisType
    //        "getVolume" => T<unit> ^-> TSNumberKeyword
    //        "setVolume" => TSNumberKeyword ^-> TSThisType
    //    ]
    
    
    
    //AudioAnalyser
    //    |+> Static [
    //        Constructor (Audio * !?TSNumberKeyword)
    //    ]
    //    |+> Instance [
    //        "analyser" =@ AnalyserNode 
    //        "data" =@ Uint8Array 
    
    //        "getFrequencyData" => T<unit> ^-> Uint8Array
    //        "getAverageFrequency" => T<unit> ^-> TSNumberKeyword
    //    ]
    
    
    
    //AudioListener
    //    |+> Static [
    //        Constructor (T<unit>)
    //    ]
    //    |+> Instance [
    //        "type" =? TSUnionType 
    //        "context" =@ AudioContext 
    //        "gain" =@ GainNode 
    //        "filter" =@ AudioNode 
    //        "timeDelta" =@ TSNumberKeyword 
    
    //        "getInput" => T<unit> ^-> GainNode
    //        "removeFilter" => T<unit> ^-> TSThisType
    //        "getFilter" => T<unit> ^-> AudioNode
    //        "setFilter" => AudioNode ^-> TSThisType
    //        "getMasterVolume" => T<unit> ^-> TSNumberKeyword
    //        "setMasterVolume" => TSNumberKeyword ^-> TSThisType
    //    ]
    
    
    
    //PositionalAudio
    //    |+> Static [
    //        Constructor (AudioListener)
    //    ]
    //    |+> Instance [
    //        "panner" =@ PannerNode 
    
    //        "getOutput" => T<unit> ^-> PannerNode
    //        "getRefDistance" => T<unit> ^-> TSNumberKeyword
    //        "setRefDistance" => TSNumberKeyword ^-> TSThisType
    //        "getRolloffFactor" => T<unit> ^-> TSNumberKeyword
    //        "setRolloffFactor" => TSNumberKeyword ^-> TSThisType
    //        "getDistanceModel" => T<unit> ^-> TSStringKeyword
    //        "setDistanceModel" => TSStringKeyword ^-> TSThisType
    //        "getMaxDistance" => T<unit> ^-> TSNumberKeyword
    //        "setMaxDistance" => TSNumberKeyword ^-> TSThisType
    //        "setDirectionalCone" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
    //    ]
    
    
    
    ArrayCamera
        |=> Inherits PerspectiveCamera
        |+> Static [
            Constructor (!?TSArrayType)
        ]
        |+> Instance [
            "isArrayCamera" =? TSLiteralType 
            "cameras" =@ TSArrayType 
    
            
        ]
        |> ignore
    
    
    
    Camera
        |=> Inherits Object3D
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isCamera" =? TSLiteralType 
            "layers" =@ Layers 
            "matrixWorldInverse" =@ Matrix4 
            "projectionMatrix" =@ Matrix4 
            "projectionMatrixInverse" =@ Matrix4
            "viewport" =@ Vector4 
    
            "getWorldDirection" => Vector3 ^-> Vector3
        ]
        |> ignore

    //let WebGLCubeRenderTarget =
    //    Class "WebGLCubeRenderTarget"
    //    |+> Static [
    //        Constructor T<float> * T<obj>
    //    ]
    //    |+> Instance [
    //        "fromEquirectangular" => WebGLRenderer * Texture ^-> WebGLCubeRenderTarget

    //    ]

    
    //CubeCamera
    //    |+> Static [
    //        Constructor (TSNumberKeyword * TSNumberKeyword * WebGLCubeRenderTarget)
    //    ]
    //    |+> Instance [
    //        "type" =? TSUnionType 
    //        "renderTarget" =@ WebGLCubeRenderTarget 
    //        //"coordinateSystem" =@ CoordinateSystem 
    //        "activeMipmapLevel" =@ TSNumberKeyword 
    
    //        "updateCoordinateSystem" => T<unit> ^-> TSVoidKeyword
    //        "update" => WebGLRenderer * Object3D ^-> TSVoidKeyword
    //    ]
    
    
    
    OrthographicCamera
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isOrthographicCamera" =? TSLiteralType 
            "zoom" =@ TSNumberKeyword 
            "view" =@ TSUnionType 
            "left" =@ TSNumberKeyword 
            "right" =@ TSNumberKeyword 
            "top" =@ TSNumberKeyword 
            "bottom" =@ TSNumberKeyword 
            "near" =@ TSNumberKeyword 
            "far" =@ TSNumberKeyword 
    
            "updateProjectionMatrix" => T<unit> ^-> TSVoidKeyword
            "setViewOffset" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "clearViewOffset" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    
    PerspectiveCamera
        |=> Inherits Camera
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isPerspectiveCamera" =? TSLiteralType 
            "type" =? TSUnionType 
            "zoom" =@ TSNumberKeyword 
            "fov" =@ TSNumberKeyword 
            "aspect" =@ TSNumberKeyword 
            "near" =@ TSNumberKeyword 
            "far" =@ TSNumberKeyword 
            "focus" =@ TSNumberKeyword 
            "view" =@ TSUnionType 
            "filmGauge" =@ TSNumberKeyword 
            "filmOffset" =@ TSNumberKeyword 
    
            "getFocalLength" => T<unit> ^-> TSNumberKeyword
            "setFocalLength" => TSNumberKeyword ^-> TSVoidKeyword
            "getEffectiveFOV" => T<unit> ^-> TSNumberKeyword
            "getFilmWidth" => T<unit> ^-> TSNumberKeyword
            "getFilmHeight" => T<unit> ^-> TSNumberKeyword
            "getViewBounds" => TSNumberKeyword * Vector2 * Vector2 ^-> TSVoidKeyword
            "getViewSize" => TSNumberKeyword * Vector2 ^-> Vector2
            "setViewOffset" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "clearViewOffset" => T<unit> ^-> TSVoidKeyword
            "updateProjectionMatrix" => T<unit> ^-> TSVoidKeyword
            "setLens" => TSNumberKeyword * !?TSNumberKeyword ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    
    StereoCamera
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "type" =@ TSLiteralType 
            "aspect" =@ TSNumberKeyword 
            "eyeSep" =@ TSNumberKeyword 
            "cameraL" =@ PerspectiveCamera 
            "cameraR" =@ PerspectiveCamera 
    
            "update" => PerspectiveCamera ^-> TSVoidKeyword
        ]
        |> ignore
    
    let BufferGeometryGroup =
        Pattern.Config "BufferGeometryGroup" {
            Required = [
                "start", T<int>
                "end", T<int>
                "materialIndex", T<int>
            ]
            Optional = []
        }
    
    BufferGeometry
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "id" =@ TSNumberKeyword 
            "uuid" =@ TSStringKeyword 
            "name" =@ TSStringKeyword
            "attributes" =@ T<obj> 
            "morphAttributes" =@ TSTypeLiteral 
            "morphTargetsRelative" =@ TSBooleanKeyword 
            "groups" =@ !|BufferGeometryGroup 
            "boundingBox" =@ TSUnionType 
            "boundingSphere" =@ TSUnionType 
            "drawRange" =@ TSTypeLiteral 
            "userData" =@ T<obj> 
            "isBufferGeometry" =? TSLiteralType 
    
            "getIndex" => T<unit> ^-> TSUnionType
            "setIndex" => TSUnionType ^-> TSThisType
            //"setAttribute" => K * TSIndexedAccessType ^-> TSThisType
            //"getAttribute" => K ^-> TSIndexedAccessType
            "deleteAttribute" => T<obj> ^-> TSThisType
            "hasAttribute" => T<obj> ^-> TSBooleanKeyword
            "addGroup" => TSNumberKeyword * TSNumberKeyword * !?TSNumberKeyword ^-> TSVoidKeyword
            "clearGroups" => T<unit> ^-> TSVoidKeyword
            "setDrawRange" => TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "applyMatrix4" => Matrix4 ^-> TSThisType
            "applyQuaternion" => Quaternion ^-> TSThisType
            "rotateX" => TSNumberKeyword ^-> TSThisType
            "rotateY" => TSNumberKeyword ^-> TSThisType
            "rotateZ" => TSNumberKeyword ^-> TSThisType
            "translate" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "scale" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "lookAt" => Vector3 ^-> TSThisType
            "center" => T<unit> ^-> TSThisType
            "setFromPoints" => TSUnionType ^-> TSThisType
            "computeBoundingBox" => T<unit> ^-> TSVoidKeyword
            "computeBoundingSphere" => T<unit> ^-> TSVoidKeyword
            "computeTangents" => T<unit> ^-> TSVoidKeyword
            "computeVertexNormals" => T<unit> ^-> TSVoidKeyword
            "normalizeNormals" => T<unit> ^-> TSVoidKeyword
            "toNonIndexed" => T<unit> ^-> TSelf
            "toJSON" => T<unit> ^-> TSTypeLiteral
            "clone" => T<unit> ^-> TSThisType
            "copy" => BufferGeometry ^-> TSThisType
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    
    Clock
        |+> Static [
            Constructor (!?TSBooleanKeyword)
        ]
        |+> Instance [
            "autoStart" =@ TSBooleanKeyword 
            "startTime" =@ TSNumberKeyword 
            "oldTime" =@ TSNumberKeyword 
            "elapsedTime" =@ TSNumberKeyword 
            "running" =@ TSBooleanKeyword 
    
            "start" => T<unit> ^-> TSVoidKeyword
            "stop" => T<unit> ^-> TSVoidKeyword
            "getElapsedTime" => T<unit> ^-> TSNumberKeyword
            "getDelta" => T<unit> ^-> TSNumberKeyword
        ]
        |> ignore
    
    let EventListener = 
        T<obj -> unit>
    
    EventDispatcher
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            
    
            "addEventListener" => T<string> * EventListener ^-> TSVoidKeyword
            "hasEventListener" => T<string> * EventListener ^-> TSBooleanKeyword
            "removeEventListener" => T<string> * EventListener ^-> TSVoidKeyword
            "dispatchEvent" => T<obj> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    InstancedBufferAttribute
        |+> Static [
            Constructor (TypedArray * TSNumberKeyword * !?TSBooleanKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "meshPerAttribute" =@ TSNumberKeyword 
            "isInstancedBufferAttribute" =? TSLiteralType 
    
            
        ]
        |> ignore
    
    
    InstancedBufferGeometry
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "type" =@ TSStringKeyword 
            "isInstancedBufferGeometry" =? TSLiteralType 
            "instanceCount" =@ TSNumberKeyword 
    
            "copy" => InstancedBufferGeometry ^-> TSThisType
        ]
        |> ignore
    
    
    InstancedInterleavedBuffer
        |+> Static [
            Constructor (TypedArray * TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "meshPerAttribute" =@ TSNumberKeyword 
    
            
        ]
        |> ignore
    
    
    Layers
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "mask" =@ TSNumberKeyword 
    
            "set" => TSNumberKeyword ^-> TSVoidKeyword
            "enable" => TSNumberKeyword ^-> TSVoidKeyword
            "enableAll" => T<unit> ^-> TSVoidKeyword
            "toggle" => TSNumberKeyword ^-> TSVoidKeyword
            "disable" => TSNumberKeyword ^-> TSVoidKeyword
            "disableAll" => T<unit> ^-> TSVoidKeyword
            "test" => Layers ^-> TSBooleanKeyword
            "isEnabled" => TSNumberKeyword ^-> TSBooleanKeyword
        ]
        |> ignore

    let WebGLRenderer =
        Class "WebGLRenderer" |> ImportFrom "renderers"

    let Color =
        Class "Color" |> ImportFrom "math"

    let Texture =
        Class "Texture" |> ImportFrom "textures"

    let Source =
        Class "Source" |> ImportFrom "textures"

    Source
        |+> Static [
            Constructor (TSAnyKeyword)
            Constructor (TSBooleanKeyword)
        ]
        |+> Instance [
            "isSource" =? TSLiteralType
            "id" =? TSNumberKeyword
            "data" =@ TSAnyKeyword
            "dataReady" =@ TSBooleanKeyword
            "uuid" =@ TSStringKeyword
            "version" =@ TSNumberKeyword

            "toJSON" => !?TSUnionType ^-> TSTypeLiteral
        ]
        |> ignore

    let CatmullRomCurve3 =
        Class "CatmullRomCurve3"
        |> ImportFrom "extras/curves"
            |=> Inherits Curve
            |+> Static [
                Constructor (!?TSArrayType * !?TSBooleanKeyword * !?T<string> * !?TSNumberKeyword)
            ]
            |+> Instance [
                "type" =? TSUnionType
                "closed" =@ TSBooleanKeyword
                "points" =@ TSArrayType
                "curveType" =@ T<string>
                "tension" =@ TSNumberKeyword


            ]

    Texture
        |+> Instance [
            "isTexture" =? TSLiteralType
            "id" =? TSNumberKeyword
            "uuid" =@ TSStringKeyword
            "name" =@ TSStringKeyword
            "source" =@ Source
            "mipmaps" =@ TSArrayType
            "channel" =@ TSNumberKeyword
            "wrapS" =@ WrappingMode
            "wrapT" =@ WrappingMode
            "magFilter" =@ MagnificationFilter
            "minFilter" =@ MinificationFilter
            "anisotropy" =@ TSNumberKeyword
            "format" =@ TextureFormat
            "type" =@ TextureType
            "internalFormat" =@ TSUnionType
            "matrix" =@ Matrix3
            "matrixAutoUpdate" =@ TSBooleanKeyword
            "offset" =@ Vector2
            "repeat" =@ Vector2
            "center" =@ Vector2
            "rotation" =@ TSNumberKeyword
            "generateMipmaps" =@ TSBooleanKeyword
            "premultiplyAlpha" =@ TSBooleanKeyword
            "flipY" =@ TSBooleanKeyword
            "unpackAlignment" =@ TSNumberKeyword
            "colorSpace" =@ ColorSpace
            "isRenderTargetTexture" =@ TSBooleanKeyword
            "userData" =@ T<obj>
            "version" =@ TSNumberKeyword
            "pmremVersion" =@ TSNumberKeyword
            "DEFAULT_ANISOTROPY" =@ TSNumberKeyword
            "DEFAULT_IMAGE" =@ TSAnyKeyword
            "onUpdate" =@ TSFunctionType

            "image" => T<unit> ^-> TSAnyKeyword
            "transformUv" => Vector2 ^-> Vector2
            "updateMatrix" => T<unit> ^-> TSVoidKeyword
            "clone" => T<unit> ^-> TSThisType
            "copy" => Texture ^-> TSThisType
            "toJSON" => !?TSUnionType ^-> TSTypeLiteral
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore

    Color 
        |+> Static [
            Constructor (TSNumberKeyword * TSNumberKeyword * TSNumberKeyword)
        ]
        |+> Instance [
            "isColor" =? TSLiteralType
            "r" =@ TSNumberKeyword
            "g" =@ TSNumberKeyword
            "b" =@ TSNumberKeyword

            "set" => TSUnionType ^-> TSThisType
            "setFromVector3" => Vector3 ^-> TSThisType
            "setScalar" => TSNumberKeyword ^-> TSelf
            "setHex" => TSNumberKeyword * !?ColorSpace ^-> TSelf
            "setRGB" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * !?ColorSpace ^-> TSelf
            "setHSL" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * !?ColorSpace ^-> TSelf
            "setStyle" => TSStringKeyword * !?ColorSpace ^-> TSelf
            "setColorName" => TSStringKeyword * !?ColorSpace ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => TSThisType ^-> TSThisType
            "copySRGBToLinear" => Color ^-> TSelf
            "copyLinearToSRGB" => Color ^-> TSelf
            "convertSRGBToLinear" => T<unit> ^-> TSelf
            "convertLinearToSRGB" => T<unit> ^-> TSelf
            "getHex" => !?ColorSpace ^-> TSNumberKeyword
            "getHexString" => !?ColorSpace ^-> TSStringKeyword
            "getHSL" => T<obj> * !?ColorSpace ^-> T<obj>
            "getRGB" => T<obj> * !?ColorSpace ^-> T<obj>
            "getStyle" => !?ColorSpace ^-> TSStringKeyword
            "offsetHSL" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "add" => Color ^-> TSThisType
            "addColors" => Color * Color ^-> TSThisType
            "addScalar" => TSNumberKeyword ^-> TSThisType
            "applyMatrix3" => Matrix3 ^-> TSThisType
            "sub" => Color ^-> TSThisType
            "multiply" => Color ^-> TSThisType
            "multiplyScalar" => TSNumberKeyword ^-> TSThisType
            "lerp" => Color * TSNumberKeyword ^-> TSThisType
            "lerpColors" => Color * Color * TSNumberKeyword ^-> TSThisType
            "lerpHSL" => Color * TSNumberKeyword ^-> TSThisType
            "equals" => Color ^-> TSBooleanKeyword
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            "toJSON" => T<unit> ^-> TSNumberKeyword
            "fromBufferAttribute" => TSUnionType * TSNumberKeyword ^-> TSThisType
        ]
        |> ignore

    let Material =
        Class "Material"
        |> ImportFrom "materials"
        |+> Static [
            Constructor (T<unit>)
            Constructor (TSNumberKeyword)
            Constructor (TSBooleanKeyword)
        ]
        |+> Instance [
            "isMaterial" =? TSLiteralType
            "alphaHash" =@ TSBooleanKeyword
            "alphaToCoverage" =@ TSBooleanKeyword
            "blendAlpha" =@ TSNumberKeyword
            "blendColor" =@ Color
            "blendDst" =@ SourceFactors
            "blendDstAlpha" =@ TSUnionType
            "blendEquation" =@ BlendingEquations
            "blendEquationAlpha" =@ TSUnionType
            "blending" =@ BlendingMode
            "blendSrc" =@ TSUnionType
            "blendSrcAlpha" =@ TSUnionType
            "clipIntersection" =@ TSBooleanKeyword
            "clippingPlanes" =@ TSUnionType
            "clipShadows" =@ TSBooleanKeyword
            "colorWrite" =@ TSBooleanKeyword
            "defines" =@ TSUnionType
            "depthFunc" =@ DepthMode
            "depthTest" =@ TSBooleanKeyword
            "depthWrite" =@ TSBooleanKeyword
            "id" =@ TSNumberKeyword
            "stencilWrite" =@ TSBooleanKeyword
            "stencilFunc" =@ StencilFunctions
            "stencilRef" =@ TSNumberKeyword
            "stencilWriteMask" =@ TSNumberKeyword
            "stencilFuncMask" =@ TSNumberKeyword
            "stencilFail" =@ StencilOperations
            "stencilZFail" =@ StencilOperations
            "stencilZPass" =@ StencilOperations
            "name" =@ TSStringKeyword
            "opacity" =@ TSNumberKeyword
            "polygonOffset" =@ TSBooleanKeyword
            "polygonOffsetFactor" =@ TSNumberKeyword
            "polygonOffsetUnits" =@ TSNumberKeyword
            "precision" =@ TSUnionType
            "premultipliedAlpha" =@ TSBooleanKeyword
            "forceSinglePass" =@ TSBooleanKeyword
            "dithering" =@ TSBooleanKeyword
            "side" =@ Side
            "shadowSide" =@ TSUnionType
            "toneMapped" =@ TSBooleanKeyword
            "transparent" =@ TSBooleanKeyword
            "type" =@ TSStringKeyword
            "uuid" =@ TSStringKeyword
            "vertexColors" =@ TSBooleanKeyword
            "visible" =@ TSBooleanKeyword
            "userData" =@ T<obj>
            "version" =@ TSNumberKeyword

            "alphaTest" => T<unit> ^-> TSNumberKeyword
            //"onBuild" => Object3D * WebGLProgramParametersWithUniforms * WebGLRenderer ^-> TSVoidKeyword
            "onBeforeRender" => WebGLRenderer * Scene * Camera * BufferGeometry * Object3D * Group ^-> TSVoidKeyword
            //"onBeforeCompile" => WebGLProgramParametersWithUniforms * WebGLRenderer ^-> TSVoidKeyword
            "customProgramCacheKey" => T<unit> ^-> TSStringKeyword
            "setValues" => T<obj> ^-> TSVoidKeyword
            "toJSON" => !?TSAnyKeyword ^-> TSAnyKeyword
            "clone" => T<unit> ^-> TSThisType
            "copy" => TSelf ^-> TSThisType
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]

    
    WebGLRenderer
        |+> Static [
            Constructor (!?T<obj>)
        ]
        |+> Instance [
            "domElement" =@ T<WebSharper.JavaScript.HTMLCanvasElement>
            "autoClear" =@ TSBooleanKeyword        
            "autoClearColor" =@ TSBooleanKeyword   
            "autoClearDepth" =@ TSBooleanKeyword   
            "autoClearStencil" =@ TSBooleanKeyword
            "debug" =@ T<obj>
            "sortObjects" =@ TSBooleanKeyword
            "clippingPlanes" =@ TSArrayType
            "localClippingEnabled" =@ TSBooleanKeyword
            "useLegacyLights" =@ TSBooleanKeyword
            "toneMapping" =@ ToneMapping
            "toneMappingExposure" =@ TSNumberKeyword
            "pixelRatio" =@ TSNumberKeyword
            "xr" =@ WebXRManager
            "compile" =@ TSFunctionType
            "compileAsync" =@ TSFunctionType
            "vr" =@ TSBooleanKeyword

            "outputColorSpace" => T<unit> ^-> ColorSpace
            "getContext" => T<unit> ^-> TSUnionType
            "getContextAttributes" => T<unit> ^-> TSAnyKeyword
            "forceContextLoss" => T<unit> ^-> TSVoidKeyword
            "forceContextRestore" => T<unit> ^-> TSVoidKeyword
            "getMaxAnisotropy" => T<unit> ^-> TSNumberKeyword
            "getPrecision" => T<unit> ^-> TSStringKeyword
            "getPixelRatio" => T<unit> ^-> TSNumberKeyword
            "setPixelRatio" => TSNumberKeyword ^-> TSVoidKeyword
            "getDrawingBufferSize" => Vector2 ^-> Vector2
            "setDrawingBufferSize" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "getSize" => Vector2 ^-> Vector2
            "setSize" => TSNumberKeyword * TSNumberKeyword * !?TSBooleanKeyword ^-> TSVoidKeyword
            "getCurrentViewport" => Vector4 ^-> Vector4
            "getViewport" => Vector4 ^-> Vector4
            "setViewport" => TSUnionType * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword ^-> TSVoidKeyword
            "getScissor" => Vector4 ^-> Vector4
            "setScissor" => TSUnionType * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword ^-> TSVoidKeyword
            "getScissorTest" => T<unit> ^-> TSBooleanKeyword
            "setScissorTest" => TSBooleanKeyword ^-> TSVoidKeyword
            "setOpaqueSort" => TSFunctionType ^-> TSVoidKeyword
            "setTransparentSort" => TSFunctionType ^-> TSVoidKeyword
            "getClearColor" => Color ^-> Color
            "setClearColor" => Color * !?TSNumberKeyword ^-> TSVoidKeyword
            "getClearAlpha" => T<unit> ^-> TSNumberKeyword
            "setClearAlpha" => TSNumberKeyword ^-> TSVoidKeyword
            "clear" => !?TSBooleanKeyword * !?TSBooleanKeyword * !?TSBooleanKeyword ^-> TSVoidKeyword
            "clearColor" => T<unit> ^-> TSVoidKeyword
            "clearDepth" => T<unit> ^-> TSVoidKeyword
            "clearStencil" => T<unit> ^-> TSVoidKeyword
            "clearTarget" => WebGLRenderTarget * TSBooleanKeyword * TSBooleanKeyword * TSBooleanKeyword ^-> TSVoidKeyword
            "resetGLState" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
            "renderBufferDirect" => Camera * Scene * BufferGeometry * Material * Object3D * TSAnyKeyword ^-> TSVoidKeyword
            "setAnimationLoop" => TSUnionType ^-> TSVoidKeyword
            "animate" => TSFunctionType ^-> TSVoidKeyword
            "render" => Object3D * Camera ^-> TSVoidKeyword
            "getActiveCubeFace" => T<unit> ^-> TSNumberKeyword
            "getActiveMipmapLevel" => T<unit> ^-> TSNumberKeyword
            "getRenderTarget" => T<unit> ^-> TSUnionType
            "getCurrentRenderTarget" => T<unit> ^-> TSUnionType
            "setRenderTarget" => TSUnionType * !?TSNumberKeyword * !?TSNumberKeyword ^-> TSVoidKeyword
            "readRenderTargetPixels" => TSUnionType * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSAnyKeyword * !?TSNumberKeyword ^-> TSVoidKeyword
            "copyFramebufferToTexture" => Vector2 * Texture * !?TSNumberKeyword ^-> TSVoidKeyword
            "copyTextureToTexture" => Vector2 * Texture * Texture * !?TSNumberKeyword ^-> TSVoidKeyword
            "copyTextureToTexture3D" => Box3 * Vector3 * Texture * TSUnionType * !?TSNumberKeyword ^-> TSVoidKeyword
            "initTexture" => Texture ^-> TSVoidKeyword
            "resetState" => T<unit> ^-> TSVoidKeyword
            "supportsFloatTextures" => T<unit> ^-> TSAnyKeyword
            "supportsHalfFloatTextures" => T<unit> ^-> TSAnyKeyword
            "supportsStandardDerivatives" => T<unit> ^-> TSAnyKeyword
            "supportsCompressedTextureS3TC" => T<unit> ^-> TSAnyKeyword
            "supportsCompressedTexturePVRTC" => T<unit> ^-> TSAnyKeyword
            "supportsBlendMinMax" => T<unit> ^-> TSAnyKeyword
            "supportsVertexTextures" => T<unit> ^-> TSAnyKeyword
            "supportsInstancedArrays" => T<unit> ^-> TSAnyKeyword
            "enableScissorTest" => TSAnyKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    Object3D
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isObject3D" =? TSLiteralType 
            "id" =? TSNumberKeyword 
            "uuid" =@ TSStringKeyword 
            "name" =@ TSStringKeyword 
            "type" =? TSUnionType 
            "parent" =@ TSUnionType 
            "children" =@ TSArrayType 
            "up" =@ Vector3 
            "position" =? Vector3 
            "rotation" =? Euler 
            "quaternion" =? Quaternion 
            "scale" =? Vector3 
            "modelViewMatrix" =? Matrix4 
            "normalMatrix" =? Matrix3 
            "matrix" =@ Matrix4 
            "matrixWorld" =@ Matrix4 
            "matrixAutoUpdate" =@ TSBooleanKeyword 
            "matrixWorldAutoUpdate" =@ TSBooleanKeyword 
            "matrixWorldNeedsUpdate" =@ TSBooleanKeyword 
            "layers" =@ Layers 
            "visible" =@ TSBooleanKeyword 
            "castShadow" =@ TSBooleanKeyword 
            "receiveShadow" =@ TSBooleanKeyword 
            "frustumCulled" =@ TSBooleanKeyword 
            "renderOrder" =@ TSNumberKeyword 
            "animations" =@ TSArrayType 
            "userData" =@ T<obj> 
            "customDepthMaterial" =@ TSUnionType 
            "customDistanceMaterial" =@ TSUnionType 
            "DEFAULT_UP" =@ Vector3 
            "DEFAULT_MATRIX_AUTO_UPDATE" =@ TSBooleanKeyword 
            "DEFAULT_MATRIX_WORLD_AUTO_UPDATE" =@ TSBooleanKeyword 
    
            "onBeforeShadow" => WebGLRenderer * Scene * Camera * BufferGeometry * Material * Group ^-> TSVoidKeyword
            "onAfterShadow" => WebGLRenderer * Scene * Camera * BufferGeometry * Material * Group ^-> TSVoidKeyword
            "onBeforeRender" => WebGLRenderer * Scene * Camera * BufferGeometry * Material * Group ^-> TSVoidKeyword
            "onAfterRender" => WebGLRenderer * Scene * Camera * BufferGeometry * Material * Group ^-> TSVoidKeyword
            "applyMatrix4" => Matrix4 ^-> TSVoidKeyword
            "applyQuaternion" => Quaternion ^-> TSThisType
            "setRotationFromAxisAngle" => Vector3 * TSNumberKeyword ^-> TSVoidKeyword
            "setRotationFromEuler" => Euler ^-> TSVoidKeyword
            "setRotationFromMatrix" => Matrix4 ^-> TSVoidKeyword
            "setRotationFromQuaternion" => Quaternion ^-> TSVoidKeyword
            "rotateOnAxis" => Vector3 * TSNumberKeyword ^-> TSThisType
            "rotateOnWorldAxis" => Vector3 * TSNumberKeyword ^-> TSThisType
            "rotateX" => TSNumberKeyword ^-> TSThisType
            "rotateY" => TSNumberKeyword ^-> TSThisType
            "rotateZ" => TSNumberKeyword ^-> TSThisType
            "translateOnAxis" => Vector3 * TSNumberKeyword ^-> TSThisType
            "translateX" => TSNumberKeyword ^-> TSThisType
            "translateY" => TSNumberKeyword ^-> TSThisType
            "translateZ" => TSNumberKeyword ^-> TSThisType
            "localToWorld" => Vector3 ^-> Vector3
            "worldToLocal" => Vector3 ^-> Vector3
            "lookAt" => Vector3 ^-> TSVoidKeyword
            "lookAt" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "add" => TSArrayType ^-> TSThisType
            "remove" => TSArrayType ^-> TSThisType
            "removeFromParent" => T<unit> ^-> TSThisType
            "clear" => T<unit> ^-> TSThisType
            "attach" => Object3D ^-> TSThisType
            "getObjectById" => TSNumberKeyword ^-> TSUnionType
            "getObjectByName" => TSStringKeyword ^-> TSUnionType
            "getObjectByProperty" => TSStringKeyword * TSAnyKeyword ^-> TSUnionType
            "getObjectsByProperty" => TSStringKeyword * TSAnyKeyword * !?TSArrayType ^-> TSArrayType
            "getWorldPosition" => Vector3 ^-> Vector3
            "getWorldQuaternion" => Quaternion ^-> Quaternion
            "getWorldScale" => Vector3 ^-> Vector3
            "getWorldDirection" => Vector3 ^-> Vector3
            "raycast" => Raycaster * TSArrayType ^-> TSVoidKeyword
            "traverse" => TSFunctionType ^-> TSVoidKeyword
            "traverseVisible" => TSFunctionType ^-> TSVoidKeyword
            "traverseAncestors" => TSFunctionType ^-> TSVoidKeyword
            "updateMatrix" => T<unit> ^-> TSVoidKeyword
            "updateMatrixWorld" => !?TSBooleanKeyword ^-> TSVoidKeyword
            "updateWorldMatrix" => TSBooleanKeyword * TSBooleanKeyword ^-> TSVoidKeyword
            "toJSON" => !?TSTypeLiteral ^-> TSAnyKeyword
            "clone" => !?TSBooleanKeyword ^-> TSThisType
            "copy" => Object3D * !?TSBooleanKeyword ^-> TSThisType
        ]
        |> ignore
    
    
    Raycaster
        |+> Static [
            Constructor (!?Vector3 * !?Vector3 * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "ray" =@ Ray 
            "near" =@ TSNumberKeyword 
            "far" =@ TSNumberKeyword 
            "camera" =@ Camera 
            "layers" =@ Layers 
            "params" =@ T<obj> 
    
            "set" => Vector3 * Vector3 ^-> TSVoidKeyword
            "setFromCamera" => Vector2 * Camera ^-> TSVoidKeyword
            //"setFromXRController" => XRTargetRaySpace ^-> TSThisType
            "intersectObject" => Object3D * !?TSBooleanKeyword * !?(!|T<obj>) ^-> (!|T<obj>)
            "intersectObjects" => TSArrayType * !?TSBooleanKeyword * !?(!|T<obj>) ^-> (!|T<obj>)
        ]
        |> ignore
    
    
    
    Uniform
        |+> Static [
            Constructor (T)
        ]
        |+> Instance [
            "value" =@ T 
    
            "clone" => T<unit> ^-> TSelf
        ]
        |> ignore

    let LoadingManager =
        Class "LoadingManager"
        |> ImportFrom "loaders"

    LoadingManager
        |+> Static [
            Constructor (!?TSFunctionType * !?TSFunctionType * !?TSFunctionType)
        ]
        |+> Instance [
            "onStart" =@ TSUnionType
            "onLoad" =@ TSFunctionType
            "onProgress" =@ TSFunctionType
            "onError" =@ TSFunctionType

            "setURLModifier" => !?TSFunctionType ^-> TSThisType
            "resolveURL" => TSStringKeyword ^-> TSStringKeyword
            "itemStart" => TSStringKeyword ^-> TSVoidKeyword
            "itemEnd" => TSStringKeyword ^-> TSVoidKeyword
            "itemError" => TSStringKeyword ^-> TSVoidKeyword
            "addHandler" => T<WebSharper.JavaScript.RegExp> * Loader ^-> TSThisType
            "removeHandler" => T<WebSharper.JavaScript.RegExp> ^-> TSThisType
            "getHandler" => TSStringKeyword ^-> TSUnionType
        ]
        |> ignore

    let CubeTexture =
        Class "CubeTexture" |> ImportFrom "textures"

    CubeTexture
        |+> Static [
            Constructor (!?TSArrayType * !?MappingMode * !?WrappingMode * !?WrappingMode * !?MagnificationFilter * !?MinificationFilter * !?TextureFormat * !?TextureType * !?TSNumberKeyword * !?ColorSpace)
        ]
        |+> Instance [
            "isCubeTexture" =? TSLiteralType
            "mapping" =@ MappingMode
            "flipY" =@ TSBooleanKeyword

            "image" => T<unit> ^-> TSAnyKeyword
            "images" => T<unit> ^-> TSAnyKeyword
        ]
        |> ignore
    
    PMREMGenerator
        |+> Static [
            Constructor (WebGLRenderer)
        ]
        |+> Instance [
            
    
            "fromScene" => Scene * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword ^-> WebGLRenderTarget
            "fromEquirectangular" => Texture * !?TSUnionType ^-> WebGLRenderTarget
            "fromCubemap" => CubeTexture * !?TSUnionType ^-> WebGLRenderTarget
            "compileCubemapShader" => T<unit> ^-> TSVoidKeyword
            "compileEquirectangularShader" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    
    Curve
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "arcLengthDivisions" =@ TSNumberKeyword 
            //Generic - fun v -> 
            //    "getPoint" => TSNumberKeyword * !?v ^-> v
            //Generic - fun v ->
            //    "getPointAt" => TSNumberKeyword * !?v ^-> v
            //Generic - fun v ->    
            //    "getTangent" => TSNumberKeyword * !?v ^-> v
            //Generic - fun v ->
            //    "getTangentAt" => TSNumberKeyword * !?v ^-> v
            "getPoints" => !?TSNumberKeyword ^-> TSArrayType
            "getSpacedPoints" => !?TSNumberKeyword ^-> TSArrayType
            "getLength" => T<unit> ^-> TSNumberKeyword
            "getLengths" => !?TSNumberKeyword ^-> TSArrayType
            "updateArcLengths" => T<unit> ^-> TSVoidKeyword
            "getUtoTmapping" => TSNumberKeyword * TSNumberKeyword ^-> TSNumberKeyword
            "computeFrenetFrames" => TSNumberKeyword * !?TSBooleanKeyword ^-> TSTypeLiteral
            "clone" => T<unit> ^-> TSThisType
            "copy" => Curve ^-> TSThisType
            "toJSON" => T<unit> ^-> TSTypeLiteral
            "fromJSON" => TSTypeLiteral ^-> TSThisType
        ]
        |> ignore
    
    
    
    CurvePath
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "curves" =@ !|Curve 
            "autoClose" =@ TSBooleanKeyword 
    
            "add" => Curve ^-> TSVoidKeyword
            "closePath" => T<unit> ^-> TSThisType
            //Generic - fun v ->
            //    "getPoint" => TSNumberKeyword * !?v ^-> v
            "getCurveLengths" => T<unit> ^-> TSArrayType
            "getPoints" => !?TSNumberKeyword ^-> TSArrayType
            "getSpacedPoints" => !?TSNumberKeyword ^-> TSArrayType
        ]
        |> ignore
    
    
    
    Path
        |+> Static [
            Constructor (!?TSArrayType)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "currentPoint" =@ Vector2 
    
            "absarc" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * !?TSBooleanKeyword ^-> TSThisType
            "absellipse" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * !?TSBooleanKeyword * !?TSNumberKeyword ^-> TSThisType
            "arc" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * !?TSBooleanKeyword ^-> TSThisType
            "bezierCurveTo" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "ellipse" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * !?TSBooleanKeyword * !?TSNumberKeyword ^-> TSThisType
            "lineTo" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "moveTo" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "quadraticCurveTo" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setFromPoints" => TSArrayType ^-> TSThisType
            "splineThru" => TSArrayType ^-> TSThisType
        ]
        |> ignore
    
    
    
    Shape
        |+> Static [
            Constructor (!?TSArrayType)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "uuid" =@ TSStringKeyword 
            "holes" =@ TSArrayType 
    
            "extractPoints" => TSNumberKeyword ^-> TSTypeLiteral
            "getPointsHoles" => TSNumberKeyword ^-> TSArrayType
        ]
        |> ignore
    
    
    ShapePath
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "type" =? TSLiteralType 
            "subPaths" =@ TSArrayType 
            "currentPath" =? TSUnionType 
            "color" =@ Color 
    
            "moveTo" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "lineTo" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "quadraticCurveTo" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "bezierCurveTo" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "splineThru" => TSArrayType ^-> TSThisType
            "toShapes" => TSBooleanKeyword ^-> TSArrayType
        ]
        |> ignore
    
    
    BoxGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    CapsuleGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    CircleGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    ConeGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSBooleanKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    CylinderGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSBooleanKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSAnyKeyword ^-> TSelf
        ]
        |> ignore
    
    
    DodecahedronGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    EdgesGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?BufferGeometry * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral   
        ]
        |> ignore
    
    
    ExtrudeGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            //Constructor (!?TSUnionType * !?ExtrudeGeometryOptions)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "addShape" => Shape ^-> TSVoidKeyword
            "fromJSON" => TSTypeLiteral * T<obj> ^-> TSelf
        ]
        |> ignore
    
    
    IcosahedronGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    LatheGeometry
        |+> Static [
            Constructor (!?TSArrayType * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    OctahedronGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    PlaneGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    PolyhedronGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSArrayType * !?TSArrayType * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    RingGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    ShapeGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSUnionType * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    SphereGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    TetrahedronGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    TorusGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSAnyKeyword ^-> TSelf
        ]
        |> ignore
    
    
    TorusKnotGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    TubeGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?Curve * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSBooleanKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
            "tangents" =@ TSArrayType 
            "normals" =@ TSArrayType 
            "binormals" =@ TSArrayType 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    WireframeGeometry
        |=> Inherits BufferGeometry
        |+> Static [
            Constructor (!?BufferGeometry)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "parameters" =? TSTypeLiteral 
    
            
        ]
        |> ignore
    
    
    ArrowHelper
        |+> Static [
            Constructor (!?Vector3 * !?Vector3 * !?TSNumberKeyword * !?T<int> * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "line" =@ Line 
            "cone" =@ Mesh 
    
            "setColor" => T<int> ^-> TSVoidKeyword
            "setDirection" => Vector3 ^-> TSVoidKeyword
            "setLength" => TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword ^-> TSVoidKeyword
            "copy" => TSThisType ^-> TSThisType
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    AxesHelper
        |+> Static [
            Constructor (!?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "setColors" => T<int> * T<int> * T<int> ^-> TSThisType
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    Box3Helper
        |+> Static [
            Constructor (Box3 * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "box" =@ Box3 
    
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    BoxHelper
        |+> Static [
            Constructor (Object3D * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "update" => !?Object3D ^-> TSVoidKeyword
            "setFromObject" => Object3D ^-> TSThisType
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    CameraHelper
        |+> Static [
            Constructor (Camera)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "camera" =@ Camera 
            "pointMap" =@ TSTypeLiteral 
            "matrix" =@ Matrix4 
            "matrixAutoUpdate" =@ TSBooleanKeyword 
    
            "setColors" => Color * Color * Color * Color * Color ^-> TSThisType
            "update" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    DirectionalLightHelper
        |+> Static [
            Constructor (DirectionalLight * !?TSNumberKeyword * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "lightPlane" =@ Line 
            "light" =@ DirectionalLight 
            "matrix" =@ Matrix4 
            "matrixAutoUpdate" =@ TSBooleanKeyword 
            "color" =@ TSUnionType 
            "targetLine" =@ Line 
    
            "update" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
        
    
    GridHelper
        |=> Inherits LineSegments
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?T<int> * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    HemisphereLightHelper
        |+> Static [
            Constructor (HemisphereLight * TSNumberKeyword * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "light" =@ HemisphereLight 
            "matrix" =@ Matrix4 
            "matrixAutoUpdate" =@ TSBooleanKeyword 
            "material" =@ MeshBasicMaterial 
            "color" =@ TSUnionType 
    
            "update" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    PlaneHelper
        |+> Static [
            Constructor (Plane * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "plane" =@ Plane 
            "size" =@ TSNumberKeyword 
    
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    PointLightHelper
        |+> Static [
            Constructor (PointLight * !?TSNumberKeyword * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "light" =@ PointLight 
            "matrix" =@ Matrix4 
            "color" =@ TSUnionType 
            "matrixAutoUpdate" =@ TSBooleanKeyword 
    
            "update" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    PolarGridHelper
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?T<int> * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
    
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    SpotLightHelper
        |+> Static [
            Constructor (Light * !?T<int>)
        ]
        |+> Instance [
            "type" =? TSUnionType 
            "cone" =@ LineSegments 
            "light" =@ Light 
            "matrix" =@ Matrix4 
            "color" =@ TSUnionType 
            "matrixAutoUpdate" =@ TSBooleanKeyword 
    
            "update" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    AmbientLight
        |=> Inherits Light
        |+> Static [
            Constructor (!?T<int> * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isAmbientLight" =? TSLiteralType 
            "type" =? TSUnionType 
    
            
        ]
        |> ignore
    
    
    DirectionalLight
        |=> Inherits Light
        |+> Static [
            Constructor (!?T<int> * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isDirectionalLight" =? TSLiteralType 
            "type" =? TSUnionType 
            "castShadow" =@ TSBooleanKeyword 
            "position" =? Vector3 
            "shadow" =@ DirectionalLightShadow 
            "target" =@ Object3D 
    
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    DirectionalLightShadow
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isDirectionalLightShadow" =? TSLiteralType 
            "camera" =@ OrthographicCamera 
    
            
        ]
        |> ignore
    
    
    HemisphereLight
        |+> Static [
            Constructor (!?T<int> * !?T<int> * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isHemisphereLight" =? TSLiteralType 
            "type" =? TSUnionType 
            "position" =? Vector3 
            "color" =@ Color 
            "groundColor" =@ Color 
    
            
        ]
        |> ignore

    let BufferAttribute =
        Class "BufferAttribute"  |> ImportFrom "core"

    BufferAttribute
        |+> Static [
            Constructor (TypedArray * TSNumberKeyword * !?TSBooleanKeyword)
        ]
        |+> Instance [
            "name" =@ TSStringKeyword
            "array" =@ TypedArray
            "itemSize" =@ TSNumberKeyword
            "usage" =@ GeometryUsage
            "updateRanges" =@ !|T<obj>
            "version" =@ TSNumberKeyword
            "normalized" =@ TSBooleanKeyword
            "count" =? TSNumberKeyword
            "isBufferAttribute" =? TSLiteralType
            "onUploadCallback" =@ TSFunctionType

            "onUpload" => TSFunctionType ^-> TSThisType
            "setUsage" => GeometryUsage ^-> TSThisType
            "addUpdateRange" => TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "clearUpdateRanges" => T<unit> ^-> TSVoidKeyword
            "clone" => T<unit> ^-> TSelf
            "copy" => BufferAttribute ^-> TSThisType
            "copyAt" => TSNumberKeyword * BufferAttribute * TSNumberKeyword ^-> TSThisType
            "applyMatrix3" => Matrix3 ^-> TSThisType
            "applyMatrix4" => Matrix4 ^-> TSThisType
            "applyNormalMatrix" => Matrix3 ^-> TSThisType
            "transformDirection" => Matrix4 ^-> TSThisType
            "set" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "getComponent" => TSNumberKeyword * TSNumberKeyword ^-> TSNumberKeyword
            "setComponent" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "getX" => TSNumberKeyword ^-> TSNumberKeyword
            "setX" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "getY" => TSNumberKeyword ^-> TSNumberKeyword
            "setY" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "getZ" => TSNumberKeyword ^-> TSNumberKeyword
            "setZ" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "getW" => TSNumberKeyword ^-> TSNumberKeyword
            "setW" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setXY" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setXYZ" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setXYZW" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setAttribute" => T<string> * BufferAttribute ^-> TSThisType
            "toJSON" => T<unit> ^-> TSTypeLiteral
        ]
        |> ignore
    
    
    Light
        |+> Static [
            Constructor (!?T<int> * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isLight" =? TSLiteralType 
            "type" =? TSUnionType 
            "color" =@ Color 
            "intensity" =@ TSNumberKeyword
            //Generic - fun t ->
            //    "shadow" =@ t
    
            "copy" => TSThisType * !?TSBooleanKeyword ^-> TSThisType
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    
    LightProbe
        |+> Static [
            Constructor (!?SphericalHarmonics3 * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isLightProbe" =? TSLiteralType 
            "sh" =@ SphericalHarmonics3 
    
            "fromJSON" => TSTypeLiteral ^-> TSelf
        ]
        |> ignore
    
    
    
    //Generic - fun t ->
    //    LightShadow
    //        |+> Static [
    //            Constructor (t)
    //        ]
    //        |+> Instance [
    //            "camera" =@ t 
    //            "bias" =@ TSNumberKeyword 
    //            "normalBias" =@ TSNumberKeyword 
    //            "radius" =@ TSNumberKeyword 
    //            "blurSamples" =@ TSNumberKeyword 
    //            "mapSize" =@ Vector2 
    //            "map" =@ TSUnionType 
    //            "mapPass" =@ TSUnionType 
    //            "matrix" =@ Matrix4 
    //            "autoUpdate" =@ TSBooleanKeyword 
    //            "needsUpdate" =@ TSBooleanKeyword 
    
    //            "getViewportCount" => T<unit> ^-> TSNumberKeyword
    //            "copy" => TSelf ^-> TSelf
    //            "clone" => !?TSBooleanKeyword ^-> TSelf
    //            "toJSON" => T<unit> ^-> TSTypeLiteral
    //            "getFrustum" => T<unit> ^-> Frustum
    //            "updateMatrices" => Light ^-> TSVoidKeyword
    //            "getViewport" => TSNumberKeyword ^-> Vector4
    //            "getFrameExtents" => T<unit> ^-> Vector2
    //            "dispose" => T<unit> ^-> TSVoidKeyword
    //        ]
    //|> ignore  
    
    PointLight
        |+> Static [
            Constructor (!?T<int> * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isPointLight" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "intensity" =@ TSNumberKeyword 
            "distance" =@ TSNumberKeyword 
            "castShadow" =@ TSBooleanKeyword 
            "decay" =@ TSNumberKeyword 
            //"shadow" =@ PointLightShadow 
            "power" =@ TSNumberKeyword 
    
            
        ]
        |> ignore
    
    let CompressedTexture = Class "CompressedTexture"  |> ImportFrom "textures"

    CompressedTexture
        |=> Inherits Texture
        |+> Static [
            Constructor (TSArrayType * TSNumberKeyword * TSNumberKeyword * TextureFormat * !?TextureType * !?MappingMode * !?WrappingMode * !?WrappingMode * !?MagnificationFilter * !?MinificationFilter * !?TSNumberKeyword * !?ColorSpace)
            Constructor (TSTypeLiteral)
        ]
        |+> Instance [
            "isCompressedTexture" =? TSLiteralType
            "mipmaps" =@ TSArrayType
            "format" =@ TextureFormat
            "flipY" =@ TSBooleanKeyword
            "generateMipmaps" =@ TSBooleanKeyword

            "image" => T<unit> ^-> TSTypeLiteral
        ]
        |> ignore

    let DataTexture = Class "DataTexture"  |> ImportFrom "textures"

    DataTexture
        |+> Static [
            Constructor (!?TSUnionType * !?TSNumberKeyword * !?TSNumberKeyword * !?TextureFormat * !?TextureType * !?MappingMode * !?WrappingMode * !?WrappingMode * !?MagnificationFilter * !?MinificationFilter * !?TSNumberKeyword * !?ColorSpace)
        ]
        |+> Instance [
            "isDataTexture" =? TSLiteralType
            "magFilter" =@ MagnificationFilter
            "minFilter" =@ MinificationFilter
            "flipY" =@ TSBooleanKeyword
            "generateMipmaps" =@ TSBooleanKeyword
            "unpackAlignment" =@ TSNumberKeyword
        ]
        |> ignore
    
    RectAreaLight
        |+> Static [
            Constructor (!?T<int> * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isRectAreaLight" =? TSLiteralType 
            "type" =? TSUnionType 
            "width" =@ TSNumberKeyword 
            "height" =@ TSNumberKeyword 
            "intensity" =@ TSNumberKeyword 
            "power" =@ TSNumberKeyword 
    
            
        ]
        |> ignore
    
    
    SpotLight
        |+> Static [
            Constructor (!?T<int> * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isSpotLight" =? TSLiteralType 
            "type" =? TSUnionType 
            "position" =? Vector3 
            "target" =@ Object3D 
            "castShadow" =@ TSBooleanKeyword 
            "intensity" =@ TSNumberKeyword 
            "distance" =@ TSNumberKeyword 
            "angle" =@ TSNumberKeyword 
            "decay" =@ TSNumberKeyword 
            "shadow" =@ SpotLightShadow 
            "power" =@ TSNumberKeyword 
            "penumbra" =@ TSNumberKeyword 
            "map" =@ TSUnionType 
    
            
        ]
        |> ignore
    
    
    SpotLightShadow
        |+> Static [
            
        ]
        |+> Instance [
            "isSpotLightShadow" =? TSLiteralType 
            "camera" =@ PerspectiveCamera 
            "focus" =@ TSNumberKeyword 
    
            
        ]
        |> ignore
    
    
    AnimationLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "parse" => T<obj> ^-> TSArrayType
        ]
        |> ignore
    
    
    AudioLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            
        ]
        |> ignore
    
    
    BufferGeometryLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "parse" => T<obj> ^-> TSUnionType
        ]
        |> ignore
    
    
    CompressedTextureLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "load" => TSStringKeyword * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> CompressedTexture
        ]
        |> ignore
    
    
    CubeTextureLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "load" => T<obj> * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> CubeTexture
        ]
        |> ignore
    
    
    DataTextureLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "load" => TSStringKeyword * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> DataTexture
        ]
        |> ignore
    
    
    FileLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            "mimeType" =@ TSUnionType 
            "responseType" =@ TSUnionType 
    
            "load" => TSStringKeyword * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> TSVoidKeyword
            "setMimeType" => T<string> ^-> TSelf
            "setResponseType" => TSStringKeyword ^-> TSelf
        ]
        |> ignore
    
    
    ImageBitmapLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            "options" =@ TSUnionType 
            "isImageBitmapLoader" =? TSLiteralType 
    
            "load" => TSStringKeyword * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> TSVoidKeyword
            "setOptions" => T<obj> ^-> TSelf
        ]
        |> ignore
    
    
    ImageLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "load" => TSStringKeyword * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> T<WebSharper.JavaScript.HTMLImageElement>
        ]
        |> ignore
    
    
    
    Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            "crossOrigin" =@ TSStringKeyword 
            "withCredentials" =@ TSBooleanKeyword 
            "path" =@ TSStringKeyword 
            "resourcePath" =@ TSStringKeyword 
            "manager" =@ LoadingManager 
            "requestHeader" =@ TSTypeLiteral 
            "DEFAULT_MATERIAL_NAME" =@ TSStringKeyword 
    
            "load" => T<unit> ^-> TSVoidKeyword
            //Generic - fun t ->
            //    "loadAsync" => T<string> * !?TSFunctionType ^-> T<WebSharper.JavaScript.Promise<_>>.[t]
            "setCrossOrigin" => TSStringKeyword ^-> TSThisType
            "setWithCredentials" => TSBooleanKeyword ^-> TSThisType
            "setPath" => TSStringKeyword ^-> TSThisType
            "setResourcePath" => TSStringKeyword ^-> TSThisType
            "setRequestHeader" => TSTypeLiteral ^-> TSThisType
        ]
        |> ignore
    
    
    MaterialLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            "textures" =@ TSTypeLiteral 
    
            "parse" => T<obj> ^-> Material
            "setTextures" => TSTypeLiteral ^-> TSThisType
            "createMaterialFromType" => TSStringKeyword ^-> Material
        ]
        |> ignore
    
    
    ObjectLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "load" => TSStringKeyword * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> TSVoidKeyword
            "parse" => T<obj> * !?TSFunctionType ^-> Object3D
            //Generic - fun t -> "parseAsync" => T<obj> ^-> T<WebSharper.JavaScript.Promise<_>>.[t]
            "parseGeometries" => T<obj> ^-> TSTypeLiteral
            "parseMaterials" => T<obj> * TSTypeLiteral ^-> TSTypeLiteral
            "parseAnimations" => T<obj> ^-> TSTypeLiteral
            "parseImages" => T<obj> * !?TSFunctionType ^-> TSTypeLiteral
            //Generic - fun t ->
                //"parseImagesAsync" => T<obj> ^-> T<WebSharper.JavaScript.Promise<_>>.[t]
            "parseTextures" => T<obj> * TSTypeLiteral ^-> TSTypeLiteral
            "parseObject" => T<obj> * TSTypeLiteral * TSTypeLiteral * TSTypeLiteral ^-> Object3D
        ]
        |> ignore
    
    
    TextureLoader
        |=> Inherits Loader
        |+> Static [
            Constructor (!?LoadingManager)
        ]
        |+> Instance [
            
    
            "load" => TSStringKeyword * !?TSFunctionType * !?TSFunctionType * !?TSFunctionType ^-> Texture
        ]
        |> ignore
    
    
    LineBasicMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isLineBasicMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "color" =@ Color 
            "fog" =@ TSBooleanKeyword 
            "linewidth" =@ TSNumberKeyword 
            "linecap" =@ TSStringKeyword 
            "linejoin" =@ TSStringKeyword 
            "map" =@ TSUnionType 
        ]
        |> ignore
    
    
    LineDashedMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isLineDashedMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "scale" =@ TSNumberKeyword 
            "dashSize" =@ TSNumberKeyword 
            "gapSize" =@ TSNumberKeyword 
        ]
        |> ignore
    
    
    MeshBasicMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshBasicMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "color" =@ Color 
            "map" =@ TSUnionType 
            "lightMap" =@ TSUnionType 
            "lightMapIntensity" =@ TSNumberKeyword 
            "aoMap" =@ TSUnionType 
            "aoMapIntensity" =@ TSNumberKeyword 
            "specularMap" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "envMap" =@ TSUnionType 
            "envMapRotation" =@ Euler 
            "combine" =@ TextureCombineOperation 
            "reflectivity" =@ TSNumberKeyword 
            "refractionRatio" =@ TSNumberKeyword 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "wireframeLinecap" =@ TSStringKeyword 
            "wireframeLinejoin" =@ TSStringKeyword 
            "fog" =@ TSBooleanKeyword 
        ]
        |> ignore
    
    
    MeshDepthMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshDepthMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "map" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "depthPacking" =@ DepthPacking 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "fog" =@ TSBooleanKeyword 
    
        ]
        |> ignore
    
    
    MeshDistanceMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshDistanceMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "map" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "fog" =@ TSBooleanKeyword 
        ]
        |> ignore
    
    
    MeshLambertMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshLambertMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "color" =@ Color 
            "bumpMap" =@ TSUnionType 
            "bumpScale" =@ TSNumberKeyword 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "emissive" =@ Color 
            "emissiveIntensity" =@ TSNumberKeyword 
            "emissiveMap" =@ TSUnionType 
            "flatShading" =@ TSBooleanKeyword 
            "map" =@ TSUnionType 
            "lightMap" =@ TSUnionType 
            "lightMapIntensity" =@ TSNumberKeyword 
            "normalMap" =@ TSUnionType 
            "normalMapType" =@ NormalMapType 
            "normalScale" =@ Vector2 
            "aoMap" =@ TSUnionType 
            "aoMapIntensity" =@ TSNumberKeyword 
            "specularMap" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "envMap" =@ TSUnionType 
            "envMapRotation" =@ Euler 
            "combine" =@ TextureCombineOperation 
            "reflectivity" =@ TSNumberKeyword 
            "refractionRatio" =@ TSNumberKeyword 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "wireframeLinecap" =@ TSStringKeyword 
            "wireframeLinejoin" =@ TSStringKeyword 
            "fog" =@ TSBooleanKeyword 
    
            //"setValues" => MeshLambertMaterialParameters ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    MeshMatcapMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshMatcapMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "defines" =@ TSTypeLiteral 
            "color" =@ Color 
            "matcap" =@ TSUnionType 
            "map" =@ TSUnionType 
            "bumpMap" =@ TSUnionType 
            "bumpScale" =@ TSNumberKeyword 
            "normalMap" =@ TSUnionType 
            "normalMapType" =@ NormalMapType
            "normalScale" =@ Vector2 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "alphaMap" =@ TSUnionType 
            "flatShading" =@ TSBooleanKeyword 
            "fog" =@ TSBooleanKeyword 
    
            //"setValues" => MeshMatcapMaterialParameters ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    MeshNormalMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshNormalMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "bumpMap" =@ TSUnionType 
            "bumpScale" =@ TSNumberKeyword 
            "normalMap" =@ TSUnionType 
            "normalMapType" =@ NormalMapType
            "normalScale" =@ Vector2 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "flatShading" =@ TSBooleanKeyword 
    
            //"setValues" => MeshNormalMaterialParameters ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    MeshPhongMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshPhongMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "color" =@ Color 
            "specular" =@ Color 
            "shininess" =@ TSNumberKeyword 
            "map" =@ TSUnionType 
            "lightMap" =@ TSUnionType 
            "lightMapIntensity" =@ TSNumberKeyword 
            "aoMap" =@ TSUnionType 
            "aoMapIntensity" =@ TSNumberKeyword 
            "emissive" =@ Color 
            "emissiveIntensity" =@ TSNumberKeyword 
            "emissiveMap" =@ TSUnionType 
            "bumpMap" =@ TSUnionType 
            "bumpScale" =@ TSNumberKeyword 
            "normalMap" =@ TSUnionType 
            "normalMapType" =@ NormalMapType
            "normalScale" =@ Vector2 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "specularMap" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "envMap" =@ TSUnionType 
            "envMapRotation" =@ Euler 
            "combine" =@ TextureCombineOperation 
            "reflectivity" =@ TSNumberKeyword 
            "refractionRatio" =@ TSNumberKeyword 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "wireframeLinecap" =@ TSStringKeyword 
            "wireframeLinejoin" =@ TSStringKeyword 
            "flatShading" =@ TSBooleanKeyword 
            "metal" =@ TSBooleanKeyword 
            "fog" =@ TSBooleanKeyword
        ]
        |> ignore
    
    
    MeshStandardMaterial
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshStandardMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "defines" =@ TSTypeLiteral 
            "color" =@ Color 
            "roughness" =@ TSNumberKeyword 
            "metalness" =@ TSNumberKeyword 
            "map" =@ TSUnionType 
            "lightMap" =@ TSUnionType 
            "lightMapIntensity" =@ TSNumberKeyword 
            "aoMap" =@ TSUnionType 
            "aoMapIntensity" =@ TSNumberKeyword 
            "emissive" =@ Color 
            "emissiveIntensity" =@ TSNumberKeyword 
            "emissiveMap" =@ TSUnionType 
            "bumpMap" =@ TSUnionType 
            "bumpScale" =@ TSNumberKeyword 
            "normalMap" =@ TSUnionType 
            "normalMapType" =@ NormalMapType
            "normalScale" =@ Vector2 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "roughnessMap" =@ TSUnionType 
            "metalnessMap" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "envMap" =@ TSUnionType 
            "envMapRotation" =@ Euler 
            "envMapIntensity" =@ TSNumberKeyword 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "wireframeLinecap" =@ TSStringKeyword 
            "wireframeLinejoin" =@ TSStringKeyword 
            "flatShading" =@ TSBooleanKeyword 
            "fog" =@ TSBooleanKeyword 
        ]
        |> ignore
    
    
    MeshToonMaterial
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isMeshToonMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "defines" =@ TSTypeLiteral 
            "color" =@ Color 
            "gradientMap" =@ TSUnionType 
            "map" =@ TSUnionType 
            "lightMap" =@ TSUnionType 
            "lightMapIntensity" =@ TSNumberKeyword 
            "aoMap" =@ TSUnionType 
            "aoMapIntensity" =@ TSNumberKeyword 
            "emissive" =@ Color 
            "emissiveIntensity" =@ TSNumberKeyword 
            "emissiveMap" =@ TSUnionType 
            "bumpMap" =@ TSUnionType 
            "bumpScale" =@ TSNumberKeyword 
            "normalMap" =@ TSUnionType 
            "normalMapType" =@ NormalMapType
            "normalScale" =@ Vector2 
            "displacementMap" =@ TSUnionType 
            "displacementScale" =@ TSNumberKeyword 
            "displacementBias" =@ TSNumberKeyword 
            "alphaMap" =@ TSUnionType 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "wireframeLinecap" =@ TSStringKeyword 
            "wireframeLinejoin" =@ TSStringKeyword 
            "fog" =@ TSBooleanKeyword 
        ]
        |> ignore
    
    
    PointsMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isPointsMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "color" =@ Color 
            "map" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "size" =@ TSNumberKeyword 
            "sizeAttenuation" =@ TSBooleanKeyword 
            "fog" =@ TSBooleanKeyword 
   
        ]
        |> ignore
    
    
    RawShaderMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isRawShaderMaterial" =? TSLiteralType 
            "type" =? TSLiteralType 
    
            
        ]
        |> ignore
    
    
    ShaderMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isShaderMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "defines" =@ TSTypeLiteral 
            "uniforms" =@ TSTypeLiteral 
            "uniformsGroups" =@ TSArrayType 
            "vertexShader" =@ TSStringKeyword 
            "fragmentShader" =@ TSStringKeyword 
            "linewidth" =@ TSNumberKeyword 
            "wireframe" =@ TSBooleanKeyword 
            "wireframeLinewidth" =@ TSNumberKeyword 
            "fog" =@ TSBooleanKeyword 
            "lights" =@ TSBooleanKeyword 
            "clipping" =@ TSBooleanKeyword 
            "extensions" =@ TSTypeLiteral 
            "defaultAttributeValues" =@ TSAnyKeyword 
            "index0AttributeName" =@ TSUnionType 
            "uniformsNeedUpdate" =@ TSBooleanKeyword 
            "glslVersion" =@ TSUnionType 
    
            "toJSON" => TSAnyKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    ShadowMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isShadowMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "color" =@ Color 
            "transparent" =@ TSBooleanKeyword 
            "fog" =@ TSBooleanKeyword 
    
            
        ]
        |> ignore
    
    
    SpriteMaterial
        |=> Inherits Material
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isSpriteMaterial" =? TSLiteralType 
            "type" =@ TSStringKeyword 
            "color" =@ Color 
            "map" =@ TSUnionType 
            "alphaMap" =@ TSUnionType 
            "rotation" =@ TSNumberKeyword 
            "sizeAttenuation" =@ TSBooleanKeyword 
            "transparent" =@ TSBooleanKeyword 
            "fog" =@ TSBooleanKeyword 
    
            "copy" => SpriteMaterial ^-> TSThisType
        ]
        |> ignore
    
    
    Box2
        |+> Static [
            Constructor (!?Vector2 * !?Vector2)
        ]
        |+> Instance [
            "min" =@ Vector2 
            "max" =@ Vector2 
    
            "set" => Vector2 * Vector2 ^-> TSelf
            "setFromPoints" => TSArrayType ^-> TSelf
            "setFromCenterAndSize" => Vector2 * Vector2 ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Box2 ^-> TSThisType
            "makeEmpty" => T<unit> ^-> TSelf
            "isEmpty" => T<unit> ^-> TSBooleanKeyword
            "getCenter" => Vector2 ^-> Vector2
            "getSize" => Vector2 ^-> Vector2
            "expandByPoint" => Vector2 ^-> TSelf
            "expandByVector" => Vector2 ^-> TSelf
            "expandByScalar" => TSNumberKeyword ^-> TSelf
            "containsPoint" => Vector2 ^-> TSBooleanKeyword
            "containsBox" => Box2 ^-> TSBooleanKeyword
            "getParameter" => Vector2 * Vector2 ^-> Vector2
            "intersectsBox" => Box2 ^-> TSBooleanKeyword
            "clampPoint" => Vector2 * Vector2 ^-> Vector2
            "distanceToPoint" => Vector2 ^-> TSNumberKeyword
            "intersect" => Box2 ^-> TSelf
            "union" => Box2 ^-> TSelf
            "translate" => Vector2 ^-> TSelf
            "equals" => Box2 ^-> TSBooleanKeyword
            "empty" => T<unit> ^-> TSAnyKeyword
            "isIntersectionBox" => TSAnyKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    Box3
        |+> Static [
            Constructor (!?Vector3 * !?Vector3)
        ]
        |+> Instance [
            "min" =@ Vector3 
            "max" =@ Vector3 
            "isBox3" =? TSLiteralType 
    
            "set" => Vector3 * Vector3 ^-> TSThisType
            //"setFromArray" => ArrayLike ^-> TSThisType
            //"setFromBufferAttribute" => BufferAttribute ^-> TSThisType
            "setFromPoints" => TSArrayType ^-> TSThisType
            "setFromCenterAndSize" => Vector3 * Vector3 ^-> TSThisType
            "setFromObject" => Object3D * !?TSBooleanKeyword ^-> TSThisType
            "clone" => T<unit> ^-> TSThisType
            "copy" => Box3 ^-> TSThisType
            "makeEmpty" => T<unit> ^-> TSThisType
            "isEmpty" => T<unit> ^-> TSBooleanKeyword
            "getCenter" => Vector3 ^-> Vector3
            "getSize" => Vector3 ^-> Vector3
            "expandByPoint" => Vector3 ^-> TSThisType
            "expandByVector" => Vector3 ^-> TSThisType
            "expandByScalar" => TSNumberKeyword ^-> TSThisType
            "expandByObject" => Object3D * !?TSBooleanKeyword ^-> TSThisType
            "containsPoint" => Vector3 ^-> TSBooleanKeyword
            "containsBox" => Box3 ^-> TSBooleanKeyword
            "getParameter" => Vector3 * Vector3 ^-> Vector3
            "intersectsBox" => Box3 ^-> TSBooleanKeyword
            "intersectsSphere" => Sphere ^-> TSBooleanKeyword
            "intersectsPlane" => Plane ^-> TSBooleanKeyword
            "intersectsTriangle" => Triangle ^-> TSBooleanKeyword
            "clampPoint" => Vector3 * Vector3 ^-> Vector3
            "distanceToPoint" => Vector3 ^-> TSNumberKeyword
            "getBoundingSphere" => Sphere ^-> Sphere
            "intersect" => Box3 ^-> TSThisType
            "union" => Box3 ^-> TSThisType
            "applyMatrix4" => Matrix4 ^-> TSThisType
            "translate" => Vector3 ^-> TSThisType
            "equals" => Box3 ^-> TSBooleanKeyword
            "empty" => T<unit> ^-> TSAnyKeyword
            "isIntersectionBox" => TSAnyKeyword ^-> TSAnyKeyword
            "isIntersectionSphere" => TSAnyKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    
    Cylindrical
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "radius" =@ TSNumberKeyword 
            "theta" =@ TSNumberKeyword 
            "y" =@ TSNumberKeyword 
    
            "clone" => T<unit> ^-> TSThisType
            "copy" => Cylindrical ^-> TSThisType
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setFromVector3" => Vector3 ^-> TSThisType
            "setFromCartesianCoords" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
        ]
        |> ignore
    
    let EulerOrder =
        Pattern.EnumStrings "EulerOrder" [
            "XYZ"
            "YZX"
            "ZXY"
            "XZY"
            "YXZ"
            "ZYX"
        ]
    
    Euler
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?EulerOrder)
        ]
        |+> Instance [
            "x" =@ TSNumberKeyword 
            "y" =@ TSNumberKeyword 
            "z" =@ TSNumberKeyword 
            "order" =@ EulerOrder 
            "isEuler" =? TSLiteralType 
            //"_onChangeCallback" =@ TSFunctionType 
            "DEFAULT_ORDER" =@ TSLiteralType 
    
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * !?EulerOrder ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Euler ^-> TSThisType
            "setFromRotationMatrix" => Matrix4 * !?EulerOrder * !?TSBooleanKeyword ^-> TSelf
            "setFromQuaternion" => Quaternion * !?EulerOrder * !?TSBooleanKeyword ^-> TSelf
            "setFromVector3" => Vector3 * !?EulerOrder ^-> TSelf
            "reorder" => EulerOrder ^-> TSelf
            "equals" => Euler ^-> TSBooleanKeyword
            "fromArray" => T<float []> ^-> TSelf
            "toArray" => !?T<float []> * !?TSNumberKeyword ^-> T<float []>
        ]
        |> ignore
    
    
    
    Frustum
        |+> Static [
            Constructor (!?Plane * !?Plane * !?Plane * !?Plane * !?Plane * !?Plane)
        ]
        |+> Instance [
            "planes" =@ TSArrayType 
    
            "set" => Plane * Plane * Plane * Plane * Plane * Plane ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Frustum ^-> TSThisType
            "setFromProjectionMatrix" => Matrix4 ^-> TSThisType
            "intersectsObject" => Object3D ^-> TSBooleanKeyword
            "intersectsSprite" => Sprite ^-> TSBooleanKeyword
            "intersectsSphere" => Sphere ^-> TSBooleanKeyword
            "intersectsBox" => Box3 ^-> TSBooleanKeyword
            "containsPoint" => Vector3 ^-> TSBooleanKeyword
        ]
        |> ignore
    
    
    Interpolant
        |+> Static [
            Constructor (TSAnyKeyword * TSAnyKeyword * TSNumberKeyword * !?TSAnyKeyword)
        ]
        |+> Instance [
            "parameterPositions" =@ TSAnyKeyword 
            "sampleValues" =@ TSAnyKeyword 
            "valueSize" =@ TSNumberKeyword 
            "resultBuffer" =@ TSAnyKeyword 
    
            "evaluate" => TSNumberKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    Line3
        |+> Static [
            Constructor (!?Vector3 * !?Vector3)
        ]
        |+> Instance [
            "start" =@ Vector3 
            "end" =@ Vector3 
    
            "set" => !?Vector3 * !?Vector3 ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Line3 ^-> TSThisType
            "getCenter" => Vector3 ^-> Vector3
            "delta" => Vector3 ^-> Vector3
            "distanceSq" => T<unit> ^-> TSNumberKeyword
            "distance" => T<unit> ^-> TSNumberKeyword
            "at" => TSNumberKeyword * Vector3 ^-> Vector3
            "closestPointToPointParameter" => Vector3 * !?TSBooleanKeyword ^-> TSNumberKeyword
            "closestPointToPoint" => Vector3 * TSBooleanKeyword * Vector3 ^-> Vector3
            "applyMatrix4" => Matrix4 ^-> TSelf
            "equals" => Line3 ^-> TSBooleanKeyword
        ]
        |> ignore
    
    
    Matrix3
        |+> Static [
            Constructor (T<unit>)
            Constructor (TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword)
        ]
        |+> Instance [
            "elements" =@ TSArrayType 
    
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "identity" => T<unit> ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Matrix3 ^-> TSThisType
            "extractBasis" => Vector3 * Vector3 * Vector3 ^-> TSelf
            "setFromMatrix4" => Matrix4 ^-> TSelf
            "multiplyScalar" => TSNumberKeyword ^-> TSelf
            "determinant" => T<unit> ^-> TSNumberKeyword
            "invert" => T<unit> ^-> TSelf
            "transpose" => T<unit> ^-> TSelf
            "getNormalMatrix" => Matrix4 ^-> TSelf
            "transposeIntoArray" => TSArrayType ^-> TSelf
            "setUvTransform" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "scale" => TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "makeTranslation" => Vector2 ^-> TSThisType
            "makeTranslation" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "makeRotation" => TSNumberKeyword ^-> TSelf
            "makeScale" => TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "rotate" => TSNumberKeyword ^-> TSelf
            "translate" => TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "equals" => Matrix3 ^-> TSBooleanKeyword
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSelf
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            "multiply" => Matrix3 ^-> TSelf
            "premultiply" => Matrix3 ^-> TSelf
            "multiplyMatrices" => Matrix3 * Matrix3 ^-> TSelf
            "multiplyVector3" => Vector3 ^-> TSAnyKeyword
            "multiplyVector3Array" => TSAnyKeyword ^-> TSAnyKeyword
            "getInverse" => Matrix4 * !?TSBooleanKeyword ^-> TSelf
            "flattenToArrayOffset" => TSArrayType * TSNumberKeyword ^-> TSArrayType
        ]
        |> ignore
    
    
    Matrix4
        |+> Static [
            Constructor (T<unit>)
            Constructor (TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword)
        ]
        |+> Instance [
            "elements" =@ TSArrayType 
    
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "identity" => T<unit> ^-> TSThisType
            "clone" => T<unit> ^-> TSelf
            "copy" => Matrix4 ^-> TSThisType
            "copyPosition" => Matrix4 ^-> TSThisType
            "extractBasis" => Vector3 * Vector3 * Vector3 ^-> TSThisType
            "makeBasis" => Vector3 * Vector3 * Vector3 ^-> TSThisType
            "extractRotation" => Matrix4 ^-> TSThisType
            "makeRotationFromEuler" => Euler ^-> TSThisType
            "makeRotationFromQuaternion" => Quaternion ^-> TSThisType
            "lookAt" => Vector3 * Vector3 * Vector3 ^-> TSThisType
            "multiply" => Matrix4 ^-> TSThisType
            "premultiply" => Matrix4 ^-> TSThisType
            "multiplyMatrices" => Matrix4 * Matrix4 ^-> TSThisType
            "multiplyToArray" => Matrix4 * Matrix4 * TSArrayType ^-> TSelf
            "multiplyScalar" => TSNumberKeyword ^-> TSThisType
            "determinant" => T<unit> ^-> TSNumberKeyword
            "transpose" => T<unit> ^-> TSThisType
            "setPosition" => Vector3 ^-> TSThisType
            "setPosition" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "invert" => T<unit> ^-> TSThisType
            "scale" => Vector3 ^-> TSThisType
            "getMaxScaleOnAxis" => T<unit> ^-> TSNumberKeyword
            "makeTranslation" => Vector3 ^-> TSThisType
            "makeTranslation" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "makeRotationX" => TSNumberKeyword ^-> TSThisType
            "makeRotationY" => TSNumberKeyword ^-> TSThisType
            "makeRotationZ" => TSNumberKeyword ^-> TSThisType
            "makeRotationAxis" => Vector3 * TSNumberKeyword ^-> TSThisType
            "makeScale" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "makeShear" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "compose" => Vector3 * Quaternion * Vector3 ^-> TSThisType
            "decompose" => Vector3 * Quaternion * Vector3 ^-> TSThisType
            "makePerspective" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "makeOrthographic" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "equals" => Matrix4 ^-> TSBooleanKeyword
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            "setFromMatrix3" => Matrix3 ^-> TSThisType
            "extractPosition" => Matrix4 ^-> TSelf
            "setRotationFromQuaternion" => Quaternion ^-> TSelf
            "multiplyVector3" => TSAnyKeyword ^-> TSAnyKeyword
            "multiplyVector4" => TSAnyKeyword ^-> TSAnyKeyword
            "multiplyVector3Array" => TSArrayType ^-> TSArrayType
            "rotateAxis" => TSAnyKeyword ^-> TSVoidKeyword
            "crossVector" => TSAnyKeyword ^-> TSVoidKeyword
            "flattenToArrayOffset" => TSArrayType * TSNumberKeyword ^-> TSArrayType
        ]
        |> ignore
    
    
    Plane
        |+> Static [
            Constructor (!?Vector3 * !?TSNumberKeyword)
        ]
        |+> Instance [
            "normal" =@ Vector3 
            "constant" =@ TSNumberKeyword 
            "isPlane" =? TSLiteralType 
    
            "set" => Vector3 * TSNumberKeyword ^-> TSelf
            "setComponents" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSelf
            "setFromNormalAndCoplanarPoint" => Vector3 * Vector3 ^-> TSelf
            "setFromCoplanarPoints" => Vector3 * Vector3 * Vector3 ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Plane ^-> TSThisType
            "normalize" => T<unit> ^-> TSelf
            "negate" => T<unit> ^-> TSelf
            "distanceToPoint" => Vector3 ^-> TSNumberKeyword
            "distanceToSphere" => Sphere ^-> TSNumberKeyword
            "projectPoint" => Vector3 * Vector3 ^-> Vector3
            "intersectLine" => Line3 * Vector3 ^-> TSUnionType
            "intersectsLine" => Line3 ^-> TSBooleanKeyword
            "intersectsBox" => Box3 ^-> TSBooleanKeyword
            "intersectsSphere" => Sphere ^-> TSBooleanKeyword
            "coplanarPoint" => Vector3 ^-> Vector3
            "applyMatrix4" => Matrix4 * !?Matrix3 ^-> TSelf
            "translate" => Vector3 ^-> TSelf
            "equals" => Plane ^-> TSBooleanKeyword
            "isIntersectionLine" => TSAnyKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    Quaternion
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "x" =@ TSNumberKeyword 
            "y" =@ TSNumberKeyword 
            "z" =@ TSNumberKeyword 
            "w" =@ TSNumberKeyword 
            "isQuaternion" =? TSLiteralType 
            "_onChangeCallback" =@ TSFunctionType 
    
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "clone" => T<unit> ^-> TSThisType
            "copy" => Quaternion ^-> TSThisType
            "setFromEuler" => Euler * !?TSBooleanKeyword ^-> TSThisType
            "setFromAxisAngle" => Vector3 * TSNumberKeyword ^-> TSThisType
            "setFromRotationMatrix" => Matrix4 ^-> TSThisType
            "setFromUnitVectors" => Vector3 * Vector3 ^-> TSThisType
            "angleTo" => Quaternion ^-> TSNumberKeyword
            "rotateTowards" => Quaternion * TSNumberKeyword ^-> TSThisType
            "identity" => T<unit> ^-> TSThisType
            "invert" => T<unit> ^-> TSThisType
            "conjugate" => T<unit> ^-> TSThisType
            "dot" => Quaternion ^-> TSNumberKeyword
            "lengthSq" => T<unit> ^-> TSNumberKeyword
            "length" => T<unit> ^-> TSNumberKeyword
            "normalize" => T<unit> ^-> TSThisType
            "multiply" => Quaternion ^-> TSThisType
            "premultiply" => Quaternion ^-> TSThisType
            "multiplyQuaternions" => Quaternion * Quaternion ^-> TSThisType
            "slerp" => Quaternion * TSNumberKeyword ^-> TSThisType
            "slerpQuaternions" => Quaternion * Quaternion * TSNumberKeyword ^-> TSThisType
            "equals" => Quaternion ^-> TSBooleanKeyword
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            //"toArray" => ArrayLike * !?TSNumberKeyword ^-> ArrayLike
            //"toJSON" => T<unit> ^-> TSTupleType
            "fromBufferAttribute" => TSUnionType * TSNumberKeyword ^-> TSThisType
            "slerpFlat" => TSArrayType * TSNumberKeyword * TSArrayType * TSNumberKeyword * TSArrayType * TSNumberKeyword * TSNumberKeyword ^-> TSVoidKeyword
            "multiplyQuaternionsFlat" => TSArrayType * TSNumberKeyword * TSArrayType * TSNumberKeyword * TSArrayType * TSNumberKeyword ^-> TSArrayType
            "random" => T<unit> ^-> TSThisType
        ]
        |> ignore
    
    
    Ray
        |+> Static [
            Constructor (!?Vector3 * !?Vector3)
        ]
        |+> Instance [
            "origin" =@ Vector3 
            "direction" =@ Vector3 
    
            "set" => Vector3 * Vector3 ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Ray ^-> TSThisType
            "at" => TSNumberKeyword * Vector3 ^-> Vector3
            "lookAt" => Vector3 ^-> TSelf
            "recast" => TSNumberKeyword ^-> TSelf
            "closestPointToPoint" => Vector3 * Vector3 ^-> Vector3
            "distanceToPoint" => Vector3 ^-> TSNumberKeyword
            "distanceSqToPoint" => Vector3 ^-> TSNumberKeyword
            "distanceSqToSegment" => Vector3 * Vector3 * !?Vector3 * !?Vector3 ^-> TSNumberKeyword
            "intersectSphere" => Sphere * Vector3 ^-> TSUnionType
            "intersectsSphere" => Sphere ^-> TSBooleanKeyword
            "distanceToPlane" => Plane ^-> TSNumberKeyword
            "intersectPlane" => Plane * Vector3 ^-> TSUnionType
            "intersectsPlane" => Plane ^-> TSBooleanKeyword
            "intersectBox" => Box3 * Vector3 ^-> TSUnionType
            "intersectsBox" => Box3 ^-> TSBooleanKeyword
            "intersectTriangle" => Vector3 * Vector3 * Vector3 * TSBooleanKeyword * Vector3 ^-> TSUnionType
            "applyMatrix4" => Matrix4 ^-> TSelf
            "equals" => Ray ^-> TSBooleanKeyword
            "isIntersectionBox" => TSAnyKeyword ^-> TSAnyKeyword
            "isIntersectionPlane" => TSAnyKeyword ^-> TSAnyKeyword
            "isIntersectionSphere" => TSAnyKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    Sphere
        |+> Static [
            Constructor (!?Vector3 * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isSphere" =? TSLiteralType 
            "center" =@ Vector3 
            "radius" =@ TSNumberKeyword 
    
            "set" => Vector3 * TSNumberKeyword ^-> TSelf
            "setFromPoints" => TSArrayType * !?Vector3 ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "copy" => Sphere ^-> TSThisType
            "expandByPoint" => Vector3 ^-> TSThisType
            "isEmpty" => T<unit> ^-> TSBooleanKeyword
            "makeEmpty" => T<unit> ^-> TSThisType
            "containsPoint" => Vector3 ^-> TSBooleanKeyword
            "distanceToPoint" => Vector3 ^-> TSNumberKeyword
            "intersectsSphere" => Sphere ^-> TSBooleanKeyword
            "intersectsBox" => Box3 ^-> TSBooleanKeyword
            "intersectsPlane" => Plane ^-> TSBooleanKeyword
            "clampPoint" => Vector3 * Vector3 ^-> Vector3
            "getBoundingBox" => Box3 ^-> Box3
            "applyMatrix4" => Matrix4 ^-> TSelf
            "translate" => Vector3 ^-> TSelf
            "equals" => Sphere ^-> TSBooleanKeyword
            "union" => Sphere ^-> TSThisType
            "empty" => T<unit> ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    Spherical
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "radius" =@ TSNumberKeyword 
            "phi" =@ TSNumberKeyword 
            "theta" =@ TSNumberKeyword 
    
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "clone" => T<unit> ^-> TSThisType
            "copy" => Spherical ^-> TSThisType
            "makeSafe" => T<unit> ^-> TSThisType
            "setFromVector3" => Vector3 ^-> TSThisType
            "setFromCartesianCoords" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
        ]
        |> ignore
    
    
    SphericalHarmonics3
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "coefficients" =@ TSArrayType 
            "isSphericalHarmonics3" =? TSLiteralType 
    
            "set" => TSArrayType ^-> TSelf
            "zero" => T<unit> ^-> TSelf
            "add" => SphericalHarmonics3 ^-> TSelf
            "addScaledSH" => SphericalHarmonics3 * TSNumberKeyword ^-> TSelf
            "scale" => TSNumberKeyword ^-> TSelf
            "lerp" => SphericalHarmonics3 * TSNumberKeyword ^-> TSelf
            "equals" => SphericalHarmonics3 ^-> TSBooleanKeyword
            "copy" => SphericalHarmonics3 ^-> TSelf
            "clone" => T<unit> ^-> TSThisType
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            //"toArray" => ArrayLike * !?TSNumberKeyword ^-> ArrayLike
            "getAt" => Vector3 * Vector3 ^-> Vector3
            "getIrradianceAt" => Vector3 * Vector3 ^-> Vector3
            "getBasisAt" => Vector3 * TSArrayType ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    Triangle
        |+> Static [
            Constructor (!?Vector3 * !?Vector3 * !?Vector3)
        ]
        |+> Instance [
            "a" =@ Vector3 
            "b" =@ Vector3 
            "c" =@ Vector3 
    
            "set" => Vector3 * Vector3 * Vector3 ^-> TSelf
            "setFromPointsAndIndices" => TSArrayType * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setFromAttributeAndIndices" => TSUnionType * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "clone" => T<unit> ^-> TSThisType
            "copy" => Triangle ^-> TSThisType
            "getArea" => T<unit> ^-> TSNumberKeyword
            "getMidpoint" => Vector3 ^-> Vector3
            "getNormal" => Vector3 ^-> Vector3
            "getPlane" => Plane ^-> Plane
            "getBarycoord" => Vector3 * Vector3 ^-> TSUnionType
            "getInterpolation" => Vector3 * Vector2 * Vector2 * Vector2 * Vector2 ^-> TSUnionType
            "getInterpolation" => Vector3 * Vector3 * Vector3 * Vector3 * Vector3 ^-> TSUnionType
            "getInterpolation" => Vector3 * Vector4 * Vector4 * Vector4 * Vector4 ^-> TSUnionType
            "containsPoint" => Vector3 ^-> TSBooleanKeyword
            "intersectsBox" => Box3 ^-> TSBooleanKeyword
            "isFrontFacing" => Vector3 ^-> TSBooleanKeyword
            "closestPointToPoint" => Vector3 * Vector3 ^-> Vector3
            "equals" => Triangle ^-> TSBooleanKeyword
            "getNormal" => Vector3 * Vector3 * Vector3 * Vector3 ^-> Vector3
            "getBarycoord" => Vector3 * Vector3 * Vector3 * Vector3 * Vector3 ^-> TSUnionType
            "containsPoint" => Vector3 * Vector3 * Vector3 * Vector3 ^-> TSBooleanKeyword
            "getInterpolation" => Vector3 * Vector3 * Vector3 * Vector3 * Vector2 * Vector2 * Vector2 * Vector2 ^-> TSUnionType
            "getInterpolation" => Vector3 * Vector3 * Vector3 * Vector3 * Vector3 * Vector3 * Vector3 * Vector3 ^-> TSUnionType
            "getInterpolation" => Vector3 * Vector3 * Vector3 * Vector3 * Vector4 * Vector4 * Vector4 * Vector4 ^-> TSUnionType
            "isFrontFacing" => Vector3 * Vector3 * Vector3 * Vector3 ^-> TSBooleanKeyword
        ]
        |> ignore
    
    
    Vector2
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "x" =@ TSNumberKeyword 
            "y" =@ TSNumberKeyword 
            "width" =@ TSNumberKeyword 
            "height" =@ TSNumberKeyword 
            "isVector2" =? TSLiteralType 
    
            "set" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setScalar" => TSNumberKeyword ^-> TSThisType
            "setX" => TSNumberKeyword ^-> TSThisType
            "setY" => TSNumberKeyword ^-> TSThisType
            "setComponent" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "getComponent" => TSNumberKeyword ^-> TSNumberKeyword
            "clone" => T<unit> ^-> TSThisType
            "copy" => Vector2 ^-> TSThisType
            "add" => Vector2 ^-> TSThisType
            "addScalar" => TSNumberKeyword ^-> TSThisType
            "addVectors" => Vector2 * Vector2 ^-> TSThisType
            "addScaledVector" => Vector2 * TSNumberKeyword ^-> TSThisType
            "sub" => Vector2 ^-> TSThisType
            "subScalar" => TSNumberKeyword ^-> TSThisType
            "subVectors" => Vector2 * Vector2 ^-> TSThisType
            "multiply" => Vector2 ^-> TSThisType
            "multiplyScalar" => TSNumberKeyword ^-> TSThisType
            "divide" => Vector2 ^-> TSThisType
            "divideScalar" => TSNumberKeyword ^-> TSThisType
            "applyMatrix3" => Matrix3 ^-> TSThisType
            "min" => Vector2 ^-> TSThisType
            "max" => Vector2 ^-> TSThisType
            "clamp" => Vector2 * Vector2 ^-> TSThisType
            "clampScalar" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "clampLength" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "floor" => T<unit> ^-> TSThisType
            "ceil" => T<unit> ^-> TSThisType
            "round" => T<unit> ^-> TSThisType
            "roundToZero" => T<unit> ^-> TSThisType
            "negate" => T<unit> ^-> TSThisType
            "dot" => Vector2 ^-> TSNumberKeyword
            "cross" => Vector2 ^-> TSNumberKeyword
            "lengthSq" => T<unit> ^-> TSNumberKeyword
            "length" => T<unit> ^-> TSNumberKeyword
            "manhattanLength" => T<unit> ^-> TSNumberKeyword
            "normalize" => T<unit> ^-> TSThisType
            "angle" => T<unit> ^-> TSNumberKeyword
            "angleTo" => Vector2 ^-> TSNumberKeyword
            "distanceTo" => Vector2 ^-> TSNumberKeyword
            "distanceToSquared" => Vector2 ^-> TSNumberKeyword
            "manhattanDistanceTo" => Vector2 ^-> TSNumberKeyword
            "setLength" => TSNumberKeyword ^-> TSThisType
            "lerp" => Vector2 * TSNumberKeyword ^-> TSThisType
            "lerpVectors" => Vector2 * Vector2 * TSNumberKeyword ^-> TSThisType
            "equals" => Vector2 ^-> TSBooleanKeyword
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            //"fromBufferAttribute" => BufferAttribute * TSNumberKeyword ^-> TSThisType
            "rotateAround" => Vector2 * TSNumberKeyword ^-> TSThisType
            "random" => T<unit> ^-> TSThisType
        ]
        |> ignore
    
    
    Vector3
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "x" =@ TSNumberKeyword 
            "y" =@ TSNumberKeyword 
            "z" =@ TSNumberKeyword 
            "isVector3" =? TSLiteralType 
    
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setScalar" => TSNumberKeyword ^-> TSThisType
            "setX" => TSNumberKeyword ^-> TSThisType
            "setY" => TSNumberKeyword ^-> TSThisType
            "setZ" => TSNumberKeyword ^-> TSThisType
            "setComponent" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "getComponent" => TSNumberKeyword ^-> TSNumberKeyword
            "clone" => T<unit> ^-> TSThisType
            "copy" => Vector3 ^-> TSThisType
            "add" => Vector3 ^-> TSThisType
            "addScalar" => TSNumberKeyword ^-> TSThisType
            "addVectors" => Vector3 * Vector3 ^-> TSThisType
            "addScaledVector" => Vector3 * TSNumberKeyword ^-> TSThisType
            "sub" => Vector3 ^-> TSThisType
            "subScalar" => TSNumberKeyword ^-> TSThisType
            "subVectors" => Vector3 * Vector3 ^-> TSThisType
            "multiply" => Vector3 ^-> TSThisType
            "multiplyScalar" => TSNumberKeyword ^-> TSThisType
            "multiplyVectors" => Vector3 * Vector3 ^-> TSThisType
            "applyEuler" => Euler ^-> TSThisType
            "applyAxisAngle" => Vector3 * TSNumberKeyword ^-> TSThisType
            "applyMatrix3" => Matrix3 ^-> TSThisType
            "applyNormalMatrix" => Matrix3 ^-> TSThisType
            "applyMatrix4" => Matrix4 ^-> TSThisType
            "applyQuaternion" => Quaternion ^-> TSThisType
            "project" => Camera ^-> TSThisType
            "unproject" => Camera ^-> TSThisType
            "transformDirection" => Matrix4 ^-> TSThisType
            "divide" => Vector3 ^-> TSThisType
            "divideScalar" => TSNumberKeyword ^-> TSThisType
            "min" => Vector3 ^-> TSThisType
            "max" => Vector3 ^-> TSThisType
            "clamp" => Vector3 * Vector3 ^-> TSThisType
            "clampScalar" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "clampLength" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "floor" => T<unit> ^-> TSThisType
            "ceil" => T<unit> ^-> TSThisType
            "round" => T<unit> ^-> TSThisType
            "roundToZero" => T<unit> ^-> TSThisType
            "negate" => T<unit> ^-> TSThisType
            "dot" => Vector3 ^-> TSNumberKeyword
            "lengthSq" => T<unit> ^-> TSNumberKeyword
            "length" => T<unit> ^-> TSNumberKeyword
            "manhattanLength" => T<unit> ^-> TSNumberKeyword
            "normalize" => T<unit> ^-> TSThisType
            "setLength" => TSNumberKeyword ^-> TSThisType
            "lerp" => Vector3 * TSNumberKeyword ^-> TSThisType
            "lerpVectors" => Vector3 * Vector3 * TSNumberKeyword ^-> TSThisType
            "cross" => Vector3 ^-> TSThisType
            "crossVectors" => Vector3 * Vector3 ^-> TSThisType
            "projectOnVector" => Vector3 ^-> TSThisType
            "projectOnPlane" => Vector3 ^-> TSThisType
            "reflect" => Vector3 ^-> TSThisType
            "angleTo" => Vector3 ^-> TSNumberKeyword
            "distanceTo" => Vector3 ^-> TSNumberKeyword
            "distanceToSquared" => Vector3 ^-> TSNumberKeyword
            "manhattanDistanceTo" => Vector3 ^-> TSNumberKeyword
            "setFromSpherical" => Spherical ^-> TSThisType
            "setFromSphericalCoords" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setFromCylindrical" => Cylindrical ^-> TSThisType
            "setFromCylindricalCoords" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setFromMatrixPosition" => Matrix4 ^-> TSThisType
            "setFromMatrixScale" => Matrix4 ^-> TSThisType
            "setFromMatrixColumn" => Matrix4 * TSNumberKeyword ^-> TSThisType
            "setFromMatrix3Column" => Matrix3 * TSNumberKeyword ^-> TSThisType
            "setFromEuler" => Euler ^-> TSThisType
            "setFromColor" => T<obj> ^-> TSThisType
            "equals" => Vector3 ^-> TSBooleanKeyword
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            "toArray" => !?Vector3 * !?TSLiteralType ^-> Vector3
            "fromBufferAttribute" => TSUnionType * TSNumberKeyword ^-> TSThisType
            "random" => T<unit> ^-> TSThisType
            "randomDirection" => T<unit> ^-> TSThisType
        ]
        |> ignore
    
    
    Vector4
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "x" =@ TSNumberKeyword 
            "y" =@ TSNumberKeyword 
            "z" =@ TSNumberKeyword 
            "w" =@ TSNumberKeyword 
            "width" =@ TSNumberKeyword 
            "height" =@ TSNumberKeyword 
            "isVector4" =? TSLiteralType 
    
            "set" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "setScalar" => TSNumberKeyword ^-> TSThisType
            "setX" => TSNumberKeyword ^-> TSThisType
            "setY" => TSNumberKeyword ^-> TSThisType
            "setZ" => TSNumberKeyword ^-> TSThisType
            "setW" => TSNumberKeyword ^-> TSThisType
            "setComponent" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "getComponent" => TSNumberKeyword ^-> TSNumberKeyword
            "clone" => T<unit> ^-> TSThisType
            "copy" => Vector4 ^-> TSThisType
            "add" => Vector4 ^-> TSThisType
            "addScalar" => TSNumberKeyword ^-> TSThisType
            "addVectors" => Vector4 * Vector4 ^-> TSThisType
            "addScaledVector" => Vector4 * TSNumberKeyword ^-> TSThisType
            "sub" => Vector4 ^-> TSThisType
            "subScalar" => TSNumberKeyword ^-> TSThisType
            "subVectors" => Vector4 * Vector4 ^-> TSThisType
            "multiply" => Vector4 ^-> TSThisType
            "multiplyScalar" => TSNumberKeyword ^-> TSThisType
            "applyMatrix4" => Matrix4 ^-> TSThisType
            "divideScalar" => TSNumberKeyword ^-> TSThisType
            "setAxisAngleFromQuaternion" => Quaternion ^-> TSThisType
            "setAxisAngleFromRotationMatrix" => Matrix4 ^-> TSThisType
            "min" => Vector4 ^-> TSThisType
            "max" => Vector4 ^-> TSThisType
            "clamp" => Vector4 * Vector4 ^-> TSThisType
            "clampScalar" => TSNumberKeyword * TSNumberKeyword ^-> TSThisType
            "floor" => T<unit> ^-> TSThisType
            "ceil" => T<unit> ^-> TSThisType
            "round" => T<unit> ^-> TSThisType
            "roundToZero" => T<unit> ^-> TSThisType
            "negate" => T<unit> ^-> TSThisType
            "dot" => Vector4 ^-> TSNumberKeyword
            "lengthSq" => T<unit> ^-> TSNumberKeyword
            "length" => T<unit> ^-> TSNumberKeyword
            "manhattanLength" => T<unit> ^-> TSNumberKeyword
            "normalize" => T<unit> ^-> TSThisType
            "setLength" => TSNumberKeyword ^-> TSThisType
            "lerp" => Vector4 * TSNumberKeyword ^-> TSThisType
            "lerpVectors" => Vector4 * Vector4 * TSNumberKeyword ^-> TSThisType
            "equals" => Vector4 ^-> TSBooleanKeyword
            "fromArray" => TSUnionType * !?TSNumberKeyword ^-> TSThisType
            "toArray" => !?TSArrayType * !?TSNumberKeyword ^-> TSArrayType
            "toArray" => !?Vector4 * !?TSLiteralType ^-> Vector4
            //"toArray" => ArrayLike * !?TSNumberKeyword ^-> ArrayLike
            "fromBufferAttribute" => BufferAttribute * TSNumberKeyword ^-> TSThisType
            "random" => T<unit> ^-> TSThisType
        ]
        |> ignore
    
    
    CubicInterpolant
        |+> Static [
            Constructor (TSAnyKeyword * TSAnyKeyword * TSNumberKeyword * !?TSAnyKeyword)
        ]
        |+> Instance [
            
    
            "interpolate_" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    DiscreteInterpolant
        |+> Static [
            Constructor (TSAnyKeyword * TSAnyKeyword * TSNumberKeyword * !?TSAnyKeyword)
        ]
        |+> Instance [
            
    
            "interpolate_" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    LinearInterpolant
        |+> Static [
            Constructor (TSAnyKeyword * TSAnyKeyword * TSNumberKeyword * !?TSAnyKeyword)
        ]
        |+> Instance [
            
    
            "interpolate_" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    QuaternionLinearInterpolant
        |+> Static [
            Constructor (TSAnyKeyword * TSAnyKeyword * TSNumberKeyword * !?TSAnyKeyword)
        ]
        |+> Instance [
            
    
            "interpolate_" => TSNumberKeyword * TSNumberKeyword * TSNumberKeyword * TSNumberKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    Bone
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isBone" =? TSLiteralType 
            "type" =? TSUnionType 
    
            
        ]
        |> ignore
    
    
    Group
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isGroup" =? TSLiteralType 
            "type" =? TSUnionType 
    
            
        ]
        |> ignore
    
    
    InstancedMesh
        |+> Static [
            Constructor (TSUnionType * TSUnionType * TSNumberKeyword)
        ]
        |+> Instance [
            "isInstancedMesh" =? TSLiteralType 
            "boundingBox" =@ TSUnionType 
            "boundingSphere" =@ TSUnionType 
            "count" =@ TSNumberKeyword 
            "instanceColor" =@ TSUnionType 
            "instanceMatrix" =@ InstancedBufferAttribute 
            "morphTexture" =@ TSUnionType 
    
            "computeBoundingBox" => T<unit> ^-> TSVoidKeyword
            "computeBoundingSphere" => T<unit> ^-> TSVoidKeyword
            "getColorAt" => TSNumberKeyword * Color ^-> TSVoidKeyword
            "setColorAt" => TSNumberKeyword * Color ^-> TSVoidKeyword
            "getMatrixAt" => TSNumberKeyword * Matrix4 ^-> TSVoidKeyword
            "getMorphAt" => TSNumberKeyword * Mesh ^-> TSVoidKeyword
            "setMatrixAt" => TSNumberKeyword * Matrix4 ^-> TSVoidKeyword
            "setMorphAt" => TSNumberKeyword * Mesh ^-> TSVoidKeyword
            "updateMorphTargets" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSThisType
        ]
        |> ignore
    
    
    Line
        |=> Inherits Object3D
        |+> Static [
            Constructor (!?BufferGeometry * !?Material)
        ]
        |+> Instance [
            "isLine" =? TSLiteralType 
            "type" =? TSUnionType 
            "geometry" =@ BufferGeometry 
            "material" =@ Material 
            "morphTargetInfluences" =@ TSUnionType 
            "morphTargetDictionary" =@ TSUnionType 
    
            "computeLineDistances" => T<unit> ^-> TSThisType
            "updateMorphTargets" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    LineLoop
        |=> Inherits Line
        |+> Instance [
            "isLineLoop" =? TSLiteralType 
            "type" =? TSUnionType 
    
            
        ]
        |> ignore
    
    
    LineSegments
        |=> Inherits Line
        |+> Instance [
            "isLineSegments" =? TSLiteralType 
            "type" =? TSUnionType
        ]
        |> ignore
    
    
    LOD
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isLOD" =? TSLiteralType 
            "type" =? TSUnionType 
            "levels" =@ !|T<obj> 
            "autoUpdate" =@ TSBooleanKeyword 
    
            "addLevel" => Object3D * !?TSNumberKeyword * !?TSNumberKeyword ^-> TSThisType
            "getCurrentLevel" => T<unit> ^-> TSNumberKeyword
            "getObjectForDistance" => TSNumberKeyword ^-> TSUnionType
            "update" => Camera ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    Mesh
        |=> Inherits Object3D
        |+> Static [
            Constructor (!?BufferGeometry * !?Material)
        ]
        |+> Instance [
            "isMesh" =? TSLiteralType 
            "type" =? TSUnionType 
            "geometry" =@ BufferGeometry 
            "material" =@ Material 
            "morphTargetInfluences" =@ TSUnionType 
            "morphTargetDictionary" =@ TSUnionType 
    
            "updateMorphTargets" => T<unit> ^-> TSVoidKeyword
            "getVertexPosition" => TSNumberKeyword * Vector3 ^-> Vector3
        ]
        |> ignore
    
    
    Points
        |=> Inherits Object3D
        |+> Static [
            Constructor (!?BufferGeometry * !?Material)
        ]
        |+> Instance [
            "isPoints" =? TSLiteralType 
            "type" =? TSUnionType 
            "morphTargetInfluences" =@ TSUnionType 
            "morphTargetDictionary" =@ TSUnionType 
            "geometry" =@ BufferGeometry 
            "material" =@ Material 
    
            "updateMorphTargets" => T<unit> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    Skeleton
        |+> Static [
            Constructor (!?TSArrayType * !?TSArrayType)
        ]
        |+> Instance [
            "uuid" =@ TSStringKeyword 
            "bones" =@ TSArrayType 
            "boneInverses" =@ TSArrayType 
            "boneMatrices" =@ Float32Array 
            "boneTexture" =@ TSUnionType 
            "frame" =@ TSNumberKeyword 
    
            "init" => T<unit> ^-> TSVoidKeyword
            "calculateInverses" => T<unit> ^-> TSVoidKeyword
            "computeBoneTexture" => T<unit> ^-> TSThisType
            "pose" => T<unit> ^-> TSVoidKeyword
            "update" => T<unit> ^-> TSVoidKeyword
            "clone" => T<unit> ^-> TSelf
            "getBoneByName" => TSStringKeyword ^-> TSUnionType
            "dispose" => T<unit> ^-> TSVoidKeyword
            "toJSON" => T<unit> ^-> T<obj>
            "fromJSON" => T<obj> * T<obj> ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    SkinnedMesh
        |=> Inherits Mesh
        |+> Instance [
            "isSkinnedMesh" =? TSLiteralType 
            "type" =? TSUnionType 
            "bindMode" =@ T<string> 
            "bindMatrix" =@ Matrix4 
            "bindMatrixInverse" =@ Matrix4 
            "boundingBox" =@ Box3 
            "boundingSphere" =@ Sphere 
            "skeleton" =@ Skeleton 
    
            "bind" => Skeleton * !?Matrix4 ^-> TSVoidKeyword
            "computeBoundingBox" => T<unit> ^-> TSVoidKeyword
            "computeBoundingSphere" => T<unit> ^-> TSVoidKeyword
            "pose" => T<unit> ^-> TSVoidKeyword
            "normalizeSkinWeights" => T<unit> ^-> TSVoidKeyword
            "applyBoneTransform" => TSNumberKeyword * Vector3 ^-> Vector3
        ]
        |> ignore
    
    
    Sprite
        |+> Static [
            Constructor (!?SpriteMaterial)
        ]
        |+> Instance [
            "isSprite" =? TSLiteralType 
            "type" =? TSUnionType 
            "castShadow" =@ TSLiteralType 
            "geometry" =@ BufferGeometry 
            "material" =@ SpriteMaterial 
            "center" =@ Vector2 
    
            
        ]
        |> ignore
    
    
    WebGLRenderTarget
        |+> Static [
            Constructor (!?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isWebGLRenderTarget" =? TSLiteralType 
    
            
        ]
        |> ignore

    
    
    WebXRManager
        |+> Instance [
            "enabled" =@ TSBooleanKeyword 
            "isPresenting" =@ TSBooleanKeyword 
            "cameraAutoUpdate" =@ TSBooleanKeyword 
    
            "getController" => TSNumberKeyword ^-> Group
            "getControllerGrip" => TSNumberKeyword ^-> Group
            "getHand" => TSNumberKeyword ^-> Group
            "setFramebufferScaleFactor" => TSNumberKeyword ^-> TSVoidKeyword
            "setReferenceSpaceType" => T<string> ^-> TSVoidKeyword
            "getReferenceSpace" => T<unit> ^-> TSUnionType
            "setReferenceSpace" => T<obj> ^-> TSVoidKeyword
            "getBaseLayer" => T<unit> ^-> TSUnionType
            "getCamera" => T<unit> ^-> ArrayCamera
            "updateCamera" => PerspectiveCamera ^-> TSVoidKeyword
            "getFoveation" => T<unit> ^-> TSUnionType
            "setFoveation" => TSNumberKeyword ^-> TSVoidKeyword
        ]
        |> ignore
    
    
    Fog
        |+> Static [
            Constructor (T<int> * !?TSNumberKeyword * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isFog" =? TSLiteralType 
            "name" =@ TSStringKeyword 
            "color" =@ Color 
            "near" =@ TSNumberKeyword 
            "far" =@ TSNumberKeyword 
    
            "clone" => T<unit> ^-> TSelf
            "toJSON" => T<unit> ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    FogExp2
        |+> Static [
            Constructor (T<int> * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isFogExp2" =? TSLiteralType 
            "name" =@ TSStringKeyword 
            "color" =@ Color 
            "density" =@ TSNumberKeyword 
    
            "clone" => T<unit> ^-> TSelf
            "toJSON" => T<unit> ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    Scene
        |=> Inherits Object3D
        |+> Static [
            Constructor (T<unit>)
        ]
        |+> Instance [
            "isScene" =? TSLiteralType 
            "type" =@ TSLiteralType 
            "fog" =@ TSUnionType 
            "backgroundBlurriness" =@ TSNumberKeyword 
            "backgroundIntensity" =@ TSNumberKeyword 
            "overrideMaterial" =@ TSUnionType 
            "background" =@ TSUnionType 
            "backgroundRotation" =@ Euler 
            "environment" =@ TSUnionType 
            "environmentIntensity" =@ TSNumberKeyword 
            "environmentRotation" =@ Euler 
    
            "toJSON" => !?TSAnyKeyword ^-> TSAnyKeyword
        ]
        |> ignore
    
    
    
    CanvasTexture
        |+> Static [
            Constructor (TSUnionType * !?MappingMode * !?WrappingMode * !?WrappingMode * !?MagnificationFilter * !?MinificationFilter * !?TextureFormat * !?TextureType * !?TSNumberKeyword)
        ]
        |+> Instance [
            "isCanvasTexture" =? TSLiteralType
        ]
        |> ignore
    
    
    //CompressedCubeTexture
    //    |+> Static [
    //        Constructor (Array * !?CompressedPixelFormat * !?TextureDataType)
    //    ]
    //    |+> Instance [
    //        "isCompressedCubeTexture" =? TSLiteralType 
    //        "isCubeTexture" =? TSLiteralType 
    //    ]
    
    
    
    FramebufferTexture
        |+> Static [
            Constructor (TSNumberKeyword * TSNumberKeyword)
        ]
        |+> Instance [
            "isFramebufferTexture" =? TSLiteralType 
            "magFilter" =@ MagnificationFilter 
            "minFilter" =@ MinificationFilter 
            "generateMipmaps" =@ TSBooleanKeyword 
        ]
        |> ignore
    
    // Constants
    THREE
    |> ImportDefault "three"
    |=> Nested [
        AnimationClip
        AnimationMixer
        AnimationObjectGroup
        KeyframeTrack
        PropertyBinding
        PropertyMixer
        BooleanKeyframeTrack
        ColorKeyframeTrack
        NumberKeyframeTrack
        QuaternionKeyframeTrack
        StringKeyframeTrack
        VectorKeyframeTrack
        Audio
        AudioAnalyser
        AudioListener
        PositionalAudio
        ArrayCamera
        Camera
        CubeCamera
        OrthographicCamera
        PerspectiveCamera
        StereoCamera
        BufferGeometry
        Clock
        EventDispatcher
        InstancedBufferAttribute
        InstancedBufferGeometry
        InstancedInterleavedBuffer
        Layers
        Object3D
        Raycaster
        Uniform
        PMREMGenerator
        Curve
        CurvePath
        Path
        Shape
        ShapePath
        BoxGeometry
        CapsuleGeometry
        CircleGeometry
        ConeGeometry
        CylinderGeometry
        DodecahedronGeometry
        EdgesGeometry
        ExtrudeGeometry
        IcosahedronGeometry
        LatheGeometry
        OctahedronGeometry
        PlaneGeometry
        PolyhedronGeometry
        RingGeometry
        ShapeGeometry
        SphereGeometry
        TetrahedronGeometry
        TorusGeometry
        TorusKnotGeometry
        TubeGeometry
        WireframeGeometry
        ArrowHelper
        AxesHelper
        Box3Helper
        BoxHelper
        CameraHelper
        DirectionalLightHelper
        GridHelper
        HemisphereLightHelper
        PlaneHelper
        PointLightHelper
        PolarGridHelper
        SpotLightHelper
        AmbientLight
        DirectionalLight
        DirectionalLightShadow
        HemisphereLight
        Light
        LightProbe
        LightShadow
        PointLight
        RectAreaLight
        SpotLight
        SpotLightShadow
        AnimationLoader
        AudioLoader
        BufferGeometryLoader
        CompressedTextureLoader
        CubeTextureLoader
        DataTextureLoader
        FileLoader
        ImageBitmapLoader
        ImageLoader
        Loader
        MaterialLoader
        ObjectLoader
        TextureLoader
        LineBasicMaterial
        LineDashedMaterial
        MeshBasicMaterial
        MeshDepthMaterial
        MeshDistanceMaterial
        MeshLambertMaterial
        MeshMatcapMaterial
        MeshNormalMaterial
        MeshPhongMaterial
        MeshStandardMaterial
        MeshToonMaterial
        PointsMaterial
        RawShaderMaterial
        ShaderMaterial
        ShadowMaterial
        SpriteMaterial
        Box2
        Box3
        Cylindrical
        Euler
        Frustum
        Interpolant
        Line3
        Matrix3
        Matrix4
        Plane
        Quaternion
        Ray
        Sphere
        Spherical
        SphericalHarmonics3
        Triangle
        Vector2
        Vector3
        Vector4
        CubicInterpolant
        DiscreteInterpolant
        LinearInterpolant
        QuaternionLinearInterpolant
        Bone
        Group
        InstancedMesh
        Line
        LineLoop
        LineSegments
        LOD
        Mesh
        Points
        Skeleton
        SkinnedMesh
        Sprite
        WebGLRenderTarget
        WebGLProgram
        WebXRManager
        Fog
        FogExp2
        Scene
        CanvasTexture
        CompressedCubeTexture
        FramebufferTexture
        CompressedTexture
        DataTexture
        AnimationAction
        WebGLRenderer
        Color
        Texture
        Source
        Material
        LoadingManager
        CubeTexture
        BufferAttribute
        CatmullRomCurve3
    ]
    |+> Static [

        "REVISION" =? T<string>

        "NoColorSpace" =? T<string>
        "SRGBColorSpace" =? T<string>
        "LinearSRGBColorSpace" =? T<string>

        //"MOUSE" =? MOUSEBBUTTONS
        //"TOUCH" =? TOUCHACTIONS    
    ]
    |> ignore

    let OrbitControls =
        Class "OrbitControls"
        |> Import "OrbitControls" "three/addons/controls/OrbitControls"
        |=> Inherits Object3D
        |+> Static [
            Constructor (Camera * T<WebSharper.JavaScript.HTMLElement>)
        ]
        |+> Instance [
            "object" =@ Camera
            "domElement" =@ TSUnionType
            "enabled" =@ TSBooleanKeyword
            "target" =@ Vector3
            "center" =@ Vector3
            "cursor" =@ Vector3
            "minDistance" =@ TSNumberKeyword
            "maxDistance" =@ TSNumberKeyword
            "minZoom" =@ TSNumberKeyword
            "maxZoom" =@ TSNumberKeyword
            "minTargetRadius" =@ TSNumberKeyword
            "maxTargetRadius" =@ TSNumberKeyword
            "minPolarAngle" =@ TSNumberKeyword
            "maxPolarAngle" =@ TSNumberKeyword
            "minAzimuthAngle" =@ TSNumberKeyword
            "maxAzimuthAngle" =@ TSNumberKeyword
            "enableDamping" =@ TSBooleanKeyword
            "dampingFactor" =@ TSNumberKeyword
            "enableZoom" =@ TSBooleanKeyword
            "zoomSpeed" =@ TSNumberKeyword
            "zoomToCursor" =@ TSBooleanKeyword
            "enableRotate" =@ TSBooleanKeyword
            "rotateSpeed" =@ TSNumberKeyword
            "enablePan" =@ TSBooleanKeyword
            "panSpeed" =@ TSNumberKeyword
            "screenSpacePanning" =@ TSBooleanKeyword
            "keyPanSpeed" =@ TSNumberKeyword
            "autoRotate" =@ TSBooleanKeyword
            "autoRotateSpeed" =@ TSNumberKeyword
            "keys" =@ TSTypeLiteral
            "mouseButtons" =@ TSTypeLiteral
            "touches" =@ TSTypeLiteral
            "target0" =@ Vector3
            "position0" =@ Vector3
            "zoom0" =@ TSNumberKeyword
    
            "update" => !?TSNumberKeyword ^-> TSBooleanKeyword
            "listenToKeyEvents" => TSUnionType ^-> TSVoidKeyword
            "stopListenToKeyEvents" => T<unit> ^-> TSVoidKeyword
            "saveState" => T<unit> ^-> TSVoidKeyword
            "reset" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
            "getPolarAngle" => T<unit> ^-> TSNumberKeyword
            "getAzimuthalAngle" => T<unit> ^-> TSNumberKeyword
            "getDistance" => T<unit> ^-> TSNumberKeyword
        ]

    let TransformControls =
        Class "TransformControls"
        |> Import "TransformControls" "three/addons/controls/TransformControls"
        |=> Inherits Object3D
        |+> Static [
            Constructor (Camera * !?T<WebSharper.JavaScript.HTMLElement>)
        ]
        |+> Instance [
            "domElement" =@ T<WebSharper.JavaScript.HTMLElement>
            "camera" =@ Camera
            "object" =@ TSUnionType
            "enabled" =@ TSBooleanKeyword
            "axis" =@ TSUnionType
            "mode" =@ TSUnionType
            "translationSnap" =@ TSUnionType
            "rotationSnap" =@ TSUnionType
            "space" =@ TSUnionType
            "size" =@ TSNumberKeyword
            "dragging" =@ TSBooleanKeyword
            "showX" =@ TSBooleanKeyword
            "showY" =@ TSBooleanKeyword
            "showZ" =@ TSBooleanKeyword
            "isTransformControls" =? TSLiteralType
            "mouseButtons" =@ TSTypeLiteral
    
            "pointerHover" => TSUnionType ^-> TSVoidKeyword
            "pointerDown" => TSUnionType ^-> TSVoidKeyword
            "pointerMove" => TSUnionType ^-> TSVoidKeyword
            "pointerUp" => TSUnionType ^-> TSVoidKeyword
            "attach" => Object3D ^-> TSThisType
            "detach" => T<unit> ^-> TSThisType
            "getMode" => T<unit> ^-> TSUnionType
            "getRaycaster" => T<unit> ^-> Raycaster
            "setMode" => TSUnionType ^-> TSVoidKeyword
            "setTranslationSnap" => TSUnionType ^-> TSVoidKeyword
            "setRotationSnap" => TSUnionType ^-> TSVoidKeyword
            "setScaleSnap" => TSUnionType ^-> TSVoidKeyword
            "setSize" => TSNumberKeyword ^-> TSVoidKeyword
            "setSpace" => TSUnionType ^-> TSVoidKeyword
            "reset" => T<unit> ^-> TSVoidKeyword
            "dispose" => T<unit> ^-> TSVoidKeyword
        ]



    let Assembly =
        Assembly [
            Namespace "WebSharper.ThreeJS" [
                THREE
                LoopMode
                InterpolationMode
                EndingMode
                AnimationBlendMode
                ColorSpace
                BlendingEquations
                SourceFactors
                DestinationFactors
                GeometryUsage
                Side
                BlendingMode
                DepthMode
                TextureCombineOperation
                StencilFunctions
                StencilOperations
                NormalMapType
                CullFaceMode
                BasicShadowMap
                ToneMapping
                MappingMode
                WrappingMode
                MagnificationFilter
                MinificationFilter
                TextureType
                TextureFormat
                DDSST3CCompressedTextureFormat
                PVRTCCompressedTextureFormat
                ETCCompressedTextureFormat
                ASTCCompressedTextureFormat
                BPTCCompressedTextureFormat
                TextureComparison
                InternalFormat
                DepthPacking
                BufferGeometryGroup
                EulerOrder
                OrbitControls
                TransformControls
            ]
        ]

[<Sealed>]
type Extension () =
    interface IExtension with
        member x.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
