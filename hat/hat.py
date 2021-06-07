#!/usr/bin/env python3

import asyncio
import signal
import skywriter
import requests
import json

proxy_url = "http://localhost:3000/"
headers = {"content-type": "application/json"}


def send_data(payload):
    r = requests.post(proxy_url, data=json.dumps(payload), headers=headers)


@skywriter.flick()
def flick(start, finish):
    payload = {}
    if start == "north":
        payload = {"action": "flick-north"}
    elif start == "south":
        payload = {"action": "flick-south"}
    elif start == "east":
        payload = {"action": "flick-east"}
    elif start == "west":
        payload = {"action": "flick-west"}

    send_data(payload)
    print("flicking", start, finish)


signal.pause()
