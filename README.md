# three.js

Robust 3D library with low level complexity.

## Hello Cube!

This example shows you, how easily you can make a cube, which rotates over the time.

```fsharp
let renderer = new THREE.CanvasRenderer()

renderer.setSize(1280, 720)
renderer.setClearColor(0xffffff)

JQuery.Of("body").Append(renderer.DomElement) |> ignore

let scene = new THREE.Scene()
let light = new THREE.DirectionalLight(0xffffff)

light.Position.Z <- 5

scene.Add(light)

let cube = new THREE.Mesh(new THREE.BoxGeometry(1, 1, 1), new THREE.MeshNormalMaterial())

scene.Add(cube)

let camera = new THREE.PerspectiveCamera(45., 16./9.)

camera.Position.Z <- 5

scene.Add(camera)

//requestAnimationFrame is currently not part of the WebSharper.
[<Inline "requestAnimationFrame($0)">]
let render frame = X<unit>

//---
let rec frame () =
	renderer.render(scene, camera)

	cube.Rotation.Y <- cube.Rotation.Y + 0.01

	render frame
//---

render frame
```