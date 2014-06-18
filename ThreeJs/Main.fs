namespace ThreeJs

open IntelliFactory.WebSharper.InterfaceGenerator

module Definition =
    let O = T<unit>

    open IntelliFactory.WebSharper.InterfaceGenerator.Type

    let Vector3    = Type.New ()
    let Euler      = Type.New ()
    let Quaternion = Type.New ()
    let Matrix4    = Type.New ()

    let EventDispatcher =
        Class "THREE.EventDispatcher"
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "apply"               => T<obj>?``object`` ^-> O
            "addEventListener"    => T<string>?``type`` * (T<obj> ^-> O)?listener ^-> O
            "hasEventListener"    => T<string>?``type`` * (T<obj> ^-> O)?listener ^-> T<bool>
            "removeEventListener" => T<string>?``type`` * (T<obj> ^-> O)?listener ^-> O
            "dispatchEvent"       => T<string>?``type`` ^-> O
        ]

    let Object3D =
        let Object3D = Type.New ()
        
        Class "THREE.Object3D"
        |=> Object3D
        |=> Inherits EventDispatcher
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "id"                     =? T<int>
            "uuid"                   =? T<string>
            "name"                   =@ T<string>
            "parent"                 =@ Object3D
            "children"               =@ ArrayOf Object3D
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
            "rotateOnAxis"              => Vector3?axis * T<float>?angle ^-> Object3D
            "rotateX"                   => T<float>?angle ^-> Object3D
            "rotateY"                   => T<float>?angle ^-> Object3D
            "rotateZ"                   => T<float>?angle ^-> Object3D
            "translateOnAxis"           => Vector3?axis * T<float>?distance ^-> Object3D
            "translateX"                => T<float>?distance ^-> Object3D
            "translateY"                => T<float>?distance ^-> Object3D
            "translateZ"                => T<float>?distance ^-> Object3D
            "localToWorld"              => Vector3?vector ^-> Vector3
            "worldToLocal"              => Vector3?vector ^-> Vector3
            "lookAt"                    => Vector3?vector ^-> O
            "add"                       => Object3D?``object`` ^-> O
            "remove"                    => Object3D?``object`` ^-> O
            "traverse"                  => (Object3D ^-> O)?callback ^-> O
            "getObjectById"             => T<int>?id * T<bool>?``recursive`` ^-> Object3D
            "getObjectByName"           => T<string>?name * T<bool>?``recursive`` ^-> Object3D
            "getDescendants"            => !? (ArrayOf Object3D)?array ^-> ArrayOf Object3D
            "updateMatrix"              => O ^-> O
            "updateMatrixWorld"         => T<bool>?force ^-> O
            "clone"                     => !? Object3D?``object`` * !? T<bool>?``recursive`` ^-> Object3D
        ]

    let Camera =
        let Camera = Type.New ()
        
        Class "THREE.Camera"
        |=> Camera
        |=> Inherits Object3D
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "matrixWorldInverse" =@ Matrix4
            "projectionMatrix"   =@ Matrix4
            
            "lookAt" => Vector3?vector ^-> O
            "clone"  => !? Camera?camera ^-> Camera
        ]
    
    let OrthographicCamera =
        let OrthographicCamera = Type.New ()
        
        Class "THREE.OrthographicCamera"
        |=> OrthographicCamera
        |=> Inherits Camera
        |+> [
            Constructor (T<float>?left * T<float>?right * T<float>?top * T<float>?bottom * !? T<float>?near * !? T<float>?far)
        ]
        |+> Protocol [
            "left"   =@ T<float>
            "right"  =@ T<float>
            "top"    =@ T<float>
            "bottom" =@ T<float>
            "near"   =@ T<float>
            "far"    =@ T<float>

            "updateProjectionMatrix" => O ^-> O
            "clone"                  => O ^-> OrthographicCamera
        ]
    
    let PerspectiveCamera =
        let PerspectiveCamera = Type.New ()
        
        Class "THREE.PerspectiveCamera"
        |=> PerspectiveCamera
        |=> Inherits Camera
        |+> [
            Constructor (!? T<float>?fov * !? T<float>?aspect * !? T<float>?near * !? T<float>?far)
        ]
        |+> Protocol [
            "fov"    =@ T<float>
            "aspect" =@ T<float>
            "near"   =@ T<float>
            "far"    =@ T<float>

            "setLens"                => T<float>?focalLength * !? T<float>?frameHeight ^-> O
            "setViewOffset"          => T<float>?fullWidth * T<float>?fullHeight * T<float>?x * T<float>?y * T<float>?width * T<float>?height ^-> O
            "updateProjectionMatrix" => O ^-> O
            "clone"                  => O ^-> PerspectiveCamera
        ]

    let BufferAttribute =
        Class "THREE.BufferAttribute"
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "length" =? T<int>

            "set"     => T<obj>?value ^-> O
            "setX"    => T<int>?index * T<obj>?x ^-> O
            "setY"    => T<int>?index * T<obj>?y ^-> O
            "setZ"    => T<int>?index * T<obj>?z ^-> O
            "setXY"   => T<int>?index * T<obj>?x * T<obj>?y ^-> O
            "setXYZ"  => T<int>?index * T<obj>?x * T<obj>?y * T<obj>?z ^-> O
            "setXYZW" => T<int>?index * T<obj>?x * T<obj>?y * T<obj>?z * T<obj>?w ^-> O
        ]

    let Box3            = Type.New ()
    let Sphere          = Type.New ()
    
    open IntelliFactory.WebSharper.Html5

    let BufferGeometry =
        let BufferGeometry = Type.New ()
        
        Class "THREE.BufferGeometry"
        |=> BufferGeometry
        |=> Inherits EventDispatcher
        |+> [
            Constructor O
        ]
        |+> Protocol [
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
            "reorderBuffers"        => T<Uint16Array>?indexBuffer * T<Int32Array>?indexMap * T<int>?vertexCount ^-> O
            "clone"                 => O ^-> BufferGeometry
            "dispose"               => O ^-> O
            
        ]
    
    let Clock =
        Class "THREE.Clock"
        |+> [
            Constructor !? T<bool>?autoStart
        ]
        |+> Protocol [
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
        let Color = Type.New ()

        Class "THREE.Color"
        |=> Color
        |+> [
            Constructor (T<int>?r * T<int>?g * T<int>?b)
            Constructor (Color + T<int> + T<string>)?value
        ]
        |+> Protocol [
            "r" =@ T<int>
            "g" =@ T<int>
            "b" =@ T<int>

            "set"                  => (Color + T<int> + T<string>)?value ^-> Color
            "setHex"               => T<int>?hex ^-> Color
            "setRGB"               => T<int>?r * T<int>?g * T<int>?b ^-> Color
            "setHSL"               => T<float>?h * T<float>?s * T<float>?l ^-> Color
            "setStyle"             => T<string>?style ^-> Color
            "copy"                 => Color?color ^-> Color
            "copyGammaToLinear"    => Color?color ^-> Color
            "copyLinearToGamma"    => Color?color ^-> Color
            "convertGammaToLinear" => O ^-> Color
            "convertLinearToGamma" => O ^-> Color
            "getHex"               => O ^-> T<int>
            "getHexString"         => O ^-> T<string>
            "getHSL"               => !? HSL?optionalTarget ^-> HSL
            "getStyle"             => O ^-> T<string>
            "offsetHSL"            => T<float>?h * T<float>?s * T<float>?l ^-> Color
            "add "                 => Color?color ^-> Color
            "addColors"            => Color?color1 * Color?color2 ^-> Color
            "addScalar"            => T<int>?s ^-> Color
            "multiply"             => Color?color ^-> Color
            "multiplyScalar"       => T<int>?s ^-> Color
            "lerp"                 => Color?color * T<float>?alpha ^-> Color
            "equals"               => Color?c ^-> T<bool>
            "fromArray"            => Tuple [T<int>; T<int>; T<int>] ^-> Color
            "toArray"              => O ^-> Tuple [T<int>; T<int>; T<int>]
            "clone"                => O ^-> Color
        ]
    
    let Face3 =
        let Face3 = Type.New ()
        
        Class "THREE.Face3"
        |=> Face3
        |+> [
            Constructor (T<int>?a * T<int>?b * T<int>?c * !? Vector3?normal * !? ColorClass?color * !? T<int>?materialIndex)
        ]
        |+> Protocol [
            "a"              =@ T<int>
            "b"              =@ T<int>
            "c"              =@ T<int>
            "normal"         =@ Vector3
            "vertexNormals"  =@ Tuple [Vector3; Vector3; Vector3]
            "color"          =@ ColorClass
            "vertexColors"   =@ Tuple [ColorClass; ColorClass; ColorClass]
            "vertexTangents" =@ Tuple [T<float>; T<float>; T<float>]
            "materialIndex"  =@ T<int>

            "clone" => O ^-> Face3
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
    
    let Matrix3 = Type.New ()

    let Geometry =
        let Geometry = Type.New ()
        
        Class "THREE.Geometry"
        |=> Geometry
        |=> Inherits EventDispatcher
        |+> [
            Constructor O
        ]
        |+> Protocol [
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
            "merge"                 => Geometry?geometry * !? Matrix3?matrix * !? T<int>?materialIndexOffset ^-> O
            "mergeVertices"         => O ^-> T<int>
            "makeGroups"            => T<bool>?usesFaceMaterial * T<int>?maxVerticesInGroup ^-> O
            "clone"                 => O ^-> Geometry
            "dispose"               => O ^-> O
        ]

    let Raycaster = Type.New ()
    let Scene = Type.New ()

    let Light = Type.New ()

    let ProjectionData =
        Class "ProjectionData"
        |+> Protocol [
            "elements" =@ ArrayOf T<obj>
            "lights"   =@ ArrayOf Light
            "objects"  =@ ArrayOf Object3D
            "sprites"  =@ ArrayOf T<obj>
        ]

    let Projector =
        Class "THREE.Projector"
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "projectVector"   => Vector3?vector * Camera?camera ^-> Vector3
            "unprojectVector" => Vector3?vector * Camera?camera ^-> Vector3
            "pickingRay"      => Vector3?vector * Camera?camera ^-> Raycaster
            "projectScene"    => Scene?scene * Camera?camera * T<bool>?sortObjects * T<bool>?sortElements ^-> ProjectionData
        ]

    let Ray = Type.New ()

    let Intersection =
        Pattern.Config "Intersection" {
            Required = []
            Optional =
            [
                "distance" , T<float>
                "point"    , Vector3
                "face"     , Face3.Type
                "faceIndex", T<int>
                "object"   , Object3D.Type
            ]
        }

    let RaycasterClass =
        Class "THREE.Raycaster"
        |=> Raycaster
        |+> [
            Constructor (Vector3?origin * Vector3?direction * !? T<float>?near * !? T<float>?far)
        ]
        |+> Protocol [
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

    let LightClass =
        Class "THREE.Light"
        |=> Light
        |=> Inherits Object3D
        |+> [
            Constructor Color?color
        ]
        |+> Protocol [
            "color" =@ ColorClass

            "clone" => !? Light?light ^-> Light
        ]
    
    let AmbientLight =
        let AmbientLight = Type.New ()

        Class "THREE.AmbientLight"
        |=> AmbientLight
        |=> Inherits LightClass
        |+> [
            Constructor Color?color
        ]
        |+> Protocol [
            "clone" => O ^-> AmbientLight
        ]

    let AreaLight =
        Class "THREE.AreaLight"
        |=> Inherits LightClass
        |+> [
            Constructor (Color?color * !? T<float>?intensity)
        ]
        |+> Protocol [
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
        let DirectionalLight = Type.New ()

        Class "THREE.DirectionalLight"
        |=> DirectionalLight
        |=> Inherits LightClass
        |+> [
            Constructor (Color?color * !? T<float>?intensity)
        ]
        |+> Protocol [
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

            "clone" => O ^-> DirectionalLight
        ]

    let HemisphereLight =
        let HemisphereLight = Type.New ()
        
        Class "THREE.HemisphereLight"
        |=> HemisphereLight
        |=> Inherits LightClass
        |+> [
            Constructor (Color?skyColor * Color?groundColor * !? T<float>?intensity)
        ]
        |+> Protocol [
            "groundColor" =@ ColorClass
            "intensity"   =@ T<float>

            "clone" => O ^-> HemisphereLight
        ]
    
    let PointLight =
        let PointLight = Type.New ()

        Class "THREE.PointLight"
        |=> PointLight
        |=> Inherits LightClass
        |+> [
            Constructor (Color?color * !? T<float>?intensity * !? T<float>?distance)
        ]
        |+> Protocol [
            "intensity"   =@ T<float>
            "distance"    =@ T<float>

            "clone" => O ^-> PointLight
        ]
    
    let SpotLight =
        let SpotLight = Type.New ()

        Class "THREE.SpotLight"
        |=> SpotLight
        |=> Inherits LightClass
        |+> [
            Constructor (Color?color * !? T<float>?intensity * !? T<float>?distance * !? T<float>?angle * !? T<float>?exponent)
        ]
        |+> Protocol [
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

            "clone" => O ^-> SpotLight
        ]

    let LoadingManager = Type.New ()

    let BufferGeometryLoader =
        Class "THREE.BufferGeometryLoader"
        |+> [
            Constructor !? LoadingManager?manager
        ]
        |+> Protocol [
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? BufferGeometry ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
            "parse"          => T<obj>?json ^-> BufferGeometry
        ]
    
    let Cache =
        Class "THREE.Cache"
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "files" =@ T<obj>

            "add"    => (T<string> + T<int>)?key * T<obj>?file ^-> O
            "get"    => (T<string> + T<int>)?key ^-> O
            "remove" => (T<string> + T<int>)?key ^-> O
            "clear"  => O ^-> O
        ]
    
    open IntelliFactory.WebSharper.Dom

    let ImageLoader =
        Class "THREE.ImageLoader"
        |+> [
            Constructor !? LoadingManager?manager
        ]
        |+> Protocol [
            "cache"       =@ Cache
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * !? (!? T<obj> ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> T<Element>
            "setCrossOrigin" => T<string>?value ^-> O
        ]
        
    let Material = Type.New ()

    let Loader =
        Class "THREE.Loader"
        |+> [
            Constructor T<bool>?showStatus
        ]
        |+> Protocol [
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
        let JSONLoader = Type.New ()
        
        Class "THREE.JSONLoader"
        |=> JSONLoader
        |=> Inherits Loader
        |+> [
            Constructor T<bool>?showStatus
        ]
        |+> Protocol [
            "withCredentials" =@ T<bool>

            "load"         => T<string>?url * (!? Geometry * !? (ArrayOf Material) ^-> O)?callback * !? T<string>?texturePath ^-> O
            "loadAjaxJSON" => JSONLoader?context * T<string>?url * (!? Geometry * !? (ArrayOf Material) ^-> O)?callback * T<string>?texturePath * !? (!? T<obj> ^-> O)?callbackProgress ^-> O
            "parse"        => T<obj>?json * T<string>?texturePath ^-> T<obj>
        ]
    
    let LoadingManagerClass =
        Class "THREE.LoadingManager"
        |=> LoadingManager
        |+> [
            Constructor (!? (O ^-> O)?onLoad * !? (!? T<string>?url * !? T<int>?loaded * !? T<int>?total ^-> O)?onProgress * !? (O ^-> O)?onError)
        ]
        |+> Protocol [
            "onLoad"     =@ (O ^-> O)
            "onProgress" =@ (!? T<string>?url * !? T<int>?loaded * !? T<int>?total ^-> O)
            "onError"    =@ (O ^-> O)

            "itemStart" => T<string>?url ^-> O
            "itemEnd"   => T<string>?url ^-> O
        ]
    
    let MaterialLoader =
        Class "THREE.MaterialLoader"
        |+> [
            Constructor !? LoadingManager?manager
        ]
        |+> [
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? Material ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
            "parse"          => T<obj>?json ^-> Material
        ]

    let ObjectLoader =
        Class "THREE.ObjectLoader"
        |+> [
            Constructor !? LoadingManager?manager
        ]
        |+> Protocol [
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
        |+> [
            Constructor O
        ]
        |+> Protocol [
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
    
    let Texture = Type.New ()

    let TextureLoader =
        Class "THREE.TextureLoader"
        |=> Inherits EventDispatcher
        |+> [
            Constructor !? LoadingManager?manager
        ]
        |+> Protocol [
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? Texture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
        ]

    let XHRLoader =
        Class "THREE.XHRLoader"
        |+> [
            Constructor !? LoadingManager?manager
        ]
        |+> Protocol [
            "cache"       =@ Cache
            "manager"     =@ LoadingManager
            "crossOrigin" =@ T<string>

            "load"           => T<string>?url * (!? T<obj> ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onProgress * !? (!? T<obj> ^-> O)?onError ^-> O
            "setCrossOrigin" => T<string>?value ^-> O
        ]

    let MaterialClass =
        Class "THREE.Material"
        |=> Material
        |=> Inherits EventDispatcher
        |+> [
            Constructor O
        ]
        |+> Protocol [
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
                "color"       , Color
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
        let LineBasicMaterial = Type.New ()

        Class "THREE.LineBasicMaterial"
        |=> LineBasicMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? LineBasicMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"        =@ ColorClass
            "linewidth"    =@ T<float>
            "linecap"      =@ T<string>
            "linejoin"     =@ T<string>
            "vertexColors" =@ T<bool>
            "fog"          =@ T<bool>

            "clone" => O ^-> LineBasicMaterial
        ]
    
    let LineDashedMaterialConfiguration =
        Pattern.Config "LineDashedMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"       , Color
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
        let LineDashedMaterial = Type.New ()

        Class "THREE.LineDashedMaterial"
        |=> LineDashedMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? LineDashedMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"        =@ ColorClass
            "linewidth"    =@ T<float>
            "scale"        =@ T<float>
            "dashSize"     =@ T<float>
            "gapSize"      =@ T<float>
            "vertexColors" =@ T<bool>
            "fog"          =@ T<bool>

            "clone" => O ^-> LineDashedMaterial
        ]

    let MeshBasicMaterialConfiguration =
        Pattern.Config "MeshBasicMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"             , Color
                "opacity"           , T<float>
                "map"               , Texture
                "lightMap"          , Texture
                "specularMap"       , Texture
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
        let MeshBasicMaterial = Type.New ()

        Class "THREE.MeshBasicMaterial"
        |=> MeshBasicMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? MeshBasicMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"              =@ ColorClass
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
            
            "clone" => O ^-> MeshBasicMaterial
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
        let MeshDepthMaterial = Type.New ()
        
        Class "THREE.MeshDepthMaterial"
        |=> MeshDepthMaterial
        |+> [
            Constructor !? MeshDepthMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "morphTargets"       =@ T<bool>
            "wireframe"          =@ T<bool>
            "wireframeLinewidth" =@ T<float>

            "clone" => O ^-> MeshDepthMaterial
        ]

    let MeshFaceMaterial =
        let MeshFaceMaterial = Type.New ()

        Class "THREE.MeshFaceMaterial"
        |=> MeshFaceMaterial
        |=> Inherits Material
        |+> [
            Constructor !? (ArrayOf Material)?materials
        ]
        |+> [
            "materials" =@ ArrayOf Material

            "clone" => O ^-> MeshFaceMaterial
        ]

    let MeshLambertMaterialConfiguration =
        Pattern.Config "MeshLambertMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"             , Color
                "ambient"           , Color
                "emissive"          , Color
                "opacity"           , T<float>
                "map"               , Texture
                "lightMap"          , Texture
                "specularMap"       , Texture
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
        let MeshLambertMaterial = Type.New ()
        
        Class "THREE.MeshLambertMaterial"
        |=> MeshLambertMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? MeshLambertMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"              =@ ColorClass
            "ambient"            =@ ColorClass
            "emissive"           =@ ColorClass
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

            "clone" => O ^-> MeshLambertMaterial
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
        let MeshNormalMaterial = Type.New ()
        
        Class "THREE.MeshNormalMaterial"
        |=> MeshNormalMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? MeshNormalMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "shading"            =@ T<float>
            "wireframe"          =@ T<bool>
            "wireframeLinewidth" =@ T<float>
            "morphTargets"       =@ T<bool>
            
            "clone" => O ^-> MeshNormalMaterial
        ]

    let Vector2 = Type.New ()

    let MeshPhongMaterialConfiguration =
        Pattern.Config "MeshPhongMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"             , Color
                "ambient"           , Color
                "emissive"          , Color
                "specular"          , Color
                "shininess"         , T<float>
                "opacity"           , T<float>
                "map"               , Texture
                "lightMap"          , Texture
                "bumpMap"           , Texture
                "bumpScale"         , T<float>
                "normalMap"         , Texture
                "normalScale"       , Vector2
                "specularMap"       , Texture
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
        let MeshPhongMaterial = Type.New ()
        
        Class "THREE.MeshPhongMaterial"
        |=> MeshPhongMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? MeshPhongMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"              =@ ColorClass
            "ambient"            =@ ColorClass
            "emissive"           =@ ColorClass
            "specular"           =@ ColorClass
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

            "clone" => O ^-> MeshPhongMaterial
        ]
    
    let ParticleSystemMaterialConfiguration =
        Pattern.Config "ParticleSystemMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"       , Color
                "opacity"     , T<float>
                "map"         , Texture
                "size"        , T<float>
                "blending"    , T<int>
                "depthTest"   , T<bool>
                "depthWrite"  , T<bool>
                "vertexColors", T<bool>
                "fog"         , T<bool>
            ]
        }

    let ParticleSystemMaterial =
        let ParticleSystemMaterial = Type.New ()

        Class "THREE.ParticleSystemMaterial"
        |=> ParticleSystemMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? ParticleSystemMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"           =@ ColorClass
            "map"             =@ Texture
            "size"            =@ T<float>
            "sizeAttenuation" =@ T<bool>
            "vertexColors"    =@ T<bool>
            "fog"             =@ T<bool>

            "clone" => O ^-> ParticleSystemMaterial
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
        |+> Protocol [
            "color" =@ Tuple [T<float>; T<float>; T<float>]
            "uv"    =@ Tuple [T<float>; T<float>]
            "uv2"   =@ Tuple [T<float>; T<float>]
        ]

    let ShaderMaterial =
        let ShaderMaterial = Type.New ()

        Class "THREE.ShaderMaterial"
        |=> ShaderMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? ShaderMaterialConfiguration?parameters
        ]
        |+> Protocol [
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

            "clone" => O ^-> ShaderMaterial
        ]

    let RawShaderMaterial =
        let RawShaderMaterial = Type.New ()
        
        Class "THREE.RawShaderMaterial"
        |=> RawShaderMaterial
        |=> Inherits ShaderMaterial
        |+> [
            Constructor !? T<obj>?parameters
        ]
        |+> Protocol [
            "clone" => O ^-> RawShaderMaterial
        ]

    let SpriteCanvasMaterialConfiguration =
        Pattern.Config "SpriteCanvasMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"   , Color
                "program" , (T<obj>?context * T<obj>?color ^-> O)
                "opacity" , T<float>
                "blending", T<int>
            ]
        }

    let SpriteCanvasMaterial =
        let SpriteCanvasMaterial = Type.New ()
        
        Class "THREE.SpriteCanvasMaterial"
        |=> SpriteCanvasMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? SpriteCanvasMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"   =@ ColorClass
            "program" =@ (T<obj>?context * T<obj>?color ^-> O)

            "clone" => O ^-> SpriteCanvasMaterial
        ]
    
    let SpriteMaterialConfiguration =
        Pattern.Config "SpriteMaterialConfiguration" {
            Required = []
            Optional =
            [
                "color"     , Color
                "opacity"   , T<float>
                "map"       , Texture
                "blending"  , T<int>
                "depthTest" , T<bool>
                "depthWrite", T<bool>
                "uvOffset"  , Vector2
                "uvScale"   , Vector2
                "fog"       , T<bool>
            ]
        }

    let SpriteMaterial =
        let SpriteMaterial = Type.New ()

        Class "THREE.SpriteMaterial"
        |=> SpriteMaterial
        |=> Inherits MaterialClass
        |+> [
            Constructor !? SpriteMaterialConfiguration?parameters
        ]
        |+> Protocol [
            "color"    =@ ColorClass
            "map"      =@ Texture
            "rotation" =@ T<float>
            "fog"      =@ T<bool>

            "clone" => O ^-> SpriteMaterial
        ]

    let Box2 =
        let Box2 = Type.New ()
        
        Class "THREE.Box2"
        |=> Box2
        |+> [
            Constructor (!? Vector2?min * !? Vector2?max)
        ]
        |+> Protocol [
            "min" =@ Vector2
            "max" =@ Vector2
            
            "set"                  => Vector2?min * Vector2?max ^-> Box2
            "setFromPoints"        => (ArrayOf Vector2)?points ^-> Box2
            "setFromCenterAndSize" => Vector2?center * Vector2?size ^-> Box2
            "copy"                 => Box2?box ^-> Box2
            "makeEmpty"            => O ^-> Box2
            "empty"                => O ^-> T<bool>
            "center"               => !? Vector2?optionalTarget ^-> Vector2
            "size"                 => !? Vector2?optionalTarget ^-> Vector2
            "expandByPoint"        => Vector2?point ^-> Box2
            "expandByVector"       => Vector2?vector ^-> Box2
            "expandByScalar"       => T<float>?scalar ^-> Box2
            "containsPoint"        => Vector2?point ^-> T<bool>
            "containsBox"          => Box2?box ^-> T<bool>
            "getParameter"         => Vector2?point * !? Vector2?optionalTarget ^-> Vector2
            "isIntersectionBox"    => Box2?box ^-> T<bool>
            "clampPoint"           => Vector2?point * !? Vector2?optionalTarget ^-> Vector2
            "distanceToPoint"      => Vector2?point ^-> T<float>
            "intersect"            => Box2?box ^-> Box2
            "union"                => Box2?box ^-> Box2
            "translate"            => Vector2?offset ^-> Box2
            "equals"               => Box2?box ^-> T<bool>
            "clone"                => O ^-> Box2
        ]
    
    let Box3Class =
        Class "THREE.Box3"
        |=> Box3
        |+> [
            Constructor (!? Vector3?min * !? Vector3?max)
        ]
        |+> Protocol [
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

    let EulerClass =
        Class "THREE.Euler"
        |=> Euler
        |+> [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<string>?order)
        ]
        |+> Protocol [
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

    let Plane = Type.New ()

    let Frustum =
        let Frustum = Type.New ()
        
        Class "THREE.Frustum"
        |=> Frustum
        |+> [
            Constructor (!? Plane?p0 * !? Plane?p1 * !? Plane?p2 * !? Plane?p3 * !? Plane?p4 * !? Plane?p5)
        ]
        |+> Protocol [
            "planes" =@ ArrayOf Plane

            "set"              => Plane?p0 * Plane?p1 * Plane?p2 * Plane?p3 * Plane?p4 * Plane?p5 ^-> Frustum
            "copy"             => Frustum?frustum ^-> Frustum
            "setFromMatrix"    => Matrix4?m ^-> Frustum
            "intersectsObject" => Object3D?``object`` ^-> T<bool>
            "intersectsSphere" => Sphere?sphere ^-> T<bool>
            "intersectsBox"    => T<obj>?box ^-> T<bool>
            "containsPoint"    => Vector3?point ^-> T<bool>
            "clone"            => O ^-> Frustum
        ]

    let Line3 =
        let Line3 = Type.New ()
        
        Class "THREE.Line3"
        |=> Line3
        |+> [
            Constructor (!? Vector3?start * !? Vector3?``end``)
        ]
        |+> Protocol [
            "start" =@ Vector3
            "end"   =@ Vector3

            "set"                          => Vector3?start * Vector3?``end`` ^-> Line3
            "copy"                         => Line3?line ^-> Line3
            "center"                       => !? Vector3?optionalTarget ^-> Vector3
            "delta"                        => !? Vector3?optionalTarget ^-> Vector3
            "distanceSq"                   => O ^-> T<float>
            "distance"                     => O ^-> T<float>
            "at"                           => T<float>?t * !? Vector3?optionalTarget ^-> Vector3
            "closestPointToPointParameter" => Vector3?point * T<bool>?clampToLine ^-> T<float>
            "closestPointToPoint"          => Vector3?point * T<bool>?clampToLine * !? Vector3?optionalTarget ^-> Vector3
            "applyMatrix4"                 => Matrix4?matrix ^-> Line3
            "equals"                       => Line3?line ^-> T<bool>
            "clone"                        => O ^-> Line3
        ]

    let Math =
        Class "THREE.Math"
        |+> [
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
    
    let Matrix3Class =
        Class "THREE.Matrix3"
        |=> Matrix3
        |+> [
            Constructor (!? T<float>?n11 * !? T<float>?n12 * !? T<float>?n13 * !? T<float>?n21 * !? T<float>?n22 * !? T<float>?n23 * !? T<float>?n31 * !? T<float>?n32 * !? T<float>?n33)
        ]
        |+> Protocol [
            "elements" =@ T<Float32Array>

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

    let Matrix4Class =
        Class "THREE.Matrix4"
        |=> Matrix4
        |+> [
            Constructor (!? T<float>?n11 * !? T<float>?n12 * !? T<float>?n13 * !? T<float>?n14 * !? T<float>?n21 * !? T<float>?n22 * !? T<float>?n23 * !? T<float>?n24 * !? T<float>?n31 * !? T<float>?n32 * !? T<float>?n33 * !? T<float>?n34 * !? T<float>?n41 * !? T<float>?n42 * !? T<float>?n43 * !? T<float>?n44)
        ]
        |+> [
            "elements" =@ T<Float32Array>

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
            "multiplyToArray"            => Matrix4?a * Matrix4?b * ((ArrayOf T<float>) + T<Float32Array>)?r ^-> Matrix4
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

    let PlaneClass =
        Class "THREE.Plane"
        |=> Plane
        |+> [
            Constructor (!? Vector3?normal * !? T<float>?constant)
        ]
        |+> Protocol [
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

    let QuaternionClass =
        Class "THREE.Quaternion"
        |=> Quaternion
        |+> [
            Constructor (!? T<float>?x * !? T<float>?y * !? T<float>?z * !? T<float>?w)
        ]
        |+> Protocol [
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

    let RayClass =
        Class "THREE.Ray"
        |=> Ray
        |+> [
            Constructor (Vector3?origin * Vector3?direction)
        ]
        |+> Protocol [
            "origin"    =@ Vector3
            "direction" =@ Vector3

            "applyMatrix4"         => Matrix4?matrix4 ^-> Ray
            "at"                   => T<float>?t * Vector3?optionalTarget ^-> Vector3
            "clone"                => O ^-> Ray
            "closestPointToPoint"  => Vector3?point * Vector3?optionalTarget ^-> Vector3
            "copy"                 => Ray?ray ^-> Ray
            "distanceSqToSegment"  => Vector3?v0 * Vector3?v1 * Vector3?optionalPointOnRay * Vector3?optionalPointOnSegment ^-> T<float>
            "distanceToPlane"      => Plane?plane ^-> T<float>
            "distanceToPoint"      => Vector3?point ^-> T<float>
            "equals"               => Ray?ray ^-> T<bool>
            "intersectBox"         => Box3?box * Vector3?optionalTarget ^-> Vector3
            "intersectPlane"       => Plane?plane * Vector3?optionalTarget ^-> Vector3
            "intersectTriangle"    => Vector3?a * Vector3?b * Vector3?c * T<bool>?backfaceCulling * Vector3?optionalTarget ^-> Vector3
            "isIntersectionBox"    => Box3?box ^-> T<bool>
            "isIntersectionPlane"  => Plane?plane ^-> T<bool>
            "isIntersectionSphere" => Sphere?sphere ^-> T<bool>
            "recast"               => T<float>?t ^-> O
            "set"                  => Vector3?origin * Vector3?direction ^-> Ray
        ]

    let SphereClass =
        Class "THREE.Sphere"
        |=> Sphere
        |+> [
            Constructor (Vector3?center * T<float>?radius)
        ]
        |+> Protocol [
            "center" =@ Vector3
            "radius" =@ T<float>

            "set"              => Vector3?center * T<float>?radius ^-> Sphere
            "applyMatrix4"     => Matrix4?matrix ^-> Sphere
            "clampPoint"       => Vector3?point * Vector3?optionalTarget ^-> Vector3
            "translate"        => Vector3?offset ^-> Sphere
            "clone"            => O ^-> Sphere
            "equals"           => Sphere?sphere ^-> T<bool>
            "setFromPoints"    => (ArrayOf Vector3)?points * Vector3?optionalCenter ^-> Sphere
            "distanceToPoint"  => Vector3?point ^-> T<float>
            "getBoundingBox"   => Box3?optionalTarget ^-> Box3
            "containsPoint"    => Vector3?point ^-> T<bool>
            "copy"             => Sphere?sphere ^-> Sphere
            "intersectsSphere" => Sphere?sphere ^-> T<bool>
            "empty"            => O ^-> T<bool>
        ]

    let Spline =
        Class "THREE.Spline"
        |+> [
            Constructor (ArrayOf Vector3)?points
        ]
        |+> Protocol [
            "points" =@ ArrayOf Vector3

            "initFromArray"            => (ArrayOf Vector3)?a ^-> O
            "getPoint"                 => T<int>?k ^-> O
            "getControlPointsArray"    => O ^-> O
            "getLength"                => T<int>?nSubDivisions ^-> O
            "reparametrizeByArcLength" => T<float>?samplingCoef ^-> O
        ]

    let Triangle =
        let Triangle = Type.New ()
        
        Class "THREE.Triangle"
        |=> Triangle
        |+> [
            Constructor (Vector3?a * Vector3?b * Vector3?c)
        ]
        |+> Protocol [
            "a" =@ Vector3
            "c" =@ Vector3
            "b" =@ Vector3

            "setFromPointsAndIndices" => (ArrayOf Vector3)?points * T<int>?i0 * T<int>?i1 * T<int>?i2 ^-> Triangle
            "set"                     => Vector3?a * Vector3?b * Vector3?c ^-> Triangle
            "normal"                  => Vector3?optionalTarget ^-> Vector3
            "barycoordFromPoint"      => Vector3?point * Vector3?optionalTarget ^-> Vector3
            "clone"                   => O ^-> Triangle
            "area"                    => O ^-> T<float>
            "midpoint"                => Vector3?optionalTarget ^-> Vector3
            "equals"                  => Triangle?triangle ^-> T<bool>
            "plane"                   => Plane?optionalTarget ^-> Plane
            "containsPoint"           => Vector3?point ^-> T<bool>
            "copy"                    => Triangle?triangle ^-> Triangle
        ]

    let Vector2Class =
        Class "THREE.Vector2"
        |=> Vector2
        |+> [
            Constructor (T<float>?x * T<float>?y)
        ]
        |+> Protocol [
            "x" =@ T<float>
            "y" =@ T<float>

            "set"               => T<float>?x * T<float>?y ^-> Vector2
            "copy"              => Vector2?v ^-> Vector2
            "add"               => Vector2?v ^-> Vector2
            "addVectors"        => Vector2?a * Vector2?b ^-> Vector2
            "sub"               => Vector2?v ^-> Vector2
            "subVectors"        => Vector2?a * Vector2?b ^-> Vector2
            "multiplyScalar"    => T<float>?s ^-> Vector2
            "divideScalar"      => T<float>?s ^-> Vector2
            "negate"            => O ^-> Vector2
            "dot"               => Vector2?v ^-> T<float>
            "lengthSq"          => O ^-> T<float>
            "length"            => O ^-> T<float>
            "normalize"         => O ^-> Vector2
            "distanceTo"        => Vector2?v ^-> T<float>
            "distanceToSquared" => Vector2?v ^-> T<float>
            "setLength"         => T<float>?l ^-> Vector2
            "equals"            => Vector2?v ^-> T<bool>
            "clone"             => O ^-> Vector2
            "clamp"             => Vector2?min * Vector2?max ^-> Vector2
            "clampScalar"       => T<float>?min * T<float>?max ^-> Vector2
            "floor"             => O ^-> Vector2
            "ceil"              => O ^-> Vector2
            "round"             => O ^-> Vector2
            "roundToZero"       => O ^-> Vector2
            "lerp"              => Vector2?v * T<float>?alpha ^-> Vector2
            "setComponent"      => T<int>?index * T<float>?value ^-> O
            "addScalar"         => T<float>?s ^-> Vector2
            "getComponent"      => T<int>?index ^-> T<float>
            "fromArray"         => (Tuple [T<float>; T<float>])?array ^-> Vector2
            "toArray"           => O ^-> Tuple [T<float>; T<float>]
            "min"               => Vector2?v ^-> Vector2
            "max"               => Vector2?v ^-> Vector2
            "setX"              => T<float>?x ^-> Vector2
            "setY"              => T<float>?y ^-> Vector2
        ]

    let Vector3Class =
        Class "THREE.Vector3"
        |=> Vector3
        |+> [
            Constructor (T<float>?x * T<float>?y * T<float>?z)
        ]
        |+> Protocol [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>

            "set"                   => T<float>?x * T<float>?y * T<float>?z ^-> Vector3
            "setX"                  => T<float>?x ^-> Vector3
            "setY"                  => T<float>?y ^-> Vector3
            "setZ"                  => T<float>?z ^-> Vector3
            "copy"                  => Vector3?v ^-> Vector3
            "add"                   => Vector3?v ^-> Vector3
            "addVectors"            => Vector3?a * Vector3?b ^-> Vector3
            "sub"                   => Vector3?v ^-> Vector3
            "subVectors"            => Vector3?a * Vector3?b ^-> Vector3
            "multiplyScalar"        => T<float>?s ^-> Vector3
            "divideScalar"          => T<float>?s ^-> Vector3
            "negate"                => O ^-> Vector3
            "dot"                   => Vector3?v ^-> T<float>
            "lengthSq"              => O ^-> T<float>
            "length"                => O ^-> T<float>
            "lengthManhattan"       => O ^-> T<float>
            "normalize"             => O ^-> Vector3
            "distanceTo"            => Vector3?v ^-> T<float>
            "distanceToSquared"     => Vector3?v ^-> T<float>
            "setLength"             => T<float>?l ^-> Vector3
            "cross"                 => Vector3?v ^-> Vector3
            "crossVectors"          => Vector3?a * Vector3?b ^-> Vector3
            "setFromMatrixPosition" => Matrix4?m ^-> Vector3
            "setFromMatrixScale"    => Matrix4?m ^-> Vector3
            "equals"                => Vector3?v ^-> T<bool>
            "clone"                 => O ^-> Vector3
            "clamp"                 => Vector3?min * Vector3?max ^-> Vector3
            "clampScalar"           => T<float>?min * T<float>?max ^-> Vector3
            "floor"                 => O ^-> Vector3
            "ceil"                  => O ^-> Vector3
            "round"                 => O ^-> Vector3
            "roundToZero"           => O ^-> Vector3
            "applyMatrix3"          => Matrix3?m ^-> Vector3
            "applyMatrix4"          => Matrix3?m ^-> Vector3
            "projectOnPlane"        => Vector3?planeNormal ^-> Vector3
            "projectOnVector"       => O ^-> Vector3
            "addScalar"             => O ^-> Vector3
            "divide"                => Vector3?v ^-> Vector3
            "min"                   => Vector3?v ^-> Vector3
            "max"                   => Vector3?v ^-> Vector3
            "setComponent"          => T<int>?index * T<float>?value ^-> Vector3
            "transformDirection"    => Matrix4?m ^-> Vector3
            "multiplyVectors"       => Vector3?a * Vector3?b ^-> Vector3
            "getComponent"          => T<int>?index ^-> T<float>
            "applyAxisAngle"        => Vector3?axis * T<float>?angle ^-> Vector3
            "lerp"                  => Vector3?v * T<float>?alpha ^-> Vector3
            "angleTo"               => Vector3?v ^-> T<float>
            "setFromMatrixColumn"   => T<int>?index * Matrix4?matrix ^-> Vector3
            "reflect"               => Vector3?normal ^-> Vector3
            "fromArray"             => (Type.Tuple [T<float>; T<float>; T<float>])?array ^-> Vector3
            "multiply"              => Vector3?v ^-> Vector3
            "applyProjection"       => Matrix4?m ^-> Vector3
            "toArray"               => O ^-> Type.Tuple [T<float>; T<float>; T<float>]
            "applyEuler"            => Euler?euler ^-> Vector3
            "applyQuaternion"       => Quaternion?quaternion ^-> Vector3
        ]

    let Vector4 =
        let Vector4 = Type.New ()

        Class "THREE.Vector4"
        |=> Vector4
        |+> [
            Constructor (T<float>?x * T<float>?y * T<float>?z * T<float>?w)
        ]
        |+> Protocol [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>
            "w" =@ T<float>

            "set"                            => T<float>?x * T<float>?y * T<float>?z * T<float>?w ^-> Vector4
            "copy"                           => Vector4?v ^-> Vector4
            "add"                            => Vector4?v ^-> Vector4
            "addVectors"                     => Vector4?a * Vector4?b ^-> Vector4
            "sub"                            => Vector4?v ^-> Vector4
            "subVectors"                     => Vector4?a * Vector4?b ^-> Vector4
            "multiplyScalar"                 => T<float>?s ^-> Vector4
            "divideScalar"                   => T<float>?s ^-> Vector4
            "negate"                         => O ^-> Vector4
            "dot"                            => Vector4?v ^-> T<float>
            "lengthSq"                       => O ^-> T<float>
            "length"                         => O ^-> T<float>
            "normalize"                      => O ^-> Vector4
            "setLength"                      => T<float>?l ^-> Vector4
            "lerp"                           => Vector4?v * T<float>?alpha ^-> Vector4
            "clone"                          => O ^-> Vector4
            "clamp"                          => Vector4?min * Vector4?max ^-> Vector4
            "clampScalar"                    => T<float>?min * T<float>?max ^-> Vector4
            "floor"                          => O ^-> Vector4
            "ceil"                           => O ^-> Vector4
            "round"                          => O ^-> Vector4
            "roundToZero"                    => O ^-> Vector4
            "applyMatrix4"                   => Matrix4?m ^-> Vector4
            "min"                            => Vector4?v ^-> Vector4
            "max"                            => Vector4?v ^-> Vector4
            "addScalar"                      => T<float>?s ^-> Vector4
            "equals"                         => Vector4?v ^-> T<bool>
            "setAxisAngleFromRotationMatrix" => Matrix4?m ^-> Vector4
            "setAxisAngleFromQuaternion"     => Quaternion?q ^-> Vector4
            "getComponent"                   => T<int>?index ^-> T<float>
            "setComponent"                   => T<int>?index * T<float>?value ^-> O
            "fromArray"                      => (Tuple [T<float>; T<float>; T<float>; T<float>])?array ^-> Vector4
            "toArray"                        => O ^-> Tuple [T<float>; T<float>; T<float>; T<float>]
            "lengthManhattan"                => O ^-> T<float>
            "setX"                           => T<float>?x ^-> Vector4
            "setY"                           => T<float>?y ^-> Vector4
            "setZ"                           => T<float>?z ^-> Vector4
            "setW"                           => T<float>?w ^-> Vector4
        ]
    
    let SkinnedMesh = Type.New ()

    let Bone =
        Class "THREE.Bone"
        |=> Inherits Object3D
        |+> [
            Constructor (SkinnedMesh?belongsToSkin)
        ]
        |+> Protocol [
            "skin"                 =@ SkinnedMesh
            "skinMatrix"           =@ Matrix4
            "accumulatedRotWeight" =@ T<float>
            "accumulatedPosWeight" =@ T<float>
            "accumulatedSclWeight" =@ T<float>

            "update" => Matrix4?parentSkinMatrix * !? T<bool>?forceUpdate ^-> O
        ]

    let Line =
        let Line = Type.New ()
        
        Class "THREE.Line"
        |=> Line
        |=> Inherits Object3D
        |+> [
            Constructor (!? Geometry?geometry * !? Material?material * !? T<int>?``type``)
        ]
        |+> Protocol [
            "geometry" =@ Geometry
            "material" =@ Material
            "type"     =@ T<int>

            "clone" => !? Line?``object`` ^-> Line
        ]
    
    let LOD =
        let LOD = Type.New ()
        
        Class "THREE.LOD"
        |=> LOD
        |=> Inherits Object3D
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "objects" =@ ArrayOf Object3D

            "addLevel"             => Object3D?``object`` * !? T<float>?distance ^-> O
            "getObjectForDistance" => T<float>?distance ^-> Object3D
            "update"               => Camera?camera ^-> O
            "clone"                => !? LOD?``object`` ^-> LOD
        ]
    
    let Mesh =
        let Mesh = Type.New ()

        Class "THREE.Mesh"
        |=> Mesh
        |=> Inherits Object3D
        |+> [
            Constructor (!? Geometry?geometry * !? Material?material)
        ]
        |+> Protocol [
            "geometry" =@ Geometry
            "material" =@ Material

            "updateMorphTargets"        => O ^-> O
            "getMorphTargetIndexByName" => T<string>?name ^-> T<int>
            "clone"                     => !? Mesh?``object`` * !? T<bool>?``recursive`` ^-> Mesh
            
        ]

    let MorphAnimMesh =
        let MorphAnimMesh = Type.New ()

        Class "THREE.MorphAnimMesh"
        |=> MorphAnimMesh
        |=> Inherits Mesh
        |+> [
            Constructor (Geometry?geometry * Material?material)
        ]
        |+> Protocol [
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
            "clone"                => !? MorphAnimMesh?``object`` ^-> MorphAnimMesh
        ]

    let ParticleSystem =
        let ParticleSystem = Type.New ()
        
        Class "THREE.ParticleSystem"
        |=> ParticleSystem
        |=> Inherits Object3D
        |+> [
            Constructor (!? Geometry?geometry * !? Material?material)
        ]
        |+> Protocol [
            "geometry"       =@ Geometry
            "material"       =@ Material
            "sortParticles"  =@ T<bool>
            "frustrumCulled" =@ T<bool>

            "clone" => !? ParticleSystem ^-> ParticleSystem
        ]

    let Skeleton = Type.New ()

    let SkinnedMeshClass =
        Class "THREE.SkinnedMesh"
        |=> SkinnedMesh
        |=> Inherits Mesh
        |+> [
            Constructor (Geometry?geometry * Material?material * T<bool>?useVertexTexture)
        ]
        |+> Protocol [
            "skeleton"       =@ Skeleton
            "identityMatrix" =@ Matrix4

            "updateMatrixWorld"    => T<bool>?force ^-> O
            "pose"                 => O ^-> O
            "normalizeSkinWeights" => O ^-> O
            "clone"                => !? SkinnedMesh?``object`` ^-> SkinnedMesh
        ]

    let Sprite =
        let Sprite = Type.New ()
        
        Class "THREE.Sprite"
        |=> Sprite
        |=> Inherits Object3D
        |+> [
            Constructor (!? Material?material)
        ]
        |+> Protocol [
            "geometry" =@ Geometry
            "material" =@ SpriteMaterial

            "updateMatrix" => O ^-> O
            "clone"        => !? Sprite?``object`` ^-> O
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
        |+> [
            Constructor !? CanvasRendererConfiguration?parameters
        ]
        |+> Protocol [
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
        |+> Protocol [
            "programs"   =@ T<int>
            "geometries" =@ T<int>
            "textures"   =@ T<int>
        ]

    let RenderInfo =
        Class "RenderInfo"
        |+> Protocol [
            "calls"    =@ T<int>
            "vertices" =@ T<int>
            "faces"    =@ T<int>
            "points"   =@ T<int>
        ]

    let Info =
        Class "Info"
        |+> Protocol [
            "memory" =@ MemoryInfo
            "render" =@ RenderInfo
        ]

    let WebGLRenderer =
        Class "THREE.WebGLRenderer"
        |+> [
            Constructor !? WebGLRendererConfiguration?parameters
        ]
        |+> Protocol [
            "domElement"          =@ T<Element>
            "context"             =@ T<WebGL.WebGLRenderingContext>
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
            

            "getContext"                      => O ^-> T<WebGL.WebGLRenderingContext>
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
            "getClearColor"                   => O ^-> ColorClass
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
        |+> [
            Constructor (T<float>?width * T<float>?height * !? T<obj>?options)
        ]
        |+> Protocol [
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
        |+> Protocol [
            "activeCubeFace" =@ T<int>
        ]

    let RenderableVertex = Type.New ()

    let RenderableFace =
        Class "THREE.RenderableFace"
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "id"                  =? T<int>
            "v1"                  =@ RenderableVertex
            "v2"                  =@ RenderableVertex
            "v3"                  =@ RenderableVertex
            "normalModel"         =@ Vector3
            "vertexNormalsModel"  =@ Tuple [Vector3; Vector3; Vector3]
            "vertexNormalsLength" =@ T<int>
            "color"               =@ ColorClass
            "material"            =@ Material
            "uvs"                 =@ Tuple [Vector2; Vector2; Vector2]
            "z"                   =@ T<float>
        ]
    
    let RenderableLine =
        Class "THREE.RenderableLine"
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "id"           =? T<int>
            "v1"           =@ RenderableVertex
            "v2"           =@ RenderableVertex
            "vertexColors" =@ Tuple [ColorClass; ColorClass]
            "material"     =@ Material
            "z"            =@ T<obj>
            
        ]

    let RenderableObject =
        Class "THREE.RenderableObject"
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "id"     =@ T<int>
            "object" =@ Object3D
            "z"      =@ T<float>
        ]

    let RenderableSprite =
        Class "THREE.RenderableSprite"
        |+> [
            Constructor O
        ]
        |+> Protocol [
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
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "position"       =@ Vector3
            "positionWorld"  =@ Vector3
            "positionScreen" =@ Vector4
            "visible"        =@ T<bool>
            
            "copy" => RenderableVertex?vertex ^-> O
        ]

    let ShaderChunk =
        Class "THREE.ShaderChunk"
        |+> [
            "fog_pars_fragment"          =? T<string>
            "fog_fragment"               =? T<string>
            "envmap_pars_fragment"       =? T<string>
            "envmap_fragment"            =? T<string>
            "envmap_pars_vertex"         =? T<string>
            "worldpos_vertex"            =? T<string>
            "envmap_vertex"              =? T<string>
            "map_particle_pars_fragment" =? T<string>
            "map_particle_fragment"      =? T<string>
            "map_pars_vertex"            =? T<string>
            "map_pars_fragment"          =? T<string>
            "map_vertex"                 =? T<string>
            "map_fragment"               =? T<string>
            "lightmap_pars_fragment"     =? T<string>
            "lightmap_pars_vertex"       =? T<string>
            "lightmap_fragment"          =? T<string>
            "lightmap_vertex"            =? T<string>
            "bumpmap_pars_fragment"      =? T<string>
            "normalmap_pars_fragment"    =? T<string>
            "specularmap_pars_fragment"  =? T<string>
            "specularmap_fragment"       =? T<string>
            "lights_lambert_pars_vertex" =? T<string>
            "lights_lambert_vertex"      =? T<string>
            "lights_phong_pars_vertex"   =? T<string>
            "lights_phong_vertex"        =? T<string>
            "lights_phong_pars_fragment" =? T<string>
            "lights_phong_fragment"      =? T<string>
            "color_pars_fragment"        =? T<string>
            "color_fragment"             =? T<string>
            "color_pars_vertex"          =? T<string>
            "color_vertex"               =? T<string>
            "skinning_pars_vertex"       =? T<string>
            "skinbase_vertex"            =? T<string>
            "skinning_vertex"            =? T<string>
            "morphtarget_pars_vertex"    =? T<string>
            "morphtarget_vertex"         =? T<string>
            "default_vertex"             =? T<string>
            "morphnormal_vertex"         =? T<string>
            "skinnormal_vertex"          =? T<string>
            "defaultnormal_vertex"       =? T<string>
            "shadowmap_pars_fragment"    =? T<string>
            "shadowmap_fragment"         =? T<string>
            "shadowmap_pars_vertex"      =? T<string>
            "shadowmap_vertex"           =? T<string>
            "alphatest_fragment"         =? T<string>
            "linear_to_gamma_fragment"   =? T<string>
            "logdepthbuf_pars_vertex"    =? T<string>
            "logdepthbuf_vertex"         =? T<string>
            "logdepthbuf_pars_fragment"  =? T<string>
            "logdepthbuf_fragment"       =? T<string>
        ]

    let ShaderLib =
        let Info =
            Class "Info"
            |+> Protocol [
                "uniforms"       =? T<obj>
                "vertexShader"   =? T<string>
                "fragmentShader" =? T<string>
            ]
        
        Class "THREE.ShaderLib"
        |+> [
            "basic"          =? Info
            "lambert"        =? Info
            "phong"          =? Info
            "particle_basic" =? Info
            "dashed"         =? Info
            "depth"          =? Info
            "normal"         =? Info
            "normalmap"      =? Info
            "cube"           =? Info
            "depthRGBA"      =? Info
        ]
        |=> Nested [
            Info
        ]
    
    let TypeValuePair =
        Generic / fun a ->
            Class "TypeValuePair"
            |+> [
                "type"  =@ T<string>
                "value" =@ a
            ]

    let UniformsLib =
        let Common =
            Class "Common"
            |+> Protocol [
                "diffuse"               =@ TypeValuePair ColorClass
                "opacity"               =@ TypeValuePair T<float>
                "map"                   =@ TypeValuePair Texture
                "offsetRepeat"          =@ TypeValuePair Vector4
                "lightMap"              =@ TypeValuePair T<obj>
                "specularMap"           =@ TypeValuePair T<obj>
                "envMap"                =@ TypeValuePair T<obj>
                "flipEnvMap"            =@ TypeValuePair T<int>
                "useRefract"            =@ TypeValuePair T<int>
                "reflectivity"          =@ TypeValuePair T<float>
                "refractionRatio"       =@ TypeValuePair T<float>
                "combine"               =@ TypeValuePair T<int>
                "morphTargetInfluences" =@ TypeValuePair T<int>
            ]
        
        let Bump =
            Class "Bump"
            |+> Protocol [
                "bumpMap"   =@ TypeValuePair T<obj>
                "bumpScale" =@ TypeValuePair T<float>
            ]

        let Normalmap =
            Class "Normalmap"
            |+> Protocol [
                "normalMap"   =@ TypeValuePair T<obj>
                "normalScale" =@ TypeValuePair Vector2
            ]
    
        let Fog =
            Class "Fog"
            |+> Protocol [
                "fogDestiny" =@ TypeValuePair T<float>
                "fogNear"    =@ TypeValuePair T<float>
                "fogFar"     =@ TypeValuePair T<float>
                "fogColor"   =@ TypeValuePair ColorClass
            ]

        let Lights =
            Class "Lights"
            |+> Protocol [
                "ambientLightColor"           =@ TypeValuePair (ArrayOf T<obj>)
                "directionalLightDirection"   =@ TypeValuePair (ArrayOf T<obj>)
                "directionalLightColor"       =@ TypeValuePair (ArrayOf T<obj>)
                "hemisphereLightDirection"    =@ TypeValuePair (ArrayOf T<obj>)
                "hemisphereLightSkyColor"     =@ TypeValuePair (ArrayOf T<obj>)
                "hemisphereLightGroundColor"  =@ TypeValuePair (ArrayOf T<obj>)
                "pointLightColor"             =@ TypeValuePair (ArrayOf T<obj>)
                "pointLightPosition"          =@ TypeValuePair (ArrayOf T<obj>)
                "pointLightDistance"          =@ TypeValuePair (ArrayOf T<obj>)
                "spotLightColor"              =@ TypeValuePair (ArrayOf T<obj>)
                "spotLightPosition"           =@ TypeValuePair (ArrayOf T<obj>)
                "spotLightDirection"          =@ TypeValuePair (ArrayOf T<obj>)
                "spotLightDistance"           =@ TypeValuePair (ArrayOf T<obj>)
                "spotLightAngleCos"           =@ TypeValuePair (ArrayOf T<obj>)
                "spotLightExponent"           =@ TypeValuePair (ArrayOf T<obj>)
            ]

        let Particle =
            Class "Particle"
            |+> Protocol [
                "psColor"    =@ TypeValuePair ColorClass
                "opacity"    =@ TypeValuePair T<float>
                "size"       =@ TypeValuePair T<float>
                "scale"      =@ TypeValuePair T<float>
                "map"        =@ TypeValuePair Texture
                "fogDensity" =@ TypeValuePair T<float>
                "fogNear"    =@ TypeValuePair T<float>
                "fogFar"     =@ TypeValuePair T<float>
                "fogColor"   =@ TypeValuePair ColorClass
            ]

        let Shadowmap =
            Class "Shadowmap"
            |+> Protocol [
                "shadowMap"      =@ TypeValuePair (ArrayOf T<obj>)
                "shadowMapSize"  =@ TypeValuePair (ArrayOf T<obj>)
                "shadowBias"     =@ TypeValuePair (ArrayOf T<obj>)
                "shadowDarkness" =@ TypeValuePair (ArrayOf T<obj>)
                "shadowMatrix"   =@ TypeValuePair (ArrayOf T<obj>)
            ]

        Class "THREE.UniformsLib"
        |+> [
            "common"    =@ Common
            "bump"      =@ Bump
            "normalmap" =@ Normalmap
            "fog"       =@ Fog
            "lights"    =@ Lights
            "particle"  =@ Particle
            "shadowmap" =@ Shadowmap
        ]
        |=> Nested [
            Common
            Bump
            Normalmap
            Fog
            Lights
            Particle
            Shadowmap
        ]

    let UniformsUtils =
        Class "THREE.UniformsUtils"
        |+> [
            "merge" => (ArrayOf T<obj>)?uniforms ^-> T<obj>
            "clone" => T<obj>?uniforms_src ^-> T<obj>
        ]

    let WebGLProgram =
        Class "THREE.WebGLProgram"
        |+> [
            Constructor (T<obj>?renderer * T<obj>?code * Material?material * T<obj>?parameters)
        ]
        |+> Protocol [
            "uniforms"        =@ T<obj>
            "attributes"      =@ T<obj>
            "id"              =? T<int>
            "code"            =@ T<obj>
            "usedTimes"       =@ T<int>
            "program"         =@ T<obj>
            "vertexShader"    =@ T<obj>
            "fragementShader" =@ T<obj>
        ]

    let WebGLShader =
        Class "THREE.WebGLShader"
        |+> [
            Constructor (T<obj>?gl * T<obj>?``type`` * T<string>?``string``)
        ]
    
    let FogClass =
        Class "THREE.Fog"
        |=> Fog
        |+> [
            Constructor (Color?color * !? T<float>?near * !? T<float>?far)
        ]
        |+> Protocol [
            "name"  =@ T<string>
            "color" =@ ColorClass
            "near"  =@ T<float>
            "far"   =@ T<float>

            "clone" => O ^-> Fog
        ]

    let FogExp2 =
        let FogExp2 = Type.New ()
        
        Class "THREE.FogExp2"
        |=> FogExp2
        |+> [
            Constructor (Color?color * !? T<float>?density)
        ]
        |+> Protocol [
            "name"    =@ T<string>
            "color"   =@ ColorClass
            "density" =@ T<float>

            "clone" => O ^-> FogExp2
        ]

    let SceneClass =
        Class "THREE.Scene"
        |=> Scene
        |=> Inherits Object3D
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "fog"              =@ Fog
            "overrideMaterial" =@ Material
            "autoUpdate"       =@ T<bool>
            "matrixAutoUpdate" =@ T<bool>

            "clone" => !? Scene?``object`` ^-> Scene
        ]

    let TextureClass =
        Class "THREE.Texture"
        |=> Texture
        |=> Inherits EventDispatcher
        |+> [
            Constructor (T<Element>?image * !? T<int>?mapping * !? T<int>?wrapS * !? T<int>?wrapT * !? T<int>?magFilter * !? T<int>?minFilter * !? T<int>?format * !? T<int>?``type`` * !? T<int>?anisotropy)
        ]
        |+> Protocol [
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
        |=> Inherits TextureClass
        |+> [
            Constructor ((ArrayOf T<obj>)?mipmaps * T<int>?width * T<int>?height * T<int>?format * T<int>?``type`` * T<int>?mapping * T<int>?wrapS * T<int>?wrapT * T<int>?magFilter * T<int>?minFilter * T<int>?anisotropy)
        ]
        |+> Protocol [
            "image"           =@ T<obj>
            "mipmaps"         =@ ArrayOf T<obj>
            "generateMipmaps" =@ T<bool>

            "clone" => O ^-> CompressedTexture
        ]

    let DataTexture =
        let DataTexture = Type.New ()

        Class "THREE.DataTexture"
        |=> Inherits TextureClass
        |+> [
            Constructor (T<ArrayBufferView>?data * T<int>?width * T<int>?height * T<int>?format * T<int>?``type`` * T<int>?mapping * T<int>?wrapS * T<int>?wrapT * T<int>?magFilter * T<int>?minFilter * T<int>?anisotropy)
        ]
        |+> Protocol [
            "image" =@ T<obj>

            "clone" => O ^-> DataTexture
        ]

    let FontUtils =
        Class "THREE.FontUtils"
        |+> [
            "faces" =@ T<obj>
            "face" =@ T<string>
            "weight" =@ T<string>
            "style" =@ T<string>
            "size" =@ T<float>
            "division" =@ T<float>

            "getFace" => O ^-> T<obj>
            "loadFace" => T<obj>?data ^-> T<obj>
            "drawText" => T<string>?text ^-> T<obj>
            //...
        ]

    let GeometryUtils =
        Class "THREE.GeometryUtils" 

    let ImageUtils =
        Class "THREE.ImageUtils"
        |+> [
            "crossOrigin" =@ T<string>

            "loadTexture"               => T<string>?url * !? T<obj>?mapping * !? (!? Texture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> Texture
            "loadCompressedTexture"     => T<string>?url * T<obj>?mapping * !? (!? CompressedTexture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> CompressedTexture
            "loadTextureCube"           => (ArrayOf T<string>)?array * T<obj>?mapping * !? (!? Texture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> Texture
            "loadCompressedTextureCube" => (ArrayOf T<string>)?array * T<obj>?mapping * !? (!? CompressedTexture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> Texture
            "loadDDSTexture"            => T<string>?url * T<obj>?mapping * !? (!? CompressedTexture ^-> O)?onLoad * !? (!? T<obj> ^-> O)?onError ^-> CompressedTexture
            "parseDDS"                  => T<obj>?buffer * T<bool>?loadMipmaps ^-> T<obj>
            "getNormalMap"              => T<Element>?image * !? T<int>?depth ^-> T<Element>
            "generateDataTexture"       => T<float>?width * T<float>?height * ColorClass?color ^-> DataTexture
        ]

    let SceneUtils =
        Class "THREE.SceneUtils"

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

    let Path =
        Class "THREE.Path"
        |=> Inherits CurvePath

    let Shape =
        Class "THREE.Shape"
        |=> Inherits Path

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
        |+> [
            Constructor (T<float>?width * T<float>?height * T<float>?depth * !? T<int>?widthSegments * !? T<int>?heightSegments * !? T<int>?depthSegments)
        ]
        |+> Protocol [
            "parameters"     =? T<obj>
            "widthSegments"  =@ T<int>
            "heightSegments" =@ T<int>
            "depthSegments"  =@ T<int>
        ]

    let CircleGeometry =
        Class "THREE.CircleGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radius * !? T<int>?segments * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let CylinderGeometry =
        Class "THREE.CylinderGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radiusTop * !? T<float>?radiusBottom * !? T<float>?height * !? T<int>?radialSegments * !? T<int>?heightSegments * !? T<bool>?openEnded)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let ExtrudeGeometry =
        Class "THREE.ExtrudeGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? (ArrayOf Shape)?shapes * !? T<obj>?options)
        ]
        |+> Protocol [
            "shapebb" =? Box3

            "addShapeList" => (ArrayOf Shape)?shapes * !? T<obj>?options ^-> O
            "addShape"     => Shape?shape * !? T<obj>?options ^-> O
        ]

    let IcosahedronGeometry =
        Class "THREE.IcosahedronGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radius * !? T<float>?detail)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let LatheGeometry =
        Class "THREE.LatheGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor ((ArrayOf T<obj>)?points * !? T<int>?segments * !? T<float>?phiStart * !? T<float>?phiLength)
        ]

    let OctahedronGeometry =
        Class "THREE.OctahedronGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radius * !? T<float>?detail)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let ParametricGeometry =
        Class "THREE.ParametricGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor ((T<obj> * T<obj> ^-> T<obj>)?func * T<int>?slices * T<int>?stacks)
        ]

    let PlaneGeometry =
        Class "THREE.PlaneGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (T<float>?width * T<float>?height * !? T<int>?widthSegments * !? T<int>?heightSegments)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let PolyhedronGeometry =
        Class "THREE.PolyhedronGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor ((ArrayOf T<float>)?vertices * (ArrayOf T<float>)?indices * !? T<float>?radius * !? T<float>?detail)
        ]
        |+> Protocol [
            "boundingSphere" =? Sphere
        ]

    let RingGeometry =
        Class "THREE.RingGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?innerRadius * !? T<float>?outerRadius * !? T<int>?thetaSegments * !? T<int>?phiSegments * !? T<float>?thetaLength * !? T<float>?phiLength)
        ]
        |+> Protocol [
            "boundingSphere" =? Sphere
        ]

    let ShapeGeometry =
        Class "THREE.ShapeGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? (ArrayOf Shape)?shapes * !? T<obj>?options)
        ]
        |+> Protocol [
            "shapebb" =? Box3

            "addShapeList" => (ArrayOf Shape)?shapes * !? T<obj>?options ^-> O
            "addShape"     => Shape?shape * !? T<obj>?options ^-> O
        ]

    let SphereGeometry =
        Class "THREE.SphereGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radius * !? T<int>?widthSegments * !? T<int>?heightSegments * !? T<float>?phiStart * !? T<float>?phiLength * !? T<float>?thetaStart * !? T<float>?thetaLength)
        ]
        |+> Protocol [
            "parameters"     =? T<obj>
            "boundingSphere" =? Sphere
        ]

    let TetrahedronGeometry =
        Class "THREE.TetrahedronGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radius * !? T<float>?detail)
        ]

    let TextGeometry =
        Class "THREE.TextGeometry"
        |=> Inherits ExtrudeGeometry
        |+> [
            Constructor (T<string>?text * !? T<obj>?parameters)
        ]

    let TorusGeometry =
        Class "THREE.TorusGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radius * !? T<float>?tube * !? T<int>?radialSegments * !? T<int>?tubularSegments * !? T<float>?arc)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let TorusKnotGeometry =
        Class "THREE.TorusKnotGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? T<float>?radius * !? T<float>?tube * !? T<int>?radialSegments * !? T<int>?tubularSegments * !? T<float>?p * !? T<float>?q * !? T<float>?heightScale)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let TubeGeometry =
        Class "THREE.TubeGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (T<obj>?path * !? T<int>?segments * !? T<float>?radius * !? T<int>?radiusSegments * !? T<bool>?closed * !? T<bool>?debug)
        ]
        |+> Protocol [
            "parameters" =? T<obj>
        ]

    let Assembly =
        Assembly [
            Namespace "IntelliFactory.WebSharper.ThreeJs" [
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
                Generic - TypeValuePair
            ]
            Namespace "IntelliFactory.WebSharper.ThreeJs.THREE" [
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
                RaycasterClass
                AmbientLight
                AreaLight
                DirectionalLight
                HemisphereLight
                LightClass
                PointLight
                SpotLight
                BufferGeometryLoader
                Cache
                ImageLoader
                JSONLoader
                Loader
                LoadingManagerClass
                MaterialLoader
                ObjectLoader
                SceneLoader
                TextureLoader
                XHRLoader
                LineBasicMaterial
                LineDashedMaterial
                MaterialClass
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
                Box3Class
                ColorClass
                EulerClass
                Frustum
                Line3
                Math
                Matrix3Class
                Matrix4Class
                PlaneClass
                QuaternionClass
                RayClass
                SphereClass
                Spline
                Triangle
                Vector2Class
                Vector3Class
                Vector4
                Bone
                Line
                LOD
                Mesh
                MorphAnimMesh
                ParticleSystem
                SkinnedMeshClass
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
                ShaderChunk
                ShaderLib
                UniformsLib
                UniformsUtils
                WebGLProgram
                WebGLShader
                FogClass
                FogExp2
                SceneClass
                CompressedTexture
                DataTexture
                TextureClass
                FontUtils
                GeometryUtils
                ImageUtils
                SceneUtils
                Animation
                AnimationHandler
                KeyFrameAnimation
                AnimationMorphTarget
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
            ]
            Namespace "IntelliFactory.WebSharper.ThreeJs.Resources" [
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
