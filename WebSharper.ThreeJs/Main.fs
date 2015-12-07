namespace ThreeJs

open WebSharper.InterfaceGenerator

module Definition =
    let O = T<unit>

    open WebSharper.InterfaceGenerator.Type

    let Vector3    = Class "THREE.Vector3"
    let Euler      = Class "THREE.Euler"
    let Quaternion = Class "THREE.Quaternion"
    let Matrix4    = Class "THREE.Matrix4"

    let EventDispatcher =
        Class "THREE.EventDispatcher"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "apply"               => T<obj>?``object`` ^-> O
            "addEventListener"    => T<string>?``type`` * (T<obj> ^-> O)?listener ^-> O
            "hasEventListener"    => T<string>?``type`` * (T<obj> ^-> O)?listener ^-> T<bool>
            "removeEventListener" => T<string>?``type`` * (T<obj> ^-> O)?listener ^-> O
            "dispatchEvent"       => T<string>?``type`` ^-> O
        ]

    let Object3D =
        Class "THREE.Object3D"
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"                     =? T<int>
            "uuid"                   =? T<string>
            "name"                   =@ T<string>
            "parent"                 =@ TSelf
            "children"               =@ ArrayOf TSelf
            "up"                     =@ Vector3
            "position"               =@ Vector3
            "rotation"               =@ Euler
            "quaternion"             =@ Quaternion
            "scale"                  =@ Vector3
            "renderDepth"            =@ T<float>
            "rotationAutoUpdate"     =@ T<bool>
            "matrix"                 =@ Matrix4
            "matrixWorld"            =@ Matrix4
            "matrixAutoUpdate"       =@ T<bool>
            "matrixWorldNeedsUpdate" =@ T<bool>
            "visible"                =@ T<bool>
            "castShadow"             =@ T<bool>
            "receiveShadow"          =@ T<bool>
            "frustumCulled"          =@ T<bool>
            "userData"               =@ T<obj>

            "applyMatrix"               => Matrix4?matrix ^-> O
            "setRotationFromAxisAngle"  => Vector3?axis * T<float>?angle ^-> O
            "setRotationFromEuler"      => Euler?euler ^-> O
            "setRotationFromMatrix"     => Matrix4?m ^-> O
            "setRotationFromQuaternion" => Quaternion?q ^-> O
            "rotateOnAxis"              => Vector3?axis * T<float>?angle ^-> TSelf
            "rotateX"                   => T<float>?angle ^-> TSelf
            "rotateY"                   => T<float>?angle ^-> TSelf
            "rotateZ"                   => T<float>?angle ^-> TSelf
            "translateOnAxis"           => Vector3?axis * T<float>?distance ^-> TSelf
            "translateX"                => T<float>?distance ^-> TSelf
            "translateY"                => T<float>?distance ^-> TSelf
            "translateZ"                => T<float>?distance ^-> TSelf
            "localToWorld"              => Vector3?vector ^-> Vector3
            "worldToLocal"              => Vector3?vector ^-> Vector3
            "lookAt"                    => Vector3?vector ^-> O
            "add"                       => TSelf?``object`` ^-> O
            "remove"                    => TSelf?``object`` ^-> O
            "traverse"                  => (TSelf ^-> O)?callback ^-> O
            "getObjectById"             => T<int>?id * T<bool>?``recursive`` ^-> TSelf
            "getObjectByName"           => T<string>?name * T<bool>?``recursive`` ^-> TSelf
            "getDescendants"            => !? (ArrayOf TSelf)?array ^-> ArrayOf TSelf
            "updateMatrix"              => O ^-> O
            "updateMatrixWorld"         => T<bool>?force ^-> O
            "clone"                     => !? TSelf?``object`` * !? T<bool>?``recursive`` ^-> TSelf
        ]

    let Camera =
        Class "THREE.Camera"
        |=> Inherits Object3D
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "matrixWorldInverse" =@ Matrix4
            "projectionMatrix"   =@ Matrix4
            
            "lookAt" => Vector3?vector ^-> O
            "clone"  => !? TSelf?camera ^-> TSelf
        ]
    
    let OrthographicCamera =
        Class "THREE.OrthographicCamera"
        |=> Inherits Camera
        |+> Static [
            Constructor (T<float>?left * T<float>?right * T<float>?top * T<float>?bottom * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "left"   =@ T<float>
            "right"  =@ T<float>
            "top"    =@ T<float>
            "bottom" =@ T<float>
            "near"   =@ T<float>
            "far"    =@ T<float>

            "updateProjectionMatrix" => O ^-> O
            "clone"                  => O ^-> TSelf
        ]
    
    let PerspectiveCamera =
        Class "THREE.PerspectiveCamera"
        |=> Inherits Camera
        |+> Static [
            Constructor (!? T<float>?fov * !? T<float>?aspect * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "fov"    =@ T<float>
            "aspect" =@ T<float>
            "near"   =@ T<float>
            "far"    =@ T<float>

            "setLens"                => T<float>?focalLength * !? T<float>?frameHeight ^-> O
            "setViewOffset"          => T<float>?fullWidth * T<float>?fullHeight * T<float>?x * T<float>?y * T<float>?width * T<float>?height ^-> O
            "updateProjectionMatrix" => O ^-> O
            "clone"                  => O ^-> TSelf
        ]

    let BufferAttribute =
        Class "THREE.BufferAttribute"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "length" =? T<int>

            "set"     => T<obj>?value ^-> O
            "setX"    => T<int>?index * T<obj>?x ^-> O
            "setY"    => T<int>?index * T<obj>?y ^-> O
            "setZ"    => T<int>?index * T<obj>?z ^-> O
            "setXY"   => T<int>?index * T<obj>?x * T<obj>?y ^-> O
            "setXYZ"  => T<int>?index * T<obj>?x * T<obj>?y * T<obj>?z ^-> O
            "setXYZW" => T<int>?index * T<obj>?x * T<obj>?y * T<obj>?z * T<obj>?w ^-> O
        ]

    let Box3            = Class "THREE.Box3"
    let Sphere          = Class "THREE.Sphere"
    
    open WebSharper

    let BufferGeometry =
        Class "THREE.BufferGeometry"
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"             =? T<int>
            "uuid"           =? T<string>
            "name"           =@ T<string>
            "attributes"     =@ T<obj>
            "offsets"        =@ ArrayOf T<obj>
            "boundingBox"    =@ Box3
            "boundingSphere" =@ Sphere
            
            "addAttribute"          => (T<string> + T<int>)?name * T<obj>?attribute ^-> O
            "getAttribute"          => (T<string> + T<int>)?name ^-> T<obj>
            "applyMatrix"           => Matrix4?matrix ^-> O
            "computeBoundingBox"    => O ^-> O
            "computeBoundingSphere" => O ^-> O
            "computeVertexNormals"  => O ^-> O
            "computeTangents"       => O ^-> O
            "computeOffsets"        => !? T<int>?indexBufferSize ^-> ArrayOf T<obj>
            
            "merge"                 => O ^-> O
            |> WithComment "Does not implemented yet!"
            
            "normalizeNormals"      => O ^-> O
            "reorderBuffers"        => T<JavaScript.Uint16Array>?indexBuffer * T<JavaScript.Int32Array>?indexMap * T<int>?vertexCount ^-> O
            "clone"                 => O ^-> TSelf
            "dispose"               => O ^-> O
            
        ]
    
    let Clock =
        Class "THREE.Clock"
        |+> Static [
            Constructor !? T<bool>?autoStart
        ]
        |+> Instance [
            "autoStart"   =@ T<bool>
            "startTime"   =@ T<int>
            "oldTime"     =@ T<int>
            "elapsedTime" =@ T<float>
            "running"     =@ T<bool>

            "start"          => O ^-> O
            "stop"           => O ^-> O
            "getElapsedTime" => O ^-> T<float>
            "getDelta"       => O ^-> T<float>
        ]
    
    let HSL =
        Pattern.Config "HSL" {
            Required = []
            Optional =
            [
                "h", T<float>
                "s", T<float>
                "l", T<float>
            ]
        }
    
    let ColorClass =
        Class "THREE.Color"
        |+> Static [
            Constructor (T<int>?r * T<int>?g * T<int>?b)
            Constructor (TSelf + T<int> + T<string>)?value
        ]
        |+> Instance [
            "r" =@ T<int>
            "g" =@ T<int>
            "b" =@ T<int>

            "set"                  => (TSelf + T<int> + T<string>)?value ^-> TSelf
            "setHex"               => T<int>?hex ^-> TSelf
            "setRGB"               => T<int>?r * T<int>?g * T<int>?b ^-> TSelf
            "setHSL"               => T<float>?h * T<float>?s * T<float>?l ^-> TSelf
            "setStyle"             => T<string>?style ^-> TSelf
            "copy"                 => TSelf?color ^-> TSelf
            "copyGammaToLinear"    => TSelf?color ^-> TSelf
            "copyLinearToGamma"    => TSelf?color ^-> TSelf
            "convertGammaToLinear" => O ^-> TSelf
            "convertLinearToGamma" => O ^-> TSelf
            "getHex"               => O ^-> T<int>
            "getHexString"         => O ^-> T<string>
            "getHSL"               => !? HSL?optionalTarget ^-> HSL
            "getStyle"             => O ^-> T<string>
            "offsetHSL"            => T<float>?h * T<float>?s * T<float>?l ^-> TSelf
            "add "                 => TSelf?color ^-> TSelf
            "addColors"            => TSelf?color1 * TSelf?color2 ^-> TSelf
            "addScalar"            => T<int>?s ^-> TSelf
            "multiply"             => TSelf?color ^-> TSelf
            "multiplyScalar"       => T<int>?s ^-> TSelf
            "lerp"                 => TSelf?color * T<float>?alpha ^-> TSelf
            "equals"               => TSelf?c ^-> T<bool>
            "fromArray"            => Tuple [T<int>; T<int>; T<int>] ^-> TSelf
            "toArray"              => O ^-> Tuple [T<int>; T<int>; T<int>]
            "clone"                => O ^-> TSelf
        ]
    
    let Face3 =
        Class "THREE.Face3"
        |+> Static [
            Constructor (T<int>?a * T<int>?b * T<int>?c * !? Vector3?normal * !? ColorClass?color * !? T<int>?materialIndex)
        ]
        |+> Instance [
            "a"              =@ T<int>
            "b"              =@ T<int>
            "c"              =@ T<int>
            "normal"         =@ Vector3
            "vertexNormals"  =@ Tuple [Vector3; Vector3; Vector3]
            "color"          =@ ColorClass
            "vertexColors"   =@ Tuple [ColorClass; ColorClass; ColorClass]
            "vertexTangents" =@ Tuple [T<float>; T<float>; T<float>]
            "materialIndex"  =@ T<int>

            "clone" => O ^-> TSelf
        ]
    
    let MorphTarget =
        Pattern.Config "MorphTarget" {
            Required = []
            Optional =
            [
                "name"    , T<string>
                "vertices", ArrayOf Vector3
            ]
        }

    let MorphColor =
        Pattern.Config "MorphColor" {
            Required = []
            Optional =
            [
                "name"  , T<string>
                "colors", ArrayOf ColorClass
            ]
        }

    let MorphNormal =
        Pattern.Config "MorphNormal" {
            Required = []
            Optional =
            [
                "name"    , T<string>
                "vertices", ArrayOf Vector3
            ]
        }
    
    let Matrix3 = Class "THREE.Matrix3"

    let Geometry =
        Class "THREE.Geometry"
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"                      =? T<int>
            "uuid"                    =? T<string>
            "name"                    =@ T<string>
            "vertices"                =@ ArrayOf Vector3
            "colors"                  =@ ArrayOf ColorClass
            "faces"                   =@ ArrayOf Face3
            "faceVertexUvs"           =@ ArrayOf (ArrayOf T<obj>)
            "morphTargets"            =@ ArrayOf MorphTarget
            "morphColors"             =@ ArrayOf MorphColor
            "morphNormals"            =@ ArrayOf MorphNormal
            "skinWeights"             =@ ArrayOf T<obj>
            "skinIndices"             =@ ArrayOf T<int>
            "lineDistances"           =@ ArrayOf T<float>
            "boundingBox"             =@ Box3
            "boundingSphere"          =@ Sphere
            "hasTangents"             =@ T<bool>
            "dynamic"                 =@ T<bool>
            "verticesNeedUpdate"      =@ T<bool>
            "elementsNeedUpdate"      =@ T<bool>
            "uvsNeedUpdate"           =@ T<bool>
            "normalsNeedUpdate"       =@ T<bool>
            "tangentsNeedUpdate"      =@ T<bool>
            "colorsNeedUpdate"        =@ T<bool>
            "lineDistancesNeedUpdate" =@ T<bool>
            "buffersNeedUpdate"       =@ T<bool>
            
            "applyMatrix"           => Matrix4?matrix ^-> O
            "computeFaceNormals"    => O ^-> O
            "computeVertexNormals"  => T<bool>?areaWeighted ^-> O
            "computeMorphNormals"   => O ^-> O
            "computeTangents"       => O ^-> O
            "computeLineDistances"  => O ^-> O
            "computeBoundingBox"    => O ^-> O
            "computeBoundingSphere" => O ^-> O
            "merge"                 => TSelf?geometry * !? Matrix3?matrix * !? T<int>?materialIndexOffset ^-> O
            "mergeVertices"         => O ^-> T<int>
            "makeGroups"            => T<bool>?usesFaceMaterial * T<int>?maxVerticesInGroup ^-> O
            "clone"                 => O ^-> TSelf
            "dispose"               => O ^-> O
        ]

    let Raycaster = Class "THREE.Raycaster"
    let Scene = Class "THREE.Scene"

    let Light = Class "THREE.Light"

    let ProjectionData =
        Class "ProjectionData"
        |+> Instance [
            "elements" =@ ArrayOf T<obj>
            "lights"   =@ ArrayOf Light
            "objects"  =@ ArrayOf Object3D
            "sprites"  =@ ArrayOf T<obj>
        ]

    let Projector =
        Class "THREE.Projector"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "projectVector"   => Vector3?vector * Camera?camera ^-> Vector3
            "unprojectVector" => Vector3?vector * Camera?camera ^-> Vector3
            "pickingRay"      => Vector3?vector * Camera?camera ^-> Raycaster
            "projectScene"    => Scene?scene * Camera?camera * T<bool>?sortObjects * T<bool>?sortElements ^-> ProjectionData
        ]

    let Ray = Class "THREE.Ray"

    let Intersection =
        Pattern.Config "Intersection" {
            Required = []
            Optional =
            [
                "distance" , T<float>
                "point"    , Vector3.Type
                "face"     , Face3.Type
                "faceIndex", T<int>
                "object"   , Object3D.Type
            ]
        }

    let Raycaster' =
        Raycaster
        |+> Static [
            Constructor (Vector3?origin * Vector3?direction * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "ray"       =@ Ray
            "near"      =@ T<float>
            "far"       =@ T<float>
            "precision" =@ T<float>
            "linePrecision" =@ T<float>

            "set"              => Vector3?origin * Vector3?direction ^-> O
            "intersectObject"  => Object3D?``object`` * T<bool>?``recursive`` ^-> ArrayOf Intersection
            "intersectObjects" => (ArrayOf Object3D)?objects * T<bool>?``recursive`` ^-> ArrayOf Intersection
        ]
    
    let Color = ColorClass + T<int> + T<string>

    let Light' =
        Light
        |=> Inherits Object3D
        |+> Static [
            Constructor Color?color
        ]
        |+> Instance [
            "color" =@ Color

            "clone" => !? Light?light ^-> Light
        ]
    
    let AmbientLight =
        Class "THREE.AmbientLight"
        |=> Inherits Light
        |+> Static [
            Constructor Color?color
        ]
        |+> Instance [
            "clone" => O ^-> TSelf
        ]

    let AreaLight =
        Class "THREE.AreaLight"
        |=> Inherits Light
        |+> Static [
            Constructor (Color?color * !? T<float>?intensity)
        ]
        |+> Instance [
            "normal"               =@ Vector3
            "right"                =@ Vector3
            "intensity"            =@ T<float>
            "width"                =@ T<float>
            "height"               =@ T<float>
            "constantAttenuation"  =@ T<float>
            "linearAttenuation"    =@ T<float>
            "quadraticAttenuation" =@ T<float>
        ]
    
    let DirectionalLight =
        Class "THREE.DirectionalLight"
        |=> Inherits Light
        |+> Static [
            Constructor (Color?color * !? T<float>?intensity)
        ]
        |+> Instance [
            "target"              =@ Object3D
            "intensity"           =@ T<float>
            "castShadow"          =@ T<bool>
            "onlyShadow"          =@ T<bool>
            "shadowCameraNear"    =@ T<float>
            "shadowCameraFar"     =@ T<float>
            "shadowCameraLeft"    =@ T<float>
            "shadowCameraRight"   =@ T<float>
            "shadowCameraTop"     =@ T<float>
            "shadowCameraBottom"  =@ T<float>
            "shadowCameraVisible" =@ T<bool>
            "shadowBias"          =@ T<float>
            "shadowDarkness"      =@ T<float>
            "shadowMapWidth"      =@ T<float>
            "shadowMapHeight"     =@ T<float>
            "shadowCascade"       =@ T<bool>
            "shadowCascadeOffset" =@ Vector3
            "shadowCascadeCount"  =@ T<int>
            "shadowCascadeBias"   =@ Tuple [T<float>; T<float>; T<float>]
            "shadowCascadeWidth"  =@ Tuple [T<float>; T<float>; T<float>]
            "shadowCascadeHeight" =@ Tuple [T<float>; T<float>; T<float>]
            "shadowCascadeNearZ"  =@ Tuple [T<float>; T<float>; T<float>]
            "shadowCascadeFarZ"   =@ Tuple [T<float>; T<float>; T<float>]
            "shadowCascadeArray"  =@ ArrayOf T<obj>
            "shadowMap"           =@ T<obj>
            "shadowMapSize"       =@ T<float>
            "shadowCamera"        =@ Camera
            "shadowMatrix"        =@ T<obj>

            "clone" => O ^-> TSelf
        ]

    let HemisphereLight =
        Class "THREE.HemisphereLight"
        |=> Inherits Light
        |+> Static [
            Constructor (Color?skyColor * Color?groundColor * !? T<float>?intensity)
        ]
        |+> Instance [
            "groundColor" =@ Color
            "intensity"   =@ T<float>

            "clone" => O ^-> TSelf
        ]
    
    let PointLight =
        Class "THREE.PointLight"
        |=> Inherits Light
        |+> Static [
            Constructor (Color?color * !? T<float>?intensity * !? T<float>?distance)
        ]
        |+> Instance [
            "intensity"   =@ T<float>
            "distance"    =@ T<float>

            "clone" => O ^-> TSelf
        ]
    
    let SpotLight =
        Class "THREE.SpotLight"
        |=> Inherits Light
        |+> Static [
            Constructor (Color?color * !? T<float>?intensity * !? T<float>?distance * !? T<float>?angle * !? T<float>?exponent)
        ]
        |+> Instance [
            "target"              =@ Object3D
            "intensity"           =@ T<float>
            "distance"            =@ T<float>
            "angle"               =@ T<float>
            "exponent"            =@ T<float>
            "castShadow"          =@ T<bool>
            "onlyShadow"          =@ T<bool>
            "shadowCameraNear"    =@ T<float>
            "shadowCameraFar"     =@ T<float>
            "shadowCameraFov"     =@ T<float>
            "shadowCameraVisible" =@ T<bool>
            "shadowBias"          =@ T<float>
            "shadowDarkness"      =@ T<float>
            "shadowMapWidth"      =@ T<float>
            "shadowMapHeight"     =@ T<float>
            "shadowMap"           =@ T<obj>
            "shadowMapSize"       =@ T<float>
            "shadowCamera"        =@ Camera
            "shadowMatrix"        =@ T<obj>

            "clone" => O ^-> TSelf
        ]

    let LoadingManager = Class "THREE.LoadingManager"

    let BufferGeometryLoader =
        Class "THREE.BufferGeometryLoader"
        |+> Static [
            Constructor !? LoadingManager?manager
        ]
        |+> Instance [
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? BufferGeometry ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
            "parse"          => T<obj>?json ^-> BufferGeometry
        ]
    
    let Cache =
        Class "THREE.Cache"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "files" =@ T<obj>

            "add"    => (T<string> + T<int>)?key * T<obj>?file ^-> O
            "get"    => (T<string> + T<int>)?key ^-> O
            "remove" => (T<string> + T<int>)?key ^-> O
            "clear"  => O ^-> O
        ]
    
    open WebSharper.JavaScript.Dom

    let ImageLoader =
        Class "THREE.ImageLoader"
        |+> Static [
            Constructor !? LoadingManager?manager
        ]
        |+> Instance [
            "cache"       =@ Cache
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * !? (!? T<obj> ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> T<Element>
            "setCrossOrigin" => T<string>?value ^-> O
        ]
        
    let Material = Class "THREE.Material"

    let Loader =
        Class "THREE.Loader"
        |+> Static [
            Constructor T<bool>?showStatus
        ]
        |+> Instance [
            "showStatus"       =@ T<bool>
            "statusDomElement" =@ T<Element>
            "imageLoader"      =@ ImageLoader
            "onLoadStart"      =@ (O ^-> O)
            "onLoadProgress"   =@ (O ^-> O)
            "onLoadComplete"   =@ (O ^-> O)
            "crossOrigin"      =@ T<string>

            "addStatusElement" => O ^-> T<Element>
            "updateProgress"   => T<obj>?progress ^-> O
            "extractUrlBase"   => T<string>?url ^-> T<string>
            "initMaterials"    => (ArrayOf Material)?materials * T<string>?texturePath ^-> ArrayOf Material
            "needsTangents"    => (ArrayOf Material)?materials ^-> T<bool>
            "createMaterial"   => Material?m * T<string>?texturePath ^-> Material
        ]

    let JSONLoader =
        Class "THREE.JSONLoader"
        |=> Inherits Loader
        |+> Static [
            Constructor T<bool>?showStatus
        ]
        |+> Instance [
            "withCredentials" =@ T<bool>

            "load"         => T<string>?url * (!? Geometry * !? (ArrayOf Material) ^-> O)?callback * !? T<string>?texturePath ^-> O
            "loadAjaxJSON" => TSelf?context * T<string>?url * (!? Geometry * !? (ArrayOf Material) ^-> O)?callback * T<string>?texturePath * !? (!? T<obj> ^-> O)?callbackProgress ^-> O
            "parse"        => T<obj>?json * T<string>?texturePath ^-> T<obj>
        ]
    
    let LoadingManager' =
        LoadingManager
        |+> Static [
            Constructor (!? (O ^-> O)?onLoad * !? (!? T<string>?url * !? T<int>?loaded * !? T<int>?total ^-> O)?onProgress * !? (O ^-> O)?onError)
        ]
        |+> Instance [
            "onLoad"     =@ (O ^-> O)
            "onProgress" =@ (!? T<string>?url * !? T<int>?loaded * !? T<int>?total ^-> O)
            "onError"    =@ (O ^-> O)

            "itemStart" => T<string>?url ^-> O
            "itemEnd"   => T<string>?url ^-> O
        ]
    
    let MaterialLoader =
        Class "THREE.MaterialLoader"
        |+> Static [
            Constructor !? LoadingManager?manager
        ]
        |+> Static [
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? Material ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
            "parse"          => T<obj>?json ^-> Material
        ]

    let ObjectLoader =
        Class "THREE.ObjectLoader"
        |+> Static [
            Constructor !? LoadingManager?manager
        ]
        |+> Instance [
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"                     => T<string>?url * (!? Object3D ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin"           => T<string>?value ^-> O
            "parse"                    => T<obj>?json ^-> Object3D
            "parseGeometries"          => (ArrayOf T<obj>)?json ^-> T<obj>
            "parseMaterials"           => (ArrayOf T<obj>)?json ^-> T<obj>
            "parseObject"              => T<obj>?data * (ArrayOf Geometry)?geometries * (ArrayOf Material)?materials ^-> Object3D
        ]
    
    let SceneLoader =
        Class "THREE.SceneLoader"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "onLoadStart"         =@ (O ^-> O)
            "onLoadProgress"      =@ (O ^-> O)
            "onLoadComplete"      =@ (O ^-> O)
            "callbackSync"        =@ (!? T<obj> ^-> O)
            "callbackProgress"    =@ (!? T<obj> * !? T<obj> ^-> O)
            "hierarchyHandlers"   =@ T<obj>
            "geometryHandlers"    =@ T<obj>
            "crossOrigin"         =@ T<string>

            "load"                     => T<string>?url * (!? T<obj> ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin"           => T<string>?value ^-> O
            "addGeometryHandler"       => (T<string> + T<int>)?typeID * Loader?loaderClass ^-> O
            "addHierarchyHandler"      => (T<string> + T<int>)?typeID * Loader?loaderClass ^-> O
            "parse"                    => T<obj>?json * (!? T<obj> ^-> O)?callbackFinished * T<string>?url ^-> O
        ]
    
    let Texture = Class "THREE.Texture"

    let TextureLoader =
        Class "THREE.TextureLoader"
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor !? LoadingManager?manager
        ]
        |+> Instance [
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? Texture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
        ]

    let XHRLoader =
        Class "THREE.XHRLoader"
        |+> Static [
            Constructor !? LoadingManager?manager
        ]
        |+> Instance [
            "cache"       =@ Cache
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? T<obj> ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
        ]

    let Material' =
        Material
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"                  =? T<int>
            "uuid"                =? T<string>
            "name"                =@ T<string>
            "side"                =@ T<int>
            "opacity"             =@ T<float>
            "transparent"         =@ T<bool>
            "blending"            =@ T<int>
            "blendSrc"            =@ T<int>
            "blendDst"            =@ T<int>
            "blendEquation"       =@ T<int>
            "depthTest"           =@ T<bool>
            "depthWrite"          =@ T<bool>
            "polygonOffset"       =@ T<bool>
            "polygonOffsetFactor" =@ T<float>
            "polygonOffsetUnits"  =@ T<float>
            "alphaTest"           =@ T<float>
            "overdraw"            =@ T<float>
            "visible"             =@ T<bool>
            "needsUpdate"         =@ T<bool>
            
            "setValues" => T<obj>?values ^-> O
            "clone"     => !? Material?material ^-> Material
            "dispose"   => O ^-> O
        ]

    let LineBasicMaterialConfiguration =
        Pattern.Config "LineBasicMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"       , T<int>
                "opacity"     , T<float>
                "blending"    , T<int>
                "depthTest"   , T<bool>
                "depthWrite"  , T<bool>
                "linewidth"   , T<float>
                "linecap"     , T<string>
                "linejoin"    , T<string>
                "vertexColors", T<bool>
                "fog"         , T<bool>
            ]
        }

    let LineBasicMaterial =
        Class "THREE.LineBasicMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? LineBasicMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"        =@ Color
            "linewidth"    =@ T<float>
            "linecap"      =@ T<string>
            "linejoin"     =@ T<string>
            "vertexColors" =@ T<bool>
            "fog"          =@ T<bool>

            "clone" => O ^-> TSelf
        ]
    
    let LineDashedMaterialConfiguration =
        Pattern.Config "LineDashedMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"       , T<int>
                "opacity"     , T<float>
                "blending"    , T<int>
                "depthTest"   , T<bool>
                "depthWrite"  , T<bool>
                "linewidth"   , T<float>
                "scale"       , T<float>
                "dashSize"    , T<float>
                "gapSize"     , T<float>
                "vertexColors", T<bool>
                "fog"         , T<bool>
            ]
        }

    let LineDashedMaterial =
        Class "THREE.LineDashedMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? LineDashedMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"        =@ Color
            "linewidth"    =@ T<float>
            "scale"        =@ T<float>
            "dashSize"     =@ T<float>
            "gapSize"      =@ T<float>
            "vertexColors" =@ T<bool>
            "fog"          =@ T<bool>

            "clone" => O ^-> TSelf
        ]

    let MeshBasicMaterialConfiguration =
        Pattern.Config "MeshBasicMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"             , T<int>
                "opacity"           , T<float>
                "map"               , Texture.Type
                "lightMap"          , Texture.Type
                "specularMap"       , Texture.Type
                "envMap"            , T<obj>
                "combine"           , T<int>
                "reflectivity"      , T<float>
                "refractionRatio"   , T<float>
                "shading"           , T<int>
                "blending"          , T<int>
                "depthTest"         , T<bool>
                "depthWrite"        , T<bool>
                "wireframe"         , T<bool>
                "wireframeLinewidth", T<float>
                "vertexColors"      , T<int>
                "skinning"          , T<bool>
                "morphTargets"      , T<bool>
                "fog"               , T<bool>
            ]
        }

    let MeshBasicMaterial =
        Class "THREE.MeshBasicMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? MeshBasicMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"              =@ Color
            "map"                =@ Texture
            "lightMap"           =@ Texture
            "specularMap"        =@ Texture
            "envMap"             =@ T<obj>
            "combine"            =@ T<int>
            "reflectivity"       =@ T<float>
            "refractionRatio"    =@ T<float>
            "fog"                =@ T<bool>
            "shading"            =@ T<int>
            "wireframe"          =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "wireframeLinecap"   =@ T<string>
            "wireframeLinejoin"  =@ T<string>
            "vertexColors"       =@ T<int>
            "skinning"           =@ T<bool>
            "morphTargets"       =@ T<bool>
            
            "clone" => O ^-> TSelf
        ]

    let MeshDepthMaterialConfiguration =
        Pattern.Config "MeshDepthMaterialConfiguration" {
            Required = []
            Optional =
            [
                "opacity"           , T<float>
                "blending"          , T<int>
                "depthTest"         , T<bool>
                "depthWrite"        , T<bool>
                "wireframe"         , T<bool>
                "wireframeLinewidth", T<float>
            ]
        }

    let MeshDepthMaterial =
        Class "THREE.MeshDepthMaterial"
        |+> Static [
            Constructor !? MeshDepthMaterialConfiguration?parameters
        ]
        |+> Instance [
            "morphTargets"       =@ T<bool>
            "wireframe"          =@ T<bool>
            "wireframeLinewidth" =@ T<float>

            "clone" => O ^-> TSelf
        ]

    let MeshFaceMaterial =
        Class "THREE.MeshFaceMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? (ArrayOf Material)?materials
        ]
        |+> Static [
            "materials" =@ ArrayOf Material

            "clone" => O ^-> TSelf
        ]

    let MeshLambertMaterialConfiguration =
        Pattern.Config "MeshLambertMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"             , T<int>
                "ambient"           , T<int>
                "emissive"          , T<int>
                "opacity"           , T<float>
                "map"               , Texture.Type
                "lightMap"          , Texture.Type
                "specularMap"       , Texture.Type
                "envMap"            , T<obj>
                "combine"           , T<int>
                "reflectivity"      , T<float>
                "refractionRatio"   , T<float>
                "shading"           , T<int>
                "blending"          , T<int>
                "depthTest"         , T<bool>
                "depthWrite"        , T<bool>
                "wireframe"         , T<bool>
                "wireframeLinewidth", T<float>
                "vertexColors"      , T<int>
                "skinning"          , T<bool>
                "morphTargets"      , T<bool>
                "morphNormals"      , T<bool>
                "fog"               , T<bool>
                "overdraw"          , T<float>
            ]
        }

    let MeshLambertMaterial =
        Class "THREE.MeshLambertMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? MeshLambertMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"              =@ Color
            "ambient"            =@ Color
            "emissive"           =@ Color
            "wrapAround"         =@ T<bool>
            "wrapRGB"            =@ Vector3
            "map"                =@ Texture
            "lightMap"           =@ Texture
            "specularMap"        =@ Texture
            "envMap"             =@ T<obj>
            "combine"            =@ T<int>
            "reflectivity"       =@ T<float>
            "refractionRatio"    =@ T<float>
            "fog"                =@ T<bool>
            "shading"            =@ T<int>
            "wireframe"          =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "wireframeLinecap"   =@ T<string>
            "wireframeLinejoin"  =@ T<string>
            "vertexColors"       =@ T<int>
            "skinning"           =@ T<bool>
            "morphTargets"       =@ T<bool>
            "morphNormals"       =@ T<bool>

            "clone" => O ^-> TSelf
        ]

    let MeshNormalMaterialConfiguration =
        Pattern.Config "MeshNormalMaterialConfiguration" {
            Required = []
            Optional =
            [
                "opacity"           , T<float>
                "shading"           , T<int>
                "blending"          , T<int>
                "depthTest"         , T<bool>
                "depthWrite"        , T<bool>
                "wireframe"         , T<bool>
                "wireframeLinewidth", T<float>
            ]
        }
    
    let MeshNormalMaterial =
        Class "THREE.MeshNormalMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? MeshNormalMaterialConfiguration?parameters
        ]
        |+> Instance [
            "shading"            =@ T<float>
            "wireframe"          =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "morphTargets"       =@ T<bool>
            
            "clone" => O ^-> TSelf
        ]

    let Vector2 = Class "THREE.Vector2"

    let MeshPhongMaterialConfiguration =
        Pattern.Config "MeshPhongMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"             , T<int>
                "ambient"           , T<int>
                "emissive"          , T<int>
                "specular"          , T<int>
                "shininess"         , T<float>
                "opacity"           , T<float>
                "map"               , Texture.Type
                "lightMap"          , Texture.Type
                "bumpMap"           , Texture.Type
                "bumpScale"         , T<float>
                "normalMap"         , Texture.Type
                "normalScale"       , Vector2.Type
                "specularMap"       , Texture.Type
                "envMap"            , T<obj>
                "combine"           , T<int>
                "reflectivity"      , T<float>
                "refractionRatio"   , T<float>
                "shading"           , T<int>
                "blending"          , T<int>
                "depthTest"         , T<bool>
                "depthWrite"        , T<bool>
                "wireframe"         , T<bool>
                "wireframeLinewidth", T<float>
                "vertexColors"      , T<int>
                "skinning"          , T<bool>
                "morphTargets"      , T<bool>
                "morphNormals"      , T<bool>
                "fog"               , T<bool>
            ]
        }

    let MeshPhongMaterial =
        Class "THREE.MeshPhongMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? MeshPhongMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"              =@ Color
            "ambient"            =@ Color
            "emissive"           =@ Color
            "specular"           =@ Color
            "shininess"          =@ T<float>
            "metal"              =@ T<bool>
            "wrapAround"         =@ T<bool>
            "wrapRGB"            =@ Vector3
            "map"                =@ Texture
            "lightMap"           =@ Texture
            "bumpMap"            =@ T<obj>
            "bumpScale"          =@ T<float>
            "normalMap"          =@ T<obj>
            "normalScale"        =@ Vector2
            "specularMap"        =@ Texture
            "envMap"             =@ T<obj>
            "combine"            =@ T<int>
            "reflectivity"       =@ T<float>
            "refractionRatio"    =@ T<float>
            "fog"                =@ T<bool>
            "shading"            =@ T<int>
            "wireframe"          =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "wireframeLinecap"   =@ T<string>
            "wireframeLinejoin"  =@ T<string>
            "vertexColors"       =@ T<int>
            "skinning"           =@ T<bool>
            "morphTargets"       =@ T<bool>
            "morphNormals"       =@ T<bool>

            "clone" => O ^-> TSelf
        ]
    
    let ParticleSystemMaterialConfiguration =
        Pattern.Config "ParticleSystemMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"       , T<int>
                "opacity"     , T<float>
                "map"         , Texture.Type
                "size"        , T<float>
                "blending"    , T<int>
                "depthTest"   , T<bool>
                "depthWrite"  , T<bool>
                "vertexColors", T<bool>
                "fog"         , T<bool>
            ]
        }

    let ParticleSystemMaterial =
        Class "THREE.ParticleSystemMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? ParticleSystemMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"           =@ Color
            "map"             =@ Texture
            "size"            =@ T<float>
            "sizeAttenuation" =@ T<bool>
            "vertexColors"    =@ T<bool>
            "fog"             =@ T<bool>

            "clone" => O ^-> TSelf
        ]

    let ShaderMaterialConfiguration =
        Pattern.Config "ShaderMaterialConfiguration" {
            Required = []
            Optional =
            [
                "fragmentShader"    , T<string>
                "vertexShader"      , T<string>
                "uniforms"          , T<obj>
                "defines"           , T<obj>
                "shading"           , T<int>
                "blending"          , T<int>
                "depthTest"         , T<bool>
                "depthWrite"        , T<bool>
                "wireframe"         , T<bool>
                "wireframeLinewidth", T<float>
                "lights"            , T<bool>
                "vertexColors"      , T<int>
                "skinning"          , T<bool>
                "morphTargets"      , T<bool>
                "morphNormals"      , T<bool>
                "fog"               , T<bool>
            ]
        }

    let DefaultAttributeValues =
        Class "DefaultAttributeValues"
        |+> Instance [
            "color" =@ Tuple [T<float>; T<float>; T<float>]
            "uv"    =@ Tuple [T<float>; T<float>]
            "uv2"   =@ Tuple [T<float>; T<float>]
        ]

    let ShaderMaterial =
        Class "THREE.ShaderMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? ShaderMaterialConfiguration?parameters
        ]
        |+> Instance [
            "fragmentShader"         =@ T<string>
            "vertexShader"           =@ T<string>
            "uniforms"               =@ T<obj>
            "defines"                =@ T<obj>
            "attributes"             =@ T<obj>
            "shading"                =@ T<int>
            "linewidth"              =@ T<float>
            "wireframe"              =@ T<bool>
            "wireframeLinewidth"     =@ T<float>
            "fog"                    =@ T<bool>
            "lights"                 =@ T<bool>
            "vertexColors"           =@ T<float>
            "skinning"               =@ T<bool>
            "morphTargets"           =@ T<bool>
            "morphNormals"           =@ T<bool>
            "defaultAttributeValues" =@ DefaultAttributeValues
                                            
            "index0AttributeName"    =@ T<string>

            "clone" => O ^-> TSelf
        ]

    let RawShaderMaterial =
        Class "THREE.RawShaderMaterial"
        |=> Inherits ShaderMaterial
        |+> Static [
            Constructor !? T<obj>?parameters
        ]
        |+> Instance [
            "clone" => O ^-> TSelf
        ]

    let SpriteCanvasMaterialConfiguration =
        Pattern.Config "SpriteCanvasMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"   , T<int>
                "program" , (T<obj>?context * T<obj>?color ^-> O)
                "opacity" , T<float>
                "blending", T<int>
            ]
        }

    let SpriteCanvasMaterial =
        Class "THREE.SpriteCanvasMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? SpriteCanvasMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"   =@ Color
            "program" =@ (T<obj>?context * T<obj>?color ^-> O)

            "clone" => O ^-> TSelf
        ]
    
    let SpriteMaterialConfiguration =
        Pattern.Config "SpriteMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"     , T<int>
                "opacity"   , T<float>
                "map"       , Texture.Type
                "blending"  , T<int>
                "depthTest" , T<bool>
                "depthWrite", T<bool>
                "uvOffset"  , Vector2.Type
                "uvScale"   , Vector2.Type
                "fog"       , T<bool>
            ]
        }

    let SpriteMaterial =
        Class "THREE.SpriteMaterial"
        |=> Inherits Material
        |+> Static [
            Constructor !? SpriteMaterialConfiguration?parameters
        ]
        |+> Instance [
            "color"    =@ Color
            "map"      =@ Texture
            "rotation" =@ T<float>
            "fog"      =@ T<bool>

            "clone" => O ^-> TSelf
        ]

    let Box2 =
        Class "THREE.Box2"
        |+> Static [
            Constructor (!? Vector2?min * !? Vector2?max)
        ]
        |+> Instance [
            "min" =@ Vector2
            "max" =@ Vector2
            
            "set"                  => Vector2?min * Vector2?max ^-> TSelf
            "setFromPoints"        => (ArrayOf Vector2)?points ^-> TSelf
            "setFromCenterAndSize" => Vector2?center * Vector2?size ^-> TSelf
            "copy"                 => TSelf?box ^-> TSelf
            "makeEmpty"            => O ^-> TSelf
            "empty"                => O ^-> T<bool>
            "center"               => !? Vector2?optionalTarget ^-> Vector2
            "size"                 => !? Vector2?optionalTarget ^-> Vector2
            "expandByPoint"        => Vector2?point ^-> TSelf
            "expandByVector"       => Vector2?vector ^-> TSelf
            "expandByScalar"       => T<float>?scalar ^-> TSelf
            "containsPoint"        => Vector2?point ^-> T<bool>
            "containsBox"          => TSelf?box ^-> T<bool>
            "getParameter"         => Vector2?point * !? Vector2?optionalTarget ^-> Vector2
            "isIntersectionBox"    => TSelf?box ^-> T<bool>
            "clampPoint"           => Vector2?point * !? Vector2?optionalTarget ^-> Vector2
            "distanceToPoint"      => Vector2?point ^-> T<float>
            "intersect"            => TSelf?box ^-> TSelf
            "union"                => TSelf?box ^-> TSelf
            "translate"            => Vector2?offset ^-> TSelf
            "equals"               => TSelf?box ^-> T<bool>
            "clone"                => O ^-> TSelf
        ]
    
    let Box3' =
        Box3
        |+> Static [
            Constructor (!? Vector3?min * !? Vector3?max)
        ]
        |+> Instance [
            "min" =@ Vector3
            "max" =@ Vector3
            
            "set"                  => Vector3?min * Vector3?max ^-> Box3
            "addPoint"             => Vector3?point ^-> Box3
            "setFromPoints"        => (ArrayOf Vector3)?points ^-> Box3
            "setFromCenterAndSize" => Vector3?center * Vector3?size ^-> Box3
            "setFromObject"        => Object3D?``object`` ^-> Box3
            "copy"                 => Box3?box ^-> Box3
            "makeEmpty"            => O ^-> Box3
            "empty"                => O ^-> T<bool>
            "center"               => !? Vector3?optionalTarget ^-> Vector3
            "size"                 => !? Vector3?optionalTarget ^-> Vector3
            "expandByPoint"        => Vector3?point ^-> Box3
            "expandByVector"       => Vector3?vector ^-> Box3
            "expandByScalar"       => T<float>?scalar ^-> Box3
            "containsPoint"        => Vector3?point ^-> T<bool>
            "containsBox"          => Box3?box ^-> T<bool>
            "getParameter"         => Vector3?point * !? Vector3?optionalTarget ^-> Vector3
            "isIntersectionBox"    => Box3?box ^-> T<bool>
            "clampPoint"           => Vector3?point * !? Vector3?optionalTarget ^-> Vector3
            "distanceToPoint"      => Vector3?point ^-> T<float>
            "getBoundingSphere"    => !? Sphere?optionalTarget ^-> Sphere
            "intersect"            => Box3?box ^-> Box3
            "union"                => Box3?box ^-> Box3
            "applyMatrix4"         => Matrix4?matrix ^-> Box3
            "translate"            => Vector3?offset ^-> Box3
            "equals"               => Box3?box ^-> T<bool>
            "clone"                => O ^-> Box3
        ]

    let Euler' =
        Euler
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<string>?order)
        ]
        |+> Instance [
            "x"                =@ T<float>
            "y"                =@ T<float>
            "z"                =@ T<float>
            "order"            =@ T<string>
            "onChangeCallback" =@ (O ^-> O)

            "set"                   => T<float>?x * T<float>?y * T<float>?z * !? T<string>?order ^-> Euler
            "copy"                  => Euler?euler ^-> Euler
            "setFromRotationMatrix" => Matrix4?m * T<string>?order ^-> Euler
            "setFromQuaternion"     => Quaternion?q * !? T<string>?order * !? T<bool>?update ^-> Euler
            "reorder"               => T<string>?newOrder ^-> O
            "equals"                => Euler?euler ^-> T<bool>
            "fromArray"             => (Tuple [T<float>; T<float>; T<float>])?array ^-> Euler
            "fromArray"             => (Tuple [T<float>; T<float>; T<float>; T<string>])?array ^-> Euler
            "toArray"               => O ^-> Tuple [T<float>; T<float>; T<float>; T<string>]
            "onChange"              => (O ^-> O)?callback ^-> Euler
            "clone"                 => O ^-> Euler
        ]

    let Plane = Class "THREE.Plane"

    let Frustum =
        Class "THREE.Frustum"
        |+> Static [
            Constructor (!? Plane?p0 * !? Plane?p1 * !? Plane?p2 * !? Plane?p3 * !? Plane?p4 * !? Plane?p5)
        ]
        |+> Instance [
            "planes" =@ ArrayOf Plane

            "set"              => Plane?p0 * Plane?p1 * Plane?p2 * Plane?p3 * Plane?p4 * Plane?p5 ^-> TSelf
            "copy"             => TSelf?frustum ^-> TSelf
            "setFromMatrix"    => Matrix4?m ^-> TSelf
            "intersectsObject" => Object3D?``object`` ^-> T<bool>
            "intersectsSphere" => Sphere?sphere ^-> T<bool>
            "intersectsBox"    => T<obj>?box ^-> T<bool>
            "containsPoint"    => Vector3?point ^-> T<bool>
            "clone"            => O ^-> TSelf
        ]

    let Line3 =
        Class "THREE.Line3"
        |+> Static [
            Constructor (!? Vector3?start * !? Vector3?``end``)
        ]
        |+> Instance [
            "start" =@ Vector3
            "end"   =@ Vector3

            "set"                          => Vector3?start * Vector3?``end`` ^-> TSelf
            "copy"                         => TSelf?line ^-> TSelf
            "center"                       => !? Vector3?optionalTarget ^-> Vector3
            "delta"                        => !? Vector3?optionalTarget ^-> Vector3
            "distanceSq"                   => O ^-> T<float>
            "distance"                     => O ^-> T<float>
            "at"                           => T<float>?t * !? Vector3?optionalTarget ^-> Vector3
            "closestPointToPointParameter" => Vector3?point * T<bool>?clampToLine ^-> T<float>
            "closestPointToPoint"          => Vector3?point * T<bool>?clampToLine * !? Vector3?optionalTarget ^-> Vector3
            "applyMatrix4"                 => Matrix4?matrix ^-> TSelf
            "equals"                       => TSelf?line ^-> T<bool>
            "clone"                        => O ^-> TSelf
        ]

    let Math =
        Class "THREE.Math"
        |+> Static [
            "generateUUID"    => O ^-> T<string>
            "clamp"           => T<float>?x * T<float>?a * T<float>?b ^-> T<float>
            "clampBottom"     => T<float>?x * T<float>?a ^-> T<float>
            "mapLinear"       => T<float>?x * T<float>?a1 * T<float>?a2 * T<float>?b1 * T<float>?b2 ^-> T<float>
            "smoothstep"      => T<float>?x * T<float>?min * T<float>?max ^-> T<float>
            "smootherstep"    => T<float>?x * T<float>?min * T<float>?max ^-> T<float>
            "random16"        => O ^-> T<float>
            "randInt"         => T<int>?low * T<int>?high ^-> T<int>
            "randFloat"       => T<float>?low * T<float>?high ^-> T<float>
            "randFloatSpread" => T<float>?range ^-> T<float>
            "sign"            => T<float>?x ^-> T<int>
            "degToRad"        => T<float>?degrees ^-> T<float>
            "radToDeg"        => T<float>?radians ^-> T<float>
            "isPowerOfTwo"    => T<float>?value ^-> T<bool>
        ]
    
    let Matrix3' =
        Matrix3
        |+> Static [
            Constructor (!? T<float>?n11 * !? T<float>?n12 * !? T<float>?n13 * !? T<float>?n21 * !? T<float>?n22 * !? T<float>?n23 * !? T<float>?n31 * !? T<float>?n32 * !? T<float>?n33)
        ]
        |+> Instance [
            "elements" =@ T<JavaScript.Float32Array>

            "set"                  => T<float>?n11 * T<float>?n12 * T<float>?n13 * T<float>?n21 * T<float>?n22 * T<float>?n23 * T<float>?n31 * T<float>?n32 * T<float>?n33 ^-> Matrix3
            "identity"             => O ^-> Matrix3
            "copy"                 => Matrix3?matrix ^-> Matrix3
            "applyToVector3Array"  => (ArrayOf T<float>)?array * T<int>?offset * T<int>?length ^-> ArrayOf T<float>
            "multiplyScalar"       => T<float>?scalar ^-> Matrix3
            "determinant"          => O ^-> T<float>
            "getInverse"           => Matrix4?matrix4 * !? T<bool>?throwOnInvertible ^-> Matrix3
            "transpose"            => O ^-> Matrix3
            "flattenToArrayOffset" => (ArrayOf T<float>)?array * T<int>?offset ^-> ArrayOf T<float>
            "getNormalMatrix"      => Matrix4?matrix4 ^-> Matrix3
            "transposeIntoArray"   => (ArrayOf T<float>)?array ^-> Matrix3
            "fromArray"            => (ArrayOf T<float>)?array ^-> Matrix3
            "toArray"              => O ^-> ArrayOf T<float>
            "clone"                => O ^-> Matrix3
        ]

    let Matrix4' =
        Matrix4
        |+> Static [
            Constructor (!? T<float>?n11 * !? T<float>?n12 * !? T<float>?n13 * !? T<float>?n14 * !? T<float>?n21 * !? T<float>?n22 * !? T<float>?n23 * !? T<float>?n24 * !? T<float>?n31 * !? T<float>?n32 * !? T<float>?n33 * !? T<float>?n34 * !? T<float>?n41 * !? T<float>?n42 * !? T<float>?n43 * !? T<float>?n44)
        ]
        |+> Static [
            "elements" =@ T<JavaScript.Float32Array>

            "set"                        => T<float>?n11 * T<float>?n12 * T<float>?n13 * T<float>?n14 * T<float>?n21 * T<float>?n22 * T<float>?n23 * T<float>?n24 * T<float>?n31 * T<float>?n32 * T<float>?n33 * T<float>?n34 * T<float>?n41 * T<float>?n42 * T<float>?n43 * T<float>?n44 ^-> Matrix4
            "identity"                   => O ^-> Matrix4
            "copy"                       => Matrix4?m ^-> Matrix4
            "copyPosition"               => Matrix4?m ^-> Matrix4
            "extractRotation"            => Matrix4?m ^-> Matrix4
            "makeRotationFromEuler"      => Vector3?euler ^-> Matrix4
            "makeRotationFromQuaternion" => Quaternion?q ^-> Matrix4
            "lookAt"                     => Vector3?eye * Vector3?target * Vector3?up ^-> Matrix4
            "multiply"                   => Matrix4?m ^-> Matrix4
            "multiplyMatrices"           => Matrix4?a * Matrix4?b ^-> Matrix4
            "multiplyToArray"            => Matrix4?a * Matrix4?b * ((ArrayOf T<float>) + T<JavaScript.Float32Array>)?r ^-> Matrix4
            "multiplyScalar"             => T<float>?s ^-> Matrix4
            "applyToVector3Array"        => (ArrayOf T<float>)?array * !? T<int>?offset * !? T<int>?length ^-> ArrayOf T<float>
            "determinant"                => O ^-> T<float>
            "transpose"                  => O ^-> Matrix4
            "flattenToArrayOffset"       => (ArrayOf T<float>)?array * T<int>?offset ^-> ArrayOf T<float>
            "setPosition"                => Vector3?v ^-> Matrix4
            "getInverse"                 => Matrix4?m * !? T<bool>?throwOnInvertible ^-> Matrix4
            "scale"                      => Vector3?v ^-> Matrix4
            "getMaxScaleOnAxis"          => O ^-> T<float>
            "makeTranslation"            => T<float>?x * T<float>?y * T<float>?z ^-> Matrix4
            "makeRotationX"              => T<float>?theta ^-> Matrix4
            "makeRotationY"              => T<float>?theta ^-> Matrix4
            "makeRotationZ"              => T<float>?theta ^-> Matrix4
            "makeRotationAxis"           => Vector3?axis * T<float>?angle ^-> Matrix4
            "makeScale"                  => T<float>?x * T<float>?y * T<float>?z ^-> Matrix4
            "compose"                    => Vector3?position * Quaternion?quaternion * Vector3?scale ^-> Matrix4
            "decompose"                  => Vector3?position * Quaternion?quaternion * Vector3?scale ^-> Tuple [Vector3; Quaternion; Vector3]
            "makeFrustum"                => T<float>?left * T<float>?right * T<float>?bottom * T<float>?top * T<float>?near * T<float>?far ^-> Matrix4
            "makePerspective"            => T<float>?fov * T<float>?aspect * T<float>?near * T<float>?far ^-> Matrix4
            "makeOrthographic"           => T<float>?left * T<float>?right * T<float>?top * T<float>?bottom * T<float>?near * T<float>?far ^-> Matrix4
            "fromArray"                  => (ArrayOf T<float>)?array ^-> Matrix3
            "toArray"                    => O ^-> ArrayOf T<float>
            "clone"                      => O ^-> Matrix4
        ]

    let Plane' =
        Plane
        |+> Static [
            Constructor (!? Vector3?normal * !? T<float>?constant)
        ]
        |+> Instance [
            "normal"   =@ Vector3
            "constant" =@ T<float>

            "set"                           => Vector3?normal * T<float>?constant ^-> Plane
            "setComponents"                 => T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> Plane
            "setFromNormalAndCoplanarPoint" => Vector3?normal * Vector3?point ^-> Vector3
            "setFromCoplanarPoints"         => Vector3?a * Vector3?b * Vector3?c ^-> Plane
            "copy"                          => Plane?plane ^-> Plane
            "normalize"                     => O ^-> Plane
            "negate"                        => O ^-> Plane
            "distanceToPoint"               => Vector3?point ^-> T<float>
            "distanceToSphere"              => Sphere?sphere ^-> T<float>
            "projectPoint"                  => Vector3?point * !? Vector3?optionalTarget ^-> Vector3
            "orthoPoint"                    => Vector3?point * !? Vector3?optionalTarget ^-> Vector3
            "isIntersectionLine"            => Line3?line ^-> T<bool>
            "intersectLine"                 => Line3?line * !? Vector3?optionalTarget ^-> Vector3
            "coplanarPoint"                 => !? Vector3?optionalTarget ^-> Vector3
            "applyMatrix4"                  => Matrix4?matrix * !? Matrix3?optionalNormalMatrix ^-> Plane
            "translate"                     => Vector3?offset ^-> Plane
            "equals"                        => Plane?plane ^-> T<bool>
            "clone"                         => O ^-> Plane
        ]

    let Quaternion' =
        Quaternion
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<float>?w)
        ]
        |+> Instance [
            "x"                =@ T<float>
            "y"                =@ T<float>
            "z"                =@ T<float>
            "w"                =@ T<float>
            "onChangeCallback" =@ (O ^-> O)

            "set"                   => T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> Quaternion
            "copy"                  => Quaternion?quaternion ^-> Quaternion
            "setFromEuler"          => Euler?euler * !? T<bool>?update ^-> Quaternion
            "setFromAxisAngle"      => Vector3?axis * T<float>?angle ^-> Quaternion
            "setFromRotationMatrix" => Matrix4?m ^-> Quaternion
            "setFromUnitVectors"    => Vector3?vFrom * Vector3?vTo ^-> Quaternion
            "inverse"               => O ^-> Quaternion
            "conjugate"             => O ^-> Quaternion
            "lengthSq"              => O ^-> T<float>
            "length"                => O ^-> T<float>
            "normalize"             => O ^-> Quaternion
            "multiply"              => Quaternion?q ^-> Quaternion
            "multiplyQuaternions"   => Quaternion?a * Quaternion?b ^-> Quaternion
            "slerp"                 => Quaternion?qb * T<float>?t ^-> Quaternion
            "equals"                => Quaternion?quaternion ^-> T<bool>
            "fromArray"             => (Tuple [T<float>; T<float>; T<float>; T<float>])?array ^-> Quaternion
            "toArray"               => O ^-> Tuple [T<float>; T<float>; T<float>; T<float>]
            "onChange"              => (O ^-> O)?callback ^-> Quaternion
            "clone"                 => O ^-> Quaternion
        ]

    let Ray' =
        Ray
        |+> Static [
            Constructor (!? Vector3?origin * !? Vector3?direction)
        ]
        |+> Instance [
            "origin"    =@ Vector3
            "direction" =@ Vector3

            "set"                  => Vector3?origin * Vector3?direction ^-> Ray
            "copy"                 => Ray?ray ^-> Ray
            "at"                   => T<float>?t * !? Vector3?optionalTarget ^-> Vector3
            "recast"               => T<float>?t ^-> O
            "closestPointToPoint"  => Vector3?point * !? Vector3?optionalTarget ^-> Vector3
            "distanceToPoint"      => Vector3?point ^-> T<float>
            "distanceSqToSegment"  => Vector3?v0 * Vector3?v1 * !? Vector3?optionalPointOnRay * !? Vector3?optionalPointOnSegment ^-> T<float>
            "isIntersectionSphere" => Sphere?sphere ^-> T<bool>
            "isIntersectionPlane"  => Plane?plane ^-> T<bool>
            "distanceToPlane"      => Plane?plane ^-> T<float>
            "intersectPlane"       => Plane?plane * !? Vector3?optionalTarget ^-> Vector3
            "isIntersectionBox"    => Box3?box ^-> T<bool>
            "intersectBox"         => Box3?box * !? Vector3?optionalTarget ^-> Vector3
            "intersectTriangle"    => Vector3?a * Vector3?b * Vector3?c * !? T<bool>?backfaceCulling * !? Vector3?optionalTarget ^-> Vector3
            "applyMatrix4"         => Matrix4?matrix4 ^-> Ray
            "equals"               => Ray?ray ^-> T<bool>
            "clone"                => O ^-> Ray
        ]

    let Sphere' =
        Sphere
        |+> Static [
            Constructor (!? Vector3?center * !? T<float>?radius)
        ]
        |+> Instance [
            "center" =@ Vector3
            "radius" =@ T<float>

            "set"              => Vector3?center * T<float>?radius ^-> Sphere
            "setFromPoints"    => (ArrayOf Vector3)?points * !? Vector3?optionalCenter ^-> Sphere
            "copy"             => Sphere?sphere ^-> Sphere
            "empty"            => O ^-> T<bool>
            "containsPoint"    => Vector3?point ^-> T<bool>
            "distanceToPoint"  => Vector3?point ^-> T<float>
            "intersectsSphere" => Sphere?sphere ^-> T<bool>
            "clampPoint"       => Vector3?point * !? Vector3?optionalTarget ^-> Vector3
            "getBoundingBox"   => !? Box3?optionalTarget ^-> Box3
            "applyMatrix4"     => Matrix4?matrix ^-> Sphere
            "translate"        => Vector3?offset ^-> Sphere
            "equals"           => Sphere?sphere ^-> T<bool>
            "clone"            => O ^-> Sphere
        ]

    let Spline =
        let Length =
            Class "Length"
            |+> Instance [
                "chunkLengths" =? ArrayOf T<float> + T<float>
            ]
        
        Class "THREE.Spline"
        |+> Static [
            Constructor (ArrayOf Vector3)?points
        ]
        |+> Instance [
            "points" =@ ArrayOf Vector3

            "initFromArray"            => (ArrayOf Vector3)?a ^-> O
            "getPoint"                 => T<int>?k ^-> Vector3
            "getControlPointsArray"    => O ^-> ArrayOf (Tuple [T<float>; T<float>; T<float>])
            "getLength"                => !? T<int>?nSubDivisions ^-> Length
            "reparametrizeByArcLength" => T<float>?samplingCoef ^-> O
            "interpolate"              => T<float>?p0 * T<float>?p1 * T<float>?p2 * T<float>?p3 * T<float>?t * T<float>?t2 * T<float>?t3 ^-> T<float>
        ]
        |=> Nested [
            Length
        ]

    let Triangle =
        Class "THREE.Triangle"
        |+> Static [
            Constructor (!? Vector3?a * !? Vector3?b * !? Vector3?c)
        ]
        |+> Instance [
            "a" =@ Vector3
            "c" =@ Vector3
            "b" =@ Vector3

            "set"                     => Vector3?a * Vector3?b * Vector3?c ^-> TSelf
            "setFromPointsAndIndices" => (ArrayOf Vector3)?points * T<int>?i0 * T<int>?i1 * T<int>?i2 ^-> TSelf
            "copy"                    => TSelf?triangle ^-> TSelf
            "area"                    => O ^-> T<float>
            "midpoint"                => !? Vector3?optionalTarget ^-> Vector3
            "normal"                  => !? Vector3?optionalTarget ^-> Vector3
            "plane"                   => !? Plane?optionalTarget ^-> Plane
            "barycoordFromPoint"      => Vector3?point * !? Vector3?optionalTarget ^-> Vector3
            "containsPoint"           => Vector3?point ^-> T<bool>
            "equals"                  => TSelf?triangle ^-> T<bool>
            "clone"                   => O ^-> TSelf
        ]

    let Vector2' =
        Vector2
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>

            "set"               => T<float>?x * T<float>?y ^-> Vector2
            "setX"              => T<float>?x ^-> Vector2
            "setY"              => T<float>?y ^-> Vector2
            "setComponent"      => T<int>?index * T<float>?value ^-> O
            "getComponent"      => T<int>?index ^-> T<float>
            "copy"              => Vector2?v ^-> Vector2
            "add"               => Vector2?v ^-> Vector2
            "addVectors"        => Vector2?a * Vector2?b ^-> Vector2
            "addScalar"         => T<float>?s ^-> Vector2
            "sub"               => Vector2?v ^-> Vector2
            "subVectors"        => Vector2?a * Vector2?b ^-> Vector2
            "multiply"          => Vector2?v ^-> Vector2
            "multiplyScalar"    => T<float>?s ^-> Vector2
            "divide"            => Vector2?v ^-> Vector2
            "divideScalar"      => T<float>?s ^-> Vector2
            "min"               => Vector2?v ^-> Vector2
            "max"               => Vector2?v ^-> Vector2
            "clamp"             => Vector2?min * Vector2?max ^-> Vector2
            "clampScalar"       => T<float>?minVal * T<float>?maxVal ^-> Vector2
            "floor"             => O ^-> Vector2
            "ceil"              => O ^-> Vector2
            "round"             => O ^-> Vector2
            "roundToZero"       => O ^-> Vector2
            "negate"            => O ^-> Vector2
            "dot"               => Vector2?v ^-> T<float>
            "lengthSq"          => O ^-> T<float>
            "length"            => O ^-> T<float>
            "normalize"         => O ^-> Vector2
            "distanceTo"        => Vector2?v ^-> T<float>
            "distanceToSquared" => Vector2?v ^-> T<float>
            "setLength"         => T<float>?l ^-> Vector2
            "lerp"              => Vector2?v * T<float>?alpha ^-> Vector2
            "equals"            => Vector2?v ^-> T<bool>
            "fromArray"         => (Tuple [T<float>; T<float>])?array ^-> Vector2
            "toArray"           => O ^-> Tuple [T<float>; T<float>]
            "clone"             => O ^-> Vector2
        ]

    let Vector3' =
        Vector3
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>

            "set"                   => T<float>?x * T<float>?y * T<float>?z ^-> Vector3
            "setX"                  => T<float>?x ^-> Vector3
            "setY"                  => T<float>?y ^-> Vector3
            "setZ"                  => T<float>?z ^-> Vector3
            "setComponent"          => T<int>?index * T<float>?value ^-> Vector3
            "getComponent"          => T<int>?index ^-> T<float>
            "copy"                  => Vector3?v ^-> Vector3
            "add"                   => Vector3?v ^-> Vector3
            "addScalar"             => T<float>?s ^-> Vector3
            "addVectors"            => Vector3?a * Vector3?b ^-> Vector3
            "sub"                   => Vector3?v ^-> Vector3
            "subVectors"            => Vector3?a * Vector3?b ^-> Vector3
            "multiply"              => Vector3?v ^-> Vector3
            "multiplyScalar"        => T<float>?s ^-> Vector3
            "multiplyVectors"       => Vector3?a * Vector3?b ^-> Vector3
            "applyEuler"            => Euler?euler ^-> Vector3
            "applyAxisAngle"        => Vector3?axis * T<float>?angle ^-> Vector3
            "applyMatrix3"          => Matrix3?m ^-> Vector3
            "applyMatrix4"          => Matrix4?m ^-> Vector3
            "applyProjection"       => Matrix4?m ^-> Vector3
            "applyQuaternion"       => Quaternion?quaternion ^-> Vector3
            "transformDirection"    => Matrix4?m ^-> Vector3
            "divide"                => Vector3?v ^-> Vector3
            "divideScalar"          => T<float>?s ^-> Vector3
            "min"                   => Vector3?v ^-> Vector3
            "max"                   => Vector3?v ^-> Vector3
            "clamp"                 => Vector3?min * Vector3?max ^-> Vector3
            "clampScalar"           => T<float>?minVal * T<float>?maxVal ^-> Vector3
            "floor"                 => O ^-> Vector3
            "ceil"                  => O ^-> Vector3
            "round"                 => O ^-> Vector3
            "roundToZero"           => O ^-> Vector3
            "negate"                => O ^-> Vector3
            "dot"                   => Vector3?v ^-> T<float>
            "lengthSq"              => O ^-> T<float>
            "length"                => O ^-> T<float>
            "lengthManhattan"       => O ^-> T<float>
            "normalize"             => O ^-> Vector3
            "setLength"             => T<float>?l ^-> Vector3
            "lerp"                  => Vector3?v * T<float>?alpha ^-> Vector3
            "cross"                 => Vector3?v ^-> Vector3
            "crossVectors"          => Vector3?a * Vector3?b ^-> Vector3
            "projectOnVector"       => Vector3?vector ^-> Vector3
            "projectOnPlane"        => Vector3?planeNormal ^-> Vector3
            "reflect"               => Vector3?normal ^-> Vector3
            "angleTo"               => Vector3?v ^-> T<float>
            "distanceTo"            => Vector3?v ^-> T<float>
            "distanceToSquared"     => Vector3?v ^-> T<float>
            "setFromMatrixPosition" => Matrix4?m ^-> Vector3
            "setFromMatrixScale"    => Matrix4?m ^-> Vector3
            "setFromMatrixColumn"   => T<int>?index * Matrix4?matrix ^-> Vector3
            "equals"                => Vector3?v ^-> T<bool>
            "fromArray"             => (Tuple [T<float>; T<float>; T<float>])?array ^-> Vector3
            "toArray"               => O ^-> Tuple [T<float>; T<float>; T<float>]
            "clone"                 => O ^-> Vector3
        ]

    let Vector4 =
        Class "THREE.Vector4"
        |+> Static [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<float>?w)
        ]
        |+> Instance [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>
            "w" =@ T<float>

            "set"                            => T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> TSelf
            "setX"                           => T<float>?x ^-> TSelf
            "setY"                           => T<float>?y ^-> TSelf
            "setZ"                           => T<float>?z ^-> TSelf
            "setW"                           => T<float>?w ^-> TSelf
            "setComponent"                   => T<int>?index * T<float>?value ^-> O
            "getComponent"                   => T<int>?index ^-> T<float>
            "copy"                           => TSelf?v ^-> TSelf
            "add"                            => TSelf?v ^-> TSelf
            "addScalar"                      => T<float>?s ^-> TSelf
            "addVectors"                     => TSelf?a * TSelf?b ^-> TSelf
            "sub"                            => TSelf?v ^-> TSelf
            "subVectors"                     => TSelf?a * TSelf?b ^-> TSelf
            "multiplyScalar"                 => T<float>?s ^-> TSelf
            "applyMatrix4"                   => Matrix4?m ^-> TSelf
            "divideScalar"                   => T<float>?s ^-> TSelf
            "setAxisAngleFromQuaternion"     => Quaternion?q ^-> TSelf
            "setAxisAngleFromRotationMatrix" => Matrix4?m ^-> TSelf
            "min"                            => TSelf?v ^-> TSelf
            "max"                            => TSelf?v ^-> TSelf
            "clamp"                          => TSelf?min * TSelf?max ^-> TSelf
            "clampScalar"                    => T<float>?minVal * T<float>?maxVal ^-> TSelf
            "floor"                          => O ^-> TSelf
            "ceil"                           => O ^-> TSelf
            "round"                          => O ^-> TSelf
            "roundToZero"                    => O ^-> TSelf
            "negate"                         => O ^-> TSelf
            "dot"                            => TSelf?v ^-> T<float>
            "lengthSq"                       => O ^-> T<float>
            "length"                         => O ^-> T<float>
            "lengthManhattan"                => O ^-> T<float>
            "normalize"                      => O ^-> TSelf
            "setLength"                      => T<float>?l ^-> TSelf
            "lerp"                           => TSelf?v * T<float>?alpha ^-> TSelf
            "equals"                         => TSelf?v ^-> T<bool>
            "fromArray"                      => (Tuple [T<float>; T<float>; T<float>; T<float>])?array ^-> TSelf
            "toArray"                        => O ^-> Tuple [T<float>; T<float>; T<float>; T<float>]
            "clone"                          => O ^-> TSelf
        ]
    
    let SkinnedMesh = Class "THREE.SkinnedMesh"

    let Bone =
        Class "THREE.Bone"
        |=> Inherits Object3D
        |+> Static [
            Constructor (SkinnedMesh?belongsToSkin)
        ]
        |+> Instance [
            "skin"                 =@ SkinnedMesh
            "skinMatrix"           =@ Matrix4
            "accumulatedRotWeight" =@ T<float>
            "accumulatedPosWeight" =@ T<float>
            "accumulatedSclWeight" =@ T<float>

            "update" => Matrix4?parentSkinMatrix * !? T<bool>?forceUpdate ^-> O
        ]

    let Line =
        Class "THREE.Line"
        |=> Inherits Object3D
        |+> Static [
            Constructor (!? Geometry?geometry * !? Material?material * !? T<int>?``type``)
        ]
        |+> Instance [
            "geometry" =@ Geometry
            "material" =@ Material
            "type"     =@ T<int>

            "clone" => !? TSelf?``object`` ^-> TSelf
        ]
    
    let LOD =
        Class "THREE.LOD"
        |=> Inherits Object3D
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "objects" =@ ArrayOf Object3D

            "addLevel"             => Object3D?``object`` * !? T<float>?distance ^-> O
            "getObjectForDistance" => T<float>?distance ^-> Object3D
            "update"               => Camera?camera ^-> O
            "clone"                => !? TSelf?``object`` ^-> TSelf
        ]
    
    let Mesh =
        Class "THREE.Mesh"
        |=> Inherits Object3D
        |+> Static [
            Constructor (!? Geometry?geometry * !? Material?material)
        ]
        |+> Instance [
            "geometry" =@ Geometry
            "material" =@ Material

            "updateMorphTargets"        => O ^-> O
            "getMorphTargetIndexByName" => T<string>?name ^-> T<int>
            "clone"                     => !? TSelf?``object`` * !? T<bool>?``recursive`` ^-> TSelf
            
        ]

    let MorphAnimMesh =
        Class "THREE.MorphAnimMesh"
        |=> Inherits Mesh
        |+> Static [
            Constructor (Geometry?geometry * Material?material)
        ]
        |+> Instance [
            "duration"     =@ T<int>
            "mirroredLoop" =@ T<bool>
            "time"         =@ T<int>

            "setFrameRange"        => T<int>?start * T<int>?``end`` ^-> O
            "setDirectionForward"  => O ^-> O
            "setDirectionBackward" => O ^-> O
            "parseAnimations"      => O ^-> O
            "setAnimationLabel"    => T<string>?label * T<int>?start * T<int>?``end`` ^-> O
            "playAnimation"        => T<string>?label * T<int>?fps ^-> O
            "updateAnimation"      => T<int>?delta ^-> O
            "clone"                => !? TSelf?``object`` ^-> TSelf
        ]

    let ParticleSystem =
        Class "THREE.ParticleSystem"
        |=> Inherits Object3D
        |+> Static [
            Constructor (!? Geometry?geometry * !? Material?material)
        ]
        |+> Instance [
            "geometry"       =@ Geometry
            "material"       =@ Material
            "sortParticles"  =@ T<bool>
            "frustrumCulled" =@ T<bool>

            "clone" => !? TSelf ^-> TSelf
        ]

    let SkinnedMesh' =
        SkinnedMesh
        |=> Inherits Mesh
        |+> Static [
            Constructor (Geometry?geometry * Material?material * T<bool>?useVertexTexture)
        ]
        |+> Instance [
            "skeleton"       =@ T<obj>
            "identityMatrix" =@ Matrix4

            "updateMatrixWorld"    => T<bool>?force ^-> O
            "pose"                 => O ^-> O
            "normalizeSkinWeights" => O ^-> O
            "clone"                => !? SkinnedMesh?``object`` ^-> SkinnedMesh
        ]

    let Sprite =
        Class "THREE.Sprite"
        |=> Inherits Object3D
        |+> Static [
            Constructor (!? Material?material)
        ]
        |+> Instance [
            "geometry" =@ Geometry
            "material" =@ SpriteMaterial

            "updateMatrix" => O ^-> O
            "clone"        => !? TSelf?``object`` ^-> TSelf
        ]

    let CanvasRendererConfiguration =
        Pattern.Config "CanvasRendererConfiguration" {
            Required = []
            Optional =
            [
                "canvas"          , T<Element>
                "devicePixelRatio", T<float>
            ]
        }

    let CanvasRenderer =
        Class "THREE.CanvasRenderer"
        |+> Static [
            Constructor !? CanvasRendererConfiguration?parameters
        ]
        |+> Instance [
            "domElement"       =@ T<Element>
            "devicePixelRatio" =@ T<float>
            "autoClear"        =@ T<bool>
            "sortObjects"      =@ T<bool>
            "sortElements"     =@ T<bool>
            "info"             =@ T<obj>
            
            "setSize"                => T<int>?width * T<int>?height * !? T<bool>?updateStyle ^-> O
            "setViewport"            => T<float>?x * T<float>?y * T<float>?width * T<float>?height ^-> O
            "setClearColor"          => Color?color * !? T<float>?alpha ^-> O
            "getMaxAnisotropy"       => O ^-> T<int>
            "clear"                  => O ^-> O
            "render"                 => Scene?scene * Camera?camera ^-> O
        ]
    
    let WebGLRendererPrecision =
        Pattern.EnumStrings "WebGLRendererPrecision" [
            "lowp"
            "mediump"
            "highp"
        ]

    let WebGLRendererConfiguration =
        Pattern.Config "WebGLRendererConfiguration" {
            Required = []
            Optional =
            [
                "canvas"               , T<Element>
                "precision"            , WebGLRendererPrecision.Type
                "alpha"                , T<bool>
                "premultipliedAlpha"   , T<bool>
                "antialias"            , T<bool>
                "stencil"              , T<bool>
                "preserveDrawingBuffer", T<bool>
                "maxLights"            , T<int>
            ]
        }

    let ShadowMapPlugin   = Type.New ()
    let Fog               = Type.New ()
    let WebGLRenderTarget = Type.New ()

    let MemoryInfo =
        Class "MemoryInfo"
        |+> Instance [
            "programs"   =@ T<int>
            "geometries" =@ T<int>
            "textures"   =@ T<int>
        ]

    let RenderInfo =
        Class "RenderInfo"
        |+> Instance [
            "calls"    =@ T<int>
            "vertices" =@ T<int>
            "faces"    =@ T<int>
            "points"   =@ T<int>
        ]

    let Info =
        Class "Info"
        |+> Instance [
            "memory" =@ MemoryInfo
            "render" =@ RenderInfo
        ]

    let WebGLRenderer =
        Class "THREE.WebGLRenderer"
        |+> Static [
            Constructor !? WebGLRendererConfiguration?parameters
        ]
        |+> Instance [
            "domElement"          =@ T<Element>
            "context"             =@ T<JavaScript.WebGL.RenderingContext>
            "devicePixelRatio"    =@ T<float>
            "autoClear"           =@ T<bool>
            "autoClearColor"      =@ T<bool>
            "autoClearDepth"      =@ T<bool>
            "autoClearStencil"    =@ T<bool>
            "sortObjects"         =@ T<bool>
            "autoUpdateObjects"   =@ T<bool>
            "gammaInput"          =@ T<bool>
            "gammaOutput"         =@ T<bool>
            "shadowMapEnabled"    =@ T<bool>
            "shadowMapAutoUpdate" =@ T<bool>
            "shadowMapType"       =@ T<int>
            "shadowMapCullFace"   =@ T<int>
            "shadowMapDebug"      =@ T<bool>
            "shadowMapCascade"    =@ T<bool>
            "maxMorphTargets"     =@ T<int>
            "maxMorphNormals"     =@ T<int>
            "autoScaleCubemaps"   =@ T<bool>
            "renderPluginsPre"    =@ ArrayOf T<obj>
            "renderPluginsPost"   =@ ArrayOf T<obj>
            "info"                =@ Info
            "shadowMapPlugin"     =@ ShadowMapPlugin
            

            "getContext"                      => O ^-> T<JavaScript.WebGL.RenderingContext>
            "supportsVertexTextures"          => O ^-> T<bool>
            "supportsFloatTextures"           => O ^-> T<bool>
            "supportsStandardDerivatives"     => O ^-> T<bool>
            "supportsCompressedTextureS3TC"   => O ^-> T<bool>
            "getMaxAnisotropy"                => O ^-> T<int>
            "getPrecision"                    => O ^-> T<string>
            "setSize"                         => T<int>?width * T<int>?height * !? T<bool>?updateStyle ^-> O
            "setViewport"                     => T<float>?x * T<float>?y * T<float>?width * T<float>?height ^-> O
            "setScissor"                      => T<float>?x * T<float>?y * T<float>?width * T<float>?height ^-> O
            "enableScissorTest"               => T<bool>?enable ^-> O
            "setClearColor"                   => Color?color * !? T<float>?alpha ^-> O
            "getClearColor"                   => O ^-> Color
            "getClearAlpha"                   => O ^-> T<float>
            "clear"                           => !? T<bool>?color * !? T<bool>?depth * !? T<bool>?stencil ^-> O
            "clearColor"                      => O ^-> O
            "clearDepth"                      => O ^-> O
            "clearStencil"                    => O ^-> O
            "clearTarget"                     => WebGLRenderTarget?renderTarget * T<bool>?color * T<bool>?depth * T<bool>?stencil ^-> O
            "addPostPlugin"                   => T<obj> ^-> O
            "addPrePlugin"                    => T<obj> ^-> O
            "updateShadowMap"                 => Scene?scene * Camera?camera ^-> O
            "renderBufferImmediate"           => Object3D?``object`` * T<obj>?program * Material?material ^-> O
            "renderBufferDirect"              => Camera?camera * (ArrayOf Light)?lights * Fog?fog * Material?material * T<obj>?geometry * Object3D?``object`` ^-> O
            "renderBuffer"                    => Camera?camera * (ArrayOf Light)?lights * Fog?fog * Material?material * T<obj>?geometryGroup * Object3D?``object`` ^-> O
            "render"                          => Scene?scene * Camera?camera * !? T<obj>?renderTarget * !? T<bool>?forceClear ^-> O
            "renderImmediateObject"           => Camera?camera * (ArrayOf Light)?lights * Fog?fog * Material?material * Object3D?``object`` ^-> O
            "initWebGLObjects"                => Scene?scene ^-> O
            "initMaterial"                    => Material?material * (ArrayOf Light)?lights * Fog?fog * Object3D?``object`` ^-> O
            "setFaceCulling"                  => T<int>?cullFace * T<int>?frontFaceDirection ^-> O
            "setMaterialFaces"                => Material?material ^-> O
            "setDepthTest"                    => T<bool>?depthTest ^-> O
            "setDepthWrite"                   => T<bool>?depthWrite ^-> O
            "setBlending"                     => T<int>?blending * T<int>?blendEquation * T<int>?blendSrc * T<int>?blendDst ^-> O
            "setTexture"                      => Texture?texture * T<int>?slot ^-> O
            "setRenderTarget"                 => WebGLRenderTarget?renderTarget ^-> O
        ]
    
    let WebGLRenderTargetClass =
        Class "THREE.WebGLRenderTarget"
        |=> WebGLRenderTarget
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor (T<float>?width * T<float>?height * !? T<obj>?options)
        ]
        |+> Instance [
            "wrapS"           =@ T<int>
            "wrapT"           =@ T<int>
            "magFilter"       =@ T<int>
            "minFilter"       =@ T<int>
            "anisotropy"      =@ T<float>
            "offset"          =@ Vector2
            "repeat"          =@ Vector2
            "format"          =@ T<int>
            "type"            =@ T<int>
            "depthBuffer"     =@ T<bool>
            "stencilBuffer"   =@ T<bool>
            "generateMipmaps" =@ T<bool>
            "shareDepthFrom"  =@ T<obj>

            "setSize" => T<float>?width * T<float>?height ^-> O
            "clone"   => O ^-> WebGLRenderTarget
            "dispose" => O ^-> O
        ]
    
    let WebGLRenderTargetCube =
        Class "THREE.WebGLRenderTargetCube"
        |=> Inherits WebGLRenderTargetClass
        |+> Instance [
            "activeCubeFace" =@ T<int>
        ]

    let RenderableVertex = Type.New ()

    let RenderableFace =
        Class "THREE.RenderableFace"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"                  =? T<int>
            "v1"                  =@ RenderableVertex
            "v2"                  =@ RenderableVertex
            "v3"                  =@ RenderableVertex
            "normalModel"         =@ Vector3
            "vertexNormalsModel"  =@ Tuple [Vector3; Vector3; Vector3]
            "vertexNormalsLength" =@ T<int>
            "color"               =@ Color
            "material"            =@ Material
            "uvs"                 =@ Tuple [Vector2; Vector2; Vector2]
            "z"                   =@ T<float>
        ]
    
    let RenderableLine =
        Class "THREE.RenderableLine"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"           =? T<int>
            "v1"           =@ RenderableVertex
            "v2"           =@ RenderableVertex
            "vertexColors" =@ Tuple [Color; Color]
            "material"     =@ Material
            "z"            =@ T<obj>
            
        ]

    let RenderableObject =
        Class "THREE.RenderableObject"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"     =@ T<int>
            "object" =@ Object3D
            "z"      =@ T<float>
        ]

    let RenderableSprite =
        Class "THREE.RenderableSprite"
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "id"           =? T<int>
            "object"       =@ Object3D
            "x"            =@ T<float>
            "y"            =@ T<float>
            "z"            =@ T<float>
            "rotation"     =@ T<float>
            "scale"        =@ Vector2
            "material"     =@ Material
        ]

    let RenderableVertexClass =
        Class "THREE.RenderableVertex"
        |=> RenderableVertex
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "position"       =@ Vector3
            "positionWorld"  =@ Vector3
            "positionScreen" =@ Vector4
            "visible"        =@ T<bool>
            
            "copy" => RenderableVertex?vertex ^-> O
        ]

    let FogClass =
        Class "THREE.Fog"
        |=> Fog
        |+> Static [
            Constructor (Color?color * !? T<float>?near * !? T<float>?far)
        ]
        |+> Instance [
            "name"  =@ T<string>
            "color" =@ Color
            "near"  =@ T<float>
            "far"   =@ T<float>

            "clone" => O ^-> Fog
        ]

    let FogExp2 =
        let FogExp2 = Type.New ()
        
        Class "THREE.FogExp2"
        |=> FogExp2
        |+> Static [
            Constructor (Color?color * !? T<float>?density)
        ]
        |+> Instance [
            "name"    =@ T<string>
            "color"   =@ Color
            "density" =@ T<float>

            "clone" => O ^-> FogExp2
        ]

    let Scene' =
        Scene
        |=> Inherits Object3D
        |+> Static [
            Constructor O
        ]
        |+> Instance [
            "fog"              =@ Fog
            "overrideMaterial" =@ Material
            "autoUpdate"       =@ T<bool>
            "matrixAutoUpdate" =@ T<bool>

            "clone" => !? Scene?``object`` ^-> Scene
        ]

    let Texture' =
        Texture
        |=> Inherits EventDispatcher
        |+> Static [
            Constructor (T<Element>?image * !? T<int>?mapping * !? T<int>?wrapS * !? T<int>?wrapT * !? T<int>?magFilter * !? T<int>?minFilter * !? T<int>?format * !? T<int>?``type`` * !? T<int>?anisotropy)
        ]
        |+> Instance [
            "id"                 =? T<int>
            "uuid"               =? T<string>
            "name"               =? T<string>
            "image"              =@ T<Element>
            "mipmaps"            =@ ArrayOf T<obj>
            "mapping"            =@ T<int>
            "wrapS"              =@ T<int>
            "wrapT"              =@ T<int>
            "magFilter"          =@ T<int>
            "minFilter"          =@ T<int>
            "anisotropy"         =@ T<int>
            "format"             =@ T<int>
            "type"               =@ T<int>
            "offset"             =@ Vector2
            "repeat"             =@ Vector2
            "generateMipmaps"    =@ T<bool>
            "premultiplyAlpha"   =@ T<bool>
            "flipY"              =@ T<bool>
            "unpackAlignment"    =@ T<int>
            "onUpdate"           =@ O ^-> O
            
            "clone"   => !? Texture?texture ^-> O
            "update"  => O ^-> O
            "dispose" => O ^-> O
        ]

    let CompressedTexture =
        let CompressedTexture = Type.New ()
        
        Class "THREE.CompressedTexture"
        |=> Inherits Texture
        |+> Static [
            Constructor ((ArrayOf T<obj>)?mipmaps * T<int>?width * T<int>?height * T<int>?format * T<int>?``type`` * T<int>?mapping * T<int>?wrapS * T<int>?wrapT * T<int>?magFilter * T<int>?minFilter * T<int>?anisotropy)
        ]
        |+> Instance [
            "image"           =@ T<obj>
            "mipmaps"         =@ ArrayOf T<obj>
            "generateMipmaps" =@ T<bool>

            "clone" => O ^-> CompressedTexture
        ]

    let DataTexture =
        let DataTexture = Type.New ()

        Class "THREE.DataTexture"
        |=> Inherits Texture
        |+> Static [
            Constructor (T<JavaScript.ArrayBufferView>?data * T<int>?width * T<int>?height * T<int>?format * T<int>?``type`` * T<int>?mapping * T<int>?wrapS * T<int>?wrapT * T<int>?magFilter * T<int>?minFilter * T<int>?anisotropy)
        ]
        |+> Instance [
            "image" =@ T<obj>

            "clone" => O ^-> DataTexture
        ]
    
    let Path  = Type.New ()
    let Shape = Type.New ()

    let FontUtils =
        Class "THREE.FontUtils"
        |+> Static [
            "faces"    =@ T<obj>
            "face"     =@ T<string>
            "weight"   =@ T<string>
            "style"    =@ T<string>
            "size"     =@ T<float>
            "division" =@ T<float>

            "getFace"            => O ^-> T<obj>
            "loadFace"           => T<obj>?data ^-> T<obj>
            "drawText"           => T<string>?text ^-> T<obj>
            "extractGlyphPoints" => T<int>?c * Face3?face * T<float>?scale * T<int>?offset * Path?path ^-> T<obj>
            "generateShapes"     => T<string>?text * !? T<obj>?parameters ^-> ArrayOf Shape
        ]

    let GeometryUtils =
        Class "THREE.GeometryUtils"
        |+> Static [
            "merge"                  => Geometry?geometry1 * Geometry?geometry2 * T<int>?materialIndexOffset ^-> Geometry
            "randomPointInTriangle"  => Vector3?VectorA * Vector3?VectorB * Vector3?VectorC ^-> Vector3
            "randomPointInFace"      => Face3?Face * Geometry?Geometry * T<bool>?useCachedAreas ^-> Vector3
            "randomPointsInGeometry" => Geometry?Geometry * (ArrayOf Vector3)?Points ^-> ArrayOf Vector3
            "triangleArea"           => Vector3?VectorA * Vector3?VectorB * Vector3?VectorC ^-> T<float>
            "center"                 => Geometry?Geometry ^-> Vector3
        ]

    let ImageUtils =
        Class "THREE.ImageUtils"
        |+> Static [
            "crossOrigin" =@ T<string>

            "loadTexture"               => T<string>?url * !? T<obj>?mapping * !? (!? Texture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> Texture
            "loadCompressedTexture"     => T<string>?url * T<obj>?mapping * !? (!? CompressedTexture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> CompressedTexture
            "loadTextureCube"           => (ArrayOf T<string>)?array * T<obj>?mapping * !? (!? Texture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> Texture
            "loadCompressedTextureCube" => (ArrayOf T<string>)?array * T<obj>?mapping * !? (!? CompressedTexture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> Texture
            "loadDDSTexture"            => T<string>?url * T<obj>?mapping * !? (!? CompressedTexture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> CompressedTexture
            "parseDDS"                  => T<obj>?buffer * T<bool>?loadMipmaps ^-> T<obj>
            "getNormalMap"              => T<Element>?image * !? T<int>?depth ^-> T<Element>
            "generateDataTexture"       => T<float>?width * T<float>?height * Color?color ^-> DataTexture
        ]

    let SceneUtils =
        Class "THREE.SceneUtils"
        |+> Static [
            "createMultiMaterialObject" => Geometry?geometry * (ArrayOf Material)?materials ^-> Object3D
            "attach"                    => Object3D?child * Scene?scene * Object3D?parent ^-> O
        ]

    let Animation =
        Class "THREE.Animation"

    let AnimationHandler =
        Class "THREE.AnimationHandler"

    let KeyFrameAnimation =
        Class "THREE.KeyFrameAnimation"

    let AnimationMorphTarget =
        Class "THREE.AnimationMorphTarget"
    
    let CombiedCamera =
        Class "THREE.CombinedCamera"
        |=> Inherits Camera

    let CubeCamera =
        Class "THREE.CubeCamera"
        |=> Inherits Object3D

    let Curve =
        Class "THREE.Curve"

    let CurvePath =
        Class "THREE.CurvePath"
        |=> Inherits Curve

    let Gyroscope =
        Class "THREE.Gyroscope"
        |=> Inherits Object3D

    let PathClass =
        Class "THREE.Path"
        |=> Path
        |=> Inherits CurvePath

    let ShapeClass =
        Class "THREE.Shape"
        |=> Shape
        |=> Inherits PathClass

    let EllipseCurve =
        Class "THREE.EllipseCurve"
        |=> Inherits Curve

    let ArcCurve =
        Class "THREE.ArcCurve"
        |=> Inherits EllipseCurve

    let ClosedSplineCurve3 =
        Class "THREE.ClosedSplineCurve3"
        |=> Inherits Curve

    let CubicBezierCurve =
        Class "THREE.CubicBezierCurve"
        |=> Inherits Curve

    let CubicBezierCurve3 =
        Class "THREE.CubicBezierCurve3"
        |=> Inherits Curve

    let LineCurve =
        Class "THREE.LineCurve"
        |=> Inherits Curve

    let LineCurve3 =
        Class "THREE.LineCurve3"
        |=> Inherits Curve

    let QuadraticBezierCurve =
        Class "THREE.QuadraticBezierCurve"
        |=> Inherits Curve

    let QuadraticBezierCurve3 =
        Class "THREE.QuadraticBezierCurve3"
        |=> Inherits Curve

    let SplineCurve =
        Class "THREE.SplineCurve"
        |=> Inherits Curve

    let SplineCurve3 =
        Class "THREE.SplineCurve3"
        |=> Inherits Curve

    let BoxGeometry =
        Class "THREE.BoxGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (T<float>?width * T<float>?height * T<float>?depth * !? T<int>?widthSegments * !? T<int>?heightSegments * !? T<int>?depthSegments)
        ]
        |+> Instance [
            "parameters"     =? T<obj>
            "widthSegments"  =@ T<int>
            "heightSegments" =@ T<int>
            "depthSegments"  =@ T<int>
        ]

    let CircleGeometry =
        Class "THREE.CircleGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?segments * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let CylinderGeometry =
        Class "THREE.CylinderGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radiusTop * !? T<float>?radiusBottom * !? T<float>?height * !? T<int>?radialSegments * !? T<int>?heightSegments * !? T<bool>?openEnded)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let ExtrudeGeometry =
        Class "THREE.ExtrudeGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? (ArrayOf Shape)?shapes * !? T<obj>?options)
        ]
        |+> Instance [
            "shapebb" =? Box3

            "addShapeList" => (ArrayOf Shape)?shapes * !? T<obj>?options ^-> O
            "addShape"     => Shape?shape * !? T<obj>?options ^-> O
        ]

    let IcosahedronGeometry =
        Class "THREE.IcosahedronGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?detail)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let LatheGeometry =
        Class "THREE.LatheGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor ((ArrayOf T<obj>)?points * !? T<int>?segments * !? T<float>?phiStart * !? T<float>?phiLength)
        ]

    let OctahedronGeometry =
        Class "THREE.OctahedronGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?detail)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let ParametricGeometry =
        Class "THREE.ParametricGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor ((T<obj> * T<obj> ^-> T<obj>)?func * T<int>?slices * T<int>?stacks)
        ]

    let PlaneGeometry =
        Class "THREE.PlaneGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (T<float>?width * T<float>?height * !? T<int>?widthSegments * !? T<int>?heightSegments)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let PolyhedronGeometry =
        Class "THREE.PolyhedronGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor ((ArrayOf T<float>)?vertices * (ArrayOf T<float>)?indices * !? T<float>?radius * !? T<float>?detail)
        ]
        |+> Instance [
            "boundingSphere" =? Sphere
        ]

    let RingGeometry =
        Class "THREE.RingGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?innerRadius * !? T<float>?outerRadius * !? T<int>?thetaSegments * !? T<int>?phiSegments * !? T<float>?thetaLength * !? T<float>?phiLength)
        ]
        |+> Instance [
            "boundingSphere" =? Sphere
        ]

    let ShapeGeometry =
        Class "THREE.ShapeGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? (ArrayOf Shape)?shapes * !? T<obj>?options)
        ]
        |+> Instance [
            "shapebb" =? Box3

            "addShapeList" => (ArrayOf Shape)?shapes * !? T<obj>?options ^-> O
            "addShape"     => Shape?shape * !? T<obj>?options ^-> O
        ]

    let SphereGeometry =
        Class "THREE.SphereGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<int>?widthSegments * !? T<int>?heightSegments * !? T<float>?phiStart * !? T<float>?phiLength * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |+> Instance [
            "parameters"     =? T<obj>
            "boundingSphere" =? Sphere
        ]

    let TetrahedronGeometry =
        Class "THREE.TetrahedronGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?detail)
        ]

    let TextGeometry =
        Class "THREE.TextGeometry"
        |=> Inherits ExtrudeGeometry
        |+> Static [
            Constructor (T<string>?text * !? T<obj>?parameters)
        ]

    let TorusGeometry =
        Class "THREE.TorusGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?tube * !? T<int>?radialSegments * !? T<int>?tubularSegments * !? T<float>?arc)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let TorusKnotGeometry =
        Class "THREE.TorusKnotGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (!? T<float>?radius * !? T<float>?tube * !? T<int>?radialSegments * !? T<int>?tubularSegments * !? T<float>?p * !? T<float>?q * !? T<float>?heightScale)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let TubeGeometry =
        Class "THREE.TubeGeometry"
        |=> Inherits Geometry
        |+> Static [
            Constructor (T<obj>?path * !? T<int>?segments * !? T<float>?radius * !? T<int>?radiusSegments * !? T<bool>?closed * !? T<bool>?debug)
        ]
        |+> Instance [
            "parameters" =? T<obj>
        ]

    let AxisHelper =
        Class "THREE.AxisHelper"
        |=> Inherits Line
        |+> Static [
            Constructor T<float>?size
        ]

    let MorphAnimation =
        Class "THREE.MorphAnimation"
        |+> Static [
            Constructor Mesh?mesh
        ]
        |+> Instance [
            "mesh"        =@ Mesh
            "frames"      =@ T<int>
            "currentTime" =@ T<int>
            "duration"    =@ T<int>
            "loop"        =@ T<bool>
            "isPlaying"   =@ T<bool>

            "play"   => O ^-> O
            "pause"  => O ^-> O
            "update" => O ^-> O
        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.ThreeJs" [
                HSL
                MorphTarget
                MorphColor
                MorphNormal
                Intersection
                LineBasicMaterialConfiguration
                LineDashedMaterialConfiguration
                MeshBasicMaterialConfiguration
                MeshDepthMaterialConfiguration
                MeshLambertMaterialConfiguration
                MeshNormalMaterialConfiguration
                MeshPhongMaterialConfiguration
                ParticleSystemMaterialConfiguration
                ShaderMaterialConfiguration
                SpriteCanvasMaterialConfiguration
                SpriteMaterialConfiguration
                CanvasRendererConfiguration
                WebGLRendererConfiguration
                ProjectionData
                DefaultAttributeValues
                MemoryInfo
                RenderInfo
                Info
                WebGLRendererPrecision
            ]
            Namespace "WebSharper.ThreeJs.THREE" [
                Camera
                OrthographicCamera
                PerspectiveCamera
                BufferAttribute
                BufferGeometry
                Clock
                EventDispatcher
                Face3
                Geometry
                Object3D
                Projector
                Raycaster
                AmbientLight
                AreaLight
                DirectionalLight
                HemisphereLight
                Light'
                PointLight
                SpotLight
                BufferGeometryLoader
                Cache
                ImageLoader
                JSONLoader
                Loader
                LoadingManager
                MaterialLoader
                ObjectLoader
                SceneLoader
                TextureLoader
                XHRLoader
                LineBasicMaterial
                LineDashedMaterial
                Material'
                MeshBasicMaterial
                MeshDepthMaterial
                MeshFaceMaterial
                MeshLambertMaterial
                MeshNormalMaterial
                MeshPhongMaterial
                ParticleSystemMaterial
                RawShaderMaterial
                ShaderMaterial
                SpriteCanvasMaterial
                SpriteMaterial
                Box2
                Box3
                ColorClass
                Euler
                Frustum
                Line3
                Math
                Matrix3
                Matrix4
                Plane
                Quaternion
                Ray
                Sphere
                Spline
                Triangle
                Vector2
                Vector3
                Vector4
                Bone
                Line
                LOD
                Mesh
                MorphAnimMesh
                ParticleSystem
                SkinnedMesh'
                Sprite
                CanvasRenderer
                WebGLRenderer
                WebGLRenderTargetClass
                WebGLRenderTargetCube
                RenderableFace
                RenderableLine
                RenderableObject
                RenderableSprite
                RenderableVertexClass
                FogClass
                FogExp2
                Scene'
                CompressedTexture
                DataTexture
                Texture'
                FontUtils
                GeometryUtils
                ImageUtils
                SceneUtils
                Animation
                AnimationHandler
                KeyFrameAnimation
                AnimationMorphTarget
                CombiedCamera
                CubeCamera
                Curve
                CurvePath
                Gyroscope
                PathClass
                ShapeClass
                ArcCurve
                ClosedSplineCurve3
                CubicBezierCurve
                CubicBezierCurve3
                EllipseCurve
                LineCurve
                LineCurve3
                QuadraticBezierCurve
                QuadraticBezierCurve3
                SplineCurve
                SplineCurve3
                BoxGeometry
                CircleGeometry
                CylinderGeometry
                ExtrudeGeometry
                IcosahedronGeometry
                LatheGeometry
                OctahedronGeometry
                ParametricGeometry
                PlaneGeometry
                PolyhedronGeometry
                RingGeometry
                ShapeGeometry
                SphereGeometry
                TetrahedronGeometry
                TextGeometry
                TorusGeometry
                TorusKnotGeometry
                TubeGeometry
                AxisHelper
                MorphAnimation
            ]
            Namespace "WebSharper.ThreeJs.Resources" [
                (Resource "three.js" "three.min.js").AssemblyWide ()
            ]
        ]

[<Sealed>]
type Extension () =
    interface IExtension with
        member x.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
