const webpack = require('webpack')
const nodeEnv = process.env.NODE_ENV || 'production'
const ExtractTextPlugin = require('extract-text-webpack-plugin');
var CopyWebpackPlugin = require('copy-webpack-plugin');


console.log('loading production build')

module.exports = {
  devtool : 'source-map',
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
             presets: ['es2015', 'react']
          }
		 },
	    {
		    test: /\.scss$/,
				 loader: ExtractTextPlugin.extract({fallbackLoader: "style-loader", loader: "css-loader!sass-loader!resolve-url-loader"})
		 }
	 ]
  },
  plugins: [
     //uglify js
     new webpack.optimize.UglifyJsPlugin({
			compress: { warnings: false },
			output: {comments: false},
         sourceMap: true
	  }),

     //env plugin
	  new webpack.DefinePlugin({
        'process.env': { NODE_ENV: JSON.stringify(nodeEnv) }
	  }),

	  new CopyWebpackPlugin([
	     {from : 'src-client/images', to: 'images'}
	  ]),

     //env plugin -- css
     new ExtractTextPlugin({filename: './css/styles.css', allChunks: true})
  ]
}
