import { build } from 'esbuild'
import { readFileSync, writeFileSync, copyFileSync } from 'fs'

const name = 'WebSharper.ThreeJs.Sample'

// The WebSharper-generated module imports the npm `three` package (and its
// `three/addons/...` modules) plus the WebSharper runtime; bundle them into a
// single ES module for the static page. ESM is required by addons such as
// `DRACOLoader`/`KTX2Loader`, which resolve their decoder paths against
// `import.meta.url`.
await build({
  entryPoints: [`./build/${name}.js`],
  bundle: true,
  minify: true,
  format: 'esm',
  outfile: `../dist/Scripts/${name}.min.js`
})

copyFileSync('./site.css', '../dist/site.css')

// Fold the WebSharper head (linked resources) into the page.
const head = readFileSync(`./build/${name}.head.html`, 'utf8')
const html = readFileSync('./index.html', 'utf8').replace('<!-- ws-head -->', head)
writeFileSync('../dist/index.html', html)

console.log('Bundled:', name)