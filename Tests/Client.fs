namespace Tests

open IntelliFactory.WebSharper

[<JavaScript>]
module Client =
    open IntelliFactory.WebSharper.ThreeJS
    open IntelliFactory.WebSharper.JQuery

    open IntelliFactory.WebSharper.Html
    open IntelliFactory.WebSharper.Formlet

    [<Inline "requestAnimationFrame($0)">]
    let animate (frame : (unit -> unit)) = X<unit>

    let toRadian degree =
        degree * (EcmaScript.Math.PI / 180.)

    let Main =
        let rotationSpeed = ref 0.1

        let canvas =
            JQuery.Of("#canvas")
        let renderer =
            new THREE.WebGLRenderer(
                WebGLRendererConfiguration(
                    Canvas    = canvas.Get(0),
                    Antialias = true
                )
            )

        renderer.SetClearColor(0xffffff)

        let scene = new THREE.Scene()
        let sphere =
            new THREE.Mesh(
                new THREE.SphereGeometry(1, 100, 100),
                new THREE.MeshLambertMaterial(
                    MeshLambertMaterialConfiguration(
                        Map = THREE.ImageUtils.LoadTexture("earth.jpg")
                    )
                )
            )

        scene.Add(sphere)

        let camera = new THREE.PerspectiveCamera(45, 16./9., 1, 1000)

        camera.Position.Z <- 5.

        let light = new THREE.DirectionalLight(0xffffff)

        light.Position.Z <- 10.

        scene.Add(light)

        //---
        let rec frame () =
            renderer.Render(scene, camera)

            sphere.Rotation.Y <- sphere.Rotation.Y + (toRadian !rotationSpeed)

            animate frame

        animate frame
        //--

        (Div [
            (Controls.Input ((!rotationSpeed).ToString())
            |> Enhance.WithTextLabel "Rotation speed on the x axis (deg/frame)"
            |> Enhance.WithLabelAbove
            |> Enhance.WithSubmitAndResetButtons).Run (fun a ->
                rotationSpeed := float a
            )
        ]).AppendTo "page"
