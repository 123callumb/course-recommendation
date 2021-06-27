const path = require('path');
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
    entry: __dirname + '/SPA/App.ts',
    mode: "development",
    resolve: {
        extensions: [".ts", ".tsx", ".js", ".jsx", ".css", ".scss"]
    },
    output: {
        path: __dirname + "/wwwroot/",
        filename: "course-recommend.bundle.js"
    },
    plugins: [
        new CopyPlugin([
            { from: __dirname + "/SPA/res", to: __dirname + "/wwwroot/direct" }
        ])
    ],
    module: {
        rules: [
            {
                test: /\.(js(x?))$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            },
            {
                test: /\.ts(x?)$/,
                loader: 'babel-loader',
            },
            {
                test: /\.js$/,
                use: [
                    "source-map-loader"
                ],
                enforce: "pre"
            },
            {
                test: /\.html$/,
                use: [
                    {
                        loader: "html-loader"
                    }
                ]
            },
            {
                test: /\.(s?)css$/,
                include: [
                    path.resolve(__dirname, 'SPA/src/style/')
                ],
                use: [
                    {
                        loader: "style-loader"
                    },
                    {
                        loader: "css-modules-typescript-loader"
                    },
                    {
                        loader: 'css-loader',
                        options: {
                            importLoaders: 1,
                            modules: {
                                localIdentName: '[local]_[hash:base64:5]' // This is for dev, needs changong to full has in the production config
                            }
                        }
                    },
                    {
                        loader: 'sass-loader',
                        options: {
                            sourceMap: process.env.NODE_ENV !== 'production'
                        }
                    }
                ]
            },
            {
                test: /\.(png|jpe?g|gif|woff|woff2|eot|ttf|svg)$/i,
                loader: 'file-loader',
                options: {
                    outputPath: 'resources',
                    publicPath: `/resources`,
                }
            }
        ]
    }
}