namespace ThreeJS

open IntelliFactory.WebSharper.InterfaceGenerator

module Definition =
    open IntelliFactory.WebSharper.Dom
    
    let WebGLRendererPrecision =
        Pattern.EnumStrings "WebGLRendererPrecision" [
            "highp"
            "mediump"
            "lowp"
        ]
    
    let WebGLRendererConfiguration =
        Pattern.Config "WebGLRendererConfiguration" {
                Required = []
                Optional =
                [
                    "canvas"               , T<Node>
                    "precision"            , WebGLRendererPrecision.Type
                    "alpha"                , T<bool>
                    "premultipliedAlpha"   , T<bool>
                    "antialias"            , T<bool>
                    "stencil"              , T<bool>
                    "preserveDrawingBuffer", T<bool>
                    "maxLights"            , T<uint32>
                ]
            }
    
    
    let Number = T<int> + T<float>

    let O = T<unit>

    let Vector3 =
        Class "THREE.Vector3"
        |+> Protocol [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>
        ]
    
    let Euler =
        Class "THREE.Euler"
        |+> Protocol [
            "x" =@ T<float>
            "y" =@ T<float>
            "z" =@ T<float>
        ]

    let Object3D =
        let Object3D = Type.New ()

        Class "THREE.Object3D"
        |=> Object3D
        |+> [
            Constructor O
        ]
        |+> Protocol [
            "position" =@ Vector3
            "rotation" =@ Euler

            "add" => Object3D?``object`` ^-> O
        ]

    let Camera =
        Class "THREE.Camera"
        |=> Inherits Object3D

    let Scene =
        Class "THREE.Scene"
        |=> Inherits Object3D
        |+> [
            Constructor O
        ]

    let Color =
        Class "THREE.Color"
    
    let WebGLRenderer =
        Class "THREE.WebGLRenderer"
        |+> [
            Constructor !? WebGLRendererConfiguration?parameters
        ]
        |+> Protocol [
            "setClearColor" => (Color + T<int> + T<string>)?color * !? Number?alpha ^-> O
            "render"        => Scene?scene * Camera?camera ^-> O
        ]
    
    let Geometry =
        Class "THREE.Geometry"

    let Material =
        Class "THREE.Material"

    let Mesh =
        Class "THREE.Mesh"
        |=> Inherits Object3D
        |+> [
            Constructor (!? Geometry?geometry * !? Material?material)
        ]

    let SphereGeometry =
        Class "THREE.SphereGeometry"
        |=> Inherits Geometry
        |+> [
            Constructor (!? Number?radius * !? T<int>?widthSegments * !? T<int>?heightSegments(* * ...*))
        ]

    let MeshNormalMaterialConfiguration =
        Pattern.Config "MeshNormalMaterialConfiguration" {
            Required = []
            Optional =
            [
                "morphTargets"      , T<bool>
                //"shading"           , 
                "wireframe"         , T<bool>
                "wireframeLinewidth", T<float>
            ]
        }

    let MeshNormalMaterial =
        Class "THREE.MeshNormalMaterial"
        |=> Inherits Material
        |+> [
            Constructor !? MeshNormalMaterialConfiguration?parameters
        ]
    
    let Texture =
        Class "THREE.Texture"

    let ImageUtils =
        Class "THREE.ImageUtils"
        |+> [
            "loadTexture" => T<string>?url ^-> Texture // Incomplete
        ]

    let MeshLambertMaterialConfiguration =
        Pattern.Config "MeshLambertMaterialConfiguration" {
            Required = []
            Optional =
            [
                "map", Texture.Type
            ]
        }

    let MeshLambertMaterial =
        Class "THREE.MeshLambertMaterial"
        |=> Inherits Material
        |+> [
            Constructor !? MeshLambertMaterialConfiguration?parameters
        ]

    let PerspectiveCamera =
        Class "THREE.PerspectiveCamera"
        |=> Inherits Camera
        |+> [
            Constructor (!? Number?fov * !? Number?aspect * !? Number?near * !? Number?far)
        ]
    
    let Light =
        let Light = Type.New ()

        Class "THREE.Light"
        |=> Light
        |=> Inherits Object3D
        |+> [
            Constructor (Color + T<int> + T<string>)?color
        ]
        |+> Protocol [
            "color" =@ Color

            "clone" => !? Light?light ^-> Light
        ]

    let DirectionalLight =
        Class "THREE.DirectionalLight"
        |=> Inherits Light
        |+> [
            Constructor ((Color + T<int> + T<string>)?color * !? Number?intensity)
        ]

    let THREE =
        Pattern.EnumInlines "THREE" [
            "AddEquation", "100"
        ]
        |=> Nested [
            Color
            WebGLRenderer
            Vector3
            Object3D
            Scene
            Mesh
            Geometry
            Material
            SphereGeometry
            MeshNormalMaterial
            MeshLambertMaterial
            Camera
            PerspectiveCamera
            Light
            DirectionalLight
            Texture
            ImageUtils
            Euler
        ]

    let Assembly =
        Assembly [
            Namespace "IntelliFactory.WebSharper.ThreeJS" [
                 WebGLRendererPrecision
                 WebGLRendererConfiguration
                 MeshNormalMaterialConfiguration
                 MeshLambertMaterialConfiguration
                 THREE
            ]
            Namespace "IntelliFactory.WebSharper.ThreeJS.Resources" [
                (Resource "three.js" "http://threejs.org/build/three.min.js").AssemblyWide ()
            ]
        ]

[<Sealed>]
type Extension () =
    interface IExtension with
        member x.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
