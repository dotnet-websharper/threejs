#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.ThreeJS", "2.5")
    |> fun bt -> bt.WithFramework(bt.Framework.Net40)

let main =
    bt.WebSharper.Extension("ThreeJS")
        .SourcesFromProject()

let test =
    bt.WebSharper.BundleWebsite("Tests")
        .SourcesFromProject()
        .References(fun r -> [r.Project main])

bt.Solution [
    main
    test

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.ThreeJS-r67"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://bitbucket.org/intellifactory/websharper.threejs"
                Description = "WebSharper Extensions for three.js (r67)"
                Authors = ["IntelliFactory"]
                RequiresLicenseAcceptance = true })
        .Add(main)

]
|> bt.Dispatch
