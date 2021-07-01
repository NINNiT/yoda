import express from "express"
import http from "http"
import websocket from "ws"
import bodyparser from "body-parser"

const app = express()
app.use(bodyparser.json())
const port = 3000
const server = http.createServer(app)
const wss = new websocket.Server({ server })

wss.on("connection", (ws) => {
  console.log("Websocket connection established")

  app.post("/", (req, res) => {
    console.log("Post request incoming...")
    console.log(req.body)
    wss.clients.forEach((socket) => {
      socket.send(JSON.stringify(req.body))
    })
    res.sendStatus(200)
  })

  ws.on("message", (msg) => {
    console.log(msg)
  })

  ws.on("close", (ws) => {
    console.log("Websocket connection closed")
  })
})

server.listen(port, () => {
  console.log(`Proxy listening at http://localhost:${port}`)
})
