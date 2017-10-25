
const webpack = require('webpack')
const nodeEnv = process.env.NODE_ENV || 'development'
const ExtractTextPlugin = require('extract-text-webpack-plugin');
var CopyWebpackPlugin = require('copy-webpack-plugin');

console.log('loading webpack.config.dev.js')
module.exports = {
  devtool : 'inline-source-map',
  entry:   { filename: './src-client/index.js' },
  output : { filename: './js/bundle.js', path: `${__dirname}/wwwroot/` },
  context : `${__dirname}` ,
  module: {
    loaders: [
		 {
          test: /\.js$/,
			 exclude: /node_modules/,
			 loader: 'babel-loader',
          query: {
             presets: ['es2015', 'react', 'stage-0']
          }
		 },
	    {
		    test: /\.scss$/,
		    loader: "style-loader!css-loader!sass-loader!resolve-url-loader"
		 }
	 ]
  },
  plugins: [
     //env plugin
	  new webpack.DefinePlugin({
        'process.env': { NODE_ENV: JSON.stringify(nodeEnv) }
	  }),
     //env plugin -- css
  ]
}
