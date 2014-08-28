#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.ThreeJs", "2.5")
    |> fun bt -> bt.WithFramework(bt.Framework.Net40)

let main =
    (bt.WebSharper.Extension("IntelliFactory.WebSharper.ThreeJs")
    |> FSharpConfig.BaseDir.Custom "ThreeJs")
        .SourcesFromProject("ThreeJs.fsproj")
        .Embed(["three.min.js"])

bt.Solution [
    main

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.ThreeJs-r67"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://bitbucket.org/intellifactory/websharper.threejs"
                Description = "WebSharper Extensions for three.js (r67)"
                Authors = ["IntelliFactory"]
                RequiresLicenseAcceptance = true })
        .Add(main)

]
|> bt.Dispatch
