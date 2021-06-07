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
    res.sendStatus(200)
    console.log(req.body)
    ws.send(JSON.stringify(req.body))
  })
})

server.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})
