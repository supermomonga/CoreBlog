module.exports = {
  entry: "./Scripts/app.ts",
  output: {
    filename: "./wwwroot/dist/bundle.js"
  },
  // Enable sourcemaps for debugging webpack's output.
  devtool: "source-map",
  resolve: {
    // Add '.ts' and '.tsx' as resolvable extensions.
    extensions: ["", ".ts", ".vue", ".js"]
  },
  module: {
    loaders: [
      // All files with a '.ts' or '.tsx' extension will be handled by 'ts-loader'.
      { test: /\.vue$/, loader: 'vue' },
      { test: /\.ts?$/, loader: "vue-ts" }
    ]
  },
  vue: {
      // instruct vue-loader to load TypeScript
      loaders: { js: 'vue-ts-loader', },
      // make TS' generated code cooperate with vue-loader
      esModule: true
  },
};