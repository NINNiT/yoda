#!/usr/bin/env python3
import asyncio
import websockets
import skywriter
import time
import socket

server_ip = "192.168.0.23"
server_port = 8888

print(server_ip)
connected_clients = set()


async def begin_connection(websocket, path):
    while True:
        received_data = await websocket.recv()
        print(received_data)
        await websocket.send("Hello!")
        time.sleep(1)


# Start the server
start_server = websockets.serve(begin_connection, server_ip, server_port)
asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()
