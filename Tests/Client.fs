namespace Tests

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.JavaScript

[<JavaScript>]
module Client =
    open IntelliFactory.WebSharper.ThreeJs
    open IntelliFactory.WebSharper.Html5
    open IntelliFactory.WebSharper.JQuery

    [<Inline "requestAnimationFrame($0)">]
    let render frame = X<unit>

    let Main =
        let renderer = new THREE.CanvasRenderer()

        renderer.SetSize(1280, 720)
        renderer.SetClearColor(0xffffff)

        JQuery.Of("body").Append(renderer.DomElement) |> ignore

        let scene = new THREE.Scene()
        let light = new THREE.DirectionalLight(0xffffff)

        light.Position.Z <- 128.

        scene.Add(light)

        let flamingo =
            new THREE.Mesh(
                new THREE.Geometry(),
                new THREE.MeshNormalMaterial()
            )
        
        (new THREE.JSONLoader(false)).Load(
            "flamingo.json",
            fun (a, b) ->
                flamingo.Geometry <- a
                
                scene.Add(flamingo)
        )

        let camera = new THREE.PerspectiveCamera(45., 16./9.)

        camera.Position.Z <- 256.

        //---
        let rec frame () =
            renderer.Render(scene, camera)

            flamingo.Rotation.Y <- flamingo.Rotation.Y + 0.01

            render frame
        //---

        render frame

