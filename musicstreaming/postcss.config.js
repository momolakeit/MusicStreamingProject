module.exports = {
  plugins: {
    autoprefixer: {}
  },
  devServer: {
    proxy: 'http://localhost:50342/',
  }
}
