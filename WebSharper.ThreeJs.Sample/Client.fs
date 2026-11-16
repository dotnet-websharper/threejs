namespace WebSharper.ThreeJs.Sample

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.ThreeJs

[<JavaScript>]
module Client =

    // The template is the whole document, loaded from the DOM, so editing
    // index.html and refreshing the browser is enough.
    type IndexTemplate = Template<"index.html", ClientLoad.FromDocument>

    // ---------------------------------------------------------------
    // State bound into the template
    // ---------------------------------------------------------------

    // Theme: light is the default; the choice is persisted in localStorage.
    // The storage key is shared with the bootstrap script in index.html.
    let themeStorageKey = "websharper-threejs-theme"
    let theme = Var.Create "light"
    let themeLabel = Var.Create "🌙 Dark mode"

    let geometryName = Var.Create "Box"
    let materialName = Var.Create "Standard"
    let controlMode = Var.Create "Orbit"

    let status = Var.Create "Building the scene…"
    let picked = Var.Create "Picked: —"
    let stats = Var.Create "Rendering…"
    let clockInfo = Var.Create "—"
    let mathInfo = Var.Create "—"
    let objectCount = Var.Create "0 objects"
    let animationState = Var.Create "Pause spin"

    // ---------------------------------------------------------------
    // Small inlines: the `?` operator packs arguments into an array, so it
    // cannot be used for calls; these keep the pointer maths typed.
    // ---------------------------------------------------------------

    [<Inline "$0.addEventListener($1, $2)">]
    let private listen (target: Dom.Element) (event: string) (handler: Dom.Event -> unit) =
        X<unit>

    [<Inline "globalThis.addEventListener($0, $1)">]
    let private listenWindow (event: string) (handler: Dom.Event -> unit) =
        X<unit>

    [<Inline "globalThis.devicePixelRatio || 1">]
    let private pixelRatio () = X<float>

    [<Inline "$0.offsetX">]
    let private pointerX (e: Dom.Event) = X<float>

    [<Inline "$0.offsetY">]
    let private pointerY (e: Dom.Event) = X<float>

    // ---------------------------------------------------------------
    // Scene state
    // ---------------------------------------------------------------

    type App =
        {
            Renderer: WebGLRenderer
            Scene: Scene
            Camera: PerspectiveCamera
            Spin: Group
            SpinMesh: Mesh
            Instanced: InstancedMesh
            Points: Points
            GroundMaterial: MeshStandardMaterial
            PanelMaterial: MeshStandardMaterial
            Sun: DirectionalLight
            Pulse: PointLight
            Selection: BoxHelper
            Helpers: ResizeArray<Object3D>
            Debug: ResizeArray<Object3D>
            Pickables: ResizeArray<Object3D>
            Timer: Timer
            Mixer: AnimationMixer
            Action: AnimationAction
            Composer: EffectComposer
            Bloom: UnrealBloomPass
            FatLines: LineMaterial
        }

    let mutable app : App option = None
    let mutable helpersVisible = true
    let mutable debugVisible = false
    let mutable postFx = false
    let mutable addonClasses = 0
    let mutable frames = 0
    let mutable accumulated = 0.0

    // The active camera control (one of the addon controls) and, for the
    // "Transform"/"Drag" modes, the extra object manipulator that coexists with
    // the orbiting camera.
    let mutable cameraControl : Controls option = None
    let mutable cameraUpdate : float -> unit = ignore
    let mutable cameraReset : unit -> unit = ignore
    let mutable extraControl : Controls option = None
    let mutable extraHelper : Object3D option = None
    let mutable dragControl : DragControls option = None

    // Keep an active DragControls' object list in sync with the rig.
    let private refreshDragTargets (a: App) =
        match dragControl with
        | Some d -> d.Objects <- a.Pickables.ToArray()
        | None -> ()

    let palette =
        [| "#6366f1"; "#0ea5e9"; "#14b8a6"; "#f59e0b"; "#ef4444"; "#a855f7"; "#22c55e"; "#e11d48" |]

    let private sizeOf (host: Dom.Element) =
        max 1. host.ClientWidth, max 1. host.ClientHeight

    let private withApp (f: App -> unit) =
        match app with
        | Some a -> f a
        | None -> status.Value <- "The renderer is not ready yet."

    // ---------------------------------------------------------------
    // Geometry and material factories
    // ---------------------------------------------------------------

    let private createGeometry () : BufferGeometry =
        match geometryName.Value with
        | "Sphere"       -> upcast SphereGeometry(1.05, 48, 32)
        | "TorusKnot"    -> upcast TorusKnotGeometry(0.9, 0.32, 160, 24, 2, 3)
        | "Capsule"      -> upcast CapsuleGeometry(0.6, 1.2, 8, 24)
        | "Cone"         -> upcast ConeGeometry(1., 1.8, 40, 1)
        | "Cylinder"     -> upcast CylinderGeometry(0.8, 0.8, 1.6, 40)
        | "Ring"         -> upcast RingGeometry(0.5, 1.2, 48)
        | "Torus"        -> upcast TorusGeometry(1., 0.35, 20, 60)
        | "Icosahedron"  -> upcast IcosahedronGeometry(1.15, 0)
        | "Dodecahedron" -> upcast DodecahedronGeometry(1.15, 0)
        | "Octahedron"   -> upcast OctahedronGeometry(1.2, 0)
        | "Tetrahedron"  -> upcast TetrahedronGeometry(1.3, 0)
        | _              -> upcast BoxGeometry(1.5, 1.5, 1.5)

    let private createMaterial (index: int) : Material =
        let color = palette.[index % palette.Length]
        match materialName.Value with
        | "Physical" ->
            upcast MeshPhysicalMaterial(
                MeshPhysicalMaterialParameters(
                    Color = color,
                    Roughness = 0.18,
                    Metalness = 0.2,
                    Clearcoat = 1.,
                    ClearcoatRoughness = 0.15,
                    Transmission = 0.25))
        | "Phong" ->
            upcast MeshPhongMaterial(
                MeshPhongMaterialParameters(
                    Color = color,
                    Specular = "#ffffff",
                    Shininess = 80.,
                    FlatShading = true))
        | "Lambert" ->
            upcast MeshLambertMaterial(
                MeshLambertMaterialParameters(Color = color, Emissive = "#111827"))
        | "Toon" ->
            upcast MeshToonMaterial(MeshToonMaterialParameters(Color = color))
        | "Normal" ->
            upcast MeshNormalMaterial(MeshNormalMaterialParameters(FlatShading = true))
        | "Depth" ->
            upcast MeshDepthMaterial(MeshDepthMaterialParameters())
        | "Basic" ->
            upcast MeshBasicMaterial(MeshBasicMaterialParameters(Color = color, Wireframe = false))
        | _ ->
            upcast MeshStandardMaterial(
                MeshStandardMaterialParameters(
                    Color = color,
                    Roughness = 0.35,
                    Metalness = 0.15))

    // ---------------------------------------------------------------
    // Scene helpers
    // ---------------------------------------------------------------

    let private refreshCount () =
        withApp (fun a ->
            objectCount.Value <-
                sprintf "%d objects · %d helpers · %d debug · %d addon classes"
                    a.Pickables.Count a.Helpers.Count a.Debug.Count addonClasses)

    let private removeObject (a: App) (o: Object3D) =
        a.Pickables.Remove(o) |> ignore
        a.Spin.Remove(o) |> ignore

    let private addObject () =
        withApp (fun a ->
            let index = a.Pickables.Count
            let geometry = createGeometry ()
            let mesh = Mesh(geometry, createMaterial index)
            mesh.Name <- geometryName.Value + " · " + materialName.Value
            mesh.CastShadow <- true
            mesh.ReceiveShadow <- true

            // Place the objects on a ring, stacked a little for variety.
            let angle = float index * 1.2566
            let radius = if index = 0 then 0.0 else 3.2
            mesh.Position.Set(radius * System.Math.Cos angle, 0.85 + float (index % 2) * 1.7, radius * System.Math.Sin angle) |> ignore
            mesh.Rotation.Set(0.25, angle, 0.1) |> ignore

            a.Pickables.Add(mesh)
            a.Spin.Add(mesh) |> ignore

            // Keep the rig at a workable size.
            if a.Pickables.Count > 16 then
                removeObject a a.Pickables.[0]

            refreshDragTargets a
            refreshCount ()
            status.Value <- sprintf "Added %s with a %s material." geometryName.Value materialName.Value)

    let private clearObjects () =
        withApp (fun a ->
            for o in a.Pickables.ToArray() do
                removeObject a o
            a.Selection.Visible <- false
            picked.Value <- "Picked: —"
            refreshDragTargets a
            refreshCount ()
            status.Value <- "Cleared the rig.")

    let private resetCamera () =
        withApp (fun a ->
            a.Camera.Position.Set(7., 6., 10.) |> ignore
            a.Camera.LookAt(Vector3(0., 1., 0.))
            a.Camera.UpdateProjectionMatrix()
            cameraReset ()
            status.Value <- "Camera reset.")

    // ---------------------------------------------------------------
    // Addon controls
    // ---------------------------------------------------------------

    let private disposeControls (a: App) =
        match cameraControl with
        | Some c -> c.Dispose()
        | None -> ()
        cameraControl <- None
        cameraUpdate <- ignore
        cameraReset <- ignore
        match extraControl with
        | Some c -> c.Dispose()
        | None -> ()
        extraControl <- None
        dragControl <- None
        match extraHelper with
        | Some h -> a.Scene.Remove(h) |> ignore
        | None -> ()
        extraHelper <- None

    /// Creates the camera control (or object manipulator) selected in the panel.
    let private applyControlMode (a: App) =
        disposeControls a
        let canvas = a.Renderer.DomElement

        // A fresh OrbitControls rig, used directly and as the camera control
        // behind the Transform/Drag modes.
        let orbit () =
            let c = OrbitControls(a.Camera, canvas)
            c.Target.Set(0., 1., 0.) |> ignore
            c.EnableDamping <- true
            c.DampingFactor <- 0.06
            c.MinDistance <- 4.
            c.MaxDistance <- 26.
            c.MaxPolarAngle <- System.Math.PI / 2.0 - 0.05
            c.AutoRotateSpeed <- 0.6
            cameraControl <- Some (c :> Controls)
            cameraUpdate <- fun dt -> c.Update(dt) |> ignore
            cameraReset <- fun () -> c.Reset()

        match controlMode.Value with
        | "Map" ->
            let c = MapControls(a.Camera, canvas)
            c.Target.Set(0., 1., 0.) |> ignore
            c.EnableDamping <- true
            c.DampingFactor <- 0.08
            c.ScreenSpacePanning <- true
            c.MinDistance <- 4.
            c.MaxDistance <- 26.
            cameraControl <- Some (c :> Controls)
            cameraUpdate <- fun dt -> c.Update(dt) |> ignore
            cameraReset <- fun () -> c.Reset()
            status.Value <- "Map controls: left-drag pans, right-drag orbits, the wheel zooms."
        | "Trackball" ->
            let c = TrackballControls(a.Camera, canvas)
            c.RotateSpeed <- 2.4
            c.ZoomSpeed <- 1.4
            c.PanSpeed <- 0.6
            c.StaticMoving <- false
            c.DynamicDampingFactor <- 0.12
            c.Target.Set(0., 1., 0.) |> ignore
            cameraControl <- Some (c :> Controls)
            cameraUpdate <- fun _ -> c.Update()
            cameraReset <- fun () -> c.Reset()
            status.Value <- "Trackball controls: drag to spin the camera freely, the wheel zooms."
        | "Fly" ->
            let c = FlyControls(a.Camera, canvas)
            c.MovementSpeed <- 6.
            c.RollSpeed <- 0.6
            c.DragToLook <- true
            cameraControl <- Some (c :> Controls)
            cameraUpdate <- fun dt -> c.Update(dt)
            status.Value <- "Fly controls: drag to look around, W/S/A/D/R/F to move."
        | "First person" ->
            let c = FirstPersonControls(a.Camera, canvas)
            c.MovementSpeed <- 4.
            c.LookSpeed <- 0.09
            c.LookAt(Vector3(0., 1., 0.)) |> ignore
            cameraControl <- Some (c :> Controls)
            cameraUpdate <- fun dt -> c.Update(dt)
            status.Value <- "First-person controls: move the mouse to look, W/S to walk, Q to freeze."
        | "Arcball" ->
            let c = ArcballControls(a.Camera, canvas, a.Scene)
            c.RotateSpeed <- 1.4
            c.EnableAnimations <- true
            c.SetGizmosVisible(true)
            cameraControl <- Some (c :> Controls)
            cameraUpdate <- fun _ -> c.Update()
            cameraReset <- fun () -> c.Reset()
            status.Value <- "Arcball controls: drag to spin a virtual trackball, double-click to focus."
        | "Pointer lock" ->
            let c = PointerLockControls(a.Camera, canvas)
            c.PointerSpeed <- 1.2
            c.AddEventListener(PointerLockControlsEvent.Lock, fun _ ->
                status.Value <- "Pointer locked — move the mouse to look, Esc to release.")
            |> ignore
            c.AddEventListener(PointerLockControlsEvent.Unlock, fun _ ->
                status.Value <- "Pointer unlocked.")
            |> ignore
            cameraControl <- Some (c :> Controls)
            cameraUpdate <- ignore
            listen canvas "click" (fun _ -> c.Lock())
            status.Value <- "Pointer lock: click the viewport to capture the pointer."
        | "Transform" ->
            orbit ()
            let c = TransformControls(a.Camera, canvas)
            c.SetSize(0.9)
            let target : Object3D =
                if a.Pickables.Count = 0 then upcast a.SpinMesh
                else a.Pickables.[0]
            c.Attach(target) |> ignore
            let helper = c.GetHelper()
            a.Scene.Add(helper) |> ignore
            extraControl <- Some (c :> Controls)
            extraHelper <- Some helper
            c.AddEventListener(TransformControlsEvent.DraggingChanged, fun e ->
                match cameraControl with
                | Some cam -> cam.Enabled <- not e.Value
                | None -> ())
            |> ignore
            c.AddEventListener(TransformControlsEvent.ObjectChange, fun _ ->
                status.Value <- "The transform gizmo moved an object.")
            |> ignore
            status.Value <- "Transform gizmo: drag the arrows, rings and handles to move, rotate or scale the object."
        | "Drag" ->
            orbit ()
            let objects = a.Pickables.ToArray()
            let c = DragControls(objects, a.Camera, canvas)
            c.Recursive <- false
            c.AddEventListener(DragControlsEvent.DragStart, fun e ->
                status.Value <- "Dragging " + e.Object.Name + " — release to drop it.")
            |> ignore
            c.AddEventListener(DragControlsEvent.DragEnd, fun _ ->
                status.Value <- "Drag finished.")
            |> ignore
            extraControl <- Some (c :> Controls)
            dragControl <- Some c
            status.Value <- "Drag control: grab an object and move it in the camera plane."
        | _ ->
            orbit ()
            status.Value <- "Orbit controls: drag to orbit, scroll to zoom, right-drag to pan."

    let private toggleAnimation () =
        withApp (fun a ->
            a.Action.Paused <- not a.Action.Paused
            animationState.Value <- if a.Action.Paused then "Resume spin" else "Pause spin"
            status.Value <-
                if a.Action.Paused then "Animation paused (the rig still turns)."
                else "Animation playing.")

    let private toggleHelpers () =
        helpersVisible <- not helpersVisible
        withApp (fun a ->
            for h in a.Helpers do
                h.Visible <- helpersVisible
            status.Value <- if helpersVisible then "Helpers visible." else "Helpers hidden.")

    let private toggleDebug () =
        debugVisible <- not debugVisible
        withApp (fun a ->
            for h in a.Debug do
                h.Visible <- debugVisible
            status.Value <- if debugVisible then "Light/camera debug helpers visible." else "Debug helpers hidden.")

    let private togglePostFx () =
        postFx <- not postFx
        status.Value <-
            if postFx then "Bloom on: EffectComposer → RenderPass → UnrealBloomPass → OutputPass."
            else "Bloom off: rendering directly with WebGLRenderer."

    // ---------------------------------------------------------------
    // Theme
    // ---------------------------------------------------------------

    let private applyTheme () =
        let dark = theme.Value = "dark"
        JS.Document.DocumentElement.SetAttribute("data-theme", theme.Value)
        themeLabel.Value <- if dark then "☀️ Light mode" else "🌙 Dark mode"
        withApp (fun a ->
            let background = if dark then "#0b1220" else "#eef2ff"
            let fogColor = if dark then "#0b1220" else "#dbeafe"
            a.Scene.Background <- Color(background)
            a.Scene.Fog <- Fog(fogColor, 16., 48.)
            a.GroundMaterial.Color.Set(if dark then "#111c34" else "#e2e8f0") |> ignore
            a.PanelMaterial.Color.Set(if dark then "#1e293b" else "#f8fafc") |> ignore
            a.Renderer.SetClearColor(Color(background)))

    let private toggleTheme () =
        theme.Value <- (if theme.Value = "dark" then "light" else "dark")
        try JS.Window.LocalStorage.SetItem(themeStorageKey, theme.Value) with _ -> ()
        applyTheme ()

    // ---------------------------------------------------------------
    // Picking and the readouts
    // ---------------------------------------------------------------

    let private updatePicking (a: App) (ev: Dom.Event) =
        let canvas = a.Renderer.DomElement
        let w = max 1. canvas.ClientWidth
        let h = max 1. canvas.ClientHeight
        let ndc =
            Vector2(
                2.0 * pointerX ev / w - 1.0,
                -(2.0 * pointerY ev / h - 1.0))

        let raycaster = Raycaster()
        raycaster.SetFromCamera(ndc, a.Camera)
        let hits : seq<Intersection> = raycaster.IntersectObjects(a.Pickables.ToArray(), false)

        let first = Seq.tryHead hits
        match first with
        | Some hit ->
            a.Selection.SetFromObject(hit.Object) |> ignore
            a.Selection.Visible <- true
            let bounds = Box3().SetFromObject(hit.Object)
            let size = bounds.GetSize(Vector3())
            picked.Value <-
                sprintf "Picked: %s · distance %.2f · bbox %.2f × %.2f × %.2f"
                    hit.Object.Name hit.Distance size.X size.Y size.Z
        | None ->
            a.Selection.Visible <- false
            picked.Value <- "Picked: —"

    let private refreshReadouts (a: App) (dt: float) (elapsed: float) =
        let info = a.Renderer.Info.Render
        let fps = if dt > 0.0 then 1.0 / dt else 0.0
        stats.Value <-
            sprintf "render: %d calls · %d triangles · %d points · %.0f fps"
                info.Calls info.Triangles info.Points fps
        clockInfo.Value <-
            sprintf "timer: elapsed %.1f s · delta %.3f s · camera y %.2f"
                (a.Timer.GetElapsed()) dt a.Camera.Position.Y

        // Recompute the typed math surface from the live scene.
        let bounds = Box3().SetFromObject(a.Spin)
        let center = bounds.GetCenter(Vector3())
        let size = bounds.GetSize(Vector3())
        let sphere = bounds.GetBoundingSphere(Sphere())
        let direction = Vector3(1., 1., 0.).Normalize()
        let axis = Vector3(0., 1., 0.)
        let quarter = MathUtils.DegToRad(45.)
        let rotation = Quaternion().SetFromAxisAngle(axis, quarter)
        let transform = Matrix4().Compose(Vector3(1., 2., 3.), rotation, Vector3(1., 1., 1.))
        let inverse = Matrix4().Copy(transform).Invert()
        let point = Vector3(2., 2., 2.)
        let projected = point.Clone().ApplyMatrix4(transform)
        let unprojected = projected.Clone().ApplyMatrix4(inverse)
        let line = Line3(Vector3(0., 0., 0.), Vector3(3., 3., 3.))
        let plane = Plane(Vector3(0., 1., 0.), 0.)
        let triangle = Triangle(Vector3(0., 0., 0.), Vector3(1., 0., 0.), Vector3(0., 1., 0.))
        let ray = Ray(Vector3(0., 1., 0.), Vector3(0., -1., 0.))
        let spherical = Spherical(1., System.Math.PI / 3., System.Math.PI / 4.)
        let euler = Euler(0.1, 0.2, 0.3)
        let eulerVector = Vector3().SetFromEuler(euler)
        let hex = Color(palette.[0]).GetHexString()

        mathInfo.Value <-
            sprintf "box3 size (%.2f, %.2f, %.2f) · sphere r %.2f · center (%.2f, %.2f, %.2f)"
                size.X size.Y size.Z sphere.Radius center.X center.Y center.Z
            + sprintf " · line3 %.2f · plane→point %.2f · triangle area %.2f"
                (line.Distance()) (plane.DistanceToPoint(point)) (triangle.GetArea())
            + sprintf " · ray→plane %.2f · spherical r=%.1f θ=%.2f · euler→vec (%.2f, %.2f, %.2f)"
                (ray.DistanceToPlane(plane)) spherical.Radius spherical.Theta
                eulerVector.X eulerVector.Y eulerVector.Z
            + sprintf " · matrix round-trip %.2f · color %s · elapsed %.1f s"
                (unprojected.DistanceTo(point)) ("#" + hex) elapsed

    // ---------------------------------------------------------------
    // Scene construction
    // ---------------------------------------------------------------

    let private init () =
        match JS.Document.GetElementById "viewport" with
        | null -> status.Value <- "The viewport element was not found."
        | host ->
            let width, height = sizeOf host

            let renderer =
                WebGLRenderer(WebGLRendererOptions(Antialias = true, Alpha = false, PowerPreference = WebGLPowerPreference.HighPerformance))
            renderer.SetPixelRatio(min 2.0 (pixelRatio ()))
            renderer.SetSize(int width, int height, false)
            renderer.OutputColorSpace <- ColorSpace.SRGBColorSpace
            renderer.ToneMapping <- ToneMapping.ACESFilmicToneMapping
            renderer.ToneMappingExposure <- 1.05
            renderer.ShadowMap.Enabled <- true
            renderer.ShadowMap.Type <- ShadowMapType.PCFShadowMap
            host.AppendChild(renderer.DomElement) |> ignore

            let scene = Scene()
            scene.Background <- Color("#eef2ff")
            scene.Fog <- Fog("#dbeafe", 16., 48.)

            let camera = PerspectiveCamera(50., width / height, 0.1, 200.)
            camera.Position.Set(7., 6., 10.) |> ignore
            camera.LookAt(Vector3(0., 1., 0.))

            // Lights
            let ambient = AmbientLight("#ffffff", 0.9)
            scene.Add(ambient) |> ignore

            let hemisphere = HemisphereLight("#ffffff", "#c7d2fe", 0.7)
            scene.Add(hemisphere) |> ignore

            let sun = DirectionalLight("#ffffff", 2.8)
            sun.Position.Set(8., 12., 6.) |> ignore
            sun.CastShadow <- true
            sun.Shadow.MapSize.Set(2048., 2048.) |> ignore
            sun.Shadow.Camera.Near <- 0.5
            sun.Shadow.Camera.Far <- 48.
            sun.Shadow.Camera.Left <- -16.
            sun.Shadow.Camera.Right <- 16.
            sun.Shadow.Camera.Top <- 16.
            sun.Shadow.Camera.Bottom <- -16.
            sun.Shadow.Bias <- -0.0005
            scene.Add(sun) |> ignore
            scene.Add(sun.Target) |> ignore

            let pulse = PointLight("#f472b6", 18., 14., 2.)
            pulse.Position.Set(-4., 3.5, -2.) |> ignore
            scene.Add(pulse) |> ignore

            // Ground and backdrop
            let groundMaterial =
                MeshStandardMaterial(MeshStandardMaterialParameters(Color = "#e2e8f0", Roughness = 0.95, Metalness = 0.0))
            let ground = Mesh(PlaneGeometry(40., 40.), groundMaterial)
            ground.Rotation.X <- -System.Math.PI / 2.0
            ground.ReceiveShadow <- true
            ground.Name <- "Ground"
            scene.Add(ground) |> ignore

            // A procedurally generated checker texture (no asset downloads).
            let size = 64
            let data = Uint8Array(size * size * 4)
            for y in 0 .. size - 1 do
                for x in 0 .. size - 1 do
                    let i = (y * size + x) * 4
                    let v = if (x / 8 + y / 8) % 2 = 0 then 206uy else 232uy
                    data.Set(i, v)
                    data.Set(i + 1, v)
                    data.Set(i + 2, 255uy)
                    data.Set(i + 3, 255uy)
            let gridTexture = DataTexture(data, size, size)
            gridTexture.Name <- "Checker"
            gridTexture.WrapS <- Wrapping.RepeatWrapping
            gridTexture.WrapT <- Wrapping.RepeatWrapping
            gridTexture.Repeat.Set(12., 12.) |> ignore
            gridTexture.Anisotropy <- 4
            gridTexture.ColorSpace <- ColorSpace.SRGBColorSpace
            gridTexture.NeedsUpdate <- true
            groundMaterial.Map <- gridTexture

            // A panel that loads its texture through TextureLoader from a data URL.
            let panelMaterial =
                MeshStandardMaterial(MeshStandardMaterialParameters(Color = "#f8fafc", Roughness = 0.6, Metalness = 0.05))
            let panel = Mesh(PlaneGeometry(3.4, 3.4), panelMaterial)
            panel.Position.Set(-4.6, 1.9, -3.4) |> ignore
            panel.Rotation.Y <- 0.6
            panel.Name <- "Texture panel"
            scene.Add(panel) |> ignore

            let svg =
                "data:image/svg+xml;utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' width='96' height='96'%3E%3Crect width='96' height='96' fill='%23f8fafc'/%3E%3Ccircle cx='48' cy='48' r='34' fill='none' stroke='%236366f1' stroke-width='6'/%3E%3Ccircle cx='48' cy='48' r='12' fill='%2314b8a6'/%3E%3C/svg%3E"
            TextureLoader()
                .Load(
                    svg,
                    fun (texture: Texture) ->
                        texture.ColorSpace <- ColorSpace.SRGBColorSpace
                        texture.NeedsUpdate <- true
                        panelMaterial.Map <- texture
                        panelMaterial.NeedsUpdate <- true)
                |> ignore

            // The rig: a group of objects, spun by the render loop, plus one mesh
            // that is driven by an AnimationMixer clip.
            let spin = Group()
            spin.Name <- "Object rig"
            scene.Add(spin) |> ignore

            let spinMesh = Mesh(BoxGeometry(1.2, 1.2, 1.2), createMaterial 0)
            spinMesh.Position.Set(-2.6, 0.8, 2.2) |> ignore
            spinMesh.CastShadow <- true
            spinMesh.ReceiveShadow <- true
            spinMesh.Name <- "Animated cube"
            spin.Add(spinMesh) |> ignore

            let times = [| 0.; 2.; 4. |]
            let values = [| 0.8; 3.4; 0.8 |]
            let clip =
                AnimationClip(
                    "bob", 4.,
                    [| (NumberKeyframeTrack(".position[y]", times, values) :> KeyframeTrack) |])
            let mixer = AnimationMixer(spinMesh)
            let action = mixer.ClipAction(clip)
            action.SetLoop(LoopMode.LoopRepeat, 1) |> ignore
            action.Play() |> ignore

            // An InstancedMesh: 90 small boxes placed with Matrix4.Compose.
            let instanceMaterial =
                MeshStandardMaterial(MeshStandardMaterialParameters(Color = "#94a3b8", Roughness = 0.4, Metalness = 0.6))
            let instanced = InstancedMesh(BoxGeometry(0.22, 0.22, 0.22), instanceMaterial, 90)
            instanced.CastShadow <- true
            instanced.Name <- "Instanced grid"
            for i in 0 .. 89 do
                let angle = float i / 90.0 * System.Math.PI * 2.0
                let radius = 8.5
                let lift = float (i % 3) * 0.55
                let position = Vector3(radius * System.Math.Cos angle, 0.5 + lift, radius * System.Math.Sin angle)
                let rotation = Quaternion().SetFromAxisAngle(Vector3(0., 1., 0.), angle)
                let scale = Vector3(1., 1. + lift, 1.)
                let matrix = Matrix4().Compose(position, rotation, scale)
                instanced.SetMatrixAt(i, matrix)
            instanced.ComputeBoundingSphere()
            scene.Add(instanced) |> ignore

            // A starfield built from a BufferGeometry + BufferAttribute.
            let count = 400
            let positions = Float32Array(count * 3)
            for i in 0 .. count - 1 do
                positions.Set(i * 3, float32 (MathUtils.RandFloatSpread(60.)))
                positions.Set(i * 3 + 1, float32 (MathUtils.RandFloat(2., 34.)))
                positions.Set(i * 3 + 2, float32 (MathUtils.RandFloatSpread(60.)))
            let starGeometry = BufferGeometry()
            starGeometry.SetAttribute("position", BufferAttribute(positions, 3)) |> ignore
            starGeometry.ComputeBoundingSphere()
            let stars =
                Points(
                    starGeometry,
                    PointsMaterial(PointsMaterialParameters(Color = "#c7d2fe", Size = 0.14, SizeAttenuation = true)))
            stars.Name <- "Stars"
            scene.Add(stars) |> ignore

            // A wide line built with the addon fat-line classes (LineGeometry +
            // LineMaterial + Line2), which support arbitrary widths.
            let orbitPoints = Array.zeroCreate (73 * 3)
            for i in 0 .. 72 do
                let angle = float i / 72.0 * System.Math.PI * 2.0
                orbitPoints.[i * 3] <- 3.1 * System.Math.Cos angle
                orbitPoints.[i * 3 + 1] <- 0.06
                orbitPoints.[i * 3 + 2] <- 3.1 * System.Math.Sin angle
            let orbitGeometry = LineGeometry()
            orbitGeometry.SetPositions(orbitPoints) |> ignore
            let orbitMaterial =
                LineMaterial(
                    LineMaterialParameters(
                        Color = "#6366f1",
                        Linewidth = 3.5,
                        Dashed = true,
                        DashSize = 0.35,
                        GapSize = 0.25))
            orbitMaterial.Resolution <- Vector2(width, height)
            let orbit = Line2(orbitGeometry, orbitMaterial)
            orbit.ComputeLineDistances() |> ignore
            orbit.Name <- "Fat orbit"
            scene.Add(orbit) |> ignore

            // Merge two geometries into one with the BufferGeometryUtils addon.
            let parts : BufferGeometry[] =
                [| (BoxGeometry(0.55, 0.55, 0.55) :> BufferGeometry)
                   (SphereGeometry(0.4, 20, 14) :> BufferGeometry) |]
            let mergedGeometry = BufferGeometryUtils.MergeGeometries(parts, true)
            let merged = Mesh(mergedGeometry, createMaterial 2)
            merged.Position.Set(1.9, 0.7, -1.7) |> ignore
            merged.CastShadow <- true
            merged.Name <- "Merged (box + sphere)"
            scene.Add(merged) |> ignore

            // Helpers
            let selection = BoxHelper()
            selection.Visible <- false
            scene.Add(selection) |> ignore

            let helpers = ResizeArray<Object3D>()

            let grid = GridHelper(40., 40, "#cbd5e1", "#e2e8f0")
            helpers.Add(grid)

            let polar = PolarGridHelper(6., 16, 6, 64, "#c7d2fe", "#e0e7ff")
            helpers.Add(polar)

            let axes = AxesHelper(3.)
            helpers.Add(axes)

            for h in helpers do
                scene.Add(h) |> ignore

            // Debug helpers start hidden: light gizmos and the camera frustum
            // are useful, but they clutter the default view.
            let debug = ResizeArray<Object3D>()

            let boundsHelper = Box3Helper(Box3(Vector3(-6., 0., -6.), Vector3(6., 6., 6.)), "#94a3b8")
            debug.Add(boundsHelper)

            let sunHelper = DirectionalLightHelper(sun, 1.2, "#f59e0b")
            debug.Add(sunHelper)

            let pulseHelper = PointLightHelper(pulse, 0.25, "#f472b6")
            debug.Add(pulseHelper)

            let cameraHelper = CameraHelper(camera)
            debug.Add(cameraHelper)

            let arrow =
                ArrowHelper(Vector3(0.6, 0.7, 0.4).Normalize(), Vector3(0., 0.1, 0.), 3., "#22c55e", 0.6, 0.3)
            debug.Add(arrow)

            for h in debug do
                h.Visible <- false
                scene.Add(h) |> ignore

            let timer = Timer()
            timer.Connect(JS.Document)

            // Post-processing: EffectComposer → RenderPass → UnrealBloomPass →
            // OutputPass. Off by default; toggled from the panel.
            let composer = EffectComposer(renderer)
            composer.AddPass(RenderPass(scene, camera))
            let bloom = UnrealBloomPass(Vector2(width, height), 0.35, 0.5, 0.92)
            composer.AddPass(bloom)
            composer.AddPass(OutputPass())
            composer.SetSize(int width, int height)

            // Construct the remaining addon loaders/exporters so the sample
            // exercises the whole addon surface; it does not fetch any external
            // asset (the 3D content is procedural).
            let addonProbe : ResizeArray<obj> = ResizeArray()
            addonProbe.Add(GLTFLoader())
            addonProbe.Add(DRACOLoader())
            addonProbe.Add(KTX2Loader())
            addonProbe.Add(OBJLoader())
            addonProbe.Add(MTLLoader())
            addonProbe.Add(STLLoader())
            addonProbe.Add(PLYLoader())
            addonProbe.Add(FBXLoader())
            addonProbe.Add(RGBELoader())
            addonProbe.Add(EXRLoader())
            addonProbe.Add(SVGLoader())
            addonProbe.Add(FontLoader())
            addonProbe.Add(TTFLoader())
            addonProbe.Add(CubeTextureLoader())
            addonProbe.Add(ImageBitmapLoader())
            addonProbe.Add(Gyroscope())
            addonProbe.Add(ColladaLoader())
            addonProbe.Add(LWOLoader())
            addonProbe.Add(LUT3dlLoader())
            addonProbe.Add(Sky())
            let waterNormals = DataTexture(Uint8Array(16), 2, 2)
            addonProbe.Add(Water(PlaneGeometry(1., 1.), WaterOptions(TextureWidth = 256, TextureHeight = 256, WaterNormals = waterNormals)))
            addonProbe.Add(Water2(PlaneGeometry(1., 1.), Water2Options(TextureWidth = 256, TextureHeight = 256, NormalMap0 = waterNormals, NormalMap1 = waterNormals)))
            addonProbe.Add(Reflector(PlaneGeometry(1., 1.), ReflectorOptions(TextureWidth = 256, TextureHeight = 256)))
            addonProbe.Add(Refractor(PlaneGeometry(1., 1.), ReflectorOptions(TextureWidth = 256, TextureHeight = 256)))
            addonProbe.Add(
                ConvexGeometry(
                    [| Vector3(0., 0., 0.); Vector3(1., 0., 0.); Vector3(0., 1., 0.); Vector3(0., 0., 1.) |]))
            addonProbe.Add(ConvexHull())
            addonProbe.Add(SSAOPass(scene, camera))
            addonProbe.Add(SMAAPass())
            addonProbe.Add(BokehPass(scene, camera, BokehPassParameters(Focus = 1.0, Aperture = 0.025, Maxblur = 0.01)))
            addonProbe.Add(FilmPass())
            addonProbe.Add(AfterimagePass())
            addonProbe.Add(WireframeGeometry2(BoxGeometry(1., 1., 1.)))
            addonProbe.Add(LineSegments2())
            addonProbe.Add(TAARenderPass(scene, camera))
            addonProbe.Add(SkeletonUtils.Clone(merged))
            addonProbe.Add(BufferGeometryUtils.MergeVertices(mergedGeometry))
            addonProbe.Add(OBJExporter())
            addonProbe.Add(STLExporter())
            addonProbe.Add(PLYExporter())
            addonProbe.Add(GLTFExporter())
            addonProbe.Add(USDZExporter())
            addonClasses <- addonProbe.Count

            let state =
                {
                    Renderer = renderer
                    Scene = scene
                    Camera = camera
                    Spin = spin
                    SpinMesh = spinMesh
                    Instanced = instanced
                    Points = stars
                    GroundMaterial = groundMaterial
                    PanelMaterial = panelMaterial
                    Sun = sun
                    Pulse = pulse
                    Selection = selection
                    Helpers = helpers
                    Debug = debug
                    Pickables = ResizeArray<Object3D>()
                    Timer = timer
                    Mixer = mixer
                    Action = action
                    Composer = composer
                    Bloom = bloom
                    FatLines = orbitMaterial
                }
            app <- Some state

            // Seed the rig with one object of each kind of geometry so the
            // first screenshot is not empty.
            for name in [ "Box"; "Sphere"; "TorusKnot"; "Capsule" ] do
                geometryName.Value <- name
                addObject ()
            geometryName.Value <- "Box"

            // Create the addon control selected in the panel, and swap it out
            // whenever the selection changes. `View.Sink` also fires now, which
            // is what creates the initial OrbitControls.
            View.Sink (fun _ -> withApp (fun a -> applyControlMode a)) controlMode.View

            // Pointer picking on the canvas.
            listen renderer.DomElement "pointermove" (fun ev -> withApp (fun a -> updatePicking a ev))
            listen renderer.DomElement "pointerleave" (fun _ ->
                withApp (fun a ->
                    a.Selection.Visible <- false
                    picked.Value <- "Picked: —"))

            // Keep the canvas in sync with its container.
            let resize () =
                withApp (fun a ->
                    let w, h = sizeOf host
                    a.Renderer.SetSize(int w, int h, false)
                    a.Composer.SetSize(int w, int h)
                    a.FatLines.Resolution <- Vector2(w, h)
                    a.Camera.Aspect <- w / h
                    a.Camera.UpdateProjectionMatrix())

            listenWindow "resize" (fun _ -> resize ())

            applyTheme ()
            refreshCount ()

            let renderLoop (_time: float) =
                withApp (fun a ->
                    a.Timer.Update() |> ignore
                    let dt = a.Timer.GetDelta()
                    a.Mixer.Update(dt) |> ignore
                    if not a.Action.Paused then
                        a.SpinMesh.Rotation.Y <- a.SpinMesh.Rotation.Y + dt * 1.2
                    a.Spin.Rotation.Y <- a.Spin.Rotation.Y + dt * 0.25
                    a.Instanced.Rotation.Y <- a.Instanced.Rotation.Y - dt * 0.1
                    a.Points.Rotation.Y <- a.Points.Rotation.Y + dt * 0.02

                    let pulsePhase = a.Timer.GetElapsed()
                    a.Pulse.Position.Y <- 3.5 + System.Math.Sin pulsePhase * 1.6
                    a.Pulse.Intensity <- 14.0 + 6.0 * System.Math.Sin(pulsePhase * 2.0)

                    cameraUpdate dt
                    if postFx then a.Composer.Render(dt) else a.Renderer.Render(a.Scene, a.Camera)

                    frames <- frames + 1
                    accumulated <- accumulated + dt
                    if accumulated >= 0.4 then
                        refreshReadouts a dt accumulated
                        accumulated <- 0.0)

            renderer.SetAnimationLoop(renderLoop)
            status.Value <- "Drag to orbit, scroll to zoom, and move the pointer over an object to pick it."

    // ---------------------------------------------------------------
    // Entry point
    // ---------------------------------------------------------------

    [<SPAEntryPoint>]
    let Main () =
        // Restore a previously chosen theme (light is the default).
        let savedTheme =
            try JS.Window.LocalStorage.GetItem(themeStorageKey) with _ -> null
        if savedTheme = "dark" || savedTheme = "light" then
            theme.Value <- savedTheme
        applyTheme ()

        // `.Bind()` renders the whole document body, so the viewport element is
        // only in the DOM after this call.
        IndexTemplate()
            .themeLabel(themeLabel.V)
            .status(status.V)
            .picked(picked.V)
            .stats(stats.V)
            .clockInfo(clockInfo.V)
            .mathInfo(mathInfo.V)
            .objectCount(objectCount.V)
            .animationState(animationState.V)
            .Geometry(geometryName)
            .Material(materialName)
            .ControlMode(controlMode)
            .ToggleTheme(fun _ -> toggleTheme ())
            .AddObject(fun _ -> addObject ())
            .ClearObjects(fun _ -> clearObjects ())
            .ResetCamera(fun _ -> resetCamera ())
            .ToggleAnimation(fun _ -> toggleAnimation ())
            .ToggleHelpers(fun _ -> toggleHelpers ())
            .ToggleDebug(fun _ -> toggleDebug ())
            .ToggleBloom(fun _ -> togglePostFx ())
            .Bind()

        init ()